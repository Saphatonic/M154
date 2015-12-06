using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicSlider : MonoBehaviour {

    public void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener(OnValueChanged);
        GetComponent<Slider>().value = SongPlayer.Instance.GetComponent<AudioSource>().volume;
    }

    public void OnValueChanged(float value)
    {
        SongPlayer.Instance.GetComponent<AudioSource>().volume = value;
    }
}
