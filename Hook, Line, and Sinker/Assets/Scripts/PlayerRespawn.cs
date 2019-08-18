using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform checkpointLocation;
    [SerializeField] bool usingSaves = false;
    // Start is called before the first frame update

    private void Awake()
    {
        if (usingSaves == true)
        {
            float posX;
            float posY;
            float posZ;
            posX = PlayerPrefs.GetFloat("Checkpoint x");
            posY = PlayerPrefs.GetFloat("Checkpoint y");
            posZ = PlayerPrefs.GetFloat("Checkpoint z");
            transform.position = new Vector3(posX, posY, posZ);
        }
    }
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

    public void SetCheckpoint()
    {
        PlayerPrefs.SetFloat("Checkpoint x", checkpointLocation.position.x);
        PlayerPrefs.SetFloat("Checkpoint y", checkpointLocation.position.y);
        PlayerPrefs.SetFloat("Checkpoint z", checkpointLocation.position.z);
    }
}
