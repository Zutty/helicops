using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 3f;
	public Transform[] wheels;
	public float wheelRadius = 0.35f;

	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		foreach(Transform wheel in wheels) {
			wheel.Rotate(Vector3.right * (speed * Time.deltaTime * Mathf.Rad2Deg) / wheelRadius);
		}
	}
}
