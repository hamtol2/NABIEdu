using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstMove : MonoBehaviour
{
    // 변수.
    // public 변수유형 _ 변수이름 ;
    public Transform myTransform;

    public float speed = 0.5f;

    // Start is called before the first frame update
    // 메모용.
    void Start()
    {
        // myTransform의 위치(position)에 2,0,0 대입.
        //myTransform.position = new Vector3(2, 0, 0);
    }

    // Update is called once per frame
    // 메모.
    void Update()
    {
        // 입력받기.
        // 좌우 입력 받기. -1 ~ 1.
        // A/왼쪽 -> -1.
        // D/오른쪽 -> 1.
        // 입력없음 -> 0.
        float h = Input.GetAxis("Horizontal");

        // 위아래 입력받기.
        float v = Input.GetAxis("Vertical");

        //Debug.Log("처음 해보는 코딩.");
        myTransform.position 
            = myTransform.position 
            + new Vector3(speed * h, speed * v, 0) 
            * Time.deltaTime;
    }
}