using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    Model _model;
    View _view;
    Controller _controller;
    public Animator _animator;
    public AudioSource _audioSource;
    public Rigidbody _rb;
    public float _speed;
    public float _jumpForce;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

        _model = new Model(transform, _speed, _jumpForce, _rb);
        _view = new View(_model, _animator, _audioSource);
        _controller = new Controller(_model);

    }
    void Update()
    {
        #region FakeUpdates
        _controller.FakeUpdate();
        _view.FakeUpdate();
        _model.FakeUpdate(); 
        #endregion


    }

    private void OnCollisionEnter(Collision collision)
    {
        _model.FakeOnCollisionEnter(collision);   
    }
}
