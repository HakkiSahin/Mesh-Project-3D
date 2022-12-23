using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] private float multipleAngel = 20f;
    [SerializeField] private GameObject point;
    
    private void Update()
    {
        Execute();
    }

    /// <summary>
    /// Rotation of the balloons according to their initial position
    /// </summary>
    void Execute()
    {
        transform.LookAt(point.transform);
    }
}