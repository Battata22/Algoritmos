using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivour : PlayerWeapon
{
    [SerializeField] float _speed;
    [SerializeField] float _selfDestroyTime;
    [SerializeField] Vector3 _dir;
    float _waitDestroy;

    public ObjectPool<BulletBehaivour> _pool;

    private void Start()
    { 
        //Destroy(gameObject, _selfDestroyTime);
        //Recicle(_pool);
    }

    void Update()
    {
        _waitDestroy += Time.deltaTime;

        if(_waitDestroy >= _selfDestroyTime)
        {
            _pool.GetBack(this);
            _waitDestroy = 0;
        }

        Avance();
    }

    void Avance()
    {
        transform.position += (transform.forward * _speed * Time.deltaTime);
    }

    public void Recicle(ObjectPool<BulletBehaivour> pool)
    {
        _pool = pool;
        transform.position = EntitiesManager.Instance.Player.GetComponent<ShootingManager>()._bulletSpawnPoint.position;
        //transform.localRotation = EntitiesManager.Instance.Player.GetComponent<ShootingManager>()._bulletSpawnPoint.rotation;
        transform.LookAt(Camera.main.ViewportToWorldPoint(new Vector3(_dir.x, _dir.y, _dir.z)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.GetComponent<IDamageable>() != null)
            {
                other.GetComponent<IDamageable>().TakeDamage(_damage);
            }

            print("choque con " + other.name);
            _pool.GetBack(this);
            _waitDestroy = 0;
            //Destroy(gameObject);

        }
    }


    #region Dano
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.GetComponent<IDamageable>() != null)
    //    {
    //        var col = other.gameObject.GetComponent<IDamageable>();

    //        col.TakeDamage(_damage);
    //    }
    //    Destroy(gameObject);
    //    //print("Me choque con " + other.gameObject.name);

    //} 
    #endregion
}
