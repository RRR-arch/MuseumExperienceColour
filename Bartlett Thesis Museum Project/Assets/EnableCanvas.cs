using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanvas : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
