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
    // Start is called before the first frame update
    IEnumerator Start()
    {
        fire = true;
        yield return new WaitForSeconds(timeBetweenShots);
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        if (detected == true && fire == false)
        {
            StartCoroutine(Start());
            transform.LookAt(player);
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
        if (other.gameObject.layer == 10)
        {
            detected = false;
        }
    }

}
