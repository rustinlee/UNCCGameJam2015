using UnityEngine;
using System.Collections;

public class Searchlight : MonoBehaviour {
    public float rotateSpeed;
    public float rotateMagnitude;

	void Start () {
	
	}

	void Update () {
        transform.rotation = Quaternion.Euler(transform.rotation.x, Mathf.Sin(Time.time * rotateSpeed) * rotateMagnitude, transform.rotation.z);
	}
}
