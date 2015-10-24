using UnityEngine;
using System.Collections;

public class CameraBoatSway : MonoBehaviour {
    public float swaySpeed = 1f;
    public float swayFactor = 1f;

	void Start () {
	
	}
	
	void LateUpdate () {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Sin(Time.time * swaySpeed) * swayFactor);
	}
}
