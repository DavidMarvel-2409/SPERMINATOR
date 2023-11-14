using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Oleada : MonoBehaviour
{

    public float tiempo;
    public float tiempoTotal;
    public Image oleada;

    void Start()
    {

    }

    void Update()
    {
        tiempo -= 0.001f;
        oleada.fillAmount = tiempo / tiempoTotal;
    }
}
