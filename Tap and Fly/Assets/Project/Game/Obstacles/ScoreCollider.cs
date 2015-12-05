using UnityEngine;
using System.Collections;

public class ScoreCollider : MonoBehaviour {

    private bool _active;

    public void Start(){
        _active = true;
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
