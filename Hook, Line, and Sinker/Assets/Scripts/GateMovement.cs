using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMovement : MonoBehaviour
{
    [SerializeField] Rigidbody Self;
    [SerializeField] Transform endPosition;
    [SerializeField] Transform startPosition;
    [SerializeField] float movementRate;

    [SerializeField] private float waitTime = 1f;
    [SerializeField] bool oneTime;
    [SerializeField] bool looping ;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (looping == true)
        {
            looping = false;
            Self.MovePosition(endPosition.position);
            yield return new WaitForSeconds(waitTime);
            Self.MovePosition(startPosition.position);
            yield return new WaitForSeconds(waitTime);
            looping = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //one and done movement
        if (oneTime == true) {
            Singleuse();

        }
    }
    private void FixedUpdate()
    {
        if (looping == true)
        {
            StartCoroutine(Start());
            
        }
    }
    void Singleuse()
    {
        oneTime = false;
        transform.position = Vector3.Lerp(transform.position, endPosition.position, movementRate);
    }
}
