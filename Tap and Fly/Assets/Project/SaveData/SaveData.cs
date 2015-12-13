using UnityEngine;
using UnityEditor.Animations;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData : MonoBehaviour {
    
    [HideInInspector]
    public static SaveData Instance { get; private set; }
	// Instance
    public PlayerData PlayerData;
	//	Shop 
	public List<AvailablePlayer> AvailablePlayers;

	private string _filePath;
    private const string _version = "0.1";

	void Awake () {
        DontDestroyOnLoad(this);
        _filePath = Application.persistentDataPath + "/savedata_v" + _version + ".dat";
        Load();

        Instance = this;
	}

    private void Load()
    {
        if (File.Exists(_filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(_filePath, FileMode.Open, FileAccess.Read);
            SerializableClass serializedObject = (SerializableClass)bf.Deserialize(file);

            PlayerData = serializedObject.PlayerData;
            AvailablePlayers = serializedObject.AvailablePlayers;

            file.Close();

            //Setting MasterVolume
            AudioListener.volume = PlayerData.MasterVolume;
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

        var serializableObject = new SerializableClass { AvailablePlayers = AvailablePlayers, PlayerData = PlayerData };

        bf.Serialize(file, serializableObject);
        file.Close();
    }
}

[Serializable]
public class AvailablePlayer
{
	public AnimatorController Animator;
	public Sprite Sprite;
    public string Name;
    public int Price;
    public bool Owned;
}

[Serializable]
public class SerializableClass
{
    public PlayerData PlayerData;
    public List<AvailablePlayer> AvailablePlayers;
}