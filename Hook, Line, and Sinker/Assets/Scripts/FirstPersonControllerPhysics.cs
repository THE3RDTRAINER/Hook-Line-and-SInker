using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is the updated contoller using physics instead of transfoms 
public class FirstPersonControllerPhysics : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] Rigidbody player;
    [SerializeField] Transform FPCamera;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] GameObject PlayerCamera;

    [Header("Movement Variables")]
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float speed = .10f;
    [Range(0f, 3f)]
    [SerializeField] float sensitivity = .5f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CameraMovement();
        
    }

    void Movement()
    {

        //side to side movement 
        if (Input.GetButton("Horizontal"))
        {
            player.MovePosition(transform.position + transform.right*(speed*Input.GetAxisRaw("Horizontal")));
           
            //player.AddForce(speed * Input.GetAxisRaw("Horizontal"), 0, 0,  ForceMode.Acceleration);
            //player.AddRelativeForce(Vector3.forward * speed * Input.GetAxisRaw("Horizontal"));
        }

        //forward/backward movement
        if (Input.GetButton("Vertical"))
        {
            player.MovePosition(transform.position + transform.forward * (speed * Input.GetAxisRaw("Vertical")));

            //player.AddForce(0,0, speed * Input.GetAxisRaw("Vertical"), ForceMode.Acceleration);

        }

        //Jump 
        if (Input.GetButtonDown("Jump"))
        {
            player.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            
        }
    }

    void CameraMovement()
    {
     

        float horizontalfov = Input.GetAxis("Mouse X")*sensitivity;
        float verticalfov = -(Input.GetAxis("Mouse Y")*sensitivity);


        
        if (Input.GetAxis("Mouse X") != 0)
        {
           //FPCamera.Rotate(0f, horizontalfov, 0f, relativeTo = Space.World);
            PlayerTransform.Rotate(0f, horizontalfov, 0f, Space.Self);
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            FPCamera.Rotate(verticalfov, 0f, 0f, Space.Self);
        }

    }

}
