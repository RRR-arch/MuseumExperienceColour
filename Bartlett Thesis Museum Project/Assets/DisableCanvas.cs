using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCanvas : MonoBehaviour
{
    public GameObject canvas;

    void DisableMyCanvas()
    {
        canvas.gameObject.SetActive(false);
    }

}
