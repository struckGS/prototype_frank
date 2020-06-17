using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage = 1f;
	public float range = 100f;

	public Transform cam;
	public ParticleSystem muzzleFlash;

	GameManager game;

	void Update() {
		game = FindObjectOfType<GameManager>();
		if (Input.GetButtonDown("Fire1")) Shoot();
    }

	void Shoot() {
		muzzleFlash.Play();
		RaycastHit hit;
		if (Physics.Raycast(cam.position, cam.forward, out hit, range, game.enemyMask)) {
			Entity entity = hit.transform.GetComponent<Entity>();
			if (entity != null) entity.TakeDamage(damage);
		}
	}
}
