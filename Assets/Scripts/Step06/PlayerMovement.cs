using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;   // 네비게이션 시스템 사용을 위해.

namespace Step06
{
    public class PlayerMovement : MonoBehaviour
    {
        // 네비게이션 메시 에이전트.
        public NavMeshAgent agent;

        // 테스트 목적용 위치.
        public Transform target;

        private void Start()
        {
            // Y위치 보정.
            // 플레이어의 Y위치와 동일하도록.
            Vector3 targetPos = target.position;
            targetPos.y = transform.position.y;

            // 이동 목표 설정.
            agent.SetDestination(targetPos);
        }

        private void Update()
        {
            // Y위치 보정.
            // 플레이어의 Y위치와 동일하도록.
            Vector3 targetPos = target.position;
            targetPos.y = transform.position.y;

            // 이동 목표 설정.
            agent.SetDestination(targetPos);
        }
    }
}
