using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float minX = -2.2f, maxX = 2.2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movebar();
    }

    void Movebar()
    {
        float xMovement = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * xMovement * Time.deltaTime * movementSpeed);
        if (transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector2 (maxX, transform.position.y);
        }
    }
}
