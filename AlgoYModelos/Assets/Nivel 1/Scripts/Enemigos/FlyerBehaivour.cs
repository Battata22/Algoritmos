using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerBehaivour : Enemy
{
    [SerializeField] float _maxHp;
    [SerializeField] float _speed;
    [SerializeField] float _damage;
    
    protected override void Start()
    {
        base.Start();
        Recicle();
    }


    protected override void Update()
    {
        base.Update();

    }

    void Recicle()
    {
        //_target = EntitiesManager.Instance.Player;

        _hp = _maxHp;

    }

}
