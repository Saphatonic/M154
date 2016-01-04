using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class SkinListInjector : MonoBehaviour {

    public GameObject ShopItemPrefab;
    private List<GameObject> _list;

	void Start () 
    {
        _list = new List<GameObject>();

        var players = SaveData.Instance.AvailablePlayers.OrderBy(x => x.Price);

        foreach (var player in players)
        {
            var gameObject = Instantiate(ShopItemPrefab, ShopItemPrefab.transform.position, ShopItemPrefab.transform.rotation) as GameObject;

            ShopItem shopItem = gameObject.GetComponent<ShopItem>();
            shopItem.Image.sprite = player.Sprite;
            shopItem.NameText.text = player.Name;
            shopItem.PriceText.text = player.Price.ToString();
            shopItem.Id = SaveData.Instance.AvailablePlayers.IndexOf(player);

            if (SaveData.Instance.PlayerData.OwnedSkins.Contains(SaveData.Instance.AvailablePlayers.IndexOf(player)))
            {
                shopItem.LockedImage.enabled = false;
                shopItem.PriceText.text = "";
                shopItem.Coin.enabled = false;
            }

            gameObject.transform.SetParent(transform, false);
            _list.Add(gameObject);
        }
	}

    void Update()
    {
        foreach (var player in _list)
        {
            var shopItem = player.GetComponent<ShopItem>();
            if (SaveData.Instance.PlayerData.PlayerId == shopItem.Id)
            {
                shopItem.BackgroundImage.color = new Color(0.9f, 0.65f, 0.4f);
            }
            else
            {
                shopItem.BackgroundImage.color = new Color(1,1,1);
            }
        }
    }
}
