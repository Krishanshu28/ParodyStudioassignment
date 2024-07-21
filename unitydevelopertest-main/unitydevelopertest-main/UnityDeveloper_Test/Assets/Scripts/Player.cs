using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;
    public float gravityStrength = 9.81f;
    public Camera camera;

    public bool isGrounded;
    private Rigidbody rb;
    private Animator anim;

    [Header("Hologram Things")]
    public GameObject hologramR;
    public GameObject hologramF;
    public GameObject hologramB;
    public GameObject hologramL;
    float roatateSpeed = 1f;
    public Transform hologramHead; 
    public float rotationAngle = 90f;


    public static Player player;

    private void Awake()
    {
        player = this;
    }
    void Start()
    {
        Physics.gravity = Vector3.down * gravityStrength;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        // Movement
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forwardMovement = transform.forward * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + forwardMovement);
            anim.SetBool("Idle", false);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Run", false);
        }

        // Rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.up, 180 * Time.deltaTime);
        }

        Jump();

        //Hologram
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            hologramF.SetActive(true);

            
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            ChangeGravity(transform.forward);
            transform.Rotate(-90f, 0f, 0f);
            hologramF.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            hologramR.SetActive(true);
            
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            ChangeGravity(transform.right);
            transform.Rotate( 0f, 0f,90f);
            //camera.transform.Rotate( 0f, 0f,90f);

            hologramR.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            hologramB.SetActive(true);

            
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            ChangeGravity(-transform.forward);
            transform.Rotate(90f,0f,0f);
            hologramB.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            hologramL.SetActive(true);

           
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            ChangeGravity(-transform.right);
            transform.Rotate(0f, 0f, -90f);
            hologramL.SetActive(false);
        }

    }
    void Jump()
    {
        // Jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        else if (!isGrounded)
        {
            anim.SetBool("Fall", true);
        }

        else if (isGrounded)
        {
            anim.SetBool("Fall", false);
        }
    }

    void ChangeGravity(Vector3 direction)
    {
        //RotatePlayer(direction);
        Physics.gravity = direction * gravityStrength;
    }

    void RotatePlayer(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    


   


}
