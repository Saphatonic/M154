using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public bool Active
    {
        get
        {
            return GetComponent<Animator>().GetBool("Active");
        }
        set
        {
            GetComponent<Animator>().SetBool("Active", value);
        }
    }

    public void Awake()
    {
        var rect = GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Active)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = GetComponent<CanvasGroup>().interactable = true;
        }
        else
        {
            GetComponent<CanvasGroup>().blocksRaycasts = GetComponent<CanvasGroup>().interactable = false;
        }
	}
}
