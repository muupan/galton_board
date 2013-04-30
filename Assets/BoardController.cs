using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public int holeCount;
	public Transform wallPrefab;
	
	private List<GameObject> walls;

	// Use this for initialization
	void Start () {
		walls = new List<GameObject>();
		var wallCount = holeCount - 1;
		var wallWidth = 0.1f;
		var spaceForHole = (19f - wallWidth * wallCount) / holeCount;
		var xInterval = spaceForHole + wallWidth;
		for (var i = 0; i < wallCount; ++i) {
			var wall = ((Transform) Instantiate(wallPrefab)).gameObject;
			wall.transform.localPosition = new Vector3(9.5f - spaceForHole - 0.05f - xInterval * i, -10f, 1f);
			wall.transform.localScale = new Vector3(0.1f, 9f, 1f);
			walls.Add(wall);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
