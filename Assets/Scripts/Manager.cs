using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour 
{
    public void TestRead()
    {
        //Make sure file path exists before reading it// 
        if (File.Exists(Archive.dataDirectory + "TestName" + ".json"))
        {
            //Turn the JSON file into a C# Class// 
            SampleData readData = Archive.ReadSampleData("TestName");

            Debug.Log("Name : " + readData.sampleName +  " | Bool : " + readData.sampleBool + " | Double: " + readData.sampleDouble); 
        }
        else
        {
            Debug.Log("File path does not exist!"); 
        }
    }

    public void TestWrite()
    {
        //Create a new C# Class// 
        SampleData newData = new SampleData()
        {
            sampleName = "TestName",
            sampleBool = false,
            sampleDouble = 20.321,
            sampleInteger = 23
        };

        //Write to JSON File// 
        Archive.WriteSampleData(newData); 
    }

    public void TestClear()
    {
        Archive.ClearDirectory(Archive.dataDirectory); 
    }

    public void TestEdit()
    {
        if (File.Exists(Archive.dataDirectory + "TestName" + ".json"))
        {
            //Retreive File// 
            SampleData readData = Archive.ReadSampleData("TestName");

            //Assign a new value// 
            Debug.Log("Int was " + readData.sampleName);
            readData.sampleInteger = Random.Range(0, 999);

            //Overwrite the class -- "editing"// 
            Archive.WriteSampleData(readData); 
            Debug.Log("Int changed to " + readData.sampleInteger); 
        }
        else
        {
            Debug.Log("File does not exist!");
        }
    }
}
