using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private ParticleSystem _particleSystem;
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform raycaster;

    [SerializeField]
    private float _attDist;
    [SerializeField]
    private float _visioDist;

    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private LayerMask layer;

    [SerializeField]
    private float timeBetweenShots ;

    [SerializeField]
    private float lastShootTime = 0;




    private static readonly int _walkAnimHash = Animator.StringToHash("Walk");
    private static readonly int _gunAnimHash = Animator.StringToHash("Gun");

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        navMeshAgent.speed = 10;
        if (_anim.GetBool(_walkAnimHash) != true)
            _anim.SetTrigger(_walkAnimHash);
        navMeshAgent.destination = target.position;
        if (Vector3.Distance(transform.position, target.position) < _attDist/2)
            navMeshAgent.speed = 0f;
        if (navMeshAgent.speed == 0f)
            transform.LookAt(target);
        RaycastHit hit;
        if (Physics.Raycast(raycaster.position, raycaster.forward, out hit, _visioDist, layer))
        {
            transform.LookAt(target);
            navMeshAgent.speed = 20f;
            target = hit.collider.transform;
            if ( Vector3.Distance(transform.position,target.position) < _attDist)
            {
                if (timeBetweenShots < Time.time-lastShootTime)
                {
                    _anim.SetBool(_walkAnimHash, false);
                    if (_particleSystem.GetType() == typeof(Transform))
                        _particleSystem.Play();
                    hit.collider.GetComponent<PlayerHealth>().ApplyDamage(5);
                    _anim.SetBool(_gunAnimHash,true);
                    lastShootTime = Time.time;
                }
                ///_anim.SetBool(_gunAnimHash, false);
            }


        }
       
    }


}
