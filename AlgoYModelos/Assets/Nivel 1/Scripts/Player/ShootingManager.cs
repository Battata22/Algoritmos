using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootingManager : MonoBehaviour
{
    public Transform _bulletSpawnPoint;
    [SerializeField] BulletBehaivour _bullet;
    public bool HasCrossbow;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && HasCrossbow)
        {
            Instantiate(_bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        }
    }

}
