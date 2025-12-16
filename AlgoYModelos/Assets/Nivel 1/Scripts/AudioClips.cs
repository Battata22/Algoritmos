using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClips : MonoBehaviour
{

    public static AudioClips instance;
    private void Awake()
    {
        instance = this;
    }

    public AudioClip[] _madera;

}
