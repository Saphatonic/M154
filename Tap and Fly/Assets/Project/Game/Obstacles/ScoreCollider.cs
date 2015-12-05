using UnityEngine;
using System.Collections;

public class ScoreCollider : MonoBehaviour {
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().Score++;
        }
    }
}
