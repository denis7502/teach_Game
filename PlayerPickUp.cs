using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerAttack _playerAttack;

    private void Start()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        _playerHealth = GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Aidbox buffBox;
        if (other.TryGetComponent<Aidbox>(out buffBox))
        { 
            TakeEffect(buffBox._effect, buffBox.buff);
            Destroy(buffBox.gameObject);
        }
    }

    public void TakeEffect(Effect effect, int buff)
    {
        switch(effect)
        {
            case Effect.Heal:
                _playerHealth.ApplyDamage(-buff);
                break;
            case Effect.Ammo:
                _playerAttack.TakeAmmo(buff);
                break;
        }
    }
}
