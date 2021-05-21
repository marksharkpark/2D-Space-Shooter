using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    Transform Tip1;

    [SerializeField]
    GameObject Bullet1;

    int bulletLayer2;
    float fireDelay1 = 0.5f;
    float coolDown1 = 0f;
    Transform player;

    void Start()
    {
        bulletLayer2 = gameObject.layer;    
    }

    // Update is called once per frame
    void Update()
    {
        // Spaceship shooting/firerate 
        if (player == null)
        {
            // find spaceship
            GameObject go = GameObject.FindWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        coolDown1 -= Time.deltaTime;

        if (coolDown1 <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 6)
        {
        //    Debug.Log("fire fire");
            coolDown1 = fireDelay1;
            EnemyFireBullet();
        }
    }

    // instantiating firebullet to spaceship tip
    void EnemyFireBullet()
    {
        GameObject firedBullet = (GameObject)Instantiate(Bullet1, Tip1.position, Tip1.rotation);
        firedBullet.layer = bulletLayer2; // making enemy bullet separate from player bullet, if this is missing the enemy spaceships will kill each other
        firedBullet.GetComponent<Rigidbody2D>().velocity = Tip1.up * 10f;
    }
}
