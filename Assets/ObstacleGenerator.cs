using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclesPrefabs;
    [SerializeField] float generationInterval;
    float generationTimer;
    int obstacleIndex = 0;
    [SerializeField] Transform spawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generationTimer > 0)
        {
            generationTimer -= Time.deltaTime;
        }
        else
        {
            obstacleIndex++;
            GenerateObstacle();
            ResetTimer();
        }
    }
    void GenerateObstacle()
    {
        GameObject currentObstacle = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Count)];
        Vector3 obstaclePosition = new Vector3(spawner.position.x, currentObstacle.transform.position.y, currentObstacle.transform.position.z);
        GameObject currentInstance = GameObject.Instantiate(currentObstacle, obstaclePosition, Quaternion.identity);
        currentInstance.transform.SetParent(transform);

    }
    void ResetTimer()
    {
        generationTimer = generationInterval;
    }
}
