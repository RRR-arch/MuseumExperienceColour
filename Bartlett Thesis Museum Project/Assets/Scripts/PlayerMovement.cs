using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Text;



public class PlayerMovement : MonoBehaviour
{
    public GameObject canvas;


    public CharacterController controller;

    public float speed = 12f;
    public String position;
    List<String> positionList = new List<String>();

    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

    }

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
        }

    }


    //void DisableMyCanvas()
    //{
       
    //}


    //void makeString()
    //{
    //    string ToCSV()
    //    {
    //        String sb = new StringBuilder();
    //        foreach (var frame in keyFrames)
    //        {
    //            sb.Append('\n').Append(frame.Time.ToString()).Append(',').Append(frame.Value.ToString());
    //        }

    //        return sb.ToString();
    //    }
    //}

}

// public class KeyFrame
//{
//    public int Value;
//    public float Time;

//    public KeyFrame() { }

//    public KeyFrame(int value, float time)
//    {
//        Value = value;
//        Time = time;
//    }

//    private List<KeyFrame> keyFrames = new List<KeyFrame>(10000);
//}

