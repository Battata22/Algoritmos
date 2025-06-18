using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPSeta : MonoBehaviour, PickUp
{
    public void PickUp()
    {
        //activar efecto

        Destroy(gameObject);
    }
}

public interface PickUp
{
    public void PickUp();
}
