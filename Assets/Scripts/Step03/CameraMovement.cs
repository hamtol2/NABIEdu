using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// global.
namespace Step03
{
    public class CameraMovement : MonoBehaviour
    {
        public Transform myTransform;

        // Start is called before the first frame update
        void Start()
        {
            myTransform = GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            // 마우스 오른쪽 버튼이 눌렸는지 확인.
            // 0->왼쪽, 1->오른쪽, 2->휠버튼.
            if (Input.GetMouseButton(1))
            {
                // 마우스 드래그 입력 받기.
                // 좌우 드래그 입력.
                float yaw = Input.GetAxis("Mouse X");       // Y축 회전.
                float pitch = Input.GetAxis("Mouse Y");     // X축 회전.

                // 카메라 회전.
                myTransform.eulerAngles =
                    myTransform.eulerAngles
                    + new Vector3(-pitch, yaw, 0f);
            }
        }
    }
}