using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject Player;
	public float Offset;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(Player.transform.position.x + Offset, transform.position.y, transform.position.z);
	}
}
