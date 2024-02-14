using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 8f, gravity = -9.81f, groundDistance = 0.4f, jumpHeight = 1f;
    bool isTouching;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Rigidbody rb;
    
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isTouching = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isTouching && velocity.y < 0)
            velocity.y = -2f;

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 move = transform.right * hor + transform.forward * ver;

        characterController.Move(move * Time.deltaTime * speed);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift))
            speed = 15f;
        else
            speed = 8f;
        
        Debug.Log(speed);
        if(Input.GetKeyDown(KeyCode.Space) && isTouching)
            velocity.y = Mathf.Sqrt(-2*gravity*jumpHeight);
        
        if(Input.GetKey(KeyCode.LeftControl)){
            transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
            rb.AddForce(new Vector3(0, -0.5f, 0),ForceMode.Impulse);
            speed = 4f;
        }
        else
            transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
        
        

    }
}
