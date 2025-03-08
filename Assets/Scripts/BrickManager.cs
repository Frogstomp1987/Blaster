using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{

    [SerializeField]
    Color oneLifeColor, twoLifeColor, threeLifeColor;

    [SerializeField]
    int hitPoints;

    SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ChangeColorOnLife();
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball") 
        {
            hitPoints--;
            ChangeColorOnLife();
            if (hitPoints <= 0)
            {
                GameManager.gameManager.BrickDestroyed();
            }
        }
    }

    void ChangeColorOnLife()
    {
        switch (hitPoints)
        {
            case 1:
                sprite.color = oneLifeColor;
                break;
            case 2:
                sprite.color = twoLifeColor;
                break;
            case 3:
                sprite.color = threeLifeColor;
                break;
            default:
                sprite.color = oneLifeColor;
                break;
        }
    }
}
