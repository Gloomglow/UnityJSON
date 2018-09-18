using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//New References//
using System.IO;
using LitJson;

public class Archive : MonoBehaviour 
{
    //File Paths -- Use Forward Slashes// 
    public static string dataDirectory = "C:/Users/Andrew/Desktop/Gloom/UnityJSON/Assets/JSON/";

    //Read and Write//
    public static SampleData ReadSampleData(string fileName)
    {
        string jsonString = File.ReadAllText(dataDirectory + fileName + ".json");
        return JsonMapper.ToObject<SampleData>(jsonString);
    }
    public static void WriteSampleData(SampleData data)
    {
        JsonData jsonData = JsonMapper.ToJson(data);
        string jsonString = jsonData.ToString();
        File.WriteAllText(dataDirectory + data.sampleName + ".json", jsonString);
    }
 
    //Utility Functions// 
    public static void ClearDirectory(string path)
    {
        string[] allPaths = Directory.GetFiles(path);
        foreach (string st in allPaths) { File.Delete(st); }
    }
    public static string[] RemoveMetaTags(string[] strings)
    {
        string[] returnArray = new string[strings.Length / 2];

        int insert = 0;
        for (int i = 0; i < strings.Length; i += 2)
        {
            returnArray[insert] = strings[i];
            insert++;
        }

        return returnArray;
    }

}

public class SampleData
{
    public string sampleName; 
    public int sampleInteger;
    public double sampleDouble; 
    public bool sampleBool;

    public double XLocation;
    public double YLocation;
    public double ZLocation;
    public double YRotation;

    public double[] samplePosition; 
    //ie. samplePosition[0] is X, 1 is Y, and 2 is Z. 
}

//Note : Floats are not supported by JSON. 
//Use (double) or (float) to cast back and forth// 
//Vector3 and other unity classes are also not recognized.//
//Store individual values, or use an array. After all, a Vector3 is just 3 numbers!// 
