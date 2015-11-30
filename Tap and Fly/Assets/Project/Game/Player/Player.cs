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
    private Animator _animator;

    public void Start()
    {
        _inputHandler = InputHandler.GetComponent<InputHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update ()
	{
		if (_inputHandler.SingleTouch.Began)
		{
            Tap();
		}

        UpdateAnimation();
    }

    // Physics
	void FixedUpdate()
    {
        if (!IsDead)
		{	
			// Rotate
			_rigidbody.MoveRotation(_rigidbody.velocity.y * 6);
			// Reset Force y
			_rigidbody.velocity = new Vector2(0,_rigidbody.velocity.y);
			// Fly
			_rigidbody.AddForce(new Vector2(Speed, 0));
		}
				
    }

    public void Tap()
    {
        // Play Sound
        FlapSound.Play();
        // Reset Force y
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        // Apply Force
        _rigidbody.AddForce(new Vector2(0, TapForce));
    }

    public void Die()
    {
		IsDead = true;
		_rigidbody.Sleep();
        // Sounda and Animation 
        HitSound.Play();
        FallSound.Play();
        _animator.SetBool("Hit", true);
    }

    private void UpdateAnimation()
    {
        if (_rigidbody.velocity.y >= 0)
        {
            _animator.SetBool("Flap", true);
        }
        else
        {
            _animator.SetBool("Flap", false);
        }
    }
}
