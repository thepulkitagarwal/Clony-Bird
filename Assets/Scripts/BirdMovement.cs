using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour {
	public bool godMode = false;
	float flapSpeed = 100f;
	float forwardSpeed = 1f;

	bool didFlap = false;
	
	public bool dead = false;
	float deathCooldown;

	Rigidbody2D rigidbody2DComponent;
	Animator animator;

	void Start() {
		rigidbody2DComponent = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
	}

	void Update() {
		if(dead) {
			deathCooldown -= Time.deltaTime;

			if(deathCooldown <= 0) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
		else if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			didFlap = true;
		}
	}
	
	void FixedUpdate() {
		if(dead)
			return;

		rigidbody2DComponent.AddForce(Vector2.right * forwardSpeed);
		if(didFlap) {
			didFlap = false;
			animator.SetTrigger("DoFlap");
			rigidbody2DComponent.AddForce(Vector2.up * flapSpeed);
		}

		if(rigidbody2DComponent.velocity.y < 0) {
			float angle = Mathf.Lerp(0, -90, -rigidbody2DComponent.velocity.y/2f);
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
		else {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(godMode)
			return;
			
		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;
	}
}
