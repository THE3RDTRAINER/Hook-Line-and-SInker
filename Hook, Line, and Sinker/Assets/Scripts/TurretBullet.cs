using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TurretBullet : MonoBehaviour
{
    [SerializeField] int playerLayer;
    [SerializeField] float forceToApplyToPlayer, speed;
    [SerializeField] GameObject BulletHitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.gameObject.name);
        if (collision.collider.gameObject.layer == playerLayer && collision.collider.gameObject.GetComponent<Rigidbody>())
        {
            collision.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceToApplyToPlayer);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(BulletHitPrefab, collision.GetContact(0).point, Quaternion.Euler(-collision.GetContact(0).normal));
            Destroy(gameObject);
        }
    }
}
