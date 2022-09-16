using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] List<Obstacle> obstaclesPrefabs;
    [SerializeField] float generationInterval;
    float generationTimer;
    int obstacleIndex = 0;
    [SerializeField] Transform spawner;
    public IObjectPool<Obstacle> obstaclePool;
    [SerializeField] Destroyer obstacleDestroyer;
    private void Awake()
    {
        obstaclePool = new ObjectPool<Obstacle>(GenerateObstacle, GetObstacle, ReleaseObstacle, DestroyObstacle, true, 20, 20);
        obstacleDestroyer.SetPool(obstaclePool);
    }
    Obstacle GenerateObstacle()
    {
        Obstacle currentObstacle = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Count)];
        Vector3 obstaclePosition = new Vector3(spawner.position.x, currentObstacle.transform.position.y, currentObstacle.transform.position.z);
        Obstacle currentInstance = GameObject.Instantiate(currentObstacle, obstaclePosition, Quaternion.identity);
        currentInstance.transform.SetParent(transform);
        return currentInstance;
    }
    private void GetObstacle(Obstacle obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = new Vector3(spawner.position.x,obj.transform.position.y, obj.transform.position.z);
    }
    private void ReleaseObstacle(Obstacle obj)
    {
        obj.gameObject.SetActive(false);
    }
    private void DestroyObstacle(Obstacle obj)
    {
        Destroy(obj);
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
            obstaclePool.Get();
            ResetTimer();
        }
    }
    
    void ResetTimer()
    {
        generationTimer = generationInterval;
    }
}
