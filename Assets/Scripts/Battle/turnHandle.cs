using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState
{
    Start,
    EnemyTurn,
    FinishedTurn,
    Won,
    Lost
}
public class turnHandle : MonoBehaviour
{
    public BattleState state;

    public EnemyProfile[] EnemiesInBattle;
    private bool enemyAttacked;
    private GameObject[] EnemyAtks;

    public heartCtrl PlayerHeart;
    public int NumOfAtks = 3;

    public string winSceneName;
    public string loseSceneName;
    public void GoToWinScene()
    {
        SceneManager.LoadScene(winSceneName);
    }
    public void GoToLoseScene()
    {
        SceneManager.LoadScene(loseSceneName);
    }

    private void Start()
    {
        state = BattleState.Start;
        enemyAttacked = false;
    }

    private void Update()
    {
        if (PlayerHeart.GetComponent<playerHealth>().HP < 0)
        {
            state = BattleState.Lost;
        }
        if (state == BattleState.Lost)
        {
            GoToLoseScene();
        }

        if (state == BattleState.Start)
        {           
            state = BattleState.EnemyTurn;
        }

        else if (state == BattleState.EnemyTurn)
        {
            if (EnemiesInBattle.Length <= 0)
            {
                EnemyFinishedTurn();
            }
            else
            {
                if (!enemyAttacked)
                {
                    PlayerHeart.gameObject.SetActive(true);
                    PlayerHeart.SetHeart();

                    foreach (EnemyProfile emy in EnemiesInBattle)
                    {
                        int AtkNumb = Random.Range(0, emy.EnemiesAttacks.Length);

                        Instantiate(emy.EnemiesAttacks[AtkNumb], Vector3.zero, Quaternion.identity);
                    }

                    EnemyAtks = GameObject.FindGameObjectsWithTag("Enemy");

                    enemyAttacked = true;
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
            if (NumOfAtks <= 0)
            {
                state = BattleState.Won;
            }
            else
            {
                state = BattleState.Start;
            }
        }
        else if (state == BattleState.Won)
        {
            GoToWinScene();
        }
    }

    void EnemyFinishedTurn()
    {
        foreach (GameObject obj in EnemyAtks)
        {
            Destroy(obj);
        }
        NumOfAtks =- 1;
        enemyAttacked = false;
        state = BattleState.Start;
    }
}
