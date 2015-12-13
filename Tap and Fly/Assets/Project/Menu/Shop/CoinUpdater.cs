using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinUpdater : MonoBehaviour {

    public Text Coins; 

	void Update () {
        Coins.text = SaveData.Instance.PlayerData.Coins.ToString();
	}
}
