using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatFadeInOut : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField,Range(0,1)] int numActive;

    [SerializeField] float temp;
    void Update()
    {
        
        if (temp >= 100)
        {
            temp = 1.2f;
        }
        
        if (numActive == 0)
        {
            if (temp != 1.2f)
            {
                temp = 1.2f;
            }
            material.SetInt("_active", 0);
            material.SetFloat("_timeSine", temp);
        }
        else
        {
            temp += Time.deltaTime;
            material.SetInt("_active", 1);
            material.SetFloat("_timeSine", temp);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (numActive == 0)
            {
                numActive = 1;
            }
            else
            {
                numActive = 0;
            }
        }
        //2.9 pantallazo azul de gonza
        //termina en 4.608348
    }
}
