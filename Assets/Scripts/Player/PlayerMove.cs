using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    #region VariablesDelPlayer

    private float movX;
    private float movZ;

    [SerializeField] 
    private float speed;
    public float jumpSpeed;

    private CharacterController controller;

    private Vector3 velocity;

    public float gravity = -9.81f;

    public bool isGrounded;
    public Transform groundCheck;
    public float radius;
    public LayerMask whatIsGround;

    #endregion

    private void Start()
    {

        AudioManager.instance.PlaySound("Nivel");
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {

        PlayerMovement();

    }

    void PlayerMovement()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, radius, whatIsGround);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            AudioManager.instance.PlaySound("Salto");
            velocity.y = Mathf.Sqrt(jumpSpeed * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 move = transform.right * speed * movX + transform.forward * speed * movZ;

        controller.Move(move * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

    }

}
