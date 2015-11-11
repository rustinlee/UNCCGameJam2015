using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OverridePositionZ : MonoBehaviour {
	public List<Transform> transformList;
	public List<float> RightZValuesList;
	public List<float> LeftZValuesList;
	private PlayerInput playerInput;

	void Start() {
		playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
	}

	void LateUpdate() {
		int i = 0;
		for (i = 0; i < transformList.Count; i++) {
			Vector3 curPos = transformList[i].localPosition;
			if (playerInput.isFacingLeft()) {
				transformList[i].localPosition = new Vector3(curPos.x, curPos.y, LeftZValuesList[i]);
			} else {
				transformList[i].localPosition = new Vector3(curPos.x, curPos.y, RightZValuesList[i]);
			}
		}
	}
}
