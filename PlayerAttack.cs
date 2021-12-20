using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private List<Gun> _guns;
    [SerializeField]
    private int _gunIndex = 0;
    [SerializeField]
    private Gun _currentGun;
    [SerializeField]
    private Image _weaponUIImage;

    // Start is called before the first frame update
    void Start()
    {
        _currentGun = _guns[_gunIndex];
        _weaponUIImage.sprite = _currentGun.gunSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnFire(InputValue ctx)
    {
        _guns[_gunIndex].Shoot();
    }
    public void OnChangeWeapon(InputValue ctx)
    {
        Vector2 scrollVector2 = ctx.Get<Vector2>();
        if (scrollVector2.y == 0)
            return;
        if (_gunIndex >= _guns.Count - 1 || _gunIndex<0)
            _gunIndex = 0;
        else
            _gunIndex += (int)Mathf.Sign(scrollVector2.y) * 1;
        if (_gunIndex < 0)
            _gunIndex = 0;
        _currentGun.gameObject.SetActive(false);
        _currentGun = _guns[_gunIndex];

        _currentGun.gameObject.SetActive(true);
        _weaponUIImage.sprite = _currentGun.gunSprite;
        _guns[_gunIndex].UpdateState();
    }

    public void OnReloadGun()
    {
        _currentGun.Reload();
    }

    public void TakeAmmo(int ammo)
    {
        _currentGun.TakeAmmo(ammo);
    }
}
