using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivour : PlayerWeapon
{
    [SerializeField] float _speed;
    [SerializeField] float _selfDestroyTime;

    private void Start()
    {
        Destroy(gameObject, _selfDestroyTime);
    }

    void Update()
    {
        Avance();
    }

    void Avance()
    {
        transform.position += (transform.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.GetComponent<IDamageable>() != null)
            {
                other.GetComponent<IDamageable>().TakeDamage(_damage);
            }

            Destroy(gameObject);

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
