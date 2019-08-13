using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //[RequireComponent(typeof(Rigidbody))]
public class InteractableButton : MonoBehaviour
{
    [SerializeField] GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Colliding!");
        if(Input.GetButtonDown("Interact"))
        {
            target.SendMessage("Interact");
        }
    }

    //private void Interact()
    //{
    //    Debug.Log("Button was pushed!");
    //}
}
