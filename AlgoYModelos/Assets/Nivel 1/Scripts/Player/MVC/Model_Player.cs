using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    ParticleSystem _partSalto;

    public Model_Player(float speed, float jumpForce, CharacterController cc, Vector3 direccion, float gravedad, float yVelocity, float gravedadMult, ParticleSystem partSalto)
    {
        _speed = speed;
        _jumpForce = jumpForce;
        _cc = cc;
        _direccion = direccion;
        _gravedad = gravedad;
        _yVelocity = yVelocity;
        _gravedadMult = gravedadMult;
        _partSalto = partSalto;
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

        if (!EntitiesManager.Instance.Player.GetComponent<PlayerBehaivour>().quieto)
        {
            Vector3 dir = (transform.right * _xAxis + transform.forward * _zAxis).normalized;

            _direccion.x = dir.x;
            _direccion.z = dir.z;

            _cc.Move(_direccion * Time.fixedDeltaTime * EntitiesManager.Instance.Player.GetComponent<PlayerBehaivour>()._speed);

        }

    }

    public void Jump()
    {
        if (_cc.isGrounded == true)
        {
            _yVelocity += _jumpForce;
            //_partSalto.Play();
            if (!EntitiesManager.Instance.Player.GetComponent<PlayerBehaivour>().quieto)
            {
                EntitiesManager.Instance.Player.GetComponent<PlayerBehaivour>()._saltoSource.Play();

            }
        }
    }


}



