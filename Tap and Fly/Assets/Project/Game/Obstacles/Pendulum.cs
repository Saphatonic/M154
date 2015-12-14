using UnityEngine;
using System.Collections;

public class Pendulum : MonoBehaviour {

	public HingeJoint2D Hinge;

	// Update is called once per frame
	void Update () {
		if(Hinge.jointAngle >= Hinge.limits.max)
		{
			ChangeDirection();
		} 
		else if(Hinge.jointAngle <= Hinge.limits.min)
		{
			ChangeDirection();
		}
	}

	private void ChangeDirection()
	{
		var motor = Hinge.motor;
		motor.motorSpeed *= -1;
		Hinge.motor = motor;
	}
}
