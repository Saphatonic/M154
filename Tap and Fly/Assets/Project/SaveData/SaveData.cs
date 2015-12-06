using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData : MonoBehaviour {

    private string _filePath;

    [HideInInspector]
    public static SaveData Instance { get; private set; }
    public PlayerData PlayerData;

	void Awake () {
        DontDestroyOnLoad(this);
        _filePath = Application.persistentDataPath + "/savedata.dat";
        Load();

        Instance = this;
	}

    private void Load()
    {
        if (File.Exists(_filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(_filePath, FileMode.Open, FileAccess.Read);
            PlayerData =(PlayerData) bf.Deserialize(file);

            file.Close();
        }
        else
        {
            PlayerData = new PlayerData();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(_filePath, FileMode.OpenOrCreate, FileAccess.Write);

        bf.Serialize(file, PlayerData);
        file.Close();
    }
}
