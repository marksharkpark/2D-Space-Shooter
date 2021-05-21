using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelUpdater : MonoBehaviour
{
    int lifePlacer = GameStatus.GetLives();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Enemies Left: " + EnemySpawnerPoint.getEnemies() + " Lives: " + PlayerSpawnerSpot.GetLives();
        if(GameStatus.GetScore() == 0)
        {
            // animation You Win! 
        }
    }
}
