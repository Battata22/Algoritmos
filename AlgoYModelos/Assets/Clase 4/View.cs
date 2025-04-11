using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    Model model;
    public View(Model _model, Animator anim, AudioSource audioSource)
    {
        model = _model;

        model.EventJump += Jump;
        model.EventMove += Move;
    }
    public void FakeUpdate()
    {
        
    }

    public void Move()
    {
        Debug.Log("Activo anim move");
    }

    public void Jump()
    {
        Debug.Log("Activo anim salto");
        Debug.Log("Activo sonido salto");


    }

}
