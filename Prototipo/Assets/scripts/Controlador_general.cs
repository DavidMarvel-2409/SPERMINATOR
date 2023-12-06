using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Controlador_general : MonoBehaviour
{
    public GameObject Spawner;
    public GameObject Inicio_oleada;
    public GameObject Player1;
    public GameObject Ovulo;
    public GameObject panel_pausa;
    private string nivel;

    public GameObject Panel_Win;
    public GameObject Panel_Lose;
    public GameObject precentacion_jefe;

    public bool Menu_pausa;

    public int enemigos_en_escena;
    private bool precentacion_check = false;

    public GameObject spawn_player;

    public GameObject mapa;

    public TextMeshProUGUI oleada_text;


    private void Start()
    {
        nivel = SceneManager.GetActiveScene().name;
        Menu_pausa = false;
        enemigos_en_escena = 0;
        if (spawn_player.activeInHierarchy == true)
        {
            Player1.transform.position = spawn_player.transform.position;
        }
        setear_objetos_en_mapa("" + SceneManager.GetActiveScene().name);
        //Debug.Log("" + SceneManager.GetActiveScene().name);
    }
    private void Update()
    {

        if (nivel == "Nivel 3" && oleada_text.text == "Oleada 3" && precentacion_check == false)
        {
            precentacion_check = true;
            Time.timeScale = 0;
            spawn_player.GetComponent<creadorEnemigos>().final_boss = true;
            precentacion_jefe.SetActive(true);
        }

        if (Vector3.Distance(Player1.transform.position, Ovulo.transform.position) < 120)
        {
            Spawner.GetComponent<creadorEnemigos>().comienza = true;
            Inicio_oleada.SetActive(true);
            Inicio_oleada.GetComponent<Barra_Oleada>().IniciaOleada = true;
        }
        
        if ( Ovulo.GetComponent<uterScript>().vidaUter <= 0 || Player1.GetComponent<movement>().varVida == 0)
        {
            //SceneManager.LoadScene("Perdida");
            Time.timeScale = 0;
            Panel_Lose.SetActive(true);
        }


        if (Inicio_oleada.GetComponent<Barra_Oleada>().tiempo <= 0.1 
            && enemigos_en_escena - Player1.GetComponent<movement>().Enemigos_muertos == 0)
        {
            Panel_Win.SetActive(true);
            Time.timeScale = 0;
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

    private void setear_objetos_en_mapa(string nivel)
    {
        switch(nivel)
        {
            case "Nivel 1":
                //lo deja todo tal cual esta
                break;
            case "Nivel 2":
                a_la_Derecha();
                break;
            case "Nivel 3":
                int op = op_random(2);
                switch (op)
                {
                    case 0:
                        //eligio la derecha por lo que se queda igual
                        break;
                    case 1:
                        a_la_Derecha();
                        break;
                }
                break;
        }
    }

    private void a_la_Derecha()
    {
        Ovulo.GetComponent<Transform>().position = new Vector3(Ovulo.GetComponent<Transform>().position.x + distancia_reflejo(mapa, Ovulo),
                                                                Ovulo.GetComponent<Transform>().position.y,
                                                                Ovulo.GetComponent<Transform>().position.z);

        //objetivos
        int arr_obj_1;
        arr_obj_1 = Spawner.GetComponent<creadorEnemigos>().Objetivos_1.Length;
        for (int i = 0; i < arr_obj_1; i++)
        {
            Spawner.GetComponent<creadorEnemigos>().Objetivos_1[i].GetComponent<Transform>().position =
                new Vector3(Spawner.GetComponent<creadorEnemigos>().Objetivos_1[i].GetComponent<Transform>().position.x + distancia_reflejo(mapa, Spawner.GetComponent<creadorEnemigos>().Objetivos_1[i]),
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_1[i].GetComponent<Transform>().position.y,
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_1[i].GetComponent<Transform>().position.z);
        }
        int arr_obj_2;
        arr_obj_2 = Spawner.GetComponent<creadorEnemigos>().Objetivos_2.Length;
        for (int i = 0; i < arr_obj_2; i++)
        {
            Spawner.GetComponent<creadorEnemigos>().Objetivos_2[i].GetComponent<Transform>().position =
                new Vector3(Spawner.GetComponent<creadorEnemigos>().Objetivos_2[i].GetComponent<Transform>().position.x + distancia_reflejo(mapa, Spawner.GetComponent<creadorEnemigos>().Objetivos_2[i]),
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_2[i].GetComponent<Transform>().position.y,
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_2[i].GetComponent<Transform>().position.z);
        }
        int arr_obj_3;
        arr_obj_3 = Spawner.GetComponent<creadorEnemigos>().Objetivos_3.Length;
        for (int i = 0; i < arr_obj_3; i++)
        {
            Spawner.GetComponent<creadorEnemigos>().Objetivos_3[i].GetComponent<Transform>().position =
                new Vector3(Spawner.GetComponent<creadorEnemigos>().Objetivos_3[i].GetComponent<Transform>().position.x + distancia_reflejo(mapa, Spawner.GetComponent<creadorEnemigos>().Objetivos_3[i]),
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_3[i].GetComponent<Transform>().position.y,
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_3[i].GetComponent<Transform>().position.z);
        }
        int arr_obj_4;
        arr_obj_4 = Spawner.GetComponent<creadorEnemigos>().Objetivos_4.Length;
        for (int i = 0; i < arr_obj_4; i++)
        {
            Spawner.GetComponent<creadorEnemigos>().Objetivos_4[i].GetComponent<Transform>().position =
                new Vector3(Spawner.GetComponent<creadorEnemigos>().Objetivos_4[i].GetComponent<Transform>().position.x + distancia_reflejo(mapa, Spawner.GetComponent<creadorEnemigos>().Objetivos_4[i]),
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_4[i].GetComponent<Transform>().position.y,
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_4[i].GetComponent<Transform>().position.z);
        }
        int arr_obj_5;
        arr_obj_5 = Spawner.GetComponent<creadorEnemigos>().Objetivos_5.Length;
        for (int i = 0; i < arr_obj_5; i++)
        {
            Spawner.GetComponent<creadorEnemigos>().Objetivos_5[i].GetComponent<Transform>().position =
                new Vector3(Spawner.GetComponent<creadorEnemigos>().Objetivos_5[i].GetComponent<Transform>().position.x + distancia_reflejo(mapa, Spawner.GetComponent<creadorEnemigos>().Objetivos_5[i]),
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_5[i].GetComponent<Transform>().position.y,
                            Spawner.GetComponent<creadorEnemigos>().Objetivos_5[i].GetComponent<Transform>().position.z);
        }


    }

    private float distancia_reflejo(GameObject objeto1, GameObject objeto2)
    {
        float distancia_ = (objeto1.transform.position.x - objeto2.transform.position.x) * 2;

        return distancia_;
    }

    private int op_random(int num)
    {
        return UnityEngine.Random.Range(0, num);
    }
}
