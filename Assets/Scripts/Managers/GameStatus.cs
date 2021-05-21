using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    int resetLives = 4;
    int resetScore = 20;

    static protected int numLives = 4;
    static protected int score = 20; // enemies left
    static protected int level = 1;


    

    // Start is called before the first frame update
    void Start()
    {
     //   score = PlayerPrefs.GetInt("score", 0);
     //   numLives = PlayerPrefs.GetInt("lives", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    public static void SetScore()
    {
        numLives = 4;
    }

    public static void SetLives()
    {
        score = 20;
    }

    public void doExitGame()
    {
        Application.Quit();
    }

    void OnDestroy()
    {
        // Occurs whenever object is destroyed, including scene changes and exiting program. 
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("lives", numLives);
        PlayerPrefs.SetInt("level", level);
    }

    public void MinusScore()
    {
        score--;
    }

    public static int GetLevel()
    {
        return level;
    }

    public static int GetScore()
    {
        return score;
    }

    public static int GetLives()
    {
        return numLives;
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
