using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerGotas : MonoBehaviour
{

    [SerializeField] AudioSource _sources;
    [SerializeField] AudioClip _clip;
    [SerializeField] bool dos;
    
    void Start()
    {
        StartCoroutine(StartAudios());
    }

    IEnumerator StartAudios()
    {
        _sources.clip = _clip;

        if (dos)
        {
            yield return new WaitForSeconds(1.7f);

            _sources.Play();
        }
        else
        {
            _sources.Play();
        }
    }
}
