using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaLuzHuella : MonoBehaviour
{
    [SerializeField] Renderer _render;
    [SerializeField] float _vel;

  
    void Start()
    {
        _render = GetComponent<Renderer>();
    }

    
    void Update()
    {
        if (_render.material.GetFloat("_Float") > 0)
        {
            var anterior = _render.material.GetFloat("_Float");
            _render.material.SetFloat("_Float", anterior - Time.deltaTime * _vel);
        }
    }
}
