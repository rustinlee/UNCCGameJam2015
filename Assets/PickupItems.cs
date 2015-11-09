using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupItems : MonoBehaviour {
	public float maxThrowForce;
	public float timeToMaxThrowForce;

	private List<Transform> availableItems;
	private Transform handTransform;
	private bool isThrowing;
	private float timeStartedThrowing;
	private float throwForce;

	void Start() {
		isThrowing = false;
		availableItems = new List<Transform>();
		handTransform = GameObject.FindGameObjectWithTag("PickupHand").transform;
	}

	void Update() {
		/*
		hold down mouse to throw
		*/
		if (Input.GetButtonDown("Grab") && availableItems.Count > 0 && handTransform.childCount == 0) {
			availableItems[0].SetParent(handTransform);
			availableItems[0].GetComponent<Rigidbody2D>().isKinematic = true;
			availableItems[0].localPosition = Vector3.zero;
			availableItems[0].localRotation = Quaternion.Euler(Vector3.zero);
			availableItems.RemoveAt(0);
		}

		if (Input.GetButtonDown("Throw") && handTransform.childCount > 0) {
			isThrowing = true;
			timeStartedThrowing = Time.time;
		}

		if (isThrowing && throwForce < maxThrowForce) {
			throwForce = maxThrowForce * ((Time.time - timeStartedThrowing) / timeToMaxThrowForce);
			if (throwForce > maxThrowForce) {
				throwForce = maxThrowForce;
			}
		}

		if (Input.GetButtonUp("Throw") && isThrowing) {
			foreach (Transform child in handTransform) {
				child.SetParent(null);
				child.GetComponent<Rigidbody2D>().isKinematic = false;
				child.GetComponent<Rigidbody2D>().AddForce(new Vector3(throwForce, 0f, 0f), ForceMode2D.Impulse);
			}
			isThrowing = false;
			throwForce = 0f;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Pickup") {
			availableItems.Add(other.transform);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Pickup") {
			availableItems.Remove(other.transform);
		}
	}
}
