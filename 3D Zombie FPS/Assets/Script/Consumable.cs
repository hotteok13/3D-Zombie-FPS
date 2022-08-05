using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] Item item;

    private void Start()
    {
        Debug.Log(item.name);
        Debug.Log(item.health);
    }
}
