using UnityEngine;
using System.Collections;

public class Pendulum : MonoBehaviour {

	public HingeJoint2D Hinge;

    private LogicHandler _logic;
    private Rigidbody2D _rg;

    void Start()
    {
        _logic = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<LogicHandler>();
        _rg = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {

        if (_logic.Paused)
        {
            Hinge.useMotor = false;
            _rg.isKinematic = true;
            return;
        }
        else
        {
            _rg.isKinematic = false;
            Hinge.useMotor = true;
        }

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
