using UnityEngine;
using System.Collections;

public class SetIndoors : MonoBehaviour {
    public Transform door;

    private ToggleSounds ambience;

	void Start () {
        ambience = GameObject.FindGameObjectWithTag("AmbientSound").GetComponent<ToggleSounds>();
    }
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            ambience.setIndoors();
            GameObject.FindGameObjectWithTag("OutdoorEnvironment").SetActive(false);
            door.GetComponent<Animator>().SetTrigger("SlamDoor");
            foreach (BoxCollider2D c in door.parent.GetComponentsInChildren<BoxCollider2D>()) {
                c.enabled = true;
            }
            Destroy(gameObject);
        }
    }
}
