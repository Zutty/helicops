using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour {

	public Vector3 axis = Vector3.up;
	public float speed = 1000f;

	void Update () {
		transform.Rotate(axis * speed * Time.deltaTime);
	}
}
