using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour {
	public List<string> dialogue;
	public float triggerDistance;

	private Transform player;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;

		StartCoroutine(CheckPlayerProximity());
	}

	IEnumerator CheckPlayerProximity() {
		while (true) {
			if (Vector3.Distance(player.position, transform.position) < triggerDistance) {
				Debug.Log("trigger dialogue");
			}
			yield return new WaitForSeconds(0.25f);
		}
	}
}
