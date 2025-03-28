using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool <T>
{
    List<T> _stock = new List<T>();
    Func<T> _factory;
    Action<T> _on;
    Action<T> _off;


    public ObjectPool(Func<T> factory, Action<T> pbjOn, Action<T> objOff, int currentStock = 5)
    {
        _factory = factory;
        _on = pbjOn;
        _off = objOff;

        for (int i = 0; i < currentStock; i++)
        {
            var x = factory();
            _off(x);
            _stock.Add(x);
        }
    }

    public T Get()
    {
        T x;

        if (_stock.Count > 0)
        {
            x = _stock[0];
            _stock.Remove(x);
        }
        else
        {
            x = _factory();
        }

        _on(x);

        return x;


    }

    public void GetBack(T x)
    {
        _off(x);
        _stock.Add(x);
    }
}
