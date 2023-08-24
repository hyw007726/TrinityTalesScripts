using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject spawner;
    private BoxCollider2D col;
    private float speed = 1000f;

    private Rigidbody2D myBody;
    float x1, x2;
    private bool spawnerIsInitialized = false;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();



    }
    private void InitializeColliderProperties()
    {

            BoxCollider2D col = spawner.GetComponent<BoxCollider2D>();

            x1 = spawner.transform.position.x - col.bounds.size.x / 2f;
            x2 = spawner.transform.position.x + col.bounds.size.x / 2f;
            //Debug.Log(x1);
            //Debug.Log(x2);
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!spawnerIsInitialized)
        {
            InitializeColliderProperties();
            if (x1 != x2) // Assuming this is a valid check to confirm initialization
            {
                spawnerIsInitialized = true;
            }
        }
        

        Vector2 vel = myBody.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;
        myBody.velocity = vel;
        Vector2 newPos = myBody.position;
        newPos.x = Mathf.Clamp(newPos.x, x1, x2);
        myBody.position = newPos;
    }
}

