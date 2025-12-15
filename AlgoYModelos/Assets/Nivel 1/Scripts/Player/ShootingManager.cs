using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] public Transform _bulletSpawnPoint;
    [SerializeField] Vector3 test;

    [SerializeField] BulletBehaivour _bullet;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Shoot();

            Instantiate(_bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        }
    }

}
