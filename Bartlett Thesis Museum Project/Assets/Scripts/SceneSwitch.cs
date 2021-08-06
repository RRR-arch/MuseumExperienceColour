using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
   
    // Start is called before the first frame update
   public void StartGame( string LevelName)
    {
        SceneManager.LoadScene("Scene-01", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
