using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{

    public string cambioDeEscena;

    private void Start()
    {

        AudioManager.instance.PlaySound("Creditos");

    }

    private void Update()
    {

        ReturnLevel();

    }

    void ReturnLevel()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.instance.engranajes = 0;
            AudioManager.instance.StopSound("Creditos");
            AudioManager.instance.PlaySound("Nivel");
            SceneManager.LoadScene(cambioDeEscena);
        }

    }

}
