using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int gameState;
    public GameObject panelWinLose;
    public GameObject player;
    public TextMeshProUGUI conditionsText;
    private PlayerInputs setLockPlayer;

    private void Start()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        gameState = 0;
        player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(0,-0,0);
        setLockPlayer = PlayerInputs.Instance;
        setLockPlayer.lockPlayer = false;
    }
    

    private void Update()
    {
        if (gameState == 1) // Lost
        {
            panelWinLose.SetActive(true);
            conditionsText.text = "You lost. Your legs failed you and you have fallen down at the bottom";
            setLockPlayer.lockPlayer = true;
        }
        else if (gameState == 2) // Won
        {
            panelWinLose.SetActive(true);
            conditionsText.text = "You won! Congrats! You jumped so high you are in space!";
            setLockPlayer.lockPlayer = true;
        }
        else // Playing
        {
            panelWinLose.SetActive(false);
            player.SetActive(true);
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
