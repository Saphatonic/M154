using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Spawn : MonoBehaviour {

    public Camera Cam;
    public List<GameObject> SpawnObjects;
    public float Distance;
    public int CoinPercentage;

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
        // Spawn Obstacle
        GameObject spawn = SpawnObjects[Random.Range(0, SpawnObjects.Count)];        

        //Calculate y position
        var availableHeights = spawn.GetComponent<Obstacle>().AvailableHeights;
        float height = availableHeights[Random.Range(0, availableHeights.Length)];
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

        // Random obstacle
        int typeNumber = Random.Range(1, 101);
        if (typeNumber > CoinPercentage)
        {
            spawningObject.GetComponent<Obstacle>().CoinsSetActive(false);
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

    private float GetExtent(GameObject gameObject)
    {
        return gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
    }
}
