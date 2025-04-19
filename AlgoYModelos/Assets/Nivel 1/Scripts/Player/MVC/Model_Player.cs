using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Player
{
    float _xAxis, _zAxis;

    float _speed;
    float _jumpForce;
    CharacterController _cc;

    Vector3 _direccion;

    float _gravedad;
    float _yVelocity;
    float _gravedadMult;

    public Model_Player(float speed, float jumpForce, CharacterController cc, Vector3 direccion, float gravedad, float yVelocity, float gravedadMult)
    {
        _speed = speed;
        _jumpForce = jumpForce;
        _cc = cc;
        _direccion = direccion;
        _gravedad = gravedad;
        _yVelocity = yVelocity;
        _gravedadMult = gravedadMult;
    }

    public void FakeStart()
    {

    }

    public void FakeUpdate()
    {

    }

    public void FakeFixedUpdate()
    {

    }

    public void Gravedad()
    {
        if (_cc.isGrounded == true && _yVelocity < 0)
        {
            _yVelocity = -1;
        }
        else
        {
            _yVelocity += _gravedad * _gravedadMult * Time.fixedDeltaTime;
        }

        _direccion.y = _yVelocity;
    }

    public void Movement(Transform transform,float _xAxis, float _zAxis)
    {
        Vector3 dir = (transform.right * _xAxis + transform.forward * _zAxis).normalized;

        _direccion.x = dir.x;
        _direccion.z = dir.z;

        _cc.Move(_direccion * Time.fixedDeltaTime * _speed);
    }

    public void Jump()
    {
        if (_cc.isGrounded == true)
        {
            _yVelocity += _jumpForce;
        }

    }


}
