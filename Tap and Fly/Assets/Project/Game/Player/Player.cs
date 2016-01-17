using GooglePlayGames;
using UnityEngine;
using UnityEngine.SocialPlatforms;
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
	public GameObject AvatarSprite;
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
        GetComponent<Animator>().runtimeAnimatorController = UnityEngine.Resources.Load(SaveData.Instance.AvailablePlayers[SaveData.Instance.PlayerData.PlayerId].Animator) as RuntimeAnimatorController;
        AvatarSprite.GetComponent<SpriteRenderer>().sprite = SaveData.Instance.AvailablePlayers[SaveData.Instance.PlayerData.PlayerId].Sprite;

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

        CheckAchievements();

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
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(Resources.achievement_ouch_that_hurts, 100.0f, null);

            Social.ReportScore(Score, Resources.leaderboard_leaderboard, null);
        }

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

    private void CheckAchievements()
    {
        if (Social.localUser.authenticated)
        {
            if (_coins >= 20000)
            {
                Social.ReportProgress(Resources.achievement_im_rich_bitch, 100.0f, (bool success) => { });
            }

            if (_score >= 10)
            {
                Social.ReportProgress(Resources.achievement_10__points, 100.0f, (bool success) => { });
            }

            if (_score >= 50)
            {
                Social.ReportProgress(Resources.achievement_50__points, 100.0f, (bool success) => { });
            }

            if (_score >= 100)
            {
                Social.ReportProgress(Resources.achievement_100__points, 100.0f, (bool success) => { });
            }
        }
    }
}
