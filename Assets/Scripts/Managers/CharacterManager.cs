using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// file contains variable declarations an functions to get or set those variables. 

public class CharacterManager : MonoBehaviour
{
    private int score;
    private int highScore;
    private int level;
    private int health;
    private bool isFinished;

    public string playerName;

    public virtual void GetDefaultData()
    {
        playerName = "";
        score = 0;
        highScore = 0;
        level = 1;
        health = 2;
        isFinished = false; 
    }

    public string GetName()
    {
        return playerName; 
    }

    public void SetName(string aName)
    {
        playerName = aName; 
    }


    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int num)
    {
        level = num;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public virtual void AddScore(int win)
    {
        score += win; 
    }

    public virtual void LostScore(int loss)
    {
        score -= loss;
    }

    public void SetScore(int num)
    {
        score = num;
    }

    public int GetHealth()
    {
        return health; 
    }

    public void AddHealth(int num)
    {
        health += num;
    }

    public void ReduceHealth(int num)
    {
        health -= num;
    }

    public bool GetIsFinished()
    {
        return isFinished;
    }

    public void SetIsFinished(bool aVal)
    {
        isFinished = aVal;
    }
}

