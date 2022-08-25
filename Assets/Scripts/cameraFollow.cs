using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Assertions.Must;


public class cameraFollow : MonoBehaviour
{
    //Character reference
    [SerializeField] private Transform character;
    
    //Movement variables
    [SerializeField] private float maxSpeed = 0f;
    [SerializeField] private float dist;
    private Vector3 offset;
    
    void Start()
    {
        
        offset = new Vector3(14, 23, 0);
    }

    
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        dist = Vector3.Distance(transform.position, character.transform.position);
        maxSpeed = dist.Map(12, 16, 2, 4);
        
        transform.position = Vector3.Lerp(transform.position,character.transform.position + offset, maxSpeed*Time.deltaTime );
    }
}

public static class ExtensionMethods 
{

    public static float Map (this float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }
}