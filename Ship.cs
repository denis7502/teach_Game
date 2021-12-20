using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private CinematicCamera _cinematicCamera;
    
    [SerializeField]
    private FinalCamerf _finalCamerf;

    // Start is called before the first frame update
    void Start()
    {
        _cinematicCamera = GetComponentInChildren<CinematicCamera>();
        ///_finalCamerf = GetComponent<FinalCamerf>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fineshed()
    {
        StartCoroutine(waiter());
    }
    public IEnumerator waiter()
    {
        _cinematicCamera.PlayCustom();
        yield return new WaitForSecondsRealtime(2f);
        _cinematicCamera.StopCustom();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Scenaty.CountDetail == 0)
        {
            _finalCamerf.PlayFinal();
        }
    }
}
