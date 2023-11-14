using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_general : MonoBehaviour
{
    public GameObject Spawner;
    public GameObject Inicio_oleada;
    public GameObject Player1;
    public GameObject Ovulo;

    private void Start()
    {

    }
    private void Update()
    {
        if (Vector3.Distance(Player1.transform.position, Ovulo.transform.position) < 120)
        {
            Spawner.GetComponent<creadorEnemigos>().comienza = true;
            Inicio_oleada.SetActive(true);
            Inicio_oleada.GetComponent<Barra_Oleada>().IniciaOleada = true;
        }
    }
}
