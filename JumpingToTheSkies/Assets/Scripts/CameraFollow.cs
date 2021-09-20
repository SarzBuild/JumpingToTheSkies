using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float maxDelta = 0; 
    public float damping;
    public float maxPosY;
    
    private Vector3 initialPos;
    public static float transferIntData;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        initialPos = transform.position;
    }
    
    void LateUpdate()
    {
        Vector3 wantedPos = transform.position;
        float currentDelta = target.position.y - transform.position.y;
        if(currentDelta > maxDelta)
        {
            wantedPos.y = Mathf.Min(maxPosY, Mathf.Lerp(transform.position.y, transform.position.y + currentDelta - maxDelta, damping));            
            transform.position = wantedPos;
            transferIntData = wantedPos.y;
        } 
    }
}
