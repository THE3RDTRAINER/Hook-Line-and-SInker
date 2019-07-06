using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(LineRenderer))]
//[RequireComponent(typeof(HingeJoint))]
public class PlayerController : MonoBehaviour
{
    private LineRenderer lineRen;
    [SerializeField] private GameObject connectedObject;
    [SerializeField] private LayerMask LayersToCollideWith;
    [SerializeField] private Transform Camera;
    [SerializeField] private SpringJoint sj;
    [SerializeField] private GameObject tmpComponent;

    [Header("Controls")]
    [SerializeField] private KeyCode ShootRope;
    [Range(0,1)]
    [SerializeField] private float amountToAddToRope = .5f;
    private List<GameObject> grabbableObjects = new List<GameObject>();
    //[SerializeField] private KeyCode LongenRope;
    //[SerializeField] private KeyCode ShortenRope;
    // Start is called before the first frame update
    void Start()
    {
        lineRen = GetComponent<LineRenderer>();
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("GrabbableStatic"))
        {
            grabbableObjects.Add(i);
        }
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("GrabbableDynamic"))
        {
            grabbableObjects.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(ShootRope))
        {
            if(connectedObject == null)
            {
                Grapple(Camera.position, Camera.forward, 20f, LayersToCollideWith);
            }
            else
            {
                UnGrapple();
            }
            
        }
        lineRen.SetPosition(0, Camera.position);
        if(connectedObject != null)
        {
            lineRen.SetPosition(1, connectedObject.transform.position);
        }

        //Controls
        if (Input.GetButton("ShortenRope"))
        {
            retractRope();
        }else if (Input.GetButton("LongenRope"))
        {
            ExtendRope();
        }
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, 20f, LayersToCollideWith))
        {
            tmpComponent.SetActive(true);
        }
        else
        {
            tmpComponent.SetActive(false);
        }
    }

    void Grapple(Vector3 pos, Vector3 dir,float maxDistance, LayerMask layersToHit)
    {
        RaycastHit hit;
        if (Physics.Raycast(pos, dir, out hit, maxDistance, layersToHit, QueryTriggerInteraction.Collide))
        {
            lineRen.enabled = true;
            connectedObject = hit.collider.gameObject;
            if (connectedObject.GetComponent<Rigidbody>())
            {
                AddJoint(connectedObject.GetComponent<Rigidbody>());
            }
        }
    }

    void UnGrapple()
    {
        connectedObject = null;
        Destroy(sj);
        sj = null;
        lineRen.enabled = false;
    }

    void ExtendRope()
    {
        sj.maxDistance += amountToAddToRope;
    }
    void retractRope()
    {
        sj.maxDistance -= amountToAddToRope;
    }

    void AddJoint(Rigidbody rb)
    {
        sj = gameObject.AddComponent(typeof(SpringJoint)) as SpringJoint;
        sj.maxDistance = Vector3.Distance(connectedObject.transform.position, Camera.transform.position);
        sj.connectedBody = rb;
        sj.autoConfigureConnectedAnchor = false;
        sj.connectedAnchor = Vector3.zero;
        //sj.anchor = Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.position, Camera.forward);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach (GameObject i in grabbableObjects)
        {
            Gizmos.DrawLine(Camera.position, i.transform.position);
        }
    }
}