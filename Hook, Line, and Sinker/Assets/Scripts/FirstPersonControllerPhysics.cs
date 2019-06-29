using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is the updated contoller using physics instead of transfoms 
public class FirstPersonControllerPhysics : MonoBehaviour
{
    [SerializeField] Rigidbody player;
    [SerializeField] Transform FPCamera;
    [SerializeField] float jumpHeight=5f;
    [SerializeField] float speed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Vector3 sidemovement =new Vector3 (1f, 0f, 0f);
            player.MovePosition(transform.position + sidemovement*(speed*Input.GetAxisRaw("Horizontal")));
           
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
            Debug.Log("I am jumping");
            player.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            player.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
        }
    }

    void CameraMovement()
    {
     

        float horizontalfov = Input.GetAxis("Mouse X");
        Space relativeTo;
        float verticalfov = -(Input.GetAxis("Mouse Y"));


        
        if (Input.GetAxis("Mouse X") != 0)
        {
            FPCamera.Rotate(0f, horizontalfov, 0f, relativeTo = Space.World);
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            FPCamera.Rotate(verticalfov, 0f, 0f, relativeTo = Space.World);
        }

      
    }

}
