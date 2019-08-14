using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step04
{
    public class RayPicking : MonoBehaviour
    {
        public GameObject bomb;     // 폭발 파티클.

        void Update()
        {
            // 마우스 버튼 왼쪽 클릭.
            // 0->왼쪽 클릭, 1->오른쪽 클릭, 2->휠 클릭.
            if (Input.GetMouseButtonDown(0))
            {
                // 레이저 발사.
                // 1단계: 발사할 레이저 정보 설정하기.
                // 2단계: 발사하기.

                // 마우스 좌표를 기준으로 레이저 정보 만들기.
                Ray ray = Camera.main.ScreenPointToRay(
                        Input.mousePosition
                );

                // 발사한 레이저와 충돌한 
                // 물체의 정보를 저장하기 위한 변수.
                RaycastHit hit;

                // 발사.
                // 1: 레이저 정보. 
                // 2: 충돌한 물체 정보 저장용 변수 전달.
                // 3: 레이저의 길이(단위: 미터).

                if (Physics.Raycast(ray, out hit, 100f) == true)
                {
                    // 태그 확인(Prop 인지 확인).
                    if (hit.transform.tag.Equals("Prop"))
                    {
                        // 물체 삭제.
                        Destroy(hit.transform.gameObject);

                        // 파티클 재생.
                        // hit.point = 충돌한 위치.
                        bomb.transform.position = hit.point;

                        bomb.SetActive(false);
                        bomb.SetActive(true);
                    }
                }
            }
        }
    }
}