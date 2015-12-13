using UnityEngine;
using System.Collections;

public class CoinCollider : MonoBehaviour {

    public int Value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Coins += Value;
            Destroy(gameObject);
        }
    }
}
