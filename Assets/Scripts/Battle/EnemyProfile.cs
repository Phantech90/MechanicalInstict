using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProfile", menuName = "EnemyProfile")]
public class EnemyProfile : ScriptableObject
{
    public int Hp;
    public int CharmHp;

    public Sprite EnemyVisual;

    public GameObject[] EnemiesAttacks;
}
