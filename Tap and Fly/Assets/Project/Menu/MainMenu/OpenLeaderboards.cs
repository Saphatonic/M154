using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using System.Collections;

public class OpenLeaderboards : MonoBehaviour
{
    public void OpenLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(Resources.leaderboard_leaderboard);            
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    PlayGamesPlatform.Instance.ShowLeaderboardUI(Resources.leaderboard_leaderboard); 
                }
            });
        }
    }
}
