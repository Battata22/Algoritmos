using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPoolMia <T>
{
    List<T> _stock = new();

    public ObjectPoolMia(Func<T> factory, int actualStock = 5)
    {
        for (int i = 0; i < actualStock; i++)
        {
            var x = factory();
            _stock.Add(x);
        }
    }
}
