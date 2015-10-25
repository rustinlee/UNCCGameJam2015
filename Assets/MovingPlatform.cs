using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    public float moveX;
    public float moveY;
    public float moveXSpeed;
    public float moveYSpeed;

    private Vector3 originalPos;

	void Start() {
        originalPos = transform.position;
	}
	
    void FixedUpdate() {
        if (moveX > 0) {
            transform.position = new Vector3(originalPos.x + Mathf.Sin(Time.time * moveXSpeed) * moveX, transform.position.y, transform.position.z);
        }

        if (moveY > 0) {
            transform.position = new Vector3(originalPos.y + Mathf.Sin(Time.time * moveYSpeed) * moveY, transform.position.y, transform.position.z);
        }
    }
}
