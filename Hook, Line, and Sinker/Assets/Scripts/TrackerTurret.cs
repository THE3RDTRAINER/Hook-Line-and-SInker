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


    //Note: Start should never be a seperate function. It is called at the begining when we start the game or spawn the prefab.
    // Start is called before the first frame update
    //IEnumerator Start()
    //{
    //    fire = true;
    //    yield return new WaitForSeconds(timeBetweenShots);
    //    StartCoroutine(Fire());
    //}


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
        if (detected)
        {
            transform.LookAt(player);
        }
        if (detected == true && fire == false)
        {
            StartCoroutine(StartFire());
        }
    
    }
    IEnumerator Fire()
    {
        Rigidbody Projectile;
        Projectile = Instantiate(Bullet, Firepoint.position, Firepoint.rotation);
        yield return new WaitForSeconds(timeBetweenShots);
        fire = false;
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

}
