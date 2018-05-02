using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject spawn_object;

	public float time_interval;
	public float separation;
	private float delta_time;
	private GameObject player;
	// Use this for initialization
	void Start () {
		delta_time = time_interval;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void GameTick()
	{
		Vector2 shift2D = Random.insideUnitCircle;
		Vector3 shift = new Vector3 (shift2D.x, 0.0f, shift2D.y);
		GameObject eblo = Instantiate (spawn_object, separation*shift, Quaternion.identity, player.transform);
		eblo.transform.SetParent (null);
	}

	// Update is called once per frame
	void Update () {
		delta_time -= Time.deltaTime;
		if (delta_time <= 0.0f) {
			delta_time += time_interval;
			GameTick();
		}
	}
}
