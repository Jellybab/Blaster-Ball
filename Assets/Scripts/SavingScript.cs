using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;


public class SavingScript : MonoBehaviour {


    public static SavingScript SS;
    // Use this for initialization
    private void Awake()
    {
        if (SS == null)
        {
            DontDestroyOnLoad(gameObject);
            SS = this;
        }
        else if (SS != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save() {
        Debug.Log("File Saving");
        PlayerData data = new PlayerData();
        Game_Controller.GC.SaveData();
        data.currentBoxData = BoxController.BXC.levelBoxData;
        data.currentBalls = BallController.BC.ballData;



        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Create);
        bf.Serialize(file, data);
        file.Close();

    }
    

    public void Load() {
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {

            Debug.Log("file loading");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
  
            BoxController.BXC.levelBoxData = data.currentBoxData;
            BallController.BC.ballData = data.currentBalls;
            

        }
        else {
           Save();
        }
    }

  //  private void OnApplicationPause(bool pause)
   // {
    //    Save();
    //}
    private void OnApplicationQuit()
    {
        Save();
    }
}

[Serializable]
class PlayerData {

    //data to save, blocks currently alive, level, balls, balls location. 


   // public int level;
    public List<BoxData> currentBoxData;
    public List<BallData> currentBalls;

}


