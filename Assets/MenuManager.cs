using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource _source;
    //public string NextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            _source.clip = clip;
        }
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
