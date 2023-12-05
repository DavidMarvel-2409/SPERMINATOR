using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Velocimetro : MonoBehaviour
{
    private Quaternion original;
    private float angle;
    private int direct;

    void Start()
    {
        original = transform.rotation;
        angle = transform.rotation.z;
    }


    void Update()
    {
        Invoke("rotar(angle)", 5);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void rotar(float a)
    {
        a += 10 * direct * Time.deltaTime;

        if (a < angle - 10)
        {
            a = angle - 10;
            direct *= -1;
        }else if (a > angle + 10)
        {
            a = angle + 10;
            direct *= -1;
        }
        angle = a;
    }
}
