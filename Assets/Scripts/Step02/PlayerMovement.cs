using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;    // 3 미터/초.
    public float turnSpeed = 360f;  // 360 도/초.

    public Transform myTransform;   // 트랜스폼 컴포넌트.

    public Animator animator;       // Animator 컴포넌트.

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
        // 같은 레벨에 있는 컴포넌트를 검색해주는 기능.
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 입력 받기.
        // W/위:1, S/아래:-1, 없음:0, 
        //float v = Input.GetAxis("Vertical");
        float v = GetVerticalInput();

        // 좌우 입력.
        //float h = Input.GetAxis("Horizontal");
        float h = GetHorizontalInput();

        // 애니메이션 설정.
        // || -> 또는.
        // v가 0이 아니거나 h가 0이 아니면
        // -> 입력이 있으면.
        if (v != 0f || h != 0f)
        {
            // 달리기 애니메이션 재생.
            animator.SetInteger("state", 1);
        }
        else
        {
            // 멈추는 애니메이션 재생.
            animator.SetInteger("state", 0);
        }

        // 앞/뒤로 이동.
        //myTransform.position =
        //    myTransform.position
        //    + new Vector3(0f, 0f, v * moveSpeed)
        //    * Time.deltaTime;
        //myTransform.position =
        //    myTransform.position
        //    //+ new Vector3(0f, 0f, 1f) * v * moveSpeed
        //    + Vector3.forward * v * moveSpeed
        //    * Time.deltaTime;

        myTransform.position =
            myTransform.position
            + myTransform.forward * v * moveSpeed
            * Time.deltaTime;

        // 좌/우 회전.
        myTransform.Rotate(
            Vector3.up,
            turnSpeed * h * Time.deltaTime
        );
    }
}



