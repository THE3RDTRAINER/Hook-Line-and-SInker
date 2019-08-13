using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryTurret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform Firepoint;
    [SerializeField] private Rigidbody Bullet;
    [Header("Values")]
    [SerializeField] private float timeBetweenShots;
    bool fire=false;
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
        if (fire == false)
        {
            StartCoroutine(Start());
        }
    }
    IEnumerator Fire()
    {
        Rigidbody Projectile;
        Projectile = Instantiate(Bullet, Firepoint.position, Firepoint.rotation);
        yield return new WaitForSeconds(timeBetweenShots);
        fire = false;
    }
}
