using UnityEngine;
using System.Collections;

public class SetLightPosition : MonoBehaviour {
    private LOS.LOSRadialLight radialLightEmitter;
    private Transform lightPoint;
    private PlayerInput playerInput;

	void Start() {
        lightPoint = GameObject.FindGameObjectWithTag("Flashlight").transform.GetChild(0);
        radialLightEmitter = GetComponent<LOS.LOSRadialLight>();
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }
	
	void LateUpdate() {
        radialLightEmitter.faceAngle = lightPoint.eulerAngles.z;
        if (playerInput.isFacingLeft()) {
            Quaternion tempQuat = Quaternion.Euler(0f, 0f, radialLightEmitter.faceAngle);
            tempQuat = new Quaternion(
                tempQuat.x,
                tempQuat.y,
                tempQuat.z * -1.0f,
                tempQuat.w
            );
            radialLightEmitter.faceAngle = tempQuat.eulerAngles.z;
        }
        //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.position = lightPoint.position;
	}
}
