using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step03
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 3f;    // 3미터 / 초.

        public Transform cameraTransform;   // 카메라 트랜스폼.

        public Animator animator;       // 애니메이터 컴포넌트.

        public bool isAttack = false;  // 공격 중인지 확인하는 변수.

        //public Transform myTransform;

        // 입력 함수(메소드, method).
        // 좌우 입력 함수.
        // 반환유형_함수이름(입력변수1, 입력변수2, ...)
        float GetHorizontalInput()
        {
            if (Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.LeftArrow))
            {
                return -1f;
            }

            if (Input.GetKey(KeyCode.D)
                || Input.GetKey(KeyCode.RightArrow))
            {
                return 1f;
            }

            return 0f;
        }

        // 상하 입력 함수.
        float GetVerticalInput()
        {
            if (Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.UpArrow))
            {
                return 1f;
            }

            if (Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.DownArrow))
            {
                return -1f;
            }

            return 0f;
        }

        // Start is called before the first frame update
        void Start()
        {
            //myTransform = GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            // 공격 중인 경우에는 아래 로직(명령) 모두 무시.
            if (isAttack == true)
            {
                return;
            }

            // 마우스 왼쪽 버튼을 통해 공격.
            // 0->왼쪽, 1->오른쪽, 2->휠버튼.
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetInteger("state", 2);
                isAttack = true;

                return;
            }

            // 카메라의 앞방향.
            // (x, y, z).
            // 물체의 Z 방향.
            Vector3 forward = cameraTransform.forward;
            // 카메라의 오른쪽방향.
            Vector3 right = cameraTransform.right;

            // 입력 받기.
            float h = GetHorizontalInput();
            float v = GetVerticalInput();

            // 이동방향.
            Vector3 direction
                = forward * v + right * h;

            // 높이 성분 없애기 (매끄러운 이동을 위해).
            direction.y = 0f;

            // 애니메이션 설정.
            if (direction == new Vector3(0f, 0f, 0f))
            {
                animator.SetInteger("state", 0);
            }
            else
            {
                animator.SetInteger("state", 1);
            }

            // 카메라가 바라보는 방향 기준으로 이동.
            // transform => 같은 레벨에 있는 트랜스폼.
            transform.position
                = transform.position
                + direction
                * moveSpeed
                * Time.deltaTime;

            // 회전.
            // 캐릭터가 향하는 방향을 기준으로,
            // 회전 값을 만들어 설정하기.
            if (direction != new Vector3(0f, 0f, 0f))
            {
                transform.rotation
                    = Quaternion.LookRotation(direction);
            }
        }
    }
}
