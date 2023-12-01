using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    [SerializeField] float speed;
        
    public float varVida;

    public float espera;
    public AudioSource Sonido_Disparo;

    public int rest;
    float horizontalM;
    float verticalM;
    public float velocidadRotacion;
    float angulo;
    Vector2 movimiento;
    bool shoot;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootCooldown;

    void Start()
    {
        varVida = 100;
        Sonido_Disparo=GetComponent<AudioSource>();
    }


    void Update()
    {
        horizontalM = Input.GetAxisRaw("Horizontal");
        verticalM = Input.GetAxisRaw("Vertical");
        shoot = Input.GetKey(KeyCode.Space);

        movimiento = new Vector2(horizontalM, verticalM);
        movimiento.Normalize();
        transform.Translate(movimiento * speed * Time.deltaTime, Space.World);

        if (movimiento != Vector2.zero)
        {
            angulo = Mathf.Atan2(movimiento.y, movimiento.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angulo), velocidadRotacion * Time.deltaTime);
        }

        if (shoot)
        {
            Shoot();
        }

        if (varVida > 100)
        {
            varVida = 100;
        }
        //scoretext.text = "Enemigos derrotados:" + score;
        //restantes.text = "Derrota esta candidad de enemigos:" + rest;
        
    }

    void Shoot()
    {
        // Verificar si ha pasado suficiente tiempo desde el último disparo
        if (Time.time >= shootCooldown)
        {
            // Calcular la rotación de la bala basada en la rotación del jugador
            Quaternion bulletRotation = firePoint.rotation;

            // Instanciar la bala y ajustar su rotación
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletRotation);

            
            // Reiniciar el temporizador de disparo
            shootCooldown = Time.time + espera; // Ajusta el valor según la velocidad de disparo deseada
            Sonido_Disparo.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D npc)
    {
        if (npc.gameObject.CompareTag("enemigo"))
        {
            npc.GetComponent<enemyScript>().eliminar_cola();
            Destroy(npc.gameObject);
            
        }
        if (npc.gameObject.CompareTag("vidapower"))
        {
            varVida += 20;
        }
    }

    private void OnCollisionEnter2D(Collision2D npc)
    {
        if(npc.gameObject.CompareTag("enemigo"))
        {

            Destroy(npc.gameObject);
            //npc.collider.GetComponent<enemyScript>().eliminar_cola();
            varVida -= 10;
        }
        if (npc.gameObject.CompareTag("vidapower"))
        {
            varVida += 20;
        }
        /*if (npc.gameObject.CompareTag("shootpower"))
        {
            espera = 0.1f;
        }
        if (npc.gameObject.CompareTag("speedpower"))
        {
            speed += 50;
        }*/
    }
}
