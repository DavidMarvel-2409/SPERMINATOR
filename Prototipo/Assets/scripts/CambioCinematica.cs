using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioCinematica : MonoBehaviour
{
    private float time;
    new public string name;
    public float speed;
    public GameObject tipa;
    public GameObject tipo;
    private Vector3 tipo_coor;
    private Vector3 tipa_coor;
    private void Start()
    {
        time = 0;
        Debug.Log(tipa.transform);
        Debug.Log(tipo.transform);
        tipa_coor = tipa.transform.position;
        tipo_coor = tipo.transform.position;
        tipo_coor.y = tipa_coor.y;
        
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time < 3)
        {
            mover();
            //cambio();
        }
        if (time > 4)
        {
            cambio();
        }
        tipo.transform.position = tipo_coor;
        tipa.transform.position = tipa_coor;
    }
    private void mover()
    {
        tipa_coor.x += speed * Time.deltaTime;
        tipo_coor.x -= speed * Time.deltaTime;
    }
    private void cambio()
    {
        SceneManager.LoadScene(name);
    }
}
