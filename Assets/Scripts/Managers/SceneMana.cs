using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMana : MonoBehaviour
{
    public string sceneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // need to change this so it activates everytime a menu button is pressed or have *space to start* 
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}