using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    [SerializeField] Transform obstaclesParent;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject GameOverGO;
    void Update()
    {
        if (!GameOverGO.activeInHierarchy)
        {
            scoreText.text = Mathf.FloorToInt(Mathf.Abs(obstaclesParent.transform.position.x)).ToString();
        }
        
    }
}
