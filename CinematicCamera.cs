using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamera : MonoBehaviour
{
    [SerializeField]
    private Camera _playerCamera;

    private Camera _cinematic;


    [SerializeField]
    private Animator _anim;

    private static readonly int _castScene = Animator.StringToHash("castScene");

    // Start is called before the first frame update
    void Start()
    {
        _cinematic = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayCustom()
    {
        ///Debug.Log("gi");
        _anim.SetTrigger(_castScene);
        _playerCamera.enabled = false;
        _cinematic.enabled = true;
    }

    public void StopCustom()
    {
        _cinematic.enabled = false;
        _playerCamera.enabled = true;

    }
}
