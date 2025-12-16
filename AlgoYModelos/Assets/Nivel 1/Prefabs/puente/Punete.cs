using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punete : MonoBehaviour
{
    [SerializeField] GameObject ParedInv1, ParedInv2;
    [SerializeField] int rotos = 0;
    public int Rotos { get { return rotos; } set { rotos = value; DesactivarParedesInv(); } }


    void DesactivarParedesInv()
    {
        if (Rotos >= 2)
        {
            ParedInv1.SetActive(false);
            ParedInv2.SetActive(false);
        }
    }
}
