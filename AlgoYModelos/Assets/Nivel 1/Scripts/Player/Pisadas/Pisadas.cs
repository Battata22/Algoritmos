using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Pisadas : MonoBehaviour
{
    [SerializeField] GameObject _pisadasPrefab;
    [SerializeField] LayerMask _layerPiso;
    [SerializeField] float _tiempoPorPisada;
    [SerializeField] float _duracionHuella;
    [SerializeField] float _distHuellaDelPiso;
    [SerializeField] Material _der, _izq;
    float _waitPisadas;

    bool _lastWasRight = false;

    float _xAxis, _zAxis;

    void Update()
    {
        _waitPisadas += Time.deltaTime;

        _xAxis = Input.GetAxisRaw("Horizontal");
        _zAxis = Input.GetAxisRaw("Vertical");

        if (_xAxis != 0 || _zAxis != 0)
        {
            SpawnPisadas();
        }
    }

    public void SpawnPisadas()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1.5f, _layerPiso) && _waitPisadas >= _tiempoPorPisada)
        {
            var pisada = Instantiate(_pisadasPrefab, new Vector3(hit.point.x, hit.point.y + _distHuellaDelPiso, hit.point.z), transform.rotation);
            if(_lastWasRight == true)
            {
                pisada.GetComponent<Renderer>().material = _izq;
                _lastWasRight = false;
            }
            else
            {
                pisada.GetComponent<Renderer>().material = _der;
                _lastWasRight = true;
            }
                Destroy(pisada, _duracionHuella);

            _waitPisadas = 0;
        }
    }
}
