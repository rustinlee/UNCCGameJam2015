using UnityEngine;
using System.Collections;

public class RespawnPlayer : MonoBehaviour {
    private Vector3 respawnPoint;
    private GameObject outdoorEnvironment;

	void Start() {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        outdoorEnvironment = GameObject.FindGameObjectWithTag("OutdoorEnvironment");
    }
	
	void Update() {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.transform.position = respawnPoint;
            Camera.main.transform.position = new Vector3(respawnPoint.x, respawnPoint.y, Camera.main.transform.position.z);
            outdoorEnvironment.SetActive(true);
            GameObject.FindGameObjectWithTag("AmbientSound").GetComponent<ToggleSounds>().setOutdoors();
        }
    }
}
