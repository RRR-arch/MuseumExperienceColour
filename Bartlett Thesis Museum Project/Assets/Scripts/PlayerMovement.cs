using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Text;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{
    
    //public CSVMaker csvmaker;
    public CharacterController controller;
    public float speed = 12f;
    
   

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        CollectMovement();

    }

    public Vector3 CollectMovement()
    {
      return transform.position;  
    }

    public string GetScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    //public void GetSceneName()
    //{
    //    SceneManager.
    //}
}
