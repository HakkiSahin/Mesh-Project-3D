using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Balloon : MonoBehaviour
{

    private Rigidbody myRigid;
    private Vector3 myPos;
    private bool isFail;
    [SerializeField] private float maxBalloonHeight = 5f;

    /// <summary>
    /// Balloon start Force
    /// </summary>
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        myRigid.AddForce(((Random.Range(-1, 2) * Vector3.forward + Random.Range(-1, 2) * Vector3.right) *
                          Random.Range(0, 1f)) + (Vector3.up * 5f),
            ForceMode.Impulse);
    }


    /// <summary>
    /// this is every frame call
    /// </summary>
    private void Update()
    {
        FreezeBalloon();
    }


    /// <summary>
    /// stop when the balloon reaches the maxheight
    /// </summary>
    void FreezeBalloon()
    {
        if (Vector3.Distance(transform.localPosition, Vector3.zero) >
            maxBalloonHeight && !isFail)
        {
            isFail = true;
            myRigid.constraints = RigidbodyConstraints.FreezeAll;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Balloon>() && isFail)
        {
            PushEachOther(other.transform.localPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Balloon>() && isFail)
        {
            //transform.GetComponent<Collider>().isTrigger = false;
        }
    }

    /// <summary>
    /// Balloons touching each other pushing to get out of each other's transforms
    /// </summary>
    /// <param name="otherBallon"></param>
    void PushEachOther(Vector3 otherBallon)
    {
        otherBallon.y = 0;
        myPos = transform.localPosition;
        myPos.y = 0;

        transform.localPosition += (-otherBallon + myPos) * Time.deltaTime * 3f;
    }
}