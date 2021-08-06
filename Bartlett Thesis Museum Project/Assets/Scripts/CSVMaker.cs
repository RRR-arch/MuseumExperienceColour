using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine;

public class CSVMaker : MonoBehaviour
{
    public float sampleRate = 0.5f;
    private float sampleRateTimer;    
    public List<Decimal> time = new List<Decimal>();
    public List<Vector3> position = new List<Vector3>();


    public List<List<string>> HitName;
    public List<string> LL = new List<string>();
    public List<string> LM = new List<string>();
    public List<string> MM = new List<string>();
    public List<string> RM = new List<string>();
    public List<string> RR = new List<string>();

    public List<List<float>> HitDistance;
    public List<float> LMd = new List<float>();
    public List<float> MMd = new List<float>();
    public List<float> RMd = new List<float>();
    public List<float> RRd = new List<float>();
    public List<float> LLd = new List<float>();

    public PlayerMovement playermovement;
    public PlayerVision playervision;


    private void Start()
    {
        //  sampleRateTimer = sampleRate;
        InvokeRepeating(nameof(CollectData), 0, 0.25f);
        InvokeRepeating(nameof(WriteToFile), 2, 10);
 
    }

    private void OnApplicationQuit()
    {
        WriteToFile();
    }

    void CollectData()
    {
        List<string> names = new List<string>();
        playermovement.CollectMovement();
        playervision.CollectVision();
        
    }
    void Update()
    {
        Timer();
    }

    private void LateUpdate()
    {
        time.Add(((decimal)Time.time));

    }
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

    void Timer()
    {
        if (sampleRate > 0)
        {
            sampleRate -= Time.deltaTime;
        }
        else
        {
            WriteToFile();
            sampleRate = sampleRateTimer;
        }

        //if (Time.deltaTime > (sampleRateTimer + sampleRate))
        //{
        //    WriteToFile();
        //    sampleRateTimer = Time.deltaTime;
        //}
    }

    void WriteToFile()
    {

        string filePath = getPath();

        StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine("Time, PositionX, PositionY, Left Ray, Left Centre Ray, Centre Ray, Right Centre Ray,Right Ray, L-Dist, LC-Dist, C-Dist, RC-Dist, R-Dist");

        for (int i = 0; i < Mathf.Max(time.Count, position.Count, LL.Count, LM.Count, MM.Count, RM.Count, RR.Count); ++i)
        {
            if (i < time.Count) writer.Write(time[i]);
            writer.Write(",");
            if (i < position.Count) writer.Write(position[i].x);
            writer.Write(",");
            if (i < position.Count) writer.Write(position[i].z);
            writer.Write(",");
            if (i < LL.Count) writer.Write(LL[i]);
            writer.Write(",");
            if (i < LM.Count) writer.Write(LM[i]);
            writer.Write(",");
            if (i < MM.Count) writer.Write(MM[i]);
            writer.Write(",");
            if (i < RM.Count) writer.Write(RM[i]);
            writer.Write(",");
            if (i < RR.Count) writer.Write(RR[i]);
            writer.Write(",");
            if (i < LLd.Count) writer.Write(LLd[i]);
            writer.Write(",");
            if (i < LMd.Count) writer.Write(LMd[i]);
            writer.Write(",");
            if (i < MMd.Count) writer.Write(MMd[i]);
            writer.Write(",");
            if (i < RMd.Count) writer.Write(RMd[i]);
            writer.Write(",");
            if (i < RRd.Count) writer.Write(RRd[i]);
            writer.Write(System.Environment.NewLine);
        }

        writer.Flush();
        writer.Close();

        
    }
}



