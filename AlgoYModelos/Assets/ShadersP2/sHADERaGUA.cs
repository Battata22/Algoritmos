using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sHADERaGUA : MonoBehaviour
{
    [SerializeField] Material _PPAgua;
    [SerializeField] bool inWater;
    [SerializeField] GameObject player;

    void Start()
    {
        _PPAgua.SetFloat("_Activo", 0);
    }

    
    void Update()
    {
        if (!inWater)
        {
            _PPAgua.SetFloat("_Activo", 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other == player.GetComponent<Collider>())
        {
            inWater = true;
            _PPAgua.SetFloat("_Activo", 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            inWater = false;
            _PPAgua.SetFloat("_Activo", 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            inWater = true;
            _PPAgua.SetFloat("_Activo", 1);
        }
    }
}
