using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeSound : MonoBehaviour {

    public void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener(OnValueChanged);
        GetComponent<Slider>().value = SaveData.Instance.PlayerData.MasterVolume;
    }

    public void OnValueChanged(float value)
    {
        AudioListener.volume = value;
        SaveData.Instance.PlayerData.MasterVolume = value;
        SaveData.Instance.Save();
    }
}
