using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    Transform Tip;

    [SerializeField]
    GameObject Bullet;

    int bulletLayer;

    private Vector2 lookDirection;
    private float lookAngle;

    float fireDelay = 0.25f;
    float coolDown = 0;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        // Spaceship shooting/firerate 
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        coolDown -= Time.deltaTime;
        if(Input.GetButton("Fire1") && coolDown <= 0)
        {
            Debug.Log("fire fire");
            coolDown = fireDelay;
            FireBullet();
        }
    }

    // instantiating firebullet to spaceship tip
    void FireBullet()
    {
        GameObject firedBullet = Instantiate(Bullet, Tip.position, Tip.rotation);
        firedBullet.layer = bulletLayer;
        firedBullet.GetComponent<Rigidbody2D>().velocity = Tip.up * 10f;
    }
}
