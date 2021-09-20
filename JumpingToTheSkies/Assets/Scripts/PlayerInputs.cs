using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public bool lockPlayer;
    
    private static PlayerInputs _instance;
    public static PlayerInputs Instance 
    { 
        get 
        {
            if (_instance == null)
            {
                PlayerInputs singleton = GameObject.FindObjectOfType<PlayerInputs>();
                if (singleton == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<PlayerInputs>();
                }
            }
            return _instance;
        } 
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1;
    }
    
    public bool GetMovingUp()
    {
        if (!lockPlayer)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                return true;
            }
        }
        return false;
    }
    public bool GetMovingRight()
    {
        if (!lockPlayer)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                return true;
            }
        }
        return false;
    }
    public bool GetMovingLeft()
    {
        if (!lockPlayer)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                return true;
            }
        }
        return false;
    }
}
