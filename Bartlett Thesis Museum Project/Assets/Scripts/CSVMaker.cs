using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine;
using System.Linq;

public class CSVMaker : MonoBehaviour
{
    public float sampleRate = 0.5f;
    private float sampleRateTimer;    
   public List<string> playertime = new List<string>();

    public List<string> thisscene = new List<string>();
    
    public List<List<string>> HitName = new List<List<string>>();
    public List<string> LL = new List<string>();
    public List<string> LM = new List<string>();
    public List<string> MM = new List<string>();
    public List<string> RM = new List<string>();
    public List<string> RR = new List<string>();

    public List<List<float>> HitDistance = new List<List<float>>();
    public List<float> LMd = new List<float>();
    public List<float> MMd = new List<float>();
    public List<float> RMd = new List<float>();
    public List<float> RRd = new List<float>();
    public List<float> LLd = new List<float>();

    public PlayerMovement playermovement;
    List<Vector3> playerposition = new List<Vector3>();
    
    public PlayerVision playervision;
    public List<Vector3> playerfrontview = new List<Vector3>();

    

    private void Start()
    {
        //  sampleRateTimer = sampleRate;
        InvokeRepeating("CollectData", 0.5f, 0.25f);  //InvokeRepeating(nameof(CollectData), 0.5f, 0.25f);
        InvokeRepeating("WriteToFile", 0, 10);
 
    }

    private void OnApplicationQuit()
    {
        WriteToFile();
    }

    void CollectData()
    {
        //var t = Mathf.Round(Time.time);
        var tfloat = Time.unscaledTimeAsDouble;
       
        string t = tfloat.ToString("f2");
        Debug.Log(t);
        playertime.Add(t);

        var sce = playermovement.GetScene();
        thisscene.Add(sce);

        List<string> names = new List<string>();
        var pos = playermovement.CollectMovement();
        playerposition.Add(pos);

        var view = playervision.CollectVision();
        playerfrontview.Add(view);

        var nam = playervision.GetAllWallNames();
        HitName.AddRange(nam);

        var dist = playervision.GetAllDistances();
        HitDistance.AddRange(dist);




    }
    //void TimeUpdate()
    //{
    //    var t = Mathf.Round(Time.deltaTime);
    //    playertime.Add(t);
    //}

    //private void LateUpdate()
    //{
    //    time.Add(((decimal)Time.time));

    //}
    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/" + "Saved_Inputs.csv";
        //"Participant " + "   " + DateTime.Now.ToString("dd-MM-yy   hh-mm-ss") + ".csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_Inputs.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_Inputs.csv";
#else
        return Application.dataPath +"/"+"Saved_Inputs.csv";
#endif
    }

    //void Timer()
    //{
    //    if (sampleRate > 0)
    //    {
    //        sampleRate -= Time.deltaTime;
    //    }
    //    else
    //    {
    //        WriteToFile();
    //        sampleRate = sampleRateTimer;
    //    }

    //    //if (Time.deltaTime > (sampleRateTimer + sampleRate))
    //    //{
    //    //    WriteToFile();
    //    //    sampleRateTimer = Time.deltaTime;
    //    //}
    //}

    void WriteToFile()
    {

        string filePath = getPath();

        StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine("Time, Scene, PositionX, PositionY, FrontViewX, FrontViewY, Left Ray, Left Centre Ray, Centre Ray, Right Centre Ray,Right Ray, L-Dist, LC-Dist, C-Dist, RC-Dist, R-Dist");

        for (int i = 0; i < Mathf.Max(playertime.Count, thisscene.Count, playerposition.Count); ++i)  //Mathf.Max( //  HitName[i].Count, HitDistance[i].Count
        {
            if (i < playertime.Count) writer.Write(playertime[i]);
            writer.Write(",");
            if (i < thisscene.Count) writer.Write(thisscene[i]);
            writer.Write(",");
            if (i < playerposition.Count) writer.Write(playerposition[i].x);
            writer.Write(",");
            if (i < playerposition.Count) writer.Write(playerposition[i].z);
            writer.Write(",");
            if (i < playerfrontview.Count) writer.Write(playerfrontview[i].x);
            writer.Write(",");
            if (i < playerfrontview.Count) writer.Write(playerfrontview[i].z);
            //writer.Write(",");

           //if (i < playertime.Count) writer.Write(HitName[i][0]);
            //writer.Write(",");
            //if (i < HitName[i].Count) writer.Write(HitName[i][1]);
            //writer.Write(",");
            //if (i < HitName[i].Count) writer.Write(HitName[i][2]);
            //writer.Write(",");
            //if (i < HitName[i].Count) writer.Write(HitName[i][3]);
            //writer.Write(",");
            //if (i < HitName[i].Count) writer.Write(HitName[i][4]);
            //writer.Write(",");
            //if (i < HitDistance[i].Count) writer.Write(HitDistance[i][0]);
            //writer.Write(",");
            //if (i < HitDistance[i].Count) writer.Write(HitDistance[i][1]);
            //writer.Write(",");
            //if (i < HitDistance[i].Count) writer.Write(HitDistance[i][2]);
            //writer.Write(",");
            //if (i < HitDistance[i].Count) writer.Write(HitDistance[i][3]);
            //writer.Write(",");
            //if (i < HitDistance[i].Count) writer.Write(HitDistance[i][4]);
            writer.Write(System.Environment.NewLine);
        }

        writer.Flush();
        writer.Close();

        
    }
}



