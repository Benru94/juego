using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth = 5;
    public float maxHealth = 5;
    public UnityEvent OnDamageTaken;
    public UnityEvent OnDead;

    void damageTaken(float amount)
    {

        currentHealth -= amount;
        OnDamageTaken.Invoke();


        if (currentHealth <= 0)
        {

            OnDead.Invoke();
        }

    }

}
