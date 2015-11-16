using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Vector3 position;
	
	public int speed = 5;
	public int rotationSpeed = 1;
	public float gravity = 1f;
	
	// Update is called once per frame
	void Update () {
		position = transform.position;

		// Rotate
		transform.Rotate(Vector3.forward * rotationSpeed);

		// Update Gravity 
		gravity += 0.2f;
		// Update Position
		// position.y -= gravity * Time.deltaTime;
		transform.position = position;
	}
}
