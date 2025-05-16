using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarMovementNormal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IChangeableMovement>() != null)
        {
            var player = other.GetComponent<IChangeableMovement>();
            IMovimientos movement = player.GetMovement();
            float _speed = player.GetSpeed();
            float _speedmulti = player.GetSpeedmulti();
            Transform _transform = player.GetTransform();
            player.Change(new NormalMovement(_transform, _speed));
        }
    }
}
