using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    //이동 속도
    [SerializeField] float moveSpeed = 5.0f;

    //마우스 회전 속도
    [SerializeField] float angleSpeed = 3.5f;

    //내부에 사용할 x축 회전량을 따로 정의
    //카메라 위 아래 방향
    [SerializeField] float xRotation;
    
    void Update()
    {
        MouseRotation();
    }

    //마우스 움직임에 따라 카메라를 회전 시키는 함수
    private void MouseRotation()
    {
        //좌우로 움직임 마우스의 이동량 x 속도에 따라 카메라가 좌우로 회전하는 값
        float ySize = Input.GetAxis("Mouse X") * angleSpeed;

        float y = transform.eulerAngles.y + ySize;

        //상하로 움직임 마우스의 이동량 x 속도에 따라 카메라가 상하로 회전하는 값
        float xSize = -Input.GetAxis("Mouse Y") * angleSpeed;

        //-45는 하늘 방향 80은 아랫 방향
        xRotation = Mathf.Clamp(xRotation + xSize, -45, 80);

        transform.eulerAngles = new Vector3(xRotation, y, 0);
    }
}
