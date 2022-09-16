using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Destroyer : MonoBehaviour
{
    IObjectPool<Obstacle> obstaclePool;
    public void SetPool(IObjectPool<Obstacle> currentPool)
    {
        obstaclePool = currentPool;
    }
    

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("------------ OBSTACLE "+collider.name);
        if (collider.tag == "Player")
        {
            Debug.Log("------------ PLAyER");
            Destroy(collider.gameObject);
        }
        else if (collider.transform.parent.GetComponent<Obstacle>() != null)
        {
            Obstacle currentObstacle = collider.transform.parent.GetComponent<Obstacle>();
            obstaclePool.Release(currentObstacle);
        }
        
    }
}
