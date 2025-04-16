using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaivour : MonoBehaviour
{
    
    void Start()
    {
        EntitiesManager.Instance.Player = gameObject;
    }

}
