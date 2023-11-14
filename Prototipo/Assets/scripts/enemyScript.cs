using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    Vector2 movimiento;
    float angulo;
    public float velocidadRotacion;

    public GameObject Ovulo;
    
    public GameObject Objetivo1;
    public GameObject Objetivo2;
    public GameObject Objetivo3;
    public GameObject Objetivo3_2;
    public GameObject Objetivo3_3;
    public GameObject Objetivo4;
    public GameObject Objetivo4_2;
    public GameObject Objetivo4_3;
    public GameObject Objetivo5;
    public GameObject Objetivo5_2;
    public GameObject Objetivo5_3;

    private GameObject Objetivo_Auxiliar;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Objetivo1.transform);
        //Debug.Log(Objetivo2.transform);
        //Debug.Log(Objetivo3.transform);
        //Debug.Log(Objetivo4.transform);
        //Debug.Log(Ovulo.transform);
        
    }
    public void setObjetivos(GameObject a1, GameObject a2, GameObject a3, GameObject a4, GameObject a5, GameObject ov, GameObject a3_2, GameObject a3_3, GameObject a4_2, GameObject a4_3, GameObject a5_2, GameObject a5_3)
    {
        Objetivo1 = a1;
        Objetivo2 = a2;
        Objetivo3 = a3;
        Objetivo4 = a4;
        Objetivo5 = a5;

        Objetivo3_2 = a3_2;
        Objetivo3_3 = a3_3;
        Objetivo4_2 = a4_2;
        Objetivo4_3 = a4_3;
        Objetivo5_2 = a5_2;
        Objetivo5_3 = a5_3;

        Objetivo_Auxiliar = a1;

        Ovulo = ov;
    }
    // Update is called once per frame
    void Update()
    {
        Movimiento(Objetivo_Auxiliar);
        cambiar_angulo(Objetivo_Auxiliar);

        if (distancia_objetivo(Objetivo_Auxiliar) < 10)
        {
            Cambio_de_objetivo(Objetivo_Auxiliar);
        }

    }

    private float distancia_objetivo(GameObject _Objetivo)
    {
        float dist;
        dist = Vector3.Distance(transform.position, _Objetivo.transform.position);
        return dist;
    }


    private void Movimiento(GameObject Objetivo_)
    {
        //transform.position = Vector3.MoveTowards(transform.position, Objetivo_.transform.position, moveSpeed * Time.deltaTime);
        transform.position += (Objetivo_.transform.position- transform.position).normalized* moveSpeed * Time.deltaTime;
    }

    private void cambiar_angulo(GameObject Objetivo_)
    {
        float anguloR = Mathf.Atan2(transform.position.y - Objetivo_.transform.position.y, transform.position.x - Objetivo_.transform.position.x);
        float anguloG = (180 / Mathf.PI) * anguloR - 90;

        transform.rotation = Quaternion.Euler(0, 0, anguloG - 180);
    }

    private void Cambio_de_objetivo(GameObject _Actual)
    {
        if (_Actual == Objetivo1)
        {
            Objetivo_Auxiliar = Objetivo2;
        }
        else if (_Actual == Objetivo2)
        {
            int op = select_op();
            Debug.Log(op);
            switch (select_op())
            {
                case 0:
                    Objetivo_Auxiliar = Objetivo3;
                    break;
                case 1:
                    Objetivo_Auxiliar = Objetivo3_2;
                    break;
                case 2:
                    Objetivo_Auxiliar = Objetivo3_3;
                    break;
            }
        }
        else if (_Actual == Objetivo3 || _Actual == Objetivo3_2 || _Actual == Objetivo3_3)
        {
            switch (select_op())
            {
                case 0:
                    Objetivo_Auxiliar = Objetivo4;
                    break;
                case 1:
                    Objetivo_Auxiliar = Objetivo4_2;
                    break;
                case 2:
                    Objetivo_Auxiliar = Objetivo4_3;
                    break;
            }
        }
        else if (_Actual == Objetivo4 || _Actual == Objetivo4_2 || _Actual == Objetivo4_3)
        {
            switch (select_op())
            {
                case 0:
                    Objetivo_Auxiliar = Objetivo5;
                    break;
                case 1:
                    Objetivo_Auxiliar = Objetivo5_2;
                    break;
                case 2:
                    Objetivo_Auxiliar = Objetivo5_3;
                    break;
            }
        }
        else if (_Actual == Objetivo5 || _Actual == Objetivo5_2 || _Actual == Objetivo5_3)
        {
            Objetivo_Auxiliar = Ovulo;
        }
    }

    private void OnCollisionEnter2D(Collision2D uterocolision)
    {
        if (uterocolision.collider.CompareTag("UterPoint"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D uterocolisiondos)
    {
        if (uterocolisiondos.CompareTag("UterPoint"))
        {
            Destroy(this.gameObject);
        }
    }

    private int select_op()
    {
        int op = Random.Range(0, 3);
        return op;
    }
}

