using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
//[RequireComponent(typeof(HingeJoint))]
public class PlayerController : MonoBehaviour
{
    private LineRenderer lineRen;
    [SerializeField] private GameObject connectedObject;
    [SerializeField] private LayerMask LayersToCollideWith;
    [SerializeField] private Transform Camera;
    [SerializeField] private SpringJoint sj;
    // Start is called before the first frame update
    void Start()
    {
        lineRen = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.Space))
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

    void AddJoint(Rigidbody rb)
    {
        sj = gameObject.AddComponent(typeof(SpringJoint)) as SpringJoint;
        sj.maxDistance = Vector3.Distance(connectedObject.transform.position, Camera.transform.position);
        sj.connectedBody = rb;
        sj.autoConfigureConnectedAnchor = false;
        sj.connectedAnchor = Vector3.zero;
        //sj.anchor = Vector3.zero;
    }
}