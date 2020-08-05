using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int HP;
    public int MaxHP;

    public void TakeDamage(int Dmg)
    {
        HP -= Dmg;

        if(HP <= 0)
        {
            Death();
        }
    }

    void Death()
    {

    }
}
