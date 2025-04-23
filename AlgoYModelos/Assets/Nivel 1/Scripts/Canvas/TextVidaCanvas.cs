using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextVidaCanvas : MonoBehaviour, IObserver_
{

    [SerializeField] GameObject _player;

    [SerializeField] TextMeshProUGUI _vidatext;

    private void Awake()
    {
        _vidatext = GetComponent<TextMeshProUGUI>();

        _player = EntitiesManager.Instance.Player;

        if (_player.GetComponent<IObservable_>() != null)
        {
            _player.GetComponent<IObservable_>().Suscribe(this);
        }
    }

    public void Notify(float hp)
    {
        _vidatext.text = "Vida: " + hp;
    }
}
