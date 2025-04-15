using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float _xAxis, _zAxis;
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    CharacterController _cc;

    Vector3 _direccion;

    float _gravedad = -9.8f;
    float _yVelocity;
    [SerializeField] float _gravedadMult;
    private void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    void Update()
    {

        _xAxis = Input.GetAxisRaw("Horizontal");
        _zAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        Gravedad();

        Movement();


    }

    void Gravedad()
    {
        if(_cc.isGrounded == true && _yVelocity < 0)
        {
            _yVelocity = -1;
        }
        else
        {
            _yVelocity += _gravedad * _gravedadMult * Time.fixedDeltaTime;
        }

        _direccion.y = _yVelocity;
    }

    void Movement()
    {
        Vector3 dir = (transform.right * _xAxis + transform.forward * _zAxis).normalized;

        _direccion.x = dir.x;
        _direccion.z = dir.z;

        _cc.Move(_direccion * Time.fixedDeltaTime * _speed);
    }

    void Jump()
    {
        if(_cc.isGrounded == true)
        {
            _yVelocity += _jumpForce;
        }

    }

}
