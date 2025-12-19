using System;
using System.Collections;
using Unity.VisualScripting;
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

    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audioSource, _audioSourceAtaque;
    [SerializeField] AudioClip _ataque, _caminata, _muerte;
    [SerializeField] float _tiempoSonidoAtaque;

    bool muerto;

    private void Start()
    {
        _anim = GetComponent<Animator>();

        StartCoroutine(CheckForTarget());
    }

    IEnumerator Death()
    {
        ChangeAnimState(AnimState.Death);
        _audioSource.PlayOneShot(_muerte);
        FindFirstObjectByType<OpenSesame>().Muertos++;
        yield return null;
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

        yield return null;
    }

    public void Attack()
    {
        _audioSourceAtaque.Play();

        if (Vector3.Distance(transform.position, _player.position) <= _closeEnoughRange)
        {
            EntitiesManager.Instance.Player.GetComponent<PlayerBehaivour>()._cc.enabled = false;
            _player.position = new Vector3(25.2f, 1.30f, -62.6f);
            EntitiesManager.Instance.Player.GetComponent<PlayerBehaivour>()._cc.enabled = true;
            EntitiesManager.Instance.Player.GetComponent<PlayerBehaivour>().MuerteSound();
        }
    }

    IEnumerator CheckForTarget()
    {
        if (muerto)
        {
            _agent.isStopped = true;
            _agent.SetDestination(transform.position);
            yield break;
        }

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

    [SerializeField] int vida = 3;
    [SerializeField] float tiempoRojo;
    public Material _ogMat, rojo;
    [SerializeField] Renderer _renderer1, _renderer2;

    public void TakeDamage(float a)
    {
        vida--;

        _audioSource.Play();

        StartCoroutine(ChangeColor());

        if (vida <= 0)
        {
            muerto = true;
            StartCoroutine(Death());
            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator ChangeColor()
    {
        _renderer1.material = rojo;
        _renderer2.material = rojo;
        yield return new WaitForSeconds(tiempoRojo);
        _renderer1.material = _ogMat;
        _renderer2.material = _ogMat;
    }
}

[Flags]
public enum AnimState
{
    Idle, Walk, Attack, Death
}
