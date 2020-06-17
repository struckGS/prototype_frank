using UnityEngine;

public class Player : Entity {
	public float jumpHeight;

	public override void CalculateVelocity() {
		base.CalculateVelocity();

		if (isGrounded && Input.GetButtonDown("Jump"))
			velocity.y = Mathf.Sqrt(jumpHeight * 2f * mass * game.gravity);

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		velocity = new Vector3(0, velocity.y, 0) + move.normalized * moveSpeed;
	}
}