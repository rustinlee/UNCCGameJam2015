using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
        public float outdoorsXClampValue = -21f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;
        private Transform target;
        private PlayerInput playerInput;

        public bool isIndoors = false;
        
        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            playerInput = target.gameObject.GetComponent<PlayerInput>();
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }

        private void Update() {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta;
            if (playerInput.isFacingLeft()) {
                xMoveDelta = (target.position + m_LastTargetPosition).x;
            } else {
                xMoveDelta = (target.position - m_LastTargetPosition * 2).x;
            }

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            //m_LookAheadPos += new Vector3(0f, Input.mousePosition, 0f);
            //Debug.Log(Input.mousePosition.y - Screen.height / 2);
            
            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            if (Mathf.Abs(Input.mousePosition.y - Screen.height / 2) > Screen.height / 3) {
                m_LookAheadPos += new Vector3(0f, (Input.mousePosition.y - Screen.height / 2) / 120, 0f);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target.position;
        }

        private void LateUpdate() {
            if (!isIndoors && transform.position.x < outdoorsXClampValue) {
                transform.position = new Vector3(outdoorsXClampValue, transform.position.y, transform.position.z);
            }
        }
    }
}
