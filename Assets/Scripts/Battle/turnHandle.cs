using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    FinishedTurn,
    Won,
    Lost
}
public class turnHandle : MonoBehaviour
{
    public BattleState state;

    public EnemyProfile[] EnemiesInBattle;
    private bool enemyActed;
    private GameObject[] EnemyAtks;

    public GameObject PlayerUi;
    public heartCtrl PlayerHeart;

    private void Start()
    {
        state = BattleState.Start;
        enemyActed = false;
    }

    private void Update()
    {
        if (state == BattleState.Start)
        {
            PlayerUi.SetActive(true);
            state = BattleState.PlayerTurn;
        }
        else if (state == BattleState.PlayerTurn)
        {
            //wait for player to attack
        }
        else if (state == BattleState.EnemyTurn)
        {
            if (EnemiesInBattle.Length <= 0)
            {
                EnemyFinishedTurn();
            }
            else
            {
                if (!enemyActed)
                {
                    PlayerHeart.gameObject.SetActive(true);
                    PlayerHeart.SetHeart();

                    foreach (EnemyProfile emy in EnemiesInBattle)
                    {
                        int AtkNumb = Random.Range(0, emy.EnemiesAttacks.Length);

                        Instantiate(emy.EnemiesAttacks[AtkNumb], Vector3.zero, Quaternion.identity);
                    }

                    EnemyAtks = GameObject.FindGameObjectsWithTag("Enemy");

                    enemyActed = true;
                }
                else
                {
                    bool enemyfin = true;
                    foreach (GameObject emy in EnemyAtks)
                    {
                        if (!emy.GetComponent<EnemyTurnHandle>().FinishedTurn)
                        {
                            enemyfin = false;
                        }
                    }
                    if (enemyfin)
                    {
                        EnemyFinishedTurn();
                    }
                }
            }
            //enemy take turn 
        }
        else if (state == BattleState.FinishedTurn)
        {
            PlayerHeart.gameObject.SetActive(false);

            if (PlayerHeart.GetComponent<playerHealth>().HP < 0)
            {
                state = BattleState.Lost;
            }
            else
            {
                state = BattleState.Start;
            }
        }
        else if (state == BattleState.Won)
        {

        }
    }

    public void PlayerAct()
    {
        playerfinishTurn();
    }

    void playerfinishTurn()
    {
        PlayerUi.SetActive(false);

        state = BattleState.EnemyTurn;
    }

    void EnemyFinishedTurn()
    {
        foreach (GameObject obj in EnemyAtks)
        {
            Destroy(obj);
        }

        enemyActed = false;
        state = BattleState.FinishedTurn;
    }
}
