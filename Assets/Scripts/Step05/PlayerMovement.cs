using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step05
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 3f;    // 이동속도.

        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // 물체를 기준으로
            // 앞/뒤, 좌/우 이동 방향 설정.
            Vector3 direction
                = transform.forward * v
                + transform.right * h;

            // 이동.
            transform.position
                = transform.position
                + direction * moveSpeed * Time.deltaTime;

            // 회전.
            // yaw=Y축 회전
            float yaw = Input.GetAxis("Mouse X");
            transform.eulerAngles
                = transform.eulerAngles
                + transform.up * yaw;
        }
    }
}