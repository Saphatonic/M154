using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Spawn : MonoBehaviour {

    public Camera Cam;
    public List<GameObject> SpawnObjects;
    public float Distance;
    public int CoinPercentage;
    public Player Player;

    public float MinHeight;
    public float MaxHeight;
    public float HeightStep;

    private float _lastHeight;

    private List<GameObject> _spawnedObjects;

	// Use this for initialization
	void Start () {
        _spawnedObjects = new List<GameObject>();
        InstantiateSpawnObject(null);
	}
	
	// Update is called once per frame
	void Update () {
        if (GetCenter(_spawnedObjects.Last()) < RightCamEdge())
        {
            InstantiateSpawnObject(_spawnedObjects.Last());
        }

        for (int i = 0; i < _spawnedObjects.Count;i++)
        {
            var spawn = _spawnedObjects[i];

            if (GetCenter(spawn) + GetExtent(spawn) < LeftCamEdge())
            {
                _spawnedObjects.Remove(spawn);
                Destroy(spawn);
            }
        }
	}

    private void InstantiateSpawnObject(GameObject last)
    {
        var avaialbleSpawnObjects = SpawnObjects.Where(x => Player.Score >= x.GetComponent<Obstacle>().MinimumScore).ToList();
        // Spawn Obstacle
        GameObject spawn = avaialbleSpawnObjects[Random.Range(0, avaialbleSpawnObjects.Count)];        

        //Calculate y position
        float height;
        if (_lastHeight == 0)
        {
            height = Random.Range(MinHeight, MaxHeight);
        }
        else
        {
            height = AddOrSubstractStepAtRandom(HeightStep, _lastHeight, MinHeight, MaxHeight);
        }
        _lastHeight = height;
        float yPos = Cam.ScreenToWorldPoint(new Vector2(0, Screen.height * height)).y;

        //Instantiate
        Vector3 position;
        if (last == null)
        {
            position = new Vector3(RightCamEdge(), yPos, spawn.transform.position.z);
        }
        else 
        {
            position = new Vector3(GetRightEdge(last) + Distance, yPos, spawn.transform.position.z);
        }
        Quaternion rotation = spawn.transform.rotation;
        var spawningObject = Instantiate(spawn, position, rotation) as GameObject;

        // Add Extent 
        position.x += GetExtent(spawningObject);
        spawningObject.transform.position = position;

        _spawnedObjects.Add(spawningObject);

        // Enable or disable coins
        int typeNumber = Random.Range(1, 101);
        if (typeNumber > CoinPercentage)
        {
            spawningObject.GetComponent<Obstacle>().CoinsSetActive(false);
        }
    }

    private static float AddOrSubstractStepAtRandom(float step, float height, float min, float max)
    {
        float addSubRand = Random.Range(step, -step);
        if (height + step < min || height + step > max)
        {
            return height - step;
        }
        else
        {
            return height + step;
        }
    }

    private float RightCamEdge()
    {
        return Cam.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
    }

    private float LeftCamEdge()
    {
        return Cam.ScreenToWorldPoint(new Vector2(0, 0)).x;
    }

    private float GetCenter(GameObject gameObject)
    {
        return gameObject.GetComponent<BoxCollider2D>().bounds.center.x;
    }

	private float GetRightEdge(GameObject gameObject)
	{
		return gameObject.GetComponent<BoxCollider2D>().bounds.center.x +
			gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
	}

    private float GetExtent(GameObject gameObject)
    {
        return gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
    }
}