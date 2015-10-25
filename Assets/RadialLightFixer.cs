using UnityEngine;
using System.Collections;

public class RadialLightFixer : MonoBehaviour { 
	void LateUpdate() {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
	}
}
