using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.gameState = 1;
        }
    }
}
