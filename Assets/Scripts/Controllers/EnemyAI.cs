using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Transform player;
    float rotSpeed = 110f;


    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            // find spaceship
           GameObject go = GameObject.FindWithTag("Player");

            if(go != null)
            {
                player = go.transform;
            }
        }

        if (player == null)
            return; // try again

        // Making enemy ship to look at player ship
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; 

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

    }
}
