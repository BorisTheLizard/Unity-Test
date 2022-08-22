using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;

public class headAim : MonoBehaviour
{
    [SerializeField] GameObject self;
    GameObject BirdModel;
    [SerializeField] float AimDistance = 30;
    [SerializeField] float AimRange = 29;
    Transform BirdPosition;
    [SerializeField] GameObject HulkPosition;
    [SerializeField] MultiAimConstraint HeadWeight;
    [SerializeField] string State = "IDLE";
    [SerializeField] CinemachineVirtualCamera DoubleObjCam;
    [SerializeField] CinemachineVirtualCamera SingleObjCam;

    private void Start()
    {
        BirdModel = GameObject.Find("BirdModel");
        BirdPosition = BirdModel.transform;
    }
    void Update()
    {

        float distance = Vector3.Distance(HulkPosition.transform.position, BirdPosition.position);

        if (State == "IDLE")
        {
            DoubleObjCam.Priority = 0;
            SingleObjCam.Priority = 10;
            self.transform.position = self.transform.position;
            HeadWeight.weight = 0;

            if (distance < AimDistance)
            {
                State = "AIM";
            }
        }
        else if (State == "AIM")
        {
            DoubleObjCam.Priority = 10;
            SingleObjCam.Priority = 0;
            self.transform.position = BirdModel.transform.position;
            HeadWeight.weight = 0.6f;

            if (distance > AimRange)
            {
                State = "IDLE";
            }
        }

    }
}

