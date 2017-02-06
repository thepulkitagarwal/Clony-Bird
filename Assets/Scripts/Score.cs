using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	static int score = 0;
	static int highscore = 0;
	Text text;

	static public void AddPoint() {
		score++;
		if(score > highscore) highscore = score;
	}

	void Start() {
		score = 0;
		highscore = PlayerPrefs.GetInt("highscore", 0);
		text = GetComponent<Text>();
	}

	void OnDestroy() {
		PlayerPrefs.SetInt("highscore", highscore);
	}

	void Update() {
		text.text = "Score: " + score + "\nHighscore: "  + highscore;
	}
}
