using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

    public CanvasGroup Group;

	void Start () {
        if (Social.localUser.authenticated)
        {
            Group.alpha = 0;
            Group.interactable = false;
        }
	}

    public void Click()
    {

        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Group.alpha = 0;
                Group.interactable = false;
                Social.ReportScore(SaveData.Instance.PlayerData.Highscore, Resources.leaderboard_leaderboard, null);
            }
        });
    }
}
