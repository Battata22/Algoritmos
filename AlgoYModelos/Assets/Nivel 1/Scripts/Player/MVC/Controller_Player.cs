using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player
{
    Model_Player _model;
    Transform _transform;
    float _xAxis, _zAxis;
    public Controller_Player(Model_Player model, Transform transform)
    {
        _model = model;
        _transform = transform;
    }
    
    public void FakeUpdate()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _zAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _model.Jump();
        }
    }

    public void FakeFixedUpdate()
    {
        _model.Gravedad();

        _model.Movement(_transform, _xAxis, _zAxis);
    } 
}
