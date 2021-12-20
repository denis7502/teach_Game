using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour, IDamagable, IHealth
{
    [SerializeField]
    public int _health = 100;
    
    [SerializeField]
    private Animator _anim;
    
    [SerializeField]
    private int _longAnim;

    [SerializeField]
    private List<Aidbox> buffs;
    [SerializeField]
    private AudioSource _audioSource;

    private Vector3 start_pos;
    public bool Drop = false;

    private static readonly int _deadAnimHash = Animator.StringToHash("Dead");
    private static readonly int _hitAnimHash = Animator.StringToHash("Hit");

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _audioSource.Play();
            StartCoroutine(waiter());

            var index = Random.value < 0.5f ? 0 : 1;
            if (!Drop)
            {
                Instantiate(buffs[index], transform.position, Quaternion.identity);
                Drop = true;
            }
            if (Random.value < 0.3)
                Instantiate(gameObject, start_pos, Quaternion.identity);

            _health = 0;

        }


    }

    IEnumerator waiter()
    {
        _anim.SetTrigger(_deadAnimHash);
        yield return new WaitForSecondsRealtime(_longAnim);
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        _anim.SetTrigger(_hitAnimHash);
        ApplyDamage(damage);
    }

    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        
    }
}
