using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedButton : MonoBehaviour
{
    //TODO: Button must go down when stepped on or something is placed on it. (STATIC DYNAMIC)
    //Use spring object for this.

    [SerializeField] GameObject target;
    //private Vector3 ogPosition;
    //[SerializeField] float sensitivity; //Why do we need sensitivity? 
    private bool isActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if((transform.position.y - ogPosition.y) < -sensitivity && !isActivated)
        //{
        //    target.SendMessage("Weighted", true);
        //    isActivated = true;
        //}
        //else if ((transform.position.y - ogPosition.y) > -sensitivity && isActivated)
        //{
        //    target.SendMessage("Weighted", false);
        //    isActivated = t;
        //}


    }

    private void OnCollisionEnter(Collision collision)
    {
        isActivated = true;
        GetComponent<SpringJoint>().maxDistance = .25f;
        target.SendMessage("Weighted", true);
    }
    private void OnCollisionExit(Collision collision)
    {
        isActivated = false;
        GetComponent<SpringJoint>().maxDistance = 0f;
        target.SendMessage("Weighted", false);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //isActivated = true;
    //    target.SendMessage("Weighted", true);

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //isActivated = false;
    //    target.SendMessage("Weighted", false);
    //}

    private void Weighted(bool active)
    {
        if (active == true)
        {
            Debug.Log("Button is Active");
        }
        if (active == false)
        {
            Debug.Log("Button is No Longer Active");
        }
    }
}
