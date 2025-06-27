using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarSol : MonoBehaviour
{
    [SerializeField] float tiempo;
    [SerializeField] Light sol;
    float wait;
    void Start()
    {
        sol.enabled = true;
    }

    
    void Update()
    {
        wait += Time.deltaTime;
        
        if (wait > tiempo)
        {
            sol.enabled = false;
        }
    }
}
