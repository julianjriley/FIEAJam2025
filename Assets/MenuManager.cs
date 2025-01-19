using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //public string NextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
