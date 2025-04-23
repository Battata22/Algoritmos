using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class _ObjectPool <T>
{
    List<T> _stock = new List<T>();
    Func<T> _factory;
    Action<T> _on;
    Action<T> _off;


    public _ObjectPool(Func<T> factory, Action<T> prenderObj, Action<T> apagarObj, int actualStock = 5)
    {
        _factory = factory;
        _on = prenderObj;
        _off = apagarObj;

        for (int i = 0; i < actualStock; i++)
        {
            var x = factory();
            _off(x);
            _stock.Add(x);
        }
    }

    public T Get()
    {
        T x;

        //Chequear si la lista esta vacia
        if (_stock.Count > 0)
        {
            //Agarra el primero
            x = _stock[0];
            //Lo saca de la lista de stock
            _stock.Remove(x);
        }
        else //Si no hay nada en la lista de stock
        {
            //Spawnea uno
            x = _factory();
        }

        //Lo prendemos por las dudas
        _on(x);

        return x;


    }

    public void GetBack(T x)
    {
        _off(x);
        _stock.Add(x);
    }
}
