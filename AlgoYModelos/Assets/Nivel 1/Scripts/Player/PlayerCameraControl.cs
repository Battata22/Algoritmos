using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    [SerializeField] GameObject _cam;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _cameraHolder;
    [SerializeField] float _fixedZ, _fixedY;

    [SerializeField] float _sensibilidad;
    float _mouseX, _mouseY;
    float _xRotation, _yRotation;

    public bool menu = false;

    void Start()
    {
        _cam = Camera.main.gameObject;
        _player = gameObject;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    void Update()
    {
        //Seguimiento de la camara al player
        //_cam.transform.position = new Vector3(_player.transform.position.x/* + _distFromPlayer*/, _player.transform.position.y + _fixedY, _player.transform.position.z + _fixedZ);
        _cam.transform.position = _cameraHolder.transform.position;
        _cam.transform.rotation = _cameraHolder.transform.rotation;

        if (!menu)
        {
            MoveUpdate();
        }

    }

    private void FixedUpdate()
    {

        if (!menu)
        {
            MoveFixed();
        }

    }

    public void MoveUpdate()
    {
        //Rotacion de la camara
        _mouseX = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * _sensibilidad;
        _mouseY = Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * _sensibilidad;

        _yRotation += _mouseX;
        _xRotation -= _mouseY;

        _xRotation = Mathf.Clamp(_xRotation, -89f, 89f);
    }

    public void MoveFixed()
    {
        transform.localRotation = Quaternion.Euler(0, _yRotation, 0);

        _cameraHolder.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
    }
}
