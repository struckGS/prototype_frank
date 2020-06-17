using UnityEngine;

public class Entity : MonoBehaviour {

	protected GameManager game;

	public CharacterController controller;

	public float healthPoints;
	public float moveSpeed;
	public float mass;

	public Transform groundCheck;
	public float groundDistance;

	public bool animateDamage;
	public Color damageTint;
	public float tintDuration;
	Color defaultTint;
	Material mat;
	float delta;

	protected Vector3 velocity;
	protected bool isGrounded;

    void Start() {
		game = FindObjectOfType<GameManager>();
		if (animateDamage) {
			mat = GetComponent<MeshRenderer>().material;
			defaultTint = mat.color;
		}
    }

	void CheckGrounded() {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, game.groundMask);
	}

	public virtual void CalculateVelocity() {
		if (isGrounded)
			velocity.y = mass * -game.staticGravity;
		else
			velocity.y += mass * -game.gravity * Time.deltaTime;
	}

    void Update() {
		if (animateDamage) {
			if (delta <= 0) {
				delta = 0;
			} else {
				float fraction = Mathf.SmoothStep(1, 0, delta / tintDuration);
				mat.color = Color.Lerp(damageTint, defaultTint, fraction);
			}
			delta -= Time.deltaTime;
		}

		CheckGrounded();
		CalculateVelocity();

		controller.Move(velocity * Time.deltaTime);
    }

	public void TakeDamage(float damage) {
		healthPoints -= damage;
		if (healthPoints <= 0) {
			Die();
		} else if (animateDamage) {
			delta = tintDuration;
		}
	}

	void Die() {
		Destroy(gameObject);
	}
}
