﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMover : MonoBehaviour {
	public float skyToPlayerSpeedRatio = 0.9f;
	Rigidbody2D player;

	void Start() {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");

		if(player_go == null) {
			Debug.LogError("Couldn't find an object with tag 'Player'");
			return;
		}

		player = player_go.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate() {
		float vel = player.velocity.x * skyToPlayerSpeedRatio;
		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
	}
}
