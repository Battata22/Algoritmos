using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLife : MonoBehaviour, IObserver
{
    [SerializeField] GameObject observer;
    [SerializeField] Image imagen;


    private void Awake()
    {
        
        if(observer.GetComponent<ITargetable>() != null)
        {
            observer.GetComponent<ITargetable>().Suscribe(this);
        }
    }
    public void Notify(float hp, float maxHp)
    {
        imagen.fillAmount = hp / maxHp;
        print("refresh de vida = " + hp / maxHp);
    }

    private void OnDestroy()
    {
        if (observer.GetComponent<ITargetable>() != null)
        {
            observer.GetComponent<ITargetable>().Unsuscribe(this);
        }
    }

}
