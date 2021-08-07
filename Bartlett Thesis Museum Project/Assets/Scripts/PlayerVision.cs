using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{

    //public CSVMaker csvmaker;
    public Vector3 centreVector;
    Vector3 leftVector;
    Vector3 leftCentreVector;
    Vector3 rightCentreVector;
    Vector3 rightVector;
    public List<Vector3> allRays;
    public List<List<string>> allWallNames = new List<List<string>>();
    public List<List<float>> allDistances = new List<List<float>>();

    // Start is called before the first frame update
    void Start()
    {
        centreVector = Vector3.forward;
        leftVector = Quaternion.Euler(0, -30, 0) * centreVector;
        leftCentreVector = Quaternion.Euler(0,-15,0) * centreVector;
        rightCentreVector = Quaternion.Euler(0, 15, 0) * centreVector;
        rightVector = Quaternion.Euler(0, 30, 0) * centreVector;

       // csvmaker = GetComponent<CSVMaker>();
        allRays = new List<Vector3> { leftVector, leftCentreVector, centreVector, rightCentreVector, rightVector};

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        List<string> names = new List<string>();
        var positions = Vision(out names);
        allWallNames.Add(names);
        allDistances.Add(positions);
    }

    public Vector3 CollectVision()
    {
        return transform.forward;

    }

    
    public List<List<string>> GetAllWallNames()
    {
        return allWallNames;
    }

    public List<List<float>> GetAllDistances()
    {
        return allDistances;
    }

    public List<float> Vision(out List<string> names)
    {
        RaycastHit raycastHit;

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 7;

        names = new List<string>();
        List<float> distances = new List<float>();

        for (int i = 0; i < allRays.Count; i++)
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(allRays[i]), out raycastHit, Mathf.Infinity, layerMask)) //100 = depth 6 = layer
            {
                if (raycastHit.collider.gameObject.tag == "Blue Wall")
                {
                    Debug.Log("blue");
                    names.Add("blue"); //raycastHit.collider.gameObject.name
                    distances.Add(Vector3.Distance(transform.position, raycastHit.collider.gameObject.transform.position));

                }
                else 
                {
                    Debug.Log("white");
                    names.Add("white");
                    distances.Add(Vector3.Distance(transform.position, raycastHit.collider.gameObject.transform.position));

                }
                //else
                //{
                //    names.Add("Void");
                //    distances.Add(0);
                //}

                //  csvmaker.LL.Add(raycastHit.collider.gameObject.name);  // Add "empty"
                //  csvmaker.LLd.Add(Vector3.Distance(transform.position, raycastHit.collider.gameObject.transform.position));
            }
            //else
            //{
            //    names.Add("missed");
            //    distances.Add(-1);
            //}
            
        }
        CollectVision();
        return distances;
    }
    //// LEFT HAND VECTOR
    //if (Physics.Raycast(transform.position, transform.TransformDirection(leftVector), out raycastHit, Mathf.Infinity, layerMask))  //100 = depth 6 = layer
    //{

    //   Debug.DrawRay(transform.position, transform.TransformDirection(leftVector) * 1000, Color.yellow);
    //   // Debug.Log("Did Hit");


    //        //Debug.Log(raycastHit.collider.gameObject.name);
    //        //Debug.Log("Hit Blue Wall - Left");
    //        csvmaker.LL.Add(raycastHit.collider.gameObject.name);  // Add "empty"
    //        csvmaker.LLd.Add(Vector3.Distance(transform.position,raycastHit.collider.gameObject.transform.position));

    //}
    //else
    //{

    //}

    //// LEFT-CENTRE VECTOR

    //if (Physics.Raycast(transform.position, transform.TransformDirection(leftCentreVector), out raycastHit, Mathf.Infinity, layerMask))  //100 = depth 6 = layer
    //{

    //    Debug.DrawRay(transform.position, transform.TransformDirection(leftCentreVector) * 1000, Color.green);
    //  //  Debug.Log("Did Hit");

    //    if (raycastHit.collider.gameObject.CompareTag("Blue Wall"))
    //    {
    //      //  Debug.Log(raycastHit.collider.gameObject.name);
    //      //  Debug.Log("Hit Blue Wall - Centre Left");
    //        csvmaker.LM.Add(raycastHit.collider.gameObject.name);
    //        csvmaker.LMd.Add(Vector3.Distance(transform.position, raycastHit.collider.gameObject.transform.position));
    //    }

    //}
    // // CENTRE VECTOR
    //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, Mathf.Infinity, layerMask))  //100 = depth 6 = layer
    //{

    //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);


    //    if (raycastHit.collider.gameObject.tag == "Blue Wall")
    //    {
    //        //Debug.Log(raycastHit.collider.gameObject.name);
    //       // Debug.Log("Hit Blue Wall - Centre");
    //        csvmaker.MM.Add(raycastHit.collider.gameObject.name);
    //        csvmaker.MMd.Add(Vector3.Distance(transform.position, raycastHit.collider.gameObject.transform.position));
    //    }

    //}
    //// RIGHT-CENTRE VECTOR
    //if (Physics.Raycast(transform.position, transform.TransformDirection(rightCentreVector), out raycastHit, Mathf.Infinity, layerMask))  //100 = depth 6 = layer
    //{

    //    Debug.DrawRay(transform.position, transform.TransformDirection(rightCentreVector) * 1000, Color.green);
    //    // Debug.Log("Did Hit");

    //    if (raycastHit.collider.gameObject.tag == "Blue Wall")
    //    {
    //       // Debug.Log(raycastHit.collider.gameObject.name);
    //       // Debug.Log("Hit Blue Wall - Centre Right");
    //        csvmaker.RM.Add(raycastHit.collider.gameObject.name);
    //        csvmaker.RMd.Add(Vector3.Distance(transform.position, raycastHit.collider.gameObject.transform.position));
    //    }

    //}
    //// RIGHT VECTOR
    //if (Physics.Raycast(transform.position, transform.TransformDirection(rightVector), out raycastHit, Mathf.Infinity, layerMask))  //100 = depth 6 = layer
    //{

    //    Debug.DrawRay(transform.position, transform.TransformDirection(rightVector) * 1000, Color.yellow);
    //    // Debug.Log("Did Hit");

    //    if (raycastHit.collider.gameObject.tag == "Blue Wall")
    //    {
    //        //Debug.Log(raycastHit.collider.gameObject.name);
    //        //Debug.Log("Hit Blue Wall - Right");
    //        csvmaker.RR.Add(raycastHit.collider.gameObject.name);
    //        csvmaker.RRd.Add(Vector3.Distance(transform.position, raycastHit.collider.gameObject.transform.position));
    //    }

    //}

    // else
    //  {
    //  Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
    //Debug.Log(raycastHit.collider.gameObject.name);
    //  }

}

