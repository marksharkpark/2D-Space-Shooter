using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHit : MonoBehaviour
{
    public int life = 1;
    public float period = 2f; // setting public so player only becomes invincible 
    float invincible = 0;
    int startLayer;

    void OnTriggerEnter2D() // if collision occurs, lose life. Then set player as invincible for "period" of time since life is 2. 
    {
        Debug.Log("trigger");
        life--;
        invincible = period;
        gameObject.layer = 10;
    }

    private void Start()    // ensuring game object can return from invincible state
    {
        startLayer = gameObject.layer;
    }

    void Update() // ensuring spaceship can return from invincible state & dies when reaches end of life.
    {
        invincible -= Time.deltaTime;
        if(invincible <= 0)
        {
            gameObject.layer = startLayer;
        }
        if (life <= 0)
        {
            Die();
        }
    }

    void Die() // Dying function
    {
        Destroy(gameObject);
    }
}
