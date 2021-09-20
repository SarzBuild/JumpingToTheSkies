using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private TextMeshProUGUI scoreboard;
    public Transform camTransform;
    private int score;

    private void Start()
    {
        scoreboard = GetComponent<TextMeshProUGUI>();
        camTransform = transform.parent.parent.transform;
    }

    private void Update()
    {
        
        scoreboard.text = "Score : " + camTransform.position.y.ToString("000");
    }

}
