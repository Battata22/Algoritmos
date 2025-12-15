using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLibro : MonoBehaviour, PickUp
{
    [SerializeField] Material _PPPickUp;
    [SerializeField] float tiempoShader;
    [SerializeField] float temp;
    [SerializeField] ShootingManager shootingManager;
    [SerializeField] GameObject _crossbowCanvas;
    public void PickUp()
    {
        StartCoroutine(ActivarShader());
        transform.position = new Vector3(11111, 0, 11111);
        shootingManager.HasCrossbow = true;
        _crossbowCanvas.SetActive(true);
    }

    private void Start()
    {
        _PPPickUp.SetFloat("_ActivePickUp", 0);
    }

    void Update()
    {
        temp += Time.deltaTime;
        _PPPickUp.SetFloat("_FakeTime", temp);
    }


    IEnumerator ActivarShader()
    {
        temp = 0;
        _PPPickUp.SetFloat("_ActivePickUp", 1);
        yield return new WaitForSeconds(tiempoShader);
        _PPPickUp.SetFloat("_ActivePickUp", 0);
    }
}
