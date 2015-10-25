using UnityEngine;
using System.Collections;

public class ToggleSounds : MonoBehaviour {
    public AudioClip indoorsClip;
    public AudioClip outdoorsClip;

    private AudioSource audioSource;

    public void setIndoors() {
        float offset = audioSource.time;
        audioSource.clip = indoorsClip;
        audioSource.time = offset;
        audioSource.Play();

        Camera.main.GetComponent<UnityStandardAssets._2D.Camera2DFollow>().isIndoors = true;
    }

    public void setOutdoors() {
        float offset = audioSource.time;
        audioSource.clip = outdoorsClip;
        audioSource.time = offset;
        audioSource.Play();

        Camera.main.GetComponent<UnityStandardAssets._2D.Camera2DFollow>().isIndoors = false;
    }

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
}
