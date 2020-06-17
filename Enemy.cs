using UnityEngine;

public class Enemy : Entity {
	public float RotationSpeed;

	public override void CalculateVelocity() {
		base.CalculateVelocity();

		Vector3 direction = game.player.position - transform.position;
		direction.y = 0;

		transform.rotation = Quaternion.Slerp(transform.rotation,
			Quaternion.LookRotation(direction),
			RotationSpeed * Time.deltaTime);

		velocity = new Vector3(0, velocity.y, 0) + transform.forward * moveSpeed;
	}
}