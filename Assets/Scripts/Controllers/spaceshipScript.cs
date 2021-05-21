using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipScript : MonoBehaviour
{

    float maxSpeed = 6f; // spaceship speed 
    float boundarySpace= 0.5f;  // an invisible perimeter that prevents ship from leaving space
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate() // 
    {
        
    }

    // Update is called once per frame (setting flags for input) 
    void Update()
    {
        // Making the spaceship follow the mouse for aiming ability
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, maxSpeed * Time.deltaTime);

        // Basic 2D Spaceship Movement
        Vector3 pos = transform.position;
        pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;     // moves ship vertically 
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;   // moves ship horizontally 

        // Making sure position does not exit vertical camera-view
        if(pos.y + boundarySpace > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - boundarySpace; 
        }

        if (pos.y - boundarySpace < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + boundarySpace;
        }

        // calculating width by screen ratio 
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float width = Camera.main.orthographicSize * screenRatio;

        // Making sure position does not exit horizontal cameraview
        if(pos.x + boundarySpace > width)
        {
            pos.x = width - boundarySpace;
        }

        if (pos.x - boundarySpace < -width)
        {
            pos.x = -width + boundarySpace;
        }




        // Update position
        transform.position = pos;
    }
}
