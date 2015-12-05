using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

    private float _currentTime;
    public float MaxTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _currentTime += Time.deltaTime;

        if (_currentTime >= MaxTime)
        {
            Application.LoadLevel("Menu");
        }
	}
}
