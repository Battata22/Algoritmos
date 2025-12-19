using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSesame : MonoBehaviour
{
    [SerializeField] Puerta[] _puertas;

    [SerializeField] int _muertos;
    public int Muertos { get { return _muertos; } set { _muertos = value; StartCoroutine(OpenDoors()); } }

    IEnumerator OpenDoors()
    {
        if (Muertos < 3) yield break;

        yield return new WaitForSeconds(1);

        foreach (var puerta in _puertas)
        {
            puerta.ActivateDoor();
            yield return new WaitForSeconds(1f);
        }
    }

}
