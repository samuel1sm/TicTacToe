using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerSave data = new PlayerSave(playerData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerSave LoadPlayers()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerSave playerSave = (PlayerSave) formatter.Deserialize(stream);
            stream.Close();
            
            return playerSave;
        }
        else
        {
            // Debug.LogError("File not found" + path);
            return null;
        }
    }
    
    public static void SaveRewards(RewardBarController playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Reward.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        RewardData data = new RewardData(playerData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static RewardData LoadRewards()
    {
        string path = Application.persistentDataPath + "/Reward.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RewardData playerSave = (RewardData) formatter.Deserialize(stream);
            stream.Close();
            
            return playerSave;
        }
        else
        {
            // Debug.LogError("File not found" + path);
            return null;
        }
    }


    // Start is called before the first frame update
}