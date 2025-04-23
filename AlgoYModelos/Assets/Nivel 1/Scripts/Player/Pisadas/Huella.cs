using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huella : MonoBehaviour
{
    [SerializeField] float _multiDissolve;
    [SerializeField] Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    
    void Update()
    {
        Dissolve();
    }

    void Dissolve()
    {
        var ant = _renderer.material.GetFloat("_Dissolve");

        _renderer.material.SetFloat("_Dissolve", ant + Time.deltaTime * _multiDissolve);
        //print("seteado a " + ant * Time.deltaTime * _multiDissolve);
    }
}
