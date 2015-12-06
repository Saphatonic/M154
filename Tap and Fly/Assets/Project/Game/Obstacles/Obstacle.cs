using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public float[] AvailableHeights;
    public GameObject[] Coins;

    private bool _active;

    public void Start(){
        _active = true;
    }

    public void CoinsSetActive(bool value)
    {
        foreach (var coin in Coins)
        {
            coin.SetActive(value);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && _active)
        {
            other.GetComponent<Player>().Score++;
            _active = false;
        }
    }
}
