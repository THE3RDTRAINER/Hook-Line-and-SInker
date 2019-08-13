using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedButton : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        target.SendMessage("Weighted",true);

    }

    //private void OnTriggerExit(Collider other)
    //{
    //    SendMessage("Weighted", false);
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
