using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public int holeCount;
	public Transform wallPrefab;
	public Transform pinPrefab;
	
	private List<GameObject> walls;
	private List<GameObject> pins;

	// Use this for initialization
	void Start () {
		instantiateWalls();
		instantiatePins ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void instantiateWalls() {
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
	
	private void instantiatePins() {
		pins = new List<GameObject>();
		foreach (var wall in walls) {
			var pin = ((Transform) Instantiate(pinPrefab)).gameObject;
			pin.transform.localPosition = new Vector3(wall.transform.localPosition.x, 0f, 1f);
//			pin.transform.localScale = Vector3.one;
			pins.Add(wall);
		}
		
	}
}
