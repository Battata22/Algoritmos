using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivour : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        print("Me choque con " +  collision.gameObject.name);
    }
}
