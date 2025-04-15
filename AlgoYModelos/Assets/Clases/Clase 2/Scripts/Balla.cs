using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balla : MonoBehaviour
{


    ObjectPool<Balla> _pool;
    [SerializeField] float speed;
    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    public void Refresh(ObjectPool<Balla> pool)
    {
        _pool = pool;
        
    }

}
