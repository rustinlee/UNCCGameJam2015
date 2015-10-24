using UnityEngine;
using System.Collections;

public class SwapSprite : MonoBehaviour {
    public float leftZValue;
    public Sprite leftSprite;

    private SpriteRenderer spriteRenderer;
    private float rightZValue;
    private Sprite rightSprite;
    private Vector3 leftPos;
    private Vector3 rightPos;

	void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        rightZValue = transform.localPosition.z;
        rightSprite = spriteRenderer.sprite;

        leftPos = new Vector3(transform.localPosition.x, transform.localPosition.y, leftZValue);
        rightPos = new Vector3(transform.localPosition.x, transform.localPosition.y, rightZValue);
	}

    public void SetLeft() {
        transform.localPosition = leftPos;
        //transform.localRotation = Quaternion.Euler(transform.localRotation.x, 180f, transform.localRotation.z);
        spriteRenderer.sprite = leftSprite;
    }

    public void SetRight() {
        transform.localPosition = rightPos;
        //transform.localRotation = Quaternion.Euler(transform.localRotation.x, 0f, transform.localRotation.z);
        spriteRenderer.sprite = rightSprite;
    }
}
