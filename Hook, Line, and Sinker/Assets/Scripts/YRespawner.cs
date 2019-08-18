using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YRespawner : MonoBehaviour
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
            player.GetComponent<PlayerRespawn>().Respawn();
            Debug.Log("Player has fallen and can't get up");
        }
    }
}
