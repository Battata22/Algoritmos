using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamageable, IGravityOut
{
    public float _hp;
    public float _gravityForce;
    public float _radioBusqueda;
    public float _cooldownBusqueda;

    protected Rigidbody _rb;
    [SerializeField] protected bool _isTargeting = false;
    [SerializeField] protected GameObject _target;

    public float waitBusqueda;

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        waitBusqueda += Time.deltaTime;

        if (waitBusqueda >= _cooldownBusqueda && _isTargeting == false)
        {
            LookForTarget();
            waitBusqueda = 0;
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
            Destroy(gameObject);
        }
    }

    public virtual void NoGravity()
    {
        _rb.useGravity = false;
        _rb.constraints = RigidbodyConstraints.None;
        _rb.AddForce(transform.up * _gravityForce, ForceMode.Impulse);
        _rb.AddTorque(new Vector3(Random.Range(0, 200), Random.Range(0, 200), Random.Range(0, 200)));
    }

    public virtual void LookForTarget()
    {
        Physics.SphereCast(transform.position, _radioBusqueda, transform.position, out RaycastHit hit);

        if (hit.collider.gameObject == EntitiesManager.Instance.Player)
        {
            _target = hit.collider.gameObject;
            _isTargeting = true;
        }
        else
        {

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radioBusqueda);
    }

    //Problemas
    //El waitBusqueda no se reinicia
    //el radio de busqueda es mas grande de lo que muestra el gizmo, uno de los dos esta mal
    //

}
