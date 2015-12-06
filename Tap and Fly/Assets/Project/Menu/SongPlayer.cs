using UnityEngine;
using System.Collections;

public class SongPlayer : MonoBehaviour {

    public static GameObject Instance;

	// Use this for initialization
	void Awake () {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = gameObject;
        }
        else if (Instance != gameObject)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
