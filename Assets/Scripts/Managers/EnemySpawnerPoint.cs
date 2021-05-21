using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerPoint : MonoBehaviour
{
    public GameObject enemyPrefab; // create an array to randomly spawn enemies
    GameObject enemyInstance;
    static protected int eLeft = GameStatus.GetScore();
    static protected int lifePlacer = GameStatus.GetLives();

    //   static protected GameObject loadInstance = GameStatus.LoadScene("CreditScene");
    float distance = 10f;
    float enemyRate = 5;
    float nextEnemy = 1;



    void Start()
    { 
      if(eLeft != 0 && lifePlacer == -1) { // when player loses, game restarts
            GameStatus.SetScore();
            GameStatus.SetLives();
        }  
    }

    public static int getEnemies()
    {
        return eLeft;
    }

    void CreditScenes()
    {
      //  GameStatus.LoadScene("CreditScene");
    }

    void OnGUI()
    {
        if (eLeft == 0 && enemyInstance == null)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "WINNER!! Click on Credits!");
            // animation here 
        }
    } 

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if(nextEnemy <= 0 && eLeft != 0) // ensuring enemies spawn until game ends 
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.90f; // losing 10% of spawn rate 
            if(enemyRate < 1) // in seconds
            {
                enemyRate = 1;
            }
            Vector3 offSet = Random.onUnitSphere;
            offSet.z = 0;
            offSet = offSet.normalized * distance;

            eLeft--;
            enemyInstance = Instantiate(enemyPrefab, transform.position + offSet, Quaternion.identity); // 
        }
    }
}
