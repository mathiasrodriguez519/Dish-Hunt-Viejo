using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float life;
    public float minLife = 0;
    public float maxLife = 100;
    public float speed = 3;
    public float maxSpeed = 10;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float velHor = (horAxis * speed);
        if (velHor > maxSpeed)
        {
            velHor = maxSpeed; //movimiento derecha
        }
        else if (velHor < -maxSpeed)
        {
            velHor = -maxSpeed; //Movimiento izquierda 
        }
        Vector2 velocityHor = new Vector2(velHor, rb.velocity.y);
        rb.velocity = velocityHor;

        float verAxis = Input.GetAxis("Vertical");
        float velVer = (verAxis * speed);
        if (velVer > maxSpeed)
        {
            velVer = maxSpeed; // Movimiento arriba
        }
        else if (velVer < -maxSpeed)
        {
            velVer = -maxSpeed; // Movimiento abajo 
        }
        Vector2 velocityVer = new Vector2(rb.velocity.x, velVer);
        rb.velocity = velocityVer;
    }
}
