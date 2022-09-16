using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public List<GameObject> obstaclesPrefabs;

    public void SetObstaclesList(List<GameObject> currentList)
    {
        obstaclesPrefabs = currentList;
    }
    public void GenerateObstacle()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        GameObject currentGO = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Count)];
        Vector3 obstaclePosition = new Vector3(transform.position.x, currentGO.transform.position.y, currentGO.transform.position.z);
        GameObject currentInstance = GameObject.Instantiate(currentGO, obstaclePosition, Quaternion.identity);
        currentInstance.transform.SetParent(transform);
    }

}
