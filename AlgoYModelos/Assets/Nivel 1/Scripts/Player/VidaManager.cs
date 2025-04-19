using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaManager : MonoBehaviour, IObservable_
{
    [SerializeField] float _hp;

    List<IObserver_> _observers = new();
    public float Hp
    {
        get {  return _hp; }
    }

    [SerializeField] float _maxHp;
    [SerializeField] float _invulnerabilityTime;
    [SerializeField] float _waitInvulnerability;

    void Start()
    {
        _hp = _maxHp;


        foreach (var observer in _observers)
        {
            observer.Notify(Hp);
        }

    }

    
    void Update()
    {
        _waitInvulnerability += Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        if (_waitInvulnerability >= _invulnerabilityTime)
        {
            if (_hp > 0)
            {
                _hp -= damage;
                _waitInvulnerability = 0;
                Debug.Log("vida restante " + _hp);

                foreach (var observer in _observers)
                {
                    observer.Notify(Hp);
                }
            }
            else
            {
                Debug.Log("Muerto " + _hp);
            }

        }
    }

    public void Suscribe(IObserver_ observer)
    {
        if (_observers.Contains(observer)) return;

        _observers.Add(observer);
    }

    public void Unsuscribe(IObserver_ observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }
}
