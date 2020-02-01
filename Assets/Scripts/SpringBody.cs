using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBody : MonoBehaviour
{
    public Transform Top;
    public Transform Bottom;

    private float _distance;

    private void Start()
    {
        _distance = TopToBottom.magnitude;
    }

    private void Update()
    {
        transform.position = Top.position;
        transform.rotation = Quaternion.Euler(0, 0, ZRotation);
        transform.localScale = new Vector3(1, TopToBottom.magnitude / _distance, 1);
    }

    private float ZRotation
    {
        get
        {
            var rotatedVector = Vector3.Cross(TopToBottom, Vector3.back);

            var arcTan = Mathf.Rad2Deg * Mathf.Atan(rotatedVector.y / rotatedVector.x);

            if (rotatedVector.x <= 0)
                arcTan += 180f;

            return arcTan;
        }
    }

    private Vector2 TopToBottom => Bottom.position - Top.position;
}
