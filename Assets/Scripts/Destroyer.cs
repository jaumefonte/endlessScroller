using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Destroyer : MonoBehaviour
{
    IObjectPool<GameObject> obstaclePool;
    public void SetPool(IObjectPool<GameObject> currentPool)
    {
        obstaclePool = currentPool;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("------------ PLAyER");
            Destroy(collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("------------ OBSTACLE "+collider.name);
        if (collider.tag == "Obstacle")
        {
            Debug.Log("------------ TAG");
            //Destroy(collider.transform.parent.gameObject);
            obstaclePool.Release(collider.transform.parent.gameObject);
        }
    }
}
