using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    Model model;
    public Controller(Model _model)
    {
        model = _model;
    }
    public void FakeUpdate()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");

        if (x != 0 || z != 0)
        {
            model.Move(x, z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            model.Jump();
        }
    }

}
