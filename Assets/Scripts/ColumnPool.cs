using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

	private GameObject[] columns; //Columns Object
	public GameObject columPrefab;
	public int columnPoolSize = 5; //Number of columns inside Game
	public float SpawnRate = 4f;
	private Vector2 objectPoolPosition = new Vector2 (-15,-25);     //A holding position for our unused columns offscreen.
	private float timeSinceLastSpawned;
	public float columnMin = -1f;                                   //Minimum y value of the column position.
	public float columnMax = 3.5f;                                  //Maximum y value of the column position.
	private int currentColumn = 0;                                  //Index of the current column in the collection.
	private float spawnXPosition = 10f;

	// Use this for initialization
	void Start () {
		columns = new GameObject[columnPoolSize];
		for (int i = 0; i < columnPoolSize; i++) {
			columns [i] = (GameObject)Instantiate (columPrefab, objectPoolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawned += Time.deltaTime;
		if (GameControl.instance.gameOver == false && timeSinceLastSpawned > SpawnRate) 
		{
			timeSinceLastSpawned = 0;
			float spawnYPosition = Random.Range (columnMin, columnMax);

			//...then set the current column to that position.
			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

			//Increase the value of currentColumn. If the new size is too big, set it back to zero
			currentColumn ++;

			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}
}
