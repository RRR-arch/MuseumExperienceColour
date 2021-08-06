using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string thisScene;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(thisScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
