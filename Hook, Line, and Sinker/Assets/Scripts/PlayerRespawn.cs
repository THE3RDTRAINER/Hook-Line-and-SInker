using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform checkpointLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Respawn()
    {
        transform.position = checkpointLocation.position;
        //reset health when health becomes a thing. 
    }

    //This needs to go somewhere else I think
    public void SetCheckpoint(Transform position)
    {
        //PlayerPrefs.SetFloat("Checkpoint x", checkpointLocation.x);
    }
}
