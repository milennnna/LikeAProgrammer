using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public EnemyType type;
	private Rigidbody2D rigidBody;

	public float scaleOutFactor = 0.994f;
	public float minimalRelativeScaleFactor = 0.5f;
	public float minimalCollisionVelocityChange = 0.01f;

	public bool spawned = false;
	private bool fadingOut = false;
	private bool nearCollision = false;
	private Vector2 initialScaleFactor = new Vector2 (1.0f, 1.0f);
	private Vector2 nearCollisionVelocity;

	protected virtual bool rotateToVelocity () {
		return true;
	}

	protected virtual float rotationAngleCompensation() {
		return 90.0f;
	}

	void Awake ()
	{

		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		initialScaleFactor = gameObject.transform.localScale;
	}

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (nearCollision) {

			if ((rigidBody.velocity - nearCollisionVelocity).magnitude / nearCollisionVelocity.magnitude > minimalCollisionVelocityChange) {

				setCollidersEnabled (false);
				fadingOut = true;
			}
		}

		if (fadingOut) {

			gameObject.transform.localScale = gameObject.transform.localScale * scaleOutFactor;
			if (gameObject.transform.localScale.magnitude < minimalRelativeScaleFactor * initialScaleFactor.magnitude) {
				Destroy (gameObject);
			}
		}
	}

	public void setVelocity (Vector2 velocity)
	{
		rigidBody.velocity = velocity;

		if (rotateToVelocity ()) {
			float angle = Mathf.Atan2 (velocity.y, velocity.x) * 180.0f / Mathf.PI;
			float rotationAngle = angle + rotationAngleCompensation ();
			transform.Rotate (0.0f, 0.0f, rotationAngle);
		}
	}

	public void OnTriggerEnter2D (Collider2D otherCollider)
	{

		nearCollision = true;
		nearCollisionVelocity = rigidBody.velocity;
	}

	public void setCollidersEnabled (bool collidersEnabled)
	{

		foreach (Collider2D collider in gameObject.GetComponents<Collider2D>()) {

			collider.enabled = collidersEnabled;
		}
	}
}
