using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !other.GetComponent<Player>().IsDead)
        {
            other.gameObject.GetComponent<Player>().Die();
        }
    }
}
