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
    ObjectPool<BulletBehaivour> _poolBullets;

    private void Awake()
    {
        _poolBullets = new ObjectPool<BulletBehaivour>(Shoot, BulletOn, BulletOff, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Shoot();
            var bullet = _poolBullets.Get();
            bullet.transform.position = _bulletSpawnPoint.position;
        }
    }

    BulletBehaivour Shoot()
    {
        return Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity);

        //var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
        //bullet.transform.LookAt(Camera.main.ViewportToWorldPoint(new Vector3(test.x, test.y, test.z)));

    }

    void BulletOn(BulletBehaivour bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.Recicle(_poolBullets);

    }

    void BulletOff(BulletBehaivour bullet)
    {
        bullet.Recicle(_poolBullets);
        bullet.gameObject.SetActive(false);
    }
}
