using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class Player : MonoBehaviour, ITargetable
{

    [SerializeField] float _maxHp;
    [SerializeField] float _hp;

    List<IObserver> _observers = new List<IObserver>();

    [SerializeField] KeyCode _key;

    public Action action;
    public event Action actionEvent;

    private void Awake()
    {
        _hp = _maxHp;

        EventManager.Suscribe("EnemyCall", PlayerCall);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            GetDamage(10);
        }
    }


    public void GetDamage(float damage)
    {
        _hp -= damage;

        foreach (var observer in _observers)
        {
            observer.Notify(_hp, _maxHp);
        }

        if(_hp <= 0)
        {
            print("momo");
        }
    }

    public void Suscribe(IObserver x)
    {
        if (_observers.Contains(x)) return;

        _observers.Add(x);
    }

    public void Suscribe(IObserver x, int a)
    {
        if (_observers.Contains(x)) return;

        _observers.Add(x);
    }

    public void Unsuscribe(IObserver x)
    {
        if (_observers.Contains(x));

        _observers.Remove(x);
    }

    public void test(params object[] obj)
    {
        
    }

    public void PlayerCall(params object[] args)
    {
        print("metodo enemycall");
    }

    private void OnDestroy()
    {
        EventManager.Unsuscribe("EnemyCall", PlayerCall);
    }
}
