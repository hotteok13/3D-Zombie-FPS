using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] bool contidion = false;
    [SerializeField] GameObject[] lightEffect;

    public void LightSetting(int number)
    {
        contidion = !contidion;
        lightEffect[number].SetActive(contidion);
    }
}
