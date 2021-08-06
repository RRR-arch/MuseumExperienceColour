using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Text;



public class PlayerMovement : MonoBehaviour
{
    // public GameObject canvas;

    public CSVMaker csvmaker;
    public CharacterController controller;

    public float speed = 12f;
    
   // List<String> positionList = new List<String>();

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

    public void CollectMovement()
    {
        csvmaker.position.Add(transform.position);
    }
}
