using System;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class unit : MonoBehaviour
{

    protected AiUnit m_aiUnit;
    public bool isMoving;
    protected void Awake()
    {
        if(TryGetComponent<AiUnit>(out var aiUnit))
        {
           m_aiUnit = aiUnit;
        }
    }

    public void MoveTo(Vector3 destination)
    {
        
            m_aiUnit.SetDestination(destination);
        
    }



}