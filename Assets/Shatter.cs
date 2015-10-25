using UnityEngine;
using System.Collections;

public class Shatter : MonoBehaviour
{
    public float shatterForce;
    public AudioClip smallClink;
    public AudioClip mediumClink;
    public AudioClip shatter;

    void OnCollisionEnter2D(Collision2D coll) {
        float mag = coll.relativeVelocity.magnitude;

        if (mag > shatterForce) {
            AudioSource.PlayClipAtPoint(shatter, transform.position);
            Debug.Log("crash");
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
            foreach (Transform child in transform) {

                child.gameObject.SetActive(true);
                child.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-8f, 8f), 3f), ForceMode2D.Impulse);
            }
        } else if (mag > shatterForce / 2) {
            AudioSource.PlayClipAtPoint(mediumClink, transform.position);
            Debug.Log("clank");
        } else if (mag > 0.1f) {
            AudioSource.PlayClipAtPoint(smallClink, transform.position);
            Debug.Log("clink");
        }
    }
}