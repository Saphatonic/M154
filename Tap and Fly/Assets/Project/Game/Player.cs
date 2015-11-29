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
            // Apply Force
            _rigidbody.velocity = new Vector2(0,0);
            _rigidbody.AddForce(new Vector2(0, TapForce));
        }
    }

    // Physics
    void FixedUpadte()
    {
    }

    public void Die()
    {
        GetComponent<Rigidbody2D>().Sleep();
        HitSound.Play();
        FallSound.Play();
    }
}
