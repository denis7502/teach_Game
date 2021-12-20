using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform _shootRaycaster;

    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private float _distAttack;

    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private float timeBetweenShots;

    [SerializeField]
    private float lastShootTime = 0;

    private int _ammoInClipCount ;
    
    [SerializeField]
    private int _maxInClipCount = 10;
    
    [SerializeField]
    private int _totalAmmoCount = 50;
    
    [SerializeField]
    private int damage = 15;
    [SerializeField]
    private TextMeshProUGUI _totalAmmoText;
    [SerializeField]
    private GameObject _WarningText;
    [SerializeField]
    private TextMeshProUGUI _ammoInClipText;

    [SerializeField]
    private AudioSource _audioSource;


    public Sprite gunSprite;

    private static readonly int _shootAnimHash = Animator.StringToHash("Shoot");
    private static readonly int _showAnimHash = Animator.StringToHash("ShowGun");
    private static readonly int _swapAnimHash = Animator.StringToHash("SwapGun");
    private static readonly int _relPistAnimHash = Animator.StringToHash("Reload");
    private static readonly int _stable = Animator.StringToHash("stable");

    public bool isReloading
    {
        get;
        private set;
    }
    // Start is called before the first frame update
    void Start()
    {
        _ammoInClipCount = _maxInClipCount;
        UpdateState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        if (timeBetweenShots < Time.time - lastShootTime && (_totalAmmoCount != 0 && _ammoInClipCount >= 0))
        {
            _anim.SetTrigger(_shootAnimHash);
            _particleSystem.Play();
            _audioSource.Play();
            if (_totalAmmoCount == 0)
            {
                return;
            }

            if (_ammoInClipCount == 0)
                Reload();
            RaycastHit hit;
            if (Physics.Raycast(_shootRaycaster.position, _shootRaycaster.forward, out hit, _distAttack))
            {

                if (hit.collider.TryGetComponent<IDamagable>(out IDamagable damagable))
                    damagable.TakeDamage(damage);
            }
            GunUpdateState();
            lastShootTime = Time.time;
        }

    }

    private void OnEnable()
    {
        _particleSystem.transform.position = _shootRaycaster.position;
    }

    public void UpdateState()
    {
        _WarningText.SetActive(false);
        if (_totalAmmoCount == 0 & _ammoInClipCount == 0)
        {
            _anim.SetTrigger(_stable);
            _WarningText.SetActive(true);
        }
        _totalAmmoText.text = _totalAmmoCount.ToString();
        _ammoInClipText.text = _ammoInClipCount.ToString();
    }

    public void GunUpdateState()
    {
        if (_totalAmmoCount == 0)
        {
            _ammoInClipCount--;
            _ammoInClipText.text = _ammoInClipCount.ToString();
        }
        if (_ammoInClipCount > 0 & _totalAmmoCount != 0)
        {
            _totalAmmoCount--;
            _ammoInClipCount--;
            UpdateState();
        }

    }

    public void AnimChange(bool isShown)
    {
        _anim.SetTrigger(isShown ? _showAnimHash : _swapAnimHash);
    }
    public void Reload()
    {
        _anim.SetTrigger(_relPistAnimHash);
        if (_totalAmmoCount > _maxInClipCount)
        {
            _ammoInClipCount = _maxInClipCount;
            _totalAmmoCount -= _maxInClipCount;
            UpdateState();
        }
        else 
        {
            _ammoInClipCount = _maxInClipCount;
            _totalAmmoCount = 0;
            UpdateState();
        }
    }

    public void TakeAmmo(int ammo)
    {
        _totalAmmoCount += ammo;
        UpdateState();
    }
}
