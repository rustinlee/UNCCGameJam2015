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
        //Debug.Log(mag);

        if (mag > shatterForce) {
            AudioSource.PlayClipAtPoint(shatter, transform.position);
            Debug.Log("crash");
            //shatter that shit
        } else if (mag > shatterForce / 2) {
            AudioSource.PlayClipAtPoint(mediumClink, transform.position);
            Debug.Log("clank");
        } else if (mag > 1f) {
            AudioSource.PlayClipAtPoint(smallClink, transform.position);
            Debug.Log("clink");
        }
    }
}