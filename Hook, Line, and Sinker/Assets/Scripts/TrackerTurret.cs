using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerTurret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform Firepoint;
    [SerializeField] private Rigidbody Bullet;
    [SerializeField] private Transform player;
    [Header("Values")]
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private bool detected=false;
    bool fire = false;
    [Header("SphereCast")]
    [SerializeField] LayerMask layMask;
    [SerializeField] float radius;
    //Note: Start should never be a seperate function. It is called at the begining when we start the game or spawn the prefab.
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<SphereCollider>().radius = radius;
    }

    IEnumerator StartFire()
    {
        fire = true;
        yield return new WaitForSeconds(timeBetweenShots);
        StartCoroutine(Fire());
    }


    // Update is called once per frame
    void Update()
    {
        //TODO: Only if the turret can see the player, shoot
        if (detected==true)
        {
            transform.LookAt(player);
            if (fire == false)
            {
                StartCoroutine(StartFire());
            }

        }

    }

    IEnumerator Fire()
    {
        Rigidbody Projectile;
        Projectile = Instantiate(Bullet, Firepoint.position, Firepoint.rotation);
        yield return new WaitForSeconds(timeBetweenShots);
        fire = false;

        //TODO: Optimization, 
        Collider[] hit=Physics.OverlapSphere(transform.position, radius, layMask, QueryTriggerInteraction.UseGlobal);
        if (hit.Length>0){
            detected = true;
            Debug.Log("Target in sight");
        }
        else
        {
            detected = false;
            Debug.Log("Target Lost");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            detected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //TODO: Put a delay after the player leaves. Makes it better, way it's not instant.
        if (other.gameObject.layer == 10)
        {
            detected = false;
        }
    }
    private void OnDrawGizmos()
    {
        if (detected)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, player.position);
        }
        else
        {
            Gizmos.color = new Color(225, 235, 0, .5f);
            Gizmos.DrawSphere(transform.position, radius);
        }
    }


    //Dont use enum, at the end  of enum check for overlap sphere, if hit it wont stop if none stop 
}
