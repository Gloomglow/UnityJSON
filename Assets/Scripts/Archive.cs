using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Archive : MonoBehaviour 
{
    [Header("InputFields")]
    public string InputName;
    public int InputLevel;
    public bool InputAlive;
    public double InputHealth;
    public double[] InputPosition;

    //Read & Write//
    public void ReadPlayer()
    {
        if (File.Exists(Player.PlayerDirectory + InputName + ".json"))
        {
            Player readPlayer = Player.ReadPlayerJSON(InputName);

            Debug.Log(readPlayer.playerName);
            Debug.Log(readPlayer.playerLevel);
            Debug.Log(readPlayer.playerIsAlive);
            Debug.Log(readPlayer.playerHealth);
            Debug.Log(readPlayer.playerPosition[0]);
            Debug.Log(readPlayer.playerPosition[1]);
            Debug.Log(readPlayer.playerPosition[2]);
        }
        else
        {
            Debug.Log("File path does not exist!");
        }
    }
    public void WritePlayer()
    {
        Player writePlayer = new Player()
        {
            playerName = InputName,
            playerLevel = InputLevel,
            playerHealth = InputHealth,
            playerIsAlive = InputAlive,
            playerPosition = InputPosition
        };

        if(writePlayer.playerName != "")
        {
            Player.WritePlayerJSON(writePlayer);
        }

    }
    public void ClearPlayers()
    {
        ClearDirectory(Player.PlayerDirectory); 
    }



    //Utility// 
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




