using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

	public GameObject BackgroundPreset;

	private Camera _cam;
	private GameObject[] _backgroundList;
    private float _leftCamEdge;
    private float _rightEdge;

	void Start()
	{
		_cam = GetComponent<Camera>();
		_backgroundList = new GameObject[2];
		_backgroundList[0] = BackgroundPreset;
		_backgroundList[1] = InstantiateBackground(_backgroundList[0]);
        GetEdge();
	}

	void FixedUpdate () {
        var _leftCamEdge = _cam.ScreenToWorldPoint(new Vector2(0, 0)).x;

        if (_rightEdge < _leftCamEdge)
		{
			Destroy(_backgroundList[0]);			
			_backgroundList[0] = _backgroundList[1];
			_backgroundList[1] = InstantiateBackground(_backgroundList[0]);
            GetEdge();
		}
	}

    private void GetEdge()
    {
        _rightEdge = _backgroundList[0].GetComponent<Collider2D>().bounds.center.x + _backgroundList[0].GetComponent<Collider2D>().bounds.extents.x;
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
