using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candado : MonoBehaviour, PickUp
{
    [SerializeField] Rigidbody[] _rigidBodiesGravedad;
    [SerializeField] Animator _animPuerta;
    [SerializeField] PlayerBehaivour _player;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioSource _audioSourceDoor;

    void Start()
    {
        _rigidBodiesGravedad = GetComponentsInChildren<Rigidbody>();
    }

    public void ActivarCandado()
    {
        if (!_player.HasKey) return;

        ApagarRBs();
        //activar anim
        _animPuerta.SetTrigger("Abrir");
        _audioSource.Play();
        _audioSourceDoor.clip = AudioClips.instance.OpenDoor;
        _audioSourceDoor.Play();
    }

    void ApagarRBs()
    {
        foreach (var col in _rigidBodiesGravedad)
        {
            col.constraints = RigidbodyConstraints.None;
        }
    }

    public void PickUp()
    {
        ActivarCandado();
    }
}
