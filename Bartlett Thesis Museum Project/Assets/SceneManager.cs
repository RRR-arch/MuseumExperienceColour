using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    void DisableCanvas()
    {
       
    }

    private void OnTriggerEnter(Collider Goal)
    {
        if (Goal.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(name); 
            
        }
    }

    internal static void LoadScene(string name)
    {
        throw new NotImplementedException();
    }
}
