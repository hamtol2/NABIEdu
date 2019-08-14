using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step05
{
    public class PlayerShoot : MonoBehaviour
    {
        public GameObject bomb;     // 폭발 파티클.
        public Transform firePosition;  // 총구 위치.

        public LineRenderer lineRenderer;   // 라인 렌더러.

        public GameObject bullet;

        void Update()
        {
            // 라인 정보 설정.
            lineRenderer.SetPosition(0, firePosition.position);
            lineRenderer.SetPosition(
                1,
                firePosition.position + firePosition.forward * 10f
            );

            // 라인 충돌 검출용 레이 캐스트 발사.
            Ray lineRay = new Ray();
            lineRay.origin = firePosition.position;
            lineRay.direction = firePosition.forward;

            RaycastHit lineHit;
            if (Physics.Raycast(lineRay, out lineHit, 10f))
            {
                lineRenderer.SetPosition(1, lineHit.point);
            }

            // 마우스 왼쪽 버튼 클릭.
            if (Input.GetMouseButtonDown(0))
            {
                GameObject newBullet = Instantiate(bullet);
                newBullet.transform.position = firePosition.position;
                newBullet.transform.rotation = firePosition.rotation;

                // 레이저 정보 생성.
                Ray ray = new Ray();
                ray.origin = firePosition.position;
                ray.direction = firePosition.forward;

                // 충돌 정보 저장용 변수.
                RaycastHit hit;

                // 레이저 발사.
                if (Physics.Raycast(ray, out hit, 10f))
                {
                    // 충돌 확인.
                    if (hit.transform.tag.Equals("Prop"))
                    {
                        // 충돌 위치.
                        Vector3 hitPoint = hit.point;

                        // 라인 렌더러 끝 위치 조정.
                        lineRenderer.SetPosition(1, hitPoint);

                        // 폭발 파티클 위치 변경.
                        bomb.transform.position = hitPoint;

                        // 파티클 재생(리셋).
                        bomb.SetActive(false);
                        bomb.SetActive(true);

                        // 부딪힌 물체 삭제.
                        Destroy(hit.transform.gameObject);
                    }
                }
            }

            else
            {
                
            }
        }
    }
}
