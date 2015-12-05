using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

	public GameObject BackgroundPreset;

	private Camera _cam;
	private GameObject[] _backgroundList;

	void Start()
	{
		_cam = GetComponent<Camera>();
		_backgroundList = new GameObject[2];
		_backgroundList[0] = BackgroundPreset;
		_backgroundList[1] = InstantiateBackground(_backgroundList[0]);

	}

	// Update is called once per frame
	void FixedUpdate () {
		var rightEdge = _backgroundList[0].GetComponent<Collider2D>().bounds.center.x + _backgroundList[0].GetComponent<Collider2D>().bounds.extents.x;
		var leftCamEdge = _cam.ScreenToWorldPoint(new Vector2(0, 0)).x;

		if(rightEdge < leftCamEdge)
		{
			Destroy(_backgroundList[0]);
			
			_backgroundList[0] = _backgroundList[1];
			_backgroundList[1] = InstantiateBackground(_backgroundList[0]);
		}
	}

	private GameObject InstantiateBackground(GameObject firstBackground)
	{		
		return Instantiate(firstBackground,
		                                 new Vector3(
			firstBackground.transform.position.x + firstBackground.GetComponent<Collider2D>().bounds.size.x,
			firstBackground.transform.position.y,
			firstBackground.transform.position.z),
		                   firstBackground.transform.rotation) as GameObject;
	}
}
