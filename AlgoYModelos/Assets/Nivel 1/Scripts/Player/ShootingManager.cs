using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootingManager : MonoBehaviour
{
    public Transform _bulletSpawnPoint;
    [SerializeField] GameObject _bullet;
    public bool HasCrossbow;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && HasCrossbow)
        {
            Instantiate(_bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            _audioSource.PlayOneShot(_audioClip);
        }
    }

}
