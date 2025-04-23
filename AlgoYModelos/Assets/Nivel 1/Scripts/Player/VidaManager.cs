using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] float _restartTime;
    float _waitRestart;

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
        _waitRestart += Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        if (_waitInvulnerability >= _invulnerabilityTime)
        {
            if (_hp > damage)
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
                _hp = 0;

                foreach (var observer in _observers)
                {
                    observer.Notify(Hp);
                }

                Debug.Log("Muerto " + _hp);
                StartCoroutine(Restart());

            }

        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(_restartTime);
        
        SceneManager.LoadScene(0);
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
