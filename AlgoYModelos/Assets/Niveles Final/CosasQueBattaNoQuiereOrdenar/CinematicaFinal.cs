using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicaFinal : MonoBehaviour
{
    [SerializeField] float _speedVignette;

    [SerializeField] Camera cam;
    [SerializeField] PlayerCameraControl _playerCam;
    [SerializeField] ShootingManager _playerShoot;
    [SerializeField] Transform _camHolder;
    [SerializeField] Material _vignette;
    [SerializeField] GameObject _ballesta;
    [SerializeField] PlayerBehaivour _player;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] float _speedVolumen;

    [SerializeField] GameObject _anim;
    
    void Start()
    {
        ResetVignette();
    }

    
    void Update()
    {
        if (!_audioSource.isPlaying) return;

        _audioSource.volume += _speedVolumen * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaivour>())
        {
            ActivateCinematica();
        }
    }

    void ActivateCinematica()
    {
        _audioSource.Play();

        _playerCam.Cinematica = true;
        _ballesta.SetActive(false);
        _playerShoot.HasCrossbow = false;
        //activar el modelo del player con la animacion
        cam.transform.position = _camHolder.position;
        cam.transform.rotation = _camHolder.rotation;
        _anim.SetActive(true);
        _player.quieto = true;
        StartCoroutine(ActivateVignette());
    }

    IEnumerator ActivateVignette()
    {
        while (_vignette.GetFloat("_Power") > 0)
        {
            _vignette.SetFloat("_Power", _vignette.GetFloat("_Power") - Time.deltaTime * _speedVignette);
            yield return new WaitForEndOfFrame();
        }

        if (_vignette.GetFloat("_Power") < 0)
        {
            _vignette.SetFloat("_Power", 0);
            StartCoroutine(Salir());
        }
    }

    void ResetVignette()
    {
        _vignette.SetFloat("_Power", 15);
    }

    IEnumerator Salir()
    {
        yield return new WaitForSeconds(2);
        print("quit");
        Application.Quit();
    }

    private void OnDestroy()
    {
        ResetVignette();
    }
}
