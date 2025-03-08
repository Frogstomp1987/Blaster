using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField]
    int rows = 4, cols = 5;

    [SerializeField]
    float xDistanceBetweenBricks = 1, yDistanceBetweenBricks = -0.3f;

    [SerializeField]
    GameObject BrickPrefabs;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.gameManager.SetSpawnedBricks(rows * cols);
        SpawnBricks();
    }

    void SpawnBricks()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector2 newBrickPosition = new Vector2(transform.position.x + (j * xDistanceBetweenBricks), transform.position.y + (i * yDistanceBetweenBricks));

                GameObject.Instantiate(BrickPrefabs, newBrickPosition, Quaternion.identity);
            }
        }
    }
}
