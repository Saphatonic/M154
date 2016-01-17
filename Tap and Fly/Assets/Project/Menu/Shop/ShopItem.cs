using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ShopItem : MonoBehaviour {

    public Image Image;
    public Image Coin;
    public Image LockedImage;
    public Image BackgroundImage;
    public Text PriceText;
    public Text NameText;
    public int Id;

    public void Buy()
    {
        int price = int.Parse(PriceText.text);
        if (SaveData.Instance.PlayerData.Coins >= price)
        {
            SaveData.Instance.PlayerData.Coins -= price;
            SaveData.Instance.PlayerData.OwnedSkins.Add(Id);
            SaveData.Instance.PlayerData.PlayerId = Id;
            LockedImage.enabled = false;
            Coin.enabled = false;
            PriceText.text = string.Empty;

            if (Social.localUser.authenticated)
            {
                if (NameText.text == "Ricky")
                {
                    Social.ReportProgress(Resources.achievement_kraaah, 100.0f, (bool success) => { });
                }

            }

            SaveData.Instance.Save();
        }
    }

    public void Choose()
    {
        if (SaveData.Instance.PlayerData.OwnedSkins.Contains(Id))
        {
            SaveData.Instance.PlayerData.PlayerId = Id;
            SaveData.Instance.Save();
        }
    }
}
