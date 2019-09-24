using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour
{
    [SerializeField] private bool endOnEntrance;
    [SerializeField] private bool returnToMenu;
    [SerializeField] private string SceneToLoad;
    private string MenuName = "something";
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
        if (endOnEntrance)
        {

        }
    }

    void Activate()
    {
        if (returnToMenu)
        {
            SceneManager.LoadScene(MenuName);
        }
        else if(SceneToLoad != null)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
        else
        {
            Debug.LogError("You have not selected a level to load!");
        }
    }
}
