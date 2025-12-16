using UnityEngine;

[RequireComponent (typeof(AudioSource))]

public class Rompible : MonoBehaviour, IDamageable
{
    [SerializeField] bool _seRompeDeUna = false, madera, patasPuente;
    [SerializeField] ParticleSystem[] _part;
    [SerializeField] AudioSource _audioSource;

    private void Start()
    {
        _part = GetComponentsInChildren<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();

        _audioSource.volume = 0.5f;
    }
    public void TakeDamage(float a)
    {
        if (_seRompeDeUna)
        {
            //anim particulas
            if (!madera)
            {
                foreach (var part in _part)
                {
                    part.Play();
                }

                if (patasPuente)
                {
                    GetComponentInParent<Punete>().Rotos++;
                }
            }

            _audioSource.PlayOneShot(PlaySound());

            var flechas = GetComponentsInChildren<Jaja>();

            foreach (var flecha in flechas)
            {
                flecha.gameObject.SetActive(false);
            }

            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            //Destroy(gameObject);
        }
    }

    AudioClip PlaySound()
    {
        var r = Random.Range(0, AudioClips.instance._madera.Length);
        return AudioClips.instance._madera[r];
    }

}
