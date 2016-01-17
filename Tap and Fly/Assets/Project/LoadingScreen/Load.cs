using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Load : MonoBehaviour {

    private float _currentTime;
    public float MaxTime;
    public Button Button;
    public CanvasGroup Login;
    private Vector2 _initialPosition;

	// Use this for initialization
	void Start () {
        _initialPosition = Button.transform.position;
        PlayGamesPlatform.Activate();
        Button.transform.position = new Vector2(Screen.width * 0.5f, Screen.height * -2);
        Login.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
        _currentTime += Time.deltaTime;

        if (_currentTime >= MaxTime)
        {
            SignIn();
            Button.transform.position = Vector2.Lerp(Button.transform.position, _initialPosition, 0.3f);
            Login.alpha = 1;
        }
	}

    public void SignIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Social.ReportScore(SaveData.Instance.PlayerData.Highscore, Resources.leaderboard_leaderboard, null);
                GoToMenu();
            }
        });
    }

    public void GoToMenu()
    {
        Application.LoadLevel("Menu"); 
    }
}
