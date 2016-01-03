using UnityEngine;
using System.Collections;

public class MovingPipe : MonoBehaviour {

    public float MaxMovingDistance;
    public float MovingDistance;
    public Direction Direction;

    private Vector3 _startingPoint;
    private int _direction;

    private LogicHandler _logic;

    void Start()
    {
        var ran = Random.Range(0, 2);
        _direction = ran == 0 ? 1 : -1;
        _startingPoint = transform.position;

        _logic = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<LogicHandler>();
    }

	void Update () {

        if (_logic.Paused)
        {
            return;
        }

        float distanceToMove = Time.deltaTime * MovingDistance * _direction;
        float position = Direction == Direction.Vertical ? transform.position.y : transform.position.x;
        float startingPosition = Direction == Direction.Vertical ? _startingPoint.y : _startingPoint.x;

        if (Direction == Direction.Vertical)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + distanceToMove,
                transform.position.z);
        }
        else
        {
            transform.position = new Vector3(
                transform.position.x + distanceToMove,
                transform.position.y,
                transform.position.z);
        }

	   

        if (_direction > 0)
        {
            if (position >= startingPosition + MaxMovingDistance)
            {
                _direction *= -1;
            }
        }
        else
        {
            if (position <= startingPosition - MaxMovingDistance)
            {
                _direction *= -1;
            }
        }
	}
}
