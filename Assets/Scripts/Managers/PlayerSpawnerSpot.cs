using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerSpot : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;
    float waitTime;
    static protected int monstersLeft = EnemySpawnerPoint.getEnemies(); // setting enemies on the level, 20. 


    //  public int numLives = 3;
    static protected int lifePlacer = GameStatus.GetLives(); // holds 3

    public static int GetLives()
    {
        return lifePlacer;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(lifePlacer == -1)
        {
            lifePlacer = 3;
        }
        SpawnPlayer();
    }

    // spawning player function
    void SpawnPlayer()
    {
        lifePlacer--;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        waitTime = 1;
    }

    

    // setting display for UI 
    void OnGUI()
    {
        if (lifePlacer > 0 || playerInstance != null)
        { 
        
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over"); // game over scene
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(playerInstance == null && lifePlacer > 0) // if player is dead 
        {
            waitTime -= Time.deltaTime;

            if(waitTime <= 0)
            {
                SpawnPlayer();
            }
        }
    }
}
