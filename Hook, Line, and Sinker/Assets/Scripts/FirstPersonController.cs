using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] float speed = .5f;
    [SerializeField] Transform FPCamera;

    //void Rotate(float, float, float, Space);

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

    //Controls the movement of the first person character. 
    void Movement()
    {
        var pos = transform.position;

        if (Input.GetButton("Horizontal")&& Input.GetAxis("Horizontal")>0)
        {
            transform.position = new Vector3(pos.x + 1*speed, pos.y, pos.z);
        }
        else if (Input.GetButton("Horizontal")&& Input.GetAxis("Horizontal") < 0)
        {
            transform.position = new Vector3(pos.x - 1*speed, pos.y, pos.z);
        }

        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical")>0)
        {
            transform.position = new Vector3(pos.x, pos.y, pos.z + 1 * speed);
        }
        else if (Input.GetButton("Vertical")&& Input.GetAxis("Vertical")<0)
        {
            transform.position = new Vector3(pos.x, pos.y , pos.z - 1 * speed);
        }

    }

    void CameraMovement()
    {
        float horizontalfov = Input.GetAxis("Mouse X");
        Space relativeTo;
        float verticalfov = Input.GetAxis("Mouse Y");


        // Vector3 eulers = (transform.rotation.x , transform.rotation.y, transform.rotation.z);
        transform.Rotate(transform.rotation.x+ verticalfov,transform.rotation.y + horizontalfov,0f, relativeTo = Space.World);


        //if (Input.GetButton("Mouse X")&& Input.GetAxis("Mouse X") < 0)
        //{
        //    transform.rotation = new Quaternion(transform.rotation.w, transform.rotation.x + 1, transform.rotation.y, transform.rotation.z);
        //}

        // FPCamera.rotation = new Quaternion(FPCamera.rotation.w*0, FPCamera.rotation.x + horizontalfov, FPCamera.rotation.y*0  , FPCamera.rotation.z*0);
        //transform.rotation = Quaternion.Slerp(transform.rotation, FPCamera.rotation, .5f);

    }
}


