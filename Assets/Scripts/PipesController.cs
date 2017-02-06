using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour {
	public int numPipes = 5;
	public float distanceBetweenPipes = 1.5f;
	public float pipeUpperLimit = 0.44f;
	public float pipeLowerLimit = -0.42f;

	float pipeMoveDistance;

	void Start() {
		pipeMoveDistance = distanceBetweenPipes * numPipes;
		randomizeVerticalPosition();
	}

	public void randomizeVerticalPosition() {
		Vector3 pos = transform.position;
		pos.y = Random.Range(pipeLowerLimit, pipeUpperLimit);
		transform.position = pos;
	}

	public void movePipes() {
		Vector3 pos = transform.position;
		pos.x = pipeMoveDistance + transform.position.x;
		pos.y = Random.Range(pipeLowerLimit, pipeUpperLimit);
		transform.position = pos;
	}
}
