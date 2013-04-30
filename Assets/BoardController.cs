using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public int wallCount;
	public Transform wallPrefab;
	
	private List<GameObject> walls;

	// Use this for initialization
	void Start () {
		walls = new List<GameObject>();
		for (var i = 0; i < wallCount; ++i) {
			var wall = ((Transform) Instantiate(wallPrefab)).gameObject;
			wall.transform.localPosition = new Vector3(0, 0, 1);
			walls.Add(wall);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
