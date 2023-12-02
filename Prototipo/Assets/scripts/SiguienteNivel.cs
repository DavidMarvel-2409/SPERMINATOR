using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour
{

    public string escena;
    public void Cambio()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(escena);
    }

}
