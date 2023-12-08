using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : MonoBehaviour
{
    // Start is called before the first frame update
    public float ImpulsePower;
    public float BackPower;
    
    public float stoppingDistance;
    public float retreatDistance;
    
    private float timeBtwShots;
    public float startTimeBtwShots;
    
    public float vida = 100;
    public Transform FPEnemigo;
    public Transform Player;
    public GameObject EBPrefab;

    public GameObject Objetivo;
    public GameObject Objetivo_central;

    Rigidbody2D rb;

    void Start()
    {
        //StartCoroutine(disparar());
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(disparar());

        //Vector3 pos = transform.position;

        //pos += (movement.Player_Instance.transform.position - transform.position).normalized * movespeed * Time.deltaTime;

        //transform.position = pos;

        /*if (transform.position.x < -10f)
        {
            //Destroy(gameObject);
        }*/

        //transform.up = Player.position - transform.position;
        //transform.up = new Vector3(Player.position.x - transform.position.x, Player.transform.position.y - transform.position.y, transform.position.z);

        if (Vector2.Distance(transform.position, Player.position) > stoppingDistance)
        {
            //transform.position = Vector2.MoveTowards(transform.position, Player.position, movespeed * Time.deltaTime);
            rb.AddForce((Player.position - transform.position) * ImpulsePower, ForceMode2D.Impulse);
        }
        
        else if (Vector2.Distance(transform.position, Player.position) < stoppingDistance && Vector2.Distance(transform.position, Player.position) > retreatDistance)
        {
            //transform.position = this.transform.position;
        }
        
        else if (Vector2.Distance(transform.position, Player.position) < retreatDistance)
        {
            //transform.position = Vector2.MoveTowards(transform.position, Player.position, -movespeed * Time.deltaTime);

            rb.AddForce((-Player.position + transform.position) * BackPower, ForceMode2D.Force);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(EBPrefab, FPEnemigo.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D npc)
    {
        if (npc.gameObject.CompareTag("bala"))
        {
            vida -= 5;
            if (vida<=0)
            {
            Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            vida -= 5;
            if (vida<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
