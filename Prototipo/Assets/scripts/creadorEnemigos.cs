using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creadorEnemigos : MonoBehaviour
{
    public GameObject Player;

    public GameObject[] enemys;
    public GameObject cola;
    public GameObject[] clon;
    public float creationTime;
    public float creationRangeY;
    public float creationRangeX;
    public GameObject ovulo;
    public int radio;
    public int maxAttempts = 100; // N�mero m�ximo de intentos
    private int contador_de_espermios;
    private int contadorEnemigosGeneral;

    public string nivel;

    public GameObject[] Objetivos_1;
    public GameObject[] Objetivos_2;
    public GameObject[] Objetivos_3;
    public GameObject[] Objetivos_4;
    public GameObject[] Objetivos_5;

    public GameObject Barra_oleada;
    private string oleada;

    public TextMeshProUGUI texto;

    public bool comienza;

    public GameObject[] Spawns;

    private float spawn_espera;

    public GameObject[] drops;
    public string[] Nombre_drop;
    private int total_drops;

    public GameObject Boss;
    //public GameObject boss_firepoint;
    public GameObject Boss_clon;
    private bool final_boss;
    private bool final_boss_check;


    private float tiempo_spawn = 3;
    private bool tiempo_spawn_check = false;
    //public int nivel;


    public GameObject controlador_general;


    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.GetActiveScene().buildIndex;
        nivel = SceneManager.GetActiveScene().name;
        //Debug.Log(nivel);
        comienza = false;
        total_drops = drops.Length;
        spawn_espera = 0;
        contador_de_espermios = 0;
        contadorEnemigosGeneral = 0;
        final_boss = false;
        final_boss_check = false;
    }

    // Update is called once per frame
    void Update()
    {
        oleada = Barra_oleada.GetComponent<Barra_Oleada>().texto.text;
        if (comienza == true)
        {
            if (Barra_oleada.GetComponent<Barra_Oleada>().tiempo > 0.1f)
            {
                spawn_espera += Time.deltaTime;
                if (spawn_espera > tiempo_spawn)
                {
                    spawn_espera = 0;
                    switch (selec_spawn())
                    {
                        case 0:
                            CreateEnemies(Spawns[0]);
                            break;
                        case 1:
                            CreateEnemies(Spawns[1]);
                            break;
                        case 2:
                            CreateEnemies(Spawns[2]);
                            break;
                    }
                }
            }
            if (final_boss == true && final_boss_check == false)
            {
                Spawn_boss();
            }

            if (oleada == "Oleada 1" && tiempo_spawn_check == false)
            {
                tiempo_spawn *= 0.6f;
                tiempo_spawn_check = true;
            }
            //InvokeRepeating("CreateEnemies", 2.0f, creationTime);
        }
    }

    public void CreateEnemies(GameObject sSpawn)
    {

        if (nivel == "Nivel 1")
        {
            if (oleada == "Oleada 0" || oleada == "Oleada 1")
            {
                enemys[0].SetActive(true);
                GameObject enemy = Instantiate(enemys[0], sSpawn.transform.position, Quaternion.identity);
                contador_de_espermios += 1;
                contadorEnemigosGeneral += 1;
                texto.text = "Enemigos Totales:" + contadorEnemigosGeneral;
                controlador_general.GetComponent<Controlador_general>().enemigos_en_escena += 1;


                GameObject _cola = Instantiate(cola, sSpawn.transform.position, Quaternion.identity);
                GameObject clon_ = Instantiate(clon[0], new Vector3(sSpawn.transform.position.x,
                                                                    sSpawn.transform.position.y, 0), Quaternion.identity);

                enemy.GetComponent<enemyScript>().Objetivos_1_ = Objetivos_1;
                enemy.GetComponent<enemyScript>().Objetivos_2_ = Objetivos_2;
                enemy.GetComponent<enemyScript>().Objetivos_3_ = Objetivos_3;
                enemy.GetComponent<enemyScript>().Objetivos_4_ = Objetivos_4;
                enemy.GetComponent<enemyScript>().Objetivos_5_ = Objetivos_5;

                enemy.GetComponent<enemyScript>().Ovulo = ovulo;

                if (contador_de_espermios == 15)
                {
                    contador_de_espermios = 0;
                    int i = select_drop();
                    enemy.GetComponent<enemyScript>().drop = drops[i];
                    enemy.GetComponent<enemyScript>().nombre_drop = Nombre_drop[i];
                }
                else
                {
                    enemy.GetComponent<enemyScript>().nombre_drop = "Nada";
                }

                enemy.GetComponent<enemyScript>().Name_meco = "Bob";
                _cola.GetComponent<Script_Cola>().cabeza = enemy;

                int op = Select_Objetive();
                enemy.GetComponent<enemyScript>().Objetivo_Auxiliar = Objetivos_1[op];

                clon_.GetComponent<Clon_Meco>().meco = enemy;

                enemys[0].SetActive(false);
            }
            else if (oleada == "Oleada 2" || oleada == "Oleada 3")
            {
                int x = select_enemy(2);
                enemys[x].SetActive(true);
                GameObject enemy = Instantiate(enemys[x], sSpawn.transform.position, Quaternion.identity);
                contador_de_espermios += 1;
                contadorEnemigosGeneral += 1;
                texto.text = "Enemigos Totales:" + contadorEnemigosGeneral;
                controlador_general.GetComponent<Controlador_general>().enemigos_en_escena += 1;


                GameObject _cola = Instantiate(cola, sSpawn.transform.position, Quaternion.identity);
                GameObject clon_ = Instantiate(clon[x], new Vector3(sSpawn.transform.position.x,
                                                                    sSpawn.transform.position.y, 0), Quaternion.identity);

                enemy.GetComponent<enemyScript>().Objetivos_1_ = Objetivos_1;
                enemy.GetComponent<enemyScript>().Objetivos_2_ = Objetivos_2;
                enemy.GetComponent<enemyScript>().Objetivos_3_ = Objetivos_3;
                enemy.GetComponent<enemyScript>().Objetivos_4_ = Objetivos_4;
                enemy.GetComponent<enemyScript>().Objetivos_5_ = Objetivos_5;

                enemy.GetComponent<enemyScript>().Ovulo = ovulo;

                if (contador_de_espermios == 15)
                {
                    contador_de_espermios = 0;
                    int i = select_drop();
                    enemy.GetComponent<enemyScript>().drop = drops[i];
                    enemy.GetComponent<enemyScript>().nombre_drop = Nombre_drop[i];
                }
                else
                {
                    enemy.GetComponent<enemyScript>().nombre_drop = "Nada";
                }
                switch (x)
                {
                    case 0:
                        enemy.GetComponent<enemyScript>().Name_meco = "Bob";
                        break;
                    case 1:
                        enemy.GetComponent<enemyScript>().Name_meco = "Dash";
                        break;
                }
                _cola.GetComponent<Script_Cola>().cabeza = enemy;

                int op = Select_Objetive();
                enemy.GetComponent<enemyScript>().Objetivo_Auxiliar = Objetivos_1[op];

                clon_.GetComponent<Clon_Meco>().meco = enemy;
                enemys[x].SetActive(false);
            }
        }

        if (nivel == "Nivel 2")
        {
            if (oleada == "Oleada 0" || oleada == "Oleada 1")
            {
                int x = select_enemy(2);
                enemys[x].SetActive(true);
                GameObject enemy = Instantiate(enemys[x], sSpawn.transform.position, Quaternion.identity);
                contador_de_espermios += 1;
                contadorEnemigosGeneral += 1;
                texto.text = "Enemigos Totales:" + contadorEnemigosGeneral;
                controlador_general.GetComponent<Controlador_general>().enemigos_en_escena += 1;


                GameObject _cola = Instantiate(cola, sSpawn.transform.position, Quaternion.identity);
                GameObject clon_ = Instantiate(clon[x], new Vector3(sSpawn.transform.position.x,
                                                                    sSpawn.transform.position.y, 0), Quaternion.identity);

                enemy.GetComponent<enemyScript>().Objetivos_1_ = Objetivos_1;
                enemy.GetComponent<enemyScript>().Objetivos_2_ = Objetivos_2;
                enemy.GetComponent<enemyScript>().Objetivos_3_ = Objetivos_3;
                enemy.GetComponent<enemyScript>().Objetivos_4_ = Objetivos_4;
                enemy.GetComponent<enemyScript>().Objetivos_5_ = Objetivos_5;

                enemy.GetComponent<enemyScript>().Ovulo = ovulo;

                if (contador_de_espermios == 15)
                {
                    contador_de_espermios = 0;
                    int i = select_drop();
                    enemy.GetComponent<enemyScript>().drop = drops[i];
                    enemy.GetComponent<enemyScript>().nombre_drop = Nombre_drop[i];
                }
                else
                {
                    enemy.GetComponent<enemyScript>().nombre_drop = "Nada";
                }
                switch (x)
                {
                    case 0:
                        enemy.GetComponent<enemyScript>().Name_meco = "Bob";
                        break;
                    case 1:
                        enemy.GetComponent<enemyScript>().Name_meco = "Dash";
                        break;
                }
                _cola.GetComponent<Script_Cola>().cabeza = enemy;

                int op = Select_Objetive();
                enemy.GetComponent<enemyScript>().Objetivo_Auxiliar = Objetivos_1[op];

                clon_.GetComponent<Clon_Meco>().meco = enemy;
                enemys[x].SetActive(false);
            }
            else if (oleada == "Oleada 3" || oleada == "Oleada 2")
            {
                int x = select_enemy(3);
                enemys[x].SetActive(true);
                GameObject enemy = Instantiate(enemys[x], sSpawn.transform.position, Quaternion.identity);
                contador_de_espermios += 1;
                contadorEnemigosGeneral += 1;
                texto.text = "Enemigos Totales:" + contadorEnemigosGeneral;
                controlador_general.GetComponent<Controlador_general>().enemigos_en_escena += 1;


                GameObject _cola = Instantiate(cola, sSpawn.transform.position, Quaternion.identity);
                GameObject clon_ = Instantiate(clon[x], new Vector3(sSpawn.transform.position.x,
                                                                    sSpawn.transform.position.y, 0), Quaternion.identity);

                enemy.GetComponent<enemyScript>().Objetivos_1_ = Objetivos_1;
                enemy.GetComponent<enemyScript>().Objetivos_2_ = Objetivos_2;
                enemy.GetComponent<enemyScript>().Objetivos_3_ = Objetivos_3;
                enemy.GetComponent<enemyScript>().Objetivos_4_ = Objetivos_4;
                enemy.GetComponent<enemyScript>().Objetivos_5_ = Objetivos_5;

                enemy.GetComponent<enemyScript>().Ovulo = ovulo;

                if (contador_de_espermios == 15)
                {
                    contador_de_espermios = 0;
                    int i = select_drop();
                    enemy.GetComponent<enemyScript>().drop = drops[i];
                    enemy.GetComponent<enemyScript>().nombre_drop = Nombre_drop[i];
                }
                else
                {
                    enemy.GetComponent<enemyScript>().nombre_drop = "Nada";
                }
                switch (x)
                {
                    case 0:
                        enemy.GetComponent<enemyScript>().Name_meco = "Bob";
                        break;
                    case 1:
                        enemy.GetComponent<enemyScript>().Name_meco = "Dash";
                        break;
                    case 2:
                        enemy.GetComponent<enemyScript>().Name_meco = "Rex";
                        break;
                }
                _cola.GetComponent<Script_Cola>().cabeza = enemy;

                int op = Select_Objetive();
                enemy.GetComponent<enemyScript>().Objetivo_Auxiliar = Objetivos_1[op];

                clon_.GetComponent<Clon_Meco>().meco = enemy;
                enemys[x].SetActive(false);
            }
        }

        if (nivel == "Nivel 3")
        {
            if (oleada == "Oleada 0" || oleada == "Oleada 1")
            {
                int x = select_enemy(3);
                enemys[x].SetActive(true);
                GameObject enemy = Instantiate(enemys[x], sSpawn.transform.position, Quaternion.identity);
                contador_de_espermios += 1;
                contadorEnemigosGeneral += 1;
                texto.text = "Enemigos Totales:" + contadorEnemigosGeneral;
                controlador_general.GetComponent<Controlador_general>().enemigos_en_escena += 1;


                GameObject _cola = Instantiate(cola, sSpawn.transform.position, Quaternion.identity);
                GameObject clon_ = Instantiate(clon[x], new Vector3(sSpawn.transform.position.x,
                                                                    sSpawn.transform.position.y, 0), Quaternion.identity);

                enemy.GetComponent<enemyScript>().Objetivos_1_ = Objetivos_1;
                enemy.GetComponent<enemyScript>().Objetivos_2_ = Objetivos_2;
                enemy.GetComponent<enemyScript>().Objetivos_3_ = Objetivos_3;
                enemy.GetComponent<enemyScript>().Objetivos_4_ = Objetivos_4;
                enemy.GetComponent<enemyScript>().Objetivos_5_ = Objetivos_5;

                enemy.GetComponent<enemyScript>().Ovulo = ovulo;

                if (contador_de_espermios == 15)
                {
                    contador_de_espermios = 0;
                    int i = select_drop();
                    enemy.GetComponent<enemyScript>().drop = drops[i];
                    enemy.GetComponent<enemyScript>().nombre_drop = Nombre_drop[i];
                }
                else
                {
                    enemy.GetComponent<enemyScript>().nombre_drop = "Nada";
                }
                switch (x)
                {
                    case 0:
                        enemy.GetComponent<enemyScript>().Name_meco = "Bob";
                        break;
                    case 1:
                        enemy.GetComponent<enemyScript>().Name_meco = "Dash";
                        break;
                }
                _cola.GetComponent<Script_Cola>().cabeza = enemy;

                int op = Select_Objetive();
                enemy.GetComponent<enemyScript>().Objetivo_Auxiliar = Objetivos_1[op];

                clon_.GetComponent<Clon_Meco>().meco = enemy;
                enemys[x].SetActive(false);
            }
            else if (oleada == "Oleada 3" || oleada == "Oleada 2")
            {
                final_boss = true;
                int x = select_enemy(2);
                enemys[x+1].SetActive(true);
                GameObject enemy = Instantiate(enemys[x+1], sSpawn.transform.position, Quaternion.identity);
                contador_de_espermios += 1;
                contadorEnemigosGeneral += 1;
                texto.text = "Enemigos Totales:" + contadorEnemigosGeneral;
                controlador_general.GetComponent<Controlador_general>().enemigos_en_escena += 1;


                GameObject _cola = Instantiate(cola, sSpawn.transform.position, Quaternion.identity);
                GameObject clon_ = Instantiate(clon[x+1], new Vector3(sSpawn.transform.position.x,
                                                                    sSpawn.transform.position.y, 0), Quaternion.identity);

                enemy.GetComponent<enemyScript>().Objetivos_1_ = Objetivos_1;
                enemy.GetComponent<enemyScript>().Objetivos_2_ = Objetivos_2;
                enemy.GetComponent<enemyScript>().Objetivos_3_ = Objetivos_3;
                enemy.GetComponent<enemyScript>().Objetivos_4_ = Objetivos_4;
                enemy.GetComponent<enemyScript>().Objetivos_5_ = Objetivos_5;

                enemy.GetComponent<enemyScript>().Ovulo = ovulo;

                if (contador_de_espermios == 15)
                {
                    contador_de_espermios = 0;
                    int i = select_drop();
                    enemy.GetComponent<enemyScript>().drop = drops[i];
                    enemy.GetComponent<enemyScript>().nombre_drop = Nombre_drop[i];
                }
                else
                {
                    enemy.GetComponent<enemyScript>().nombre_drop = "Nada";
                }
                switch (x)
                {
                    case 0:
                        enemy.GetComponent<enemyScript>().Name_meco = "Bob";
                        break;
                    case 1:
                        enemy.GetComponent<enemyScript>().Name_meco = "Dash";
                        break;
                    case 2:
                        enemy.GetComponent<enemyScript>().Name_meco = "Rex";
                        break;
                }
                _cola.GetComponent<Script_Cola>().cabeza = enemy;

                int op = Select_Objetive();
                enemy.GetComponent<enemyScript>().Objetivo_Auxiliar = Objetivos_1[op];

                clon_.GetComponent<Clon_Meco>().meco = enemy;
                enemys[x].SetActive(false);

            }
        }


    }

    private int select_drop()
    {
        int i = UnityEngine.Random.Range(0, total_drops-1);
        return i;
    }

    private int selec_spawn()
    {
        int op = UnityEngine.Random.Range(0, 3);
        return op;
    }

    private int Select_Objetive()
    {
        return UnityEngine.Random.Range(0, 3);
    }

    private int select_enemy(int range)
    {
        return UnityEngine.Random.Range(0, range);
    }

    private void Spawn_boss()
    {
        final_boss_check = true;
        GameObject _boss = Instantiate(Boss, Spawns[0].transform.position, Quaternion.identity);
        GameObject _boss_clon = Instantiate(Boss_clon, Spawns[0].transform.position, Quaternion.identity);

        _boss.GetComponent<Jefe>().Player = Player.transform;
        _boss.GetComponent<Jefe>().FPEnemigo = Boss.GetComponent<Jefe>().FPEnemigo;
        _boss_clon.GetComponent<Clon_Sperminator>().Sperminator = _boss;
    }
}