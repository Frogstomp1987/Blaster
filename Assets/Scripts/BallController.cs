using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    float ballSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        KeepConstantVelocity();
    }

    void KeepConstantVelocity()
    {
        body.linearVelocity = ballSpeed * body.linearVelocity.normalized;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Death")
        { 
            GameManager.gameManager.GameOver();
        }
    }
}
