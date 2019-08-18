using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            player.GetComponent<PlayerRespawn>().checkpointLocation = transform;
            Debug.Log("Found checkpoint " + gameObject.name);
            player.GetComponent<PlayerRespawn>().SetCheckpoint();
        }
    }
}
