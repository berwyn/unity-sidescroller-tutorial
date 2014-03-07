using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour {

	#region Designer Variables
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(-1, 0);
	#endregion

	private Vector2 movement;

	void Update() {
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}
}
