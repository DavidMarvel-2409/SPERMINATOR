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
    public GameObject ob2;
    public GameObject ob3;
    public GameObject ob4;
    public GameObject ob5;

    public bool comienza;

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
                CreateEnemies();
            }
            //InvokeRepeating("CreateEnemies", 2.0f, creationTime);
        }
    }

    public void CreateEnemies()
    {

        enemys.SetActive(true);
        GameObject enemy = Instantiate(enemys, transform.position, Quaternion.identity);
        enemy.GetComponent<enemyScript>().setObjetivos(ob1, ob2, ob3, ob4, ob5, ovulo);
        enemys.SetActive(false);
    }
}