using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicSlider : MonoBehaviour {

    public void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener(OnValueChanged);
        GetComponent<Slider>().value = SaveData.Instance.PlayerData.MusicVolume;
        SongPlayer.Instance.GetComponent<AudioSource>().volume = SaveData.Instance.PlayerData.MusicVolume;
    }

    public void OnValueChanged(float value)
    {
        SaveData.Instance.PlayerData.MusicVolume = value;
        SongPlayer.Instance.GetComponent<AudioSource>().volume = value;
        SaveData.Instance.Save();
    }
}
