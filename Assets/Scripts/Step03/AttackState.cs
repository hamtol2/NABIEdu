using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step03
{
    public class AttackState : StateMachineBehaviour
    {
        public PlayerMovement playerMovement;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // 태그로 물체 검색.
            GameObject player
                = GameObject.FindGameObjectWithTag("Player");

            // 검색된 물체에서 컴포넌트 검색.
            playerMovement = player.GetComponent<PlayerMovement>();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // 공격 종료로 설정.
            playerMovement.isAttack = false;
        }
    }
}