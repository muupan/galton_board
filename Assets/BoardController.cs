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
		InstantiateObjects();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void InstantiateObjects() {
		var wallCount = holeCount - 1;
		var wallWidth = 0.1f;
		var spaceForHole = (19f - wallWidth * wallCount) / holeCount;
		var xInterval = spaceForHole + wallWidth;
		var xOffset = 9.5f - spaceForHole - 0.05f;
		InstantiateWalls(xOffset, xInterval);
		InstantiatePins(xOffset, xInterval);
	}
	
	private void InstantiateWalls(float xOffset, float xInterval) {
		walls = new List<GameObject>();
		var wallCount = holeCount - 1;
		for (var i = 0; i < wallCount; ++i) {
			var x = xOffset - xInterval * i;
			var wall = ((Transform) Instantiate(wallPrefab)).gameObject;
			wall.transform.localPosition = new Vector3(x, -10f, 1f);
			wall.transform.localScale = new Vector3(0.1f, 9f, 1f);
			walls.Add(wall);
		}
	}
	
	private void InstantiatePins(float xOffset, float xInterval) {
		pins = new List<GameObject>();
		var pinCount = holeCount - 1;
		for (var i = 0; i < pinCount; ++i) {
			var x = xOffset - xInterval * i;
			var pin = ((Transform) Instantiate(pinPrefab)).gameObject;
			pin.transform.localPosition = new Vector3(x, 0f, 1f);
			pins.Add(pin);
		}
	}
}
