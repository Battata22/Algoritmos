using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPSeta : MonoBehaviour, PickUp
{
    [SerializeField] Material _PPHue;
    [SerializeField] float tiempoDroga;

    private void Start()
    {
        _PPHue.SetFloat("_Prendido", 0);
    }
    public void PickUp()
    {
        //activar efecto
        StartCoroutine(ActivarPPSeta());
        //Destroy(gameObject);
        transform.position = new Vector3(11111, 0, 11111);
    }

    IEnumerator ActivarPPSeta()
    {
        _PPHue.SetFloat("_Prendido", 1);
        yield return new WaitForSeconds(tiempoDroga);
        _PPHue.SetFloat("_Prendido", 0);
    }
}

public interface PickUp
{
    public void PickUp();
}
