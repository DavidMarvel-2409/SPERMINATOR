using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Oleada : MonoBehaviour
{

    public float tiempo;
    public float tiempoTotal;
    public Image oleada;
    public bool IniciaOleada;

    void Start()
    {
        IniciaOleada = false;
    }

    void Update()
    {
        if (IniciaOleada)
        {
            tiempo -= 0.001f;
            oleada.fillAmount = tiempo / tiempoTotal;
        }
        
    }
}
