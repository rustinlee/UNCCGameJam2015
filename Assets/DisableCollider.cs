using UnityEngine;
using System.Collections;

public class DisableCollider : MonoBehaviour
{
    public Transform targetTransform;

    void Start() {

    }

    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            targetTransform.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
