using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	public void LoadLevel(string level) {
        Application.LoadLevel(level);
	}
}
