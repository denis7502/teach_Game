using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCamerf : MonoBehaviour
{
    [SerializeField]
    private Camera _playerCamera;

    private Camera _cinematic;

    [SerializeField]
    private AudioSource _audioSource;

    private AudioListener _audioListener;

    [SerializeField]
    private PlayMusic playMusic;

    [SerializeField]
    private Animator _anim;

    private static readonly int _winScene = Animator.StringToHash("Win");
    // Start is called before the first frame update
    void Start()
    {
        _cinematic = GetComponent<Camera>();
        _audioListener = _cinematic.GetComponent<AudioListener>();
        _audioListener.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFinal()
    {
        ///Debug.Log("gi");
        _anim.SetTrigger(_winScene);
        _playerCamera.GetComponent<AudioListener>().enabled = false;
        playMusic.StopPlay();
        _playerCamera.enabled = false;
        _cinematic.enabled = true;
        _audioListener.enabled = true;
        _audioSource.Play();
    }
}
