using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: This script acts a hub for all of the other script through communication between game state,
// creation of player objects, camera configuration, etc. 

    // override functions to match mines... awake, start, update, and fixed update is allowed since it is apart of monobehaviour 

public class GameController : MonoBehaviour
{
    bool paused;
    public GameObject d_animation;

  /*  public static GameController Instance {
        get;
        private set;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }   */

    public virtual void PlayerLostLife()
    {
        // lose life (update UI) 
    }

    public virtual void PlayerRespawn()
    {
        // player respawns 
    }

    public void SpawnPlayer()
    {
        // spawn player 
    }

    public void StartGame()
    {
        //start game 
    }

    public void DeathAnimation()
    {
        // animation when player loses all of his life 
    }

    public void RestartGame()
    {
        // restart button pushed 
    }

    public bool Paused
    {
        // paused game when menu setting pop-up appears
        get{
            return paused;
        }
        set{
            paused = value;
            if(paused){
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
