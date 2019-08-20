using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedButton : MonoBehaviour
{
    [SerializeField] GameObject target;
    //private Vector3 ogPosition;
    //[SerializeField] float sensitivity;
    //private bool isActivated = false;
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    isActivated = true;
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    isActivated = false;
    //}

    private void OnTriggerEnter(Collider other)
    {
        //isActivated = true;
        target.SendMessage("Weighted", true);

    }

    private void OnTriggerExit(Collider other)
    {
        //isActivated = false;
        SendMessage("Weighted", false);
    }

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
