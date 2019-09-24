using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ZiplineScript : MonoBehaviour
{
    [Header("Zipline settings")]
    public bool isActive = true;
    [SerializeField] private Transform PositionA, PositionB;
    [SerializeField] private LayerMask playerLayer;
    [Header("Rafter Settings")]
    [SerializeField] private bool canDismount = false;
    [SerializeField] private GameObject RafterGameObject, RafterInst;
    [SerializeField] private float speed;
    private GameObject Player;
    private float startTime;
    private Vector3 oldPosition;
    private float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer LineRen = GetComponent<LineRenderer>();
        LineRen.useWorldSpace = true;
        LineRen.SetPosition(0, PositionA.position);
        LineRen.SetPosition(1, PositionB.position);
        LineRen.enabled = isActive;
    }

    // Update is called once per frame
    void Update()
    {
        //If the zipline is activated
        if (isActive)
        {
            //If the zipline is on
            if (RafterInst != null)
            {
                t = ((Time.time - startTime) * speed) / Vector3.Distance(oldPosition, PositionB.position);
                RafterInst.transform.position = Vector3.Lerp(oldPosition, PositionB.position, t);

                //For dismount
                if ((Input.GetButtonUp("Interact") && canDismount) || t >= 1.0f)
                {
                    DismountRafter();
                }
            }
            else
            {
                RaycastHit rayHit;
                if (Physics.SphereCast(PositionA.position, 1.0f, GetDirection(PositionB, PositionA), out rayHit, Vector3.Distance(PositionA.position, PositionB.position), playerLayer))
                {
                    if (Input.GetButtonUp("Interact"))
                    {
                        SpawnRafter(rayHit.collider.gameObject);
                    }

                }
                else if (Physics.OverlapSphere(PositionA.position, 1.0f, playerLayer).Length > 0)
                {
                    if (Input.GetButtonUp("Interact"))
                    {
                        //If it is just the player
                        if (Physics.OverlapSphere(PositionA.position, 1.0f, playerLayer).Length <= 1)
                        {
                            SpawnRafter(Physics.OverlapSphere(PositionA.position, 1.0f, playerLayer)[0].gameObject);
                        }
                        //If it is the player and an item
                        else
                        {
                            GameObject temp = null;
                            foreach (Collider i in Physics.OverlapSphere(PositionA.position, 1.0f, playerLayer))
                            {
                                //9 is the layer of the grabbables
                                if (i.gameObject.layer == 9)
                                {
                                    temp = i.gameObject;
                                    break;
                                }
                            }
                            if (temp != null)
                            {
                                SpawnRafter(temp);
                            }

                        }
                    }
                }


            }
        }
    }

    Vector3 GetDirection(Transform targetPosition, Transform currentPosition)
    {
        return ((targetPosition.position - currentPosition.position) / Vector3.Distance(targetPosition.position, currentPosition.position));
    }
    //Spawn Gameobject to drag object
    void SpawnRafter(GameObject PlayerObject)
    {
        RafterInst = Instantiate(RafterGameObject, PlayerObject.transform.position, transform.rotation);
        PlayerObject.transform.parent = RafterInst.transform;
        Player = PlayerObject;
        Rigidbody temp = Player.GetComponent<Rigidbody>();
        temp.useGravity = false;
        temp.velocity = Vector3.zero;
        Player.transform.localPosition = Vector3.zero;
        startTime = Time.time;
        oldPosition = RafterInst.transform.position;
    }
    //Dismount from Gameobject
    void DismountRafter()
    {
        Player.transform.parent = null;
        Player.GetComponent<Rigidbody>().useGravity = true;
        Destroy(RafterInst);
        t = 0.0f;
    }

    private void OnDrawGizmos()
    {
        if (isActive)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(PositionA.position, PositionB.position);
            Gizmos.DrawWireSphere(PositionA.position, 1.0f);
        }
        
    }
    [ContextMenu("Activate")]
    public void Activate()
    {
        isActive = true;
        GetComponent<LineRenderer>().enabled = true;
    }
    [ContextMenu("Deactivate")]
    public void DeActivate()
    {
        isActive = false;
        GetComponent<LineRenderer>().enabled = false;
    }
}