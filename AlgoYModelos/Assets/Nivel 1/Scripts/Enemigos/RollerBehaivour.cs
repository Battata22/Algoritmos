using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBehaivour : Enemy
{
    Renderer _render;
    [SerializeField] float _ajusteCalculoVel;

    protected override void Start()
    {
        base.Start();
        _render = GetComponent<Renderer>();
    }

    protected override void Update()
    {
        base.Update();
        float shader = (_rb.angularVelocity.magnitude * Time.deltaTime * _ajusteCalculoVel);
        _render.material.SetFloat("_VelTime", shader);

    }
}
