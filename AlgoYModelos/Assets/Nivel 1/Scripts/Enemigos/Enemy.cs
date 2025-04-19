using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamageable, IGravityOut
{
    [SerializeField] protected float _hp;
    [SerializeField] protected float _maxHp;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _gravityForce;
    [SerializeField] protected float _radioBusqueda;
    [SerializeField] protected float _cooldownBusqueda;
    [SerializeField] protected float _distanciaCercania;

    [SerializeField] protected Rigidbody _rb;
    [SerializeField] protected bool _isFollowing = false;
    [SerializeField] protected GameObject _target;

    float waitBusqueda;

    EnemyStates _state = new();

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _state = EnemyStates.Idle;
        Recicle(_pool);
    }

    protected virtual void Update()
    {
        waitBusqueda += Time.deltaTime;

        LookForTarget();

    }

    private void FixedUpdate()
    {
        if (_isFollowing == true)
        {
            FollowTarget();
        }
    }

    public virtual void TakeDamage(float damage)
    {
        if (_hp > 0)
        {
            _hp -= damage;
        }
        else if (_hp <= 0) 
        {
            //Destroy(gameObject);
            _pool.GetBack(this);
        }
    }

    public virtual void NoGravity()
    {
        _rb.useGravity = false;
        _rb.constraints = RigidbodyConstraints.None;
        _rb.AddForce(transform.up * _gravityForce, ForceMode.Impulse);
        _rb.AddTorque(new Vector3(Random.Range(0, 200), Random.Range(0, 200), Random.Range(0, 200)));
    }

    protected virtual void FollowTarget()
    {
        if (_target == null)
        {
            _state = EnemyStates.Idle;
            return;
        }

        var dir = _target.transform.position - transform.position;

        float dist = Vector3.Distance(transform.position, _target.transform.position);

        if (dist <= _distanciaCercania)
        {
            //estas muy cerca
            //poner metodos distintos para poder modificarlos
        }
        else
        {

        }

        _rb.AddForce(dir * _speed * Time.fixedDeltaTime, ForceMode.Force);
    }

    protected virtual void LookForTarget()
    {

        if (waitBusqueda >= _cooldownBusqueda && _isFollowing == false)
        {
            var hit = Physics.OverlapSphere(transform.position, _radioBusqueda);

            if (hit != null)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].gameObject == EntitiesManager.Instance.Player)
                    {
                        _target = hit[i].gameObject;
                        _isFollowing = true;
                        _state = EnemyStates.Following;
                    }
                }
            }

            waitBusqueda = 0;

        }
        else return;

    }


    protected virtual void WhatToDo()
    {
        if (_state == EnemyStates.Idle)
        {
            LookForTarget();
        }
        else if (_state == EnemyStates.Following)
        {
            //Al FixedUpdate

            //FollowTarget();
        }
        else if (_state == EnemyStates.Attacking)
        {

        }
        else if (_state == EnemyStates.OutGravity)
        {

        }
        else
        {
            LookForTarget();
        }
    }

    public ObjectPool<Enemy> _pool;
    public virtual void Recicle(ObjectPool<Enemy> pool)
    {
        _pool = pool;
        _target = null;
        _hp = _maxHp;
        _state = EnemyStates.Idle;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radioBusqueda);
    }

    //Problemas
    //El waitBusqueda no se reinicia

}

public enum EnemyStates
{
    Idle, Following, Attacking, OutGravity
}