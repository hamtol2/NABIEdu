using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;        // 플레이어(따라다닐 대상).

    public Transform myTransform;   // 내 트랜스폼.

    Vector3 offset;                 // 플레이어와의 거리 저장용 변수.

    // Start is called before the first frame update
    void Start()
    {
        // 내 트랜스폼 컴포넌트는 검색해서 설정.
        myTransform = GetComponent<Transform>();

        // 플레이어와의 거리 계산.
        offset = myTransform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 따라다니기.
        myTransform.position
            = target.position + offset;
    }
}