using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkHazard : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<playerHealth>())
        {
            other.GetComponent<playerHealth>().TakeDamage(Damage);
        }
    }
}
