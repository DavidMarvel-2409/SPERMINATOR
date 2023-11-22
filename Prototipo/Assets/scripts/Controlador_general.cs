using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        
        if ( Ovulo.GetComponent<uterScript>().vidaUter <= 0 || Player1.GetComponent<movement>().varVida == 0)
        {
            SceneManager.LoadScene("Perdida");
        }

        if (Inicio_oleada.GetComponent<Barra_Oleada>().tiempo <= 1)
        {
            SceneManager.LoadScene("finalscene");
        }

    }
}
