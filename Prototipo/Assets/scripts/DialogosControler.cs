using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogosControler : MonoBehaviour
{

    public string[] Dialogo;
    public TextMeshProUGUI texto;
    private int index_text = 0;
    public GameObject pantalla_dialogo;
    public GameObject cara2;

    void Start()
    {
        texto.text = Dialogo[index_text];
    }


    void Update()
    {
        texto.text = Dialogo[index_text];
    }

    public void cambiar_dialogo()
    {
        if (index_text < Dialogo.Length - 1)
        {
            index_text++;
        }
        else
        {
            Time.timeScale = 1;
            pantalla_dialogo.SetActive(false);
        }
        if (index_text ==  Dialogo.Length - 1)
        {
            cara2.SetActive(true);
        }
    }
}
