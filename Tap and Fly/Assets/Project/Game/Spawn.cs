using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Spawn : MonoBehaviour {

    public Camera Cam;
    public List<GameObject> SpawnObjects;
    public float Distance;

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

        foreach (var spawn in _spawnedObjects)
        {
            if (GetCenter(spawn) + GetExtent(spawn) < LeftCamEdge())
            {
                _spawnedObjects.Remove(spawn);
                Destroy(spawn);
            }
        }
	}

    private void InstantiateSpawnObject(GameObject last)
    {
        // Random obstacle
        GameObject spawn = SpawnObjects[Random.Range(0, SpawnObjects.Count)];

        //Calculate y position
        float height = spawn.GetComponent<Height>().AvailableHeights[Random.Range(0, spawn.GetComponent<Height>().AvailableHeights.Length)];
        float yPos = Cam.ScreenToWorldPoint(new Vector2(0, Screen.height * height)).y;

        //Instantiate
        Vector3 position;
        if (last == null)
        {
            position = new Vector3(RightCamEdge(), yPos, spawn.transform.position.z);
        }
        else 
        {
            position = new Vector3(GetCenter(last) + Distance, yPos, spawn.transform.position.z);
        }
        Quaternion rotation = spawn.transform.rotation;
        var spawningObject = Instantiate(spawn, position, rotation) as GameObject;

        // Add Extent 
        position.x += GetExtent(spawningObject);
        spawningObject.transform.position = position;

        _spawnedObjects.Add(spawningObject);
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

    private float GetExtent(GameObject gameObject)
    {
        return gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
    }
}
