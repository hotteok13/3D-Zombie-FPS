using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //이동 속도
    [SerializeField] float moveSpeed = 5.0f;

    [SerializeField] float Xspeed = 3.5f;
    [SerializeField] float Yspeed = 3.5f;

    [SerializeField] float eulerAngleX;


    [SerializeField] float eulerAngleY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UpdateRotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    }

    //캐릭이 바라보는 위치
    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * Yspeed;
        eulerAngleX -= mouseY * Xspeed;

        eulerAngleX = ClampAngle(eulerAngleX, -80, 50);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }


}
