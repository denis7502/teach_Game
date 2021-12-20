using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int _health = 100;
    [SerializeField]
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ApplyDamage(int damage)
    {

        _health -= damage;
        _slider.value = _slider.value - damage;
        if (_health == 0)
            return;


    }

}
