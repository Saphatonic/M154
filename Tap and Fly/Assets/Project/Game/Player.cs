using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    // References
    public GameObject InputHandler;
    public AudioSource FlapSound;
    public AudioSource HitSound;
    public AudioSource FallSound;
    // Set
    public float TapForce;
	public float Speed;
    // Get
    [HideInInspector]
    public bool IsDead;
    // Private
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidbody;

    public void Start()
    {
        _inputHandler = InputHandler.GetComponent<InputHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update ()
	{
		if (_inputHandler.SingleTouch.Began)
		{
			// Play Sound
			FlapSound.Play();
			// Reset Force y
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x,0);
			// Apply Force
			_rigidbody.AddForce(new Vector2(0, TapForce));
		}
    }

    // Physics
	void FixedUpdate()
	{	if(_rigidbody.IsAwake())
		{	
			// Rotate
			_rigidbody.MoveRotation(_rigidbody.velocity.y * 6);
			// Reset Force y
			_rigidbody.velocity = new Vector2(0,_rigidbody.velocity.y);
			// Fly
			_rigidbody.AddForce(new Vector2(Speed, 0));
		}
				
    }

    public void Die()
    {
		IsDead = true;
		_rigidbody.Sleep();
        HitSound.Play();
        FallSound.Play();
    }
}
