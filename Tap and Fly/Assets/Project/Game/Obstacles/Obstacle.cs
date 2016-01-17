using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public GameObject[] Coins;
    public int MinimumScore;
    public int points;

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
            other.GetComponent<Player>().Score += points;
            _active = false;
        }
    }
}
