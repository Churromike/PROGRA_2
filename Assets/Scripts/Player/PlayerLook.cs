using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    #region VariablesDeLaCamara

    private Transform player;

    private float mouseX;
    private float mouseY;

    public float mouseXSense;
    public float mouseYSense;

    private float xRotate = 0;

    #endregion


    void Start()
    {       

        player = transform.parent;

        Cursor.lockState = CursorLockMode.Locked;

    }
 
    void Update()
    {

        MouseMouvement();

    }

    void MouseMouvement()
    {

        xRotate -= mouseY;

        xRotate = Mathf.Clamp(xRotate, -90, 90);

        mouseX = Input.GetAxis("Mouse X") * mouseXSense * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseYSense * Time.deltaTime;

        player.Rotate(Vector3.up * mouseX);

        transform.localRotation = Quaternion.Euler(xRotate, 0, 0);

    }

}
