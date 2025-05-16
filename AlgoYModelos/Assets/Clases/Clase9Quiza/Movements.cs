using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class Movements : MonoBehaviour
{

}

public class NormalMovement : IMovimientos
{
    Transform _transform;
    float _speed;
    float _xAxis, _zAxis;
    public NormalMovement(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }
    public void FakeUpdate()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");
        _transform.position += (new Vector3(_xAxis, 0, _zAxis) * _speed * Time.deltaTime);
    }
}

public class FastMovement : IMovimientos
{
    Transform _transform;
    float _speed, _speedmulti;
    float _xAxis, _zAxis;
    public FastMovement(Transform transform, float speed, float speedmulti)
    {
        _transform = transform;
        _speed = speed;
        _speedmulti = speedmulti;
    }
    public void FakeUpdate()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");
        _transform.position += (new Vector3(_xAxis, 0, _zAxis) * _speed * Time.deltaTime * _speedmulti);
    }
}

public class SuperFastMovement : IMovimientos
{
    Transform _transform;
    float _speed;
    float _xAxis, _zAxis;
    public SuperFastMovement(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }
    public void FakeUpdate()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");
        _transform.position += (new Vector3(_xAxis, 0, _zAxis) * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Salte");
        }
    }
}

public interface IMovimientos
{
    public void FakeUpdate();
}


