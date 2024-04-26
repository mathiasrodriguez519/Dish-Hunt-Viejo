using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCatcher : MonoBehaviour
{
    public List<Recipe> recipes = new List<Recipe>();
    public List<int> idReceived = new List<int>();
    private int score;
    public float speed = 3;
    public float maxSpeed = 10;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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
    }

    void Update()
    {
        checkId();
    }

    private void checkId()
    {
        for (int i = 0; i < idReceived.Count; i++)
        {
            if (idReceived[i] == recipes[0].foodId[i].id)
            {
                score += 15;
                Debug.Log("Ingrediente numero " + i + " correcto, la puntuacion es: " + score);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Food food = collision.gameObject.GetComponent<Food>();

        if (food != null)
        {
            idReceived.Add(food.id);
        }
    }
}
