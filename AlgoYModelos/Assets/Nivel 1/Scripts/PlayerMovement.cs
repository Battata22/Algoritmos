using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float _xAxis, _zAxis;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _yVelocity;
    [SerializeField] CharacterController _cc;

    [SerializeField] bool onGround = false;
    private void Start()
    {
        //_rb = GetComponent<Rigidbody>();
        _cc = GetComponent<CharacterController>();
    }

    void Update()
    {


        _xAxis = Input.GetAxisRaw("Horizontal");
        _zAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        Gravedad();

        if (_xAxis != 0 || _zAxis != 0)
        {
            Movement();
        }
    }

    void Movement()
    {
        Vector3 dir = (transform.right * _xAxis + transform.forward * _zAxis).normalized;

        _cc.Move(dir * Time.fixedDeltaTime * _speed);

        //_rb.position += (dir * Time.fixedDeltaTime * _speed);
    }

    void Gravedad()
    {
        _cc.Move(-transform.up * 9.8f * Time.fixedDeltaTime);
    }

    void Jump()
    {
        if(onGround == true)
        {
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Mapa")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Mapa")
        {
            onGround = false;
        }
    }

}
