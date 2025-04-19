using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Player
{
    Model_Player _model;
    public Animator _animController;
    public AudioSource _audioSource;

    public View_Player(Model_Player model,Animator animator, AudioSource audioSource)
    {
        _model = model;
        _animController = animator;
        _audioSource = audioSource;
    }


    
    public void FakeUpdate()
    {
        
    }

    public void Move()
    {
        Debug.Log("Me muevo");
    }

    public void Jump()
    {
        Debug.Log("Salto");
    }
}
