using UnityEngine;

public class GameManager : MonoBehaviour {

	public float staticGravity;
	public float gravity;

	public LayerMask groundMask;
	public LayerMask enemyMask;

	public Transform player;
}