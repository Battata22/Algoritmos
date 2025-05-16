using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerY : MonoBehaviour, IChangeableMovement
{
    public float _speed, _speedmulti;
    public IMovimientos _movement;

    void Start()
    {
        _movement = new NormalMovement(transform, _speed);
    }


    void Update()
    {
        _movement.FakeUpdate();
    }

    public void Change(IMovimientos movement)
    {
        _movement = movement;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float GetSpeedmulti()
    {
        return _speedmulti;
    }

    public IMovimientos GetMovement()
    {
        return _movement;
    }
}

public interface IChangeableMovement
{
    public void Change(IMovimientos movement);
    Transform GetTransform();
    float GetSpeed();
    float GetSpeedmulti();
    IMovimientos GetMovement();
}
