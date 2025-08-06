using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPFinales : MonoBehaviour
{
    [SerializeField] Material _PPQuemado, _PPGuiso, _PPPausa, _PPCorrer;
    [SerializeField] float _duracionGuiso, _duracionQuemado;

    public static PPFinales instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _PPQuemado.SetFloat("_PrendidoQuemar", 0);
        _PPGuiso.SetFloat("_CrearPVida", 0);
        _PPPausa.SetFloat("_Prendido", 0);
        _PPCorrer.SetFloat("_SprintActive", 0);
    }


    void Update()
    {
        DeteccionCorrer();
        DeteccionPausa();
    }

    void DeteccionCorrer()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _PPCorrer.SetFloat("_SprintActive", 1);
        }
        else
        {
            _PPCorrer.SetFloat("_SprintActive", 0);
        }
    }

    void DeteccionPausa()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            _PPPausa.SetFloat("_Prendido", 1);
        }
        else
        {
            _PPPausa.SetFloat("_Prendido", 0);
        }
    }

    public void PrenderPPGuiso()
    {
        StopCoroutine(ApagarGuiso());
        _PPGuiso.SetFloat("_CrearPVida", 1);
        StartCoroutine(ApagarGuiso());
    }

    IEnumerator ApagarGuiso()
    {
        yield return new WaitForSeconds(_duracionGuiso);
        _PPGuiso.SetFloat("_CrearPVida", 0);
    }

    public void PrenderQuemado()
    {
        StopCoroutine(ApagarQuemado());
        _PPQuemado.SetFloat("_PrendidoQuemar", 1);
        print("fuegooo");
        StartCoroutine(ApagarQuemado());

    }

    IEnumerator ApagarQuemado()
    {
        yield return new WaitForSeconds(_duracionQuemado);
        _PPQuemado.SetFloat("_PrendidoQuemar", 0);
    }
}
