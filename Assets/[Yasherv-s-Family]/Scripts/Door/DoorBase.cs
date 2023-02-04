using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorBase : MonoBehaviour
{
    [SerializeField] private HingeJoint hingeJoint;

    public abstract void OnEnable();
    public abstract void OnDisable();

    public virtual void OpenDoor()
    {
        JointSpring hingeSpring = hingeJoint.spring;
        hingeSpring.spring = 10;
        hingeSpring.damper = 0.1f;
        hingeSpring.targetPosition = 90f;
        hingeJoint.spring = hingeSpring;
    }
}
