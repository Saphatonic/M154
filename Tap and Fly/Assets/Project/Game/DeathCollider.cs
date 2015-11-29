using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

    public bool IsDead;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsDead = true;
        }
    }
}
