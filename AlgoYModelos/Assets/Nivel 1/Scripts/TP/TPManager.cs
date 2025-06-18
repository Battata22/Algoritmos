using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPManager : MonoBehaviour
{
    [SerializeField] Transform[] puntosDeTp;
    [SerializeField] GameObject canvasTp;
    Transform playerTransform;
    ShootingManager shootScript;
    PlayerCameraControl cameraScript;

    private void Start()
    {
        playerTransform = EntitiesManager.Instance.Player.transform;
        shootScript = EntitiesManager.Instance.Player.GetComponent<ShootingManager>();
        cameraScript = EntitiesManager.Instance.Player.GetComponent<PlayerCameraControl>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canvasTp.SetActive(true);
            shootScript.enabled = false;
            cameraScript.menu = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canvasTp.SetActive(false);
            shootScript.enabled = true;
            cameraScript.menu = false;
        }
        
    }

    public void TPBase()
    {
        playerTransform.position = puntosDeTp[0].position;
    }

    public void TPShaders()
    {
        playerTransform.position = puntosDeTp[1].position;
    }

    public void TPNiveles()
    {
        playerTransform.position = puntosDeTp[2].position;
    }

    public void Sorpresa()
    {

    }
}
