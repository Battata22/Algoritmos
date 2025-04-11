using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Model
{
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    public Transform transform;

    public event Action EventJump;
    public event Action EventMove;


    public Model(Transform _transform,float _speed, float _jumpForce, Rigidbody _rb)
    {
        speed = _speed;
        jumpForce = _jumpForce;
        rb = _rb;
        transform = _transform;
    }

    public void FakeUpdate()
    {

    }

    public void Move(float x, float z)
    {
        var dir = transform.forward * z;
        dir += transform.right * x;

        transform.position += dir.normalized * speed * Time.deltaTime;

        if (EventMove != null)
        {
            EventMove();
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        if (EventJump != null)
        {
            EventJump();
        }
    }

    public void FakeOnCollisionEnter(Collision collision)
    {

    }
}


