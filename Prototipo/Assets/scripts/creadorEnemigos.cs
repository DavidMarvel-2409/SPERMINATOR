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
    private Vector3 coor_ovulo;
    public int radio;
    public int maxAttempts = 100; // Número máximo de intentos

    public GameObject ob1;
    public GameObject ob1_2;
    public GameObject ob1_3;
    public GameObject ob2;
    public GameObject ob2_2;
    public GameObject ob2_3;
    public GameObject ob3;
    public GameObject ob3_2;
    public GameObject ob3_3;
    public GameObject ob4;
    public GameObject ob4_2;
    public GameObject ob4_3;
    public GameObject ob5;
    public GameObject ob5_2;
    public GameObject ob5_3;

    public bool comienza;

    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;

    private float spawn_espera;

    // Start is called before the first frame update
    void Start()
    {
        comienza = false;

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
                        CreateEnemies(Spawn1);
                    break;
                    case 1:
                        CreateEnemies(Spawn2);
                    break;
                    case 2:
                        CreateEnemies(Spawn3);
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
        enemy.GetComponent<enemyScript>().setObjetivos(ob1, ob2, ob3, ob4, ob5, ovulo, ob1_2, ob1_3, ob2_2, ob2_3, ob3_2, ob3_3, ob4_2, ob4_3, ob5_2, ob5_3);
        enemys.SetActive(false);
    }

    private int selec_spawn()
    {
        int op = Random.Range(0, 3);
        return op;
    }

}