using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectCollider : MonoBehaviour {

	public Transform target;
	private SphereCollider _collider;
	private Vector3 _colliderOffset;
	private float _colliderRadius;

	void Start() {
		_collider = GetComponent<SphereCollider>();
		_colliderOffset = _collider.center;
		_colliderRadius = _collider.radius;
	}

	void Update () {
		Plane plane = new Plane(Vector3.up, target.position);
		float distance;

		Vector3 v = transform.position + _colliderOffset;
		Ray ray = new Ray(v, Camera.main.transform.position - v);
		if(!plane.Raycast(ray, out distance)) {
			throw new System.InvalidOperationException();
		}
		Vector3 center = ray.GetPoint(distance);

		v = transform.position + _colliderOffset + Vector3.forward * _colliderRadius;
		ray = new Ray(v, Camera.main.transform.position - v);
		if(!plane.Raycast(ray, out distance)) {
			throw new System.InvalidOperationException();
		}
		Vector3 up = ray.GetPoint(distance);

		_collider.center = transform.InverseTransformPoint(center);
		_collider.radius = Vector3.Distance(center, up);
	}
/*
	void OnDrawGizmos() {
		SphereCollider collider = GetComponent<SphereCollider>();
		Debug.DrawLine(transform.position, transform.position + Camera.main.transform.up);
		Debug.DrawRay(transform.position + collider.center, Camera.main.transform.position - (transform.position + collider.center));
		Vector3 v = transform.position + collider.center + Camera.main.transform.up * collider.radius;
		Debug.DrawRay(v, Camera.main.transform.position - v);
	}*/
}
