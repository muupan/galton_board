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
	public Transform planePrefab;
	
	private List<GameObject> walls;
	private List<GameObject> pins;
	private List<GameObject> balls;
	
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
		
		if (Input.GetKeyUp ("r")) {
			Reset ();
		}
		
		if (Input.GetKeyUp ("left")) {
			if (holeCount > 13) {
				holeCount --;
				Reset ();
			}
		}
		
		if (Input.GetKeyUp ("right")) {
			holeCount ++;
			Reset ();
		}
		
		secondsFromLastSpawning += Time.deltaTime;
		while (secondsFromLastSpawning > spawningInterval) {
			InstantiateBall();
			secondsFromLastSpawning -= spawningInterval;
		}
	}
	
	private void Reset() {
		foreach (var wall in walls) {
			Destroy (wall);
		}
		foreach (var pin in pins) {
			Destroy (pin);
		}
		foreach (var ball in balls) {
			Destroy (ball);
		}
		Init ();
	}
	
	private void Init() {
		wallCount = holeCount - 1;
		secondsFromLastSpawning = 0f;
		wallWidth = 6f / wallCount;
		InstantiateObjects();
		balls = new List<GameObject>();
	}	
	
	private void InstantiateBall() {
		var ball = ((Transform) Instantiate(ballPrefab)).gameObject;
		ball.transform.localPosition = new Vector3((positionInterval - ballSize) * (Random.value - 0.5f), 13f, 1f);
		ball.transform.localScale = new Vector3(ballSize, ballSize, ballSize);
		//ball.renderer.material.color = new Color(Random.Range(0, 0xFF), Random.Range (0, 0xFF), Random.Range (0, 0xFF), 1);
		ball.renderer.material.color = new Color(Mathf.Sqrt(Random.value), Mathf.Sqrt(Random.value), Mathf.Sqrt(Random.value), 1);
		balls.Add(ball);
	}
	
	private void InstantiateObjects() {
		var spaceForHole = (19f - wallWidth * wallCount) / holeCount;
		ballSize = spaceForHole * 0.82f;
		positionInterval = spaceForHole + wallWidth;
		var xOffset = 9.5f - spaceForHole - wallWidth / 2f;
		InstantiateWalls(xOffset);
		//InstantiatePins(xOffset + positionInterval);
		InstantiatePins(xOffset);
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
		var pinCount = holeCount - 2;
		var yInterval = Mathf.Sin (Mathf.PI / 3f) * positionInterval;
		var yOffset = -5.5f;
		for (var line = 0; line < pinCount + 2; ++line) {
			//var xOffsetOfCurrentLine = xOffset - positionInterval * (line / 2f);
			var xOffsetOfCurrentLine = xOffset - positionInterval * ((line % 2) * 0.5f);
			var y = yOffset + yInterval * line;
			//var pinCountOfCurrentLine = pinCount - line;
			var pinCountOfCurrentLine = pinCount + ((line + 1) % 2);
			for (var i = 0; i < pinCountOfCurrentLine; ++i) {
				var x = xOffsetOfCurrentLine - positionInterval * i;
				var pin = ((Transform) Instantiate(pinPrefab)).gameObject;
				pin.transform.localPosition = new Vector3(x, y, 1f);
				pins.Add(pin);
				
			}
		}
		
//		var leftPlane = ((Transform) Instantiate(wallPrefab)).gameObject;
//		leftPlane.transform.localPosition = new Vector3(xOffset, yOffset, 1f);
//		leftPlane.transform.localScale = new Vector3(100f, wallWidth, 1f);
//		leftPlane.transform.Rotate(0f, 0f, -60f);
//		
//		var rightPlane = ((Transform) Instantiate(wallPrefab)).gameObject;
//		rightPlane.transform.localPosition = new Vector3(-xOffset, yOffset, 1f);
//		rightPlane.transform.localScale = new Vector3(100f, wallWidth, 1f);
//		rightPlane.transform.Rotate(0f, 0f, 60f);
	}
}
