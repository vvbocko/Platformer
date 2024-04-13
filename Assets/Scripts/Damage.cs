using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float healthPoints;

    void Start()
    {
        healthPoints = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            Destroy(this);
        }
    }
}
