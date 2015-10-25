using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour {
    public float walkSpeed = 20f;
    public float jumpPower = 5f;

    private SwapSprite[] swapSprites;
    private bool facingLeft;
    private bool lastFrame_facingLeft;
    private Transform upperArm;
    private Transform flashlight;
    private Transform spotlight;
    private Rigidbody2D rigid2D;
    private Animator animator;

    public bool isFacingLeft() {
        return facingLeft;
    }

	void Start() {
        animator = GetComponent<Animator>();
        swapSprites = GetComponentsInChildren<SwapSprite>();
        facingLeft = false;
        lastFrame_facingLeft = false;
        upperArm = GameObject.FindGameObjectWithTag("PivotArm").transform;
        flashlight = GameObject.FindGameObjectWithTag("Flashlight").transform;
        spotlight = flashlight.GetChild(0).GetChild(0);
        rigid2D = GetComponent<Rigidbody2D>();
    }
	
    void Update() {
        Vector3 vectorToTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        if (vectorToTarget.x < 0) {
            facingLeft = true;
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                -180f,
                transform.rotation.eulerAngles.z
            );
        } else {
            facingLeft = false;
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                0f,
                transform.rotation.eulerAngles.z
            );
        }

        upperArm.localRotation = q;

        if (facingLeft) {
            upperArm.localRotation = new Quaternion(
                upperArm.localRotation.x,
                upperArm.localRotation.y,
                upperArm.localRotation.z * -1.0f,
                upperArm.localRotation.w
            );
            upperArm.localScale = new Vector3(-1f, -1f, 1f);
        } else {
            upperArm.localScale = new Vector3(1f, 1f, 1f);
        }

        if (facingLeft != lastFrame_facingLeft) {
            if (facingLeft) {
                foreach (SwapSprite s in swapSprites) {
                    s.SetLeft();
                }
                spotlight.localRotation = Quaternion.Euler(0f, 270f, 180f);
            } else {
                foreach (SwapSprite s in swapSprites) {
                    s.SetRight();
                }
                spotlight.localRotation = Quaternion.Euler(0f, 90f, 0f);
            }

        }

        lastFrame_facingLeft = facingLeft;
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);

        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 groundPos = new Vector2(playerPos.x, playerPos.y - 3.5f);
        bool onGround = Physics2D.Linecast(playerPos, groundPos, 1 << LayerMask.NameToLayer("LightObstacle"));
        //Debug.DrawLine(new Vector3(playerPos.x, playerPos.y), new Vector3(groundPos.x, groundPos.y));
        //Debug.Log(onGround);
        if (Input.GetButtonDown("Jump") && onGround) {
            rigid2D.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate() {
        float horizInput = Input.GetAxis("Horizontal");

        if (horizInput != 0) {
            rigid2D.velocity = new Vector2(horizInput * walkSpeed, rigid2D.velocity.y);
            if (facingLeft) {
                animator.SetFloat("WalkingDirection", -horizInput * walkSpeed);
                //animator.
            } else {
                animator.SetFloat("WalkingDirection", horizInput * walkSpeed);
            }
        }
	}
}