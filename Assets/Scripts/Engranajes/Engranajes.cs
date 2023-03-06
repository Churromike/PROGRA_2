using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engranajes : MonoBehaviour
{

    #region VariablesDeLosEngranajes

    public string cambioDeEscena;

    public float radioDelPlayer;

    public int valorDelEngranaje;

    public bool check;
    public bool check2;

    public Transform particulasDeEngranajes;

    public LayerMask whatIsPlayer;

    #endregion

    private void OnMouseOver()
    {

        check = true;

    }

    private void OnMouseExit()
    {

        check = false;

    }

    void Update()
    {

        PickUpEngranajes();

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, radioDelPlayer);

    }

    void PickUpEngranajes()
    {

        if (Input.GetKeyDown(KeyCode.E) && check && check2)
        {
            AudioManager.instance.PlaySound("Engranaje");
            Instantiate(particulasDeEngranajes, transform.position, transform.rotation);
            GameManager.instance.engranajes += valorDelEngranaje;
            Destroy(this.gameObject);
            if (GameManager.instance.engranajes == 10)
            {
                AudioManager.instance.StopSound("Nivel");
                SceneManager.LoadScene(cambioDeEscena);
            }
        }

        check2 = Physics.CheckSphere(transform.position, radioDelPlayer, whatIsPlayer);

    }

}
