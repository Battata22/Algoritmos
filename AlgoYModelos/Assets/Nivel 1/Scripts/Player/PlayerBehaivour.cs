using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehaivour : MonoBehaviour
{
    Model_Player _model;
    View_Player _view;
    Controller_Player _controller;
    VidaManager _vidaManager;

    [SerializeField] float _damage;
    public float _speed;
    float _baseSpeed;
    [SerializeField] float _jumpForce;
    public CharacterController _cc;

    Vector3 _direccion;

    float _gravedad = -9.8f;
    float _yVelocity;
    [SerializeField] float _gravedadMult;

    [SerializeField] Animator _animController;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] ParticleSystem _particleSystem;

    private void Awake()
    {
        EntitiesManager.Instance.Player = gameObject;

        _cc = GetComponent<CharacterController>();
        _vidaManager = GetComponent<VidaManager>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();

        _model = new(_speed, _jumpForce, _cc, _direccion, _gravedad, _yVelocity, _gravedadMult, _particleSystem);
        _view = new(_model, _animController, _audioSource);
        _controller = new(_model, transform);
    }

    void Start()
    {
        _model.FakeStart();
        _baseSpeed = _speed;
    }

    private void Update()
    {
        _model.FakeUpdate();
        _view.FakeUpdate();
        _controller.FakeUpdate();

        LifeSaver();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_speed == _baseSpeed)
            {
                _speed = _baseSpeed * 2;

            }
        }
        else
        {
            _speed = _baseSpeed;
        }
    }

    private void FixedUpdate()
    {
        _model.FakeFixedUpdate();
        _controller.FakeFixedUpdate();
    }

    void LifeSaver()
    {
        if (transform.position.y <= -10)
        {
            transform.position = new Vector3(25.2f, 1.30f, -62.6f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            var col = collision.gameObject.GetComponent<Enemy>();
            _vidaManager.TakeDamage(col._damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "fuegoo")
        {
            PPFinales.instance.PrenderQuemado();
        }
    }

}
