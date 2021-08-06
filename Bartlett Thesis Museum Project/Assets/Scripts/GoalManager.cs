using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GoalManager : MonoBehaviour
{
    public string sceneName;
    public GameObject player;
   // SceneChanger sceneChanger;
   // public bool activate = false;
    

    private void Start()
    {
        if (player == null)
          player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider Goal)
    {

        if (Goal.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(-1, 1, -21);
            player.transform.rotation = Quaternion.Euler(0, -90, 0);
            SceneManager.LoadScene(sceneName);

        }
    }

}
