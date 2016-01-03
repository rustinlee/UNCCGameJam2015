using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour {
	public List<string> dialogue;
	public float triggerDistance;

	private Transform player;
	private Text dialogueText;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		dialogueText = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Text>();

		StartCoroutine(CheckPlayerProximity());
	}

	IEnumerator CheckPlayerProximity() {
		while (true) {
			if (Vector3.Distance(player.position, transform.position) < triggerDistance) {
				Debug.Log("trigger dialogue");
				dialogueText.text = dialogue[0];
			}
			yield return new WaitForSeconds(0.25f);
		}
	}
}
