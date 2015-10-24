using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
    public float walkSpeed = 20f;

    private Transform upperArm;
    private Transform flashlight;

	void Start() {
        upperArm = GameObject.FindGameObjectWithTag("PivotArm").transform;
        flashlight = GameObject.FindGameObjectWithTag("Flashlight").transform;
    }
	
    void Update() {
        Debug.Log(Input.mousePosition);
        //upperArm.LookAt(Input.mousePosition);
        //upperArm.rotation = ;
        Vector3 vectorToTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition) - flashlight.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        upperArm.rotation = q;
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);
    }

    void FixedUpdate() {
        float horizInput = Input.GetAxis("Horizontal");
        if (horizInput != 0) {
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(horizInput * walkSpeed, 0f), ForceMode2D.Force);
            transform.Translate(new Vector3(horizInput * Time.fixedDeltaTime * walkSpeed, 0f, 0f));
        }
	}
}
