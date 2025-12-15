using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivour : PlayerWeapon
{
    [SerializeField] float _speed;
    [SerializeField] float _selfDestroyTime;
    [SerializeField] Vector3 _dir;

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

}
