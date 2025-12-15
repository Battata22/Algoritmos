using UnityEngine;

public class Rompible : MonoBehaviour, IDamageable
{
    [SerializeField] bool _seRompeDeUna = false, madera;
    [SerializeField] ParticleSystem _part;

    private void Start()
    {
        _part = GetComponentInChildren<ParticleSystem>();
    }
    public void TakeDamage(float a)
    {
        if (_seRompeDeUna)
        {
            //anim particulas
            if (!madera)
                _part.Play();

            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            //Destroy(gameObject);
        }
    }

}
