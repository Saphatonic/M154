using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    // References
    public MenuManager MenuManager;
    public Menu Endscreen;
    public InputHandler InputHandler;
    public AudioSource FlapSound;
    public AudioSource HitSound;
    public AudioSource FallSound;
    public AudioSource ScoreSound;
    public AudioSource CoinSound;
    // Set
    public float TapForce;
	public float Speed;
    // Get
    public bool IsDead;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            ScoreSound.Play();
        }
    }
    public int Coins
    {
        get { return _coins; }
        set
        {
            _coins = value;
            CoinSound.Play();
        }
    }
    // Private
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private int _score;
    private int _coins;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _coins = SaveData.Instance.PlayerData.Coins;
    }

	// Update is called once per frame
	void Update ()
	{
        if (InputHandler.SingleTouch.Began)
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
		_rigidbody.isKinematic = true;
        // Sounda and Animation 
        HitSound.Play();
        FallSound.Play();
        _animator.SetBool("Hit", true);

        InputHandler.DisableControls = true;
        MenuManager.ShowMenu(Endscreen);
    }

    private void UpdateAnimation()
    {
        if (_rigidbody.velocity.y > 0)
        {
            _animator.SetBool("Flap", true);
        }
        else
        {
            _animator.SetBool("Flap", false);
        }
    }
}
