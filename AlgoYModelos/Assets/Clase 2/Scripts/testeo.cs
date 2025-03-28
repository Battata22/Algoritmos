using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class testeo : MonoBehaviour
{
    [SerializeField] Balla bala;
    ObjectPool<Balla> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Balla>(GetBala, On, Off, 4);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var b = _pool.Get();
            b.transform.position = transform.position;
        }
    }

    Balla GetBala()
    {
        return Instantiate(bala);
    }
    public void On(Balla bala)
    {
        bala.gameObject.SetActive(true);
    }

    public void Off(Balla bala)
    {
        bala.gameObject.SetActive(false);
    }

}
