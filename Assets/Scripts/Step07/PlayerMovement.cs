using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;   // 네비게이션 시스템 사요을 위해.

namespace Step07
{
    public class PlayerMovement : MonoBehaviour
    {
        public NavMeshAgent agent;

        void Update()
        {
            // 마우스 왼쪽 클릭 확인.
            if (Input.GetMouseButtonDown(0))
            {
                // 피킹을 이용해서 이동 위치 얻어오기.
                Ray ray
                    = Camera.main
                    .ScreenPointToRay(
                        Input.mousePosition
                    );

                // 충돌 정보 저장용 변수.
                RaycastHit hit;

                // 레이캐스트 발사.
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    // 이동할 위치 얻어오기.
                    Vector3 targetPos = hit.point;
                    targetPos.y = transform.position.y;

                    // 이동.
                    agent.SetDestination(targetPos);
                }
            }
        }
    }
}