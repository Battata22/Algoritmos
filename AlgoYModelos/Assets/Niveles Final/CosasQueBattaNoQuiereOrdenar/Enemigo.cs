using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour, IDamageable
{

    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform _player;
    [SerializeField] float _radioFov;
    [SerializeField] float _checkCooldown;
    [SerializeField] float _closeEnoughRange;
    [SerializeField] Collider[] _overlapse;

    [SerializeField] Puerta[] _puertas;

    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _ataque, _caminata, _muerte;
    [SerializeField] float _tiempoSonidoAtaque;

    bool muerto;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        StartCoroutine(CheckForTarget());
    }

    private void Update()
    {

    }

    IEnumerator Death()
    {
        foreach (var puerta in _puertas)
        {
            puerta.ActivateDoor();
            yield return new WaitForEndOfFrame();
        }

        ChangeAnimState(AnimState.Death);

        //reproducir sonido
        //_audioSource.clip = _muerte;
        //_audioSource.Play();
    }

    void ChangeAnimState(AnimState state)
    {
        _anim.SetBool("Idle", false);
        _anim.SetBool("Walk", false);
        _anim.SetBool("Attack", false);
        _anim.SetBool("Death", false);

        _anim.SetBool(state.ToString(), true);
    }

    IEnumerator CloseEnough()
    {
        _agent.isStopped = true;
        _agent.SetDestination(transform.position);

        ChangeAnimState(AnimState.Attack);

        yield return new WaitForSeconds(_tiempoSonidoAtaque);

        _audioSource.clip = _muerte;
        _audioSource.Play();
    }

    IEnumerator CheckForTarget()
    {
        if (muerto) yield return null;

        _overlapse = Physics.OverlapSphere(transform.position, _radioFov);

        foreach (Collider collider in _overlapse)
        {
            if (collider.GetComponent<PlayerBehaivour>())
            {
                if (Vector3.Distance(transform.position, _player.position) <= _closeEnoughRange)
                {
                    StartCoroutine(CloseEnough());
                }
                else
                {
                    _agent.isStopped = false;
                    _agent.SetDestination(_player.position);
                    ChangeAnimState(AnimState.Walk);
                }
            }
            else
            {
                _agent.isStopped = true;
                _agent.SetDestination(transform.position);
                ChangeAnimState(AnimState.Idle);
            }
        }

        yield return new WaitForSeconds(_checkCooldown);
        StartCoroutine(CheckForTarget());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _radioFov);
    }

    public void TakeDamage(float a)
    {
        muerto = true;
        StartCoroutine(Death());
        GetComponent<Collider>().enabled = false;
    }
}

[Flags]
public enum AnimState
{
    Idle, Walk, Attack, Death
}
