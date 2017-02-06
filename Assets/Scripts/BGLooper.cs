using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {
	public int numBGPanels = 6;

	void OnTriggerEnter2D(Collider2D collider) {
		// for pipes
		if(collider.CompareTag("Pipes")) {
			collider.GetComponent<PipesController>().movePipes();
			return;
		}

		// for background tiles
		float widthOfBGObject = ((BoxCollider2D)collider).size.x;
		Vector3 pos = collider.transform.position;
		pos.x = widthOfBGObject * numBGPanels + collider.transform.position.x;
		collider.transform.position = pos;
	}
}
