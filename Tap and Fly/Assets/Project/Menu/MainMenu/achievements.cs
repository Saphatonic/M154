using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using System.Collections;

public class achievements : MonoBehaviour {

    public void OpenAchievements()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Social.ShowAchievementsUI();
                }
            });
        }
    }
}
