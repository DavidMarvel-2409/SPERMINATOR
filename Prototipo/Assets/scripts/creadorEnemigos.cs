using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creadorEnemigos : MonoBehaviour
{
    public GameObject enemys;
    public float creationTime;
    public float creationRangeY;
    public float creationRangeX;
    public GameObject ovulo;
    public int radio;
    public int maxAttempts = 100; // Número máximo de intentos

    public GameObject[] Objetinos_1;
    public GameObject[] Objetinos_2;
    public GameObject[] Objetinos_3;
    public GameObject[] Objetinos_4;
    public GameObject[] Objetinos_5;

    public bool comienza;

    public GameObject[] Spawns;

    private float spawn_espera;

    public GameObject[] drops;
    public string[] Nombre_drop;
    private int total_drops;

    // Start is called before the first frame update
    void Start()
    {
        comienza = false;
        total_drops = drops.Length;
        spawn_espera = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (comienza == true)
        {
            spawn_espera += Time.deltaTime;
            if (spawn_espera > 2)
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
            //InvokeRepeating("CreateEnemies", 2.0f, creationTime);
        }
    }

    public void CreateEnemies(GameObject sSpawn)
    {

        enemys.SetActive(true);
        GameObject enemy = Instantiate(enemys, sSpawn.transform.position, Quaternion.identity);
        int i = select_drop();
        enemy.GetComponent<enemyScript>().setObjetivos(Objetinos_1[0], Objetinos_2[0], Objetinos_3[0], Objetinos_4[0], Objetinos_5[0], ovulo,
                                                        Objetinos_1[1], Objetinos_1[2], Objetinos_2[1], Objetinos_2[2],
                                                        Objetinos_3[1], Objetinos_3[2], Objetinos_4[1], Objetinos_4[2],
                                                        Objetinos_5[1], Objetinos_5[2], drops[i], Nombre_drop[i]);
        enemys.SetActive(false);
    }

    private int select_drop()
    {
        int i = Random.Range(0, total_drops);
        return i;
    }

    private int selec_spawn()
    {
        int op = Random.Range(0, 3);
        return op;
    }

}