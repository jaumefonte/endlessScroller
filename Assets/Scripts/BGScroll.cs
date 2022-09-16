using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{

    [SerializeField] PlayerController control;
    [SerializeField] List<SpriteRenderer> renderers;
    public float bgVelocity;

    void Update()
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            if (renderers[i].transform.position.x < -22)
            {
                renderers[i].transform.position = new Vector3(24f, renderers[i].transform.position.y, renderers[i].transform.position.z);
            }
            renderers[i].transform.position = new Vector3(renderers[i].transform.position.x - bgVelocity * Time.deltaTime, renderers[i].transform.position.y, renderers[i].transform.position.z);
            
        }

    }
}
