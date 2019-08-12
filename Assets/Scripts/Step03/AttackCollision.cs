using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step03
{
    public class AttackCollision : MonoBehaviour
    {
        public GameObject bomb; // 폭발 파티클.


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Prop"))
            {
                Vector3 direction 
                    = other.transform.position
                        - transform.position;

                // other.gameObject.GetComponent<Rigidbody>()
                //     .AddForce(direction * 3000f);

                // 부딪힌 물체 삭제.
                Destroy(other.gameObject);

                // 파티클 위치를 부딪힌 물체의 위치로 설정하기.
                bomb.transform.position = other.transform.position;

                // 파티클 재생.
                bomb.SetActive(false);
                bomb.SetActive(true);
            }
        }
    }    
}