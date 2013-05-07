using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public int holeCount;
	public Transform wallPrefab;
	public Transform pinPrefab;
	public Transform ballPrefab;
	
	private List<GameObject> walls;
	private List<GameObject> pins;

	// Use this for initialization
	void Start () {
		InstantiateObjects();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void InstantiateBall() {
		
	}
	
	private void InstantiateObjects() {
		var wallCount = holeCount - 1;
		var wallWidth = 0.2f;
		var spaceForHole = (19f - wallWidth * wallCount) / holeCount;
		var xInterval = spaceForHole + wallWidth;
		var xOffset = 9.5f - spaceForHole - 0.05f;
		InstantiateWalls(xOffset, xInterval, wallWidth);
		InstantiatePins(xOffset + xInterval, xInterval);
	}
	
	private void InstantiateWalls(float xOffset, float xInterval, float wallWidth) {
		walls = new List<GameObject>();
		var wallCount = holeCount - 1;
		for (var i = 0; i < wallCount; ++i) {
			var x = xOffset - xInterval * i;
			var wall = ((Transform) Instantiate(wallPrefab)).gameObject;
			wall.transform.localPosition = new Vector3(x, -10f, 1f);
			wall.transform.localScale = new Vector3(wallWidth, 9f, 1f);
			walls.Add(wall);
		}
	}
	
	private void InstantiatePins(float xOffset, float xInterval) {
		pins = new List<GameObject>();
		var pinCount = holeCount + 1;
		var yInterval = Mathf.Sin (Mathf.PI / 3f) * xInterval;
		var yOffset = -5.5f;
		for (var line = 0; line < pinCount - 1; ++line) {
			var xOffsetOfCurrentLine = xOffset - xInterval * (line / 2f);
			for (var i = 0; i < pinCount - line; ++i) {
				var x = xOffsetOfCurrentLine - xInterval * i;
				var y = yOffset + yInterval * line;
				var pin = ((Transform) Instantiate(pinPrefab)).gameObject;
				pin.transform.localPosition = new Vector3(x, y, 1f);
				pins.Add(pin);
			}
		}
	}
}
