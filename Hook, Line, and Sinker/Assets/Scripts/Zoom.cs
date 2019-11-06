using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [Header("Camera Positions")]
    [SerializeField] private Transform defaultPos;
    [SerializeField] private Transform scopedPos;
    [SerializeField] private GameObject Camera;

    [Header("Zoom UI")]
    [SerializeField] private GameObject redDot;
    [SerializeField] private LayerMask LayersToCollideWith;
    [SerializeField] private GameObject shotDetect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Camera.transform.position = scopedPos.position;
            redDot.SetActive(true);
        }
        //if (Input.GetButtonUp)
        else
        {
            Camera.transform.position = defaultPos.position;
            redDot.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, Mathf.Infinity, LayersToCollideWith))
        {
            shotDetect.SetActive(true);
        }
        else
        {
            shotDetect.SetActive(false);
        }
    }
}
