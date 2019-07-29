using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TurretBullet : MonoBehaviour
{
    [SerializeField] int playerLayer;
    [SerializeField] float forceToApplyToPlayer, speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == playerLayer && collision.collider.gameObject.GetComponent<Rigidbody>())
        {
            collision.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceToApplyToPlayer);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
