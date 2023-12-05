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
    public GameObject panel_pausa;

    public GameObject Panel_Win;

    public bool Menu_pausa;
    

    private void Start()
    {
        Menu_pausa = false;
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

        if (Inicio_oleada.GetComponent<Barra_Oleada>().tiempo <= 0.1)
        {
            Time.timeScale = 0;
            Panel_Win.SetActive(true);
            //SceneManager.LoadScene("finalscene");
        }

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Menu_pausa = false;
            }
            else
            {
                Time.timeScale = 0;
                Menu_pausa = true;
            }
        }
        if (Menu_pausa == true)
        {
            panel_pausa.SetActive(true);
        }
        else
        {
            panel_pausa.SetActive(false);
        }
    }
}
