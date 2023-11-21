using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Script_Cola : MonoBehaviour
{
    private float time;
    void Start()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.2f)
        {
            time = 0;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
