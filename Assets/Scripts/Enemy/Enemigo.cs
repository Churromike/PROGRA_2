using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{

    private NavMeshAgent agent;

    public Transform player;

    public string cambioDeEscena;
    
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {

        agent.SetDestination(player.position);

    }

    private void OnCollisionEnter(Collision collision) 
    {

        if (collision.gameObject.tag == "Player")
        {
            PlayerKill();
        }

    }

    void PlayerKill()
    {

        AudioManager.instance.PlaySound("Muerte");
        AudioManager.instance.StopSound("Nivel");
        GameManager.instance.engranajes = 0;
        SceneManager.LoadScene(cambioDeEscena);
        AudioManager.instance.PlaySound("Nivel");

    }

}
