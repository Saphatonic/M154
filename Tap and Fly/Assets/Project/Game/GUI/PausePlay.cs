using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PausePlay : MonoBehaviour {

    public LogicHandler LogicHandler;
    public Player Player;
    public Sprite PlaySprite;
    public Sprite PauseSprite;

    private bool _pause;

	public void Update () {
        if (Player.IsDead || LogicHandler.IsStart)
        {
            GetComponent<CanvasGroup>().interactable = false;
        }
        else
        {
            GetComponent<CanvasGroup>().interactable = true;
        }
	}
	
	public void ChangePause()
    {
        if(!_pause)
        {
            LogicHandler.PauseGame();
            _pause = true;
            this.GetComponent<Image>().sprite = PlaySprite;
        }
        else
        {
            LogicHandler.ContinueGame();
            _pause = false;
            this.GetComponent<Image>().sprite = PauseSprite;
        }
    }
}
