using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTime;
    [SerializeField] float endTime;
    [SerializeField] float completeTime;

    // Start is called before the first frame update
    void Start()
    {

            startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 )
        {

                endTime = Time.time;
                completeTime = endTime - startTime; 
            
        }
    }
}
