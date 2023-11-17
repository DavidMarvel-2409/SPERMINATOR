using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_PowerUp : MonoBehaviour
{
    public bool coliciono = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        coliciono = true;
        Invoke("volver", 0.5f);
    }
    private void volver()
    {
        coliciono = false;
    }
}
