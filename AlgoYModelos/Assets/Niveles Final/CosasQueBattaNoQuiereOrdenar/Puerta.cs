using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Puerta : MonoBehaviour
{

    [SerializeField] AudioSource _audioSource;
    [SerializeField] Animator _anim;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
    }

    public void ActivateDoor()
    {
        _anim.SetTrigger("Abrir");

        _audioSource.clip = AudioClips.instance.OpenDoor;
        _audioSource.Play();
    }
}
