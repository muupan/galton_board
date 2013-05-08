using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public int holeCount;
	public Transform wallPrefab;
	public float wallWidth;
	public float ballSize;
	public Transform pinPrefab;
	public Transform ballPrefab;
	
	private List<GameObject> walls;
	private List<GameObject> pins;
	
	private int wallCount;
	private float positionInterval;
	
	public float spawningInterval;
	private float secondsFromLastSpawning;

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		secondsFromLastSpawning += Time.deltaTime;
		while (secondsFromLastSpawning > spawningInterval) {
			InstantiateBall();
			secondsFromLastSpawning -= spawningInterval;
		}
	}
	
	private void Init() {
		wallCount = holeCount - 1;
		secondsFromLastSpawning = 0f;
		InstantiateObjects();
		InstantiateBall();
	}	
	
	private void InstantiateBall() {
		var ball = ((Transform) Instantiate(ballPrefab)).gameObject;
		ball.transform.localPosition = new Vector3(positionInterval * (Random.value - 0.5f), 12f, 1f);
		ball.transform.localScale = new Vector3(ballSize, ballSize, ballSize);
	}
	
	private void InstantiateObjects() {
		var spaceForHole = (19f - wallWidth * wallCount) / holeCount;
		positionInterval = spaceForHole + wallWidth;
		var xOffset = 9.5f - spaceForHole - wallWidth / 2f;
		InstantiateWalls(xOffset);
		InstantiatePins(xOffset + positionInterval);
	}
	
	private void InstantiateWalls(float xOffset) {
		walls = new List<GameObject>();
		var wallCount = holeCount - 1;
		for (var i = 0; i < wallCount; ++i) {
			var x = xOffset - positionInterval * i;
			var wall = ((Transform) Instantiate(wallPrefab)).gameObject;
			wall.transform.localPosition = new Vector3(x, -10f, 1f);
			wall.transform.localScale = new Vector3(wallWidth, 9f, 1f);
			walls.Add(wall);
		}
	}
	
	private void InstantiatePins(float xOffset) {
		pins = new List<GameObject>();
		var pinCount = holeCount + 1;
		var yInterval = Mathf.Sin (Mathf.PI / 3f) * positionInterval;
		var yOffset = -5.5f;
		for (var line = 0; line < pinCount - 1; ++line) {
			var xOffsetOfCurrentLine = xOffset - positionInterval * (line / 2f);
			for (var i = 0; i < pinCount - line; ++i) {
				var x = xOffsetOfCurrentLine - positionInterval * i;
				var y = yOffset + yInterval * line;
				var pin = ((Transform) Instantiate(pinPrefab)).gameObject;
				pin.transform.localPosition = new Vector3(x, y, 1f);
				pins.Add(pin);
			}
		}
	}
}
