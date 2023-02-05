using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
        public float Speed;
        public float Radius;
        public Transform Target;
        public Vector3 Center;
        private void Update()
        {
                transform.RotateAround(Target.position,Center,Speed*Time.deltaTime);
        }
}
