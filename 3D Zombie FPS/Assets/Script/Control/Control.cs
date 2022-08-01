using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    //�̵� �ӵ�
    [SerializeField] float moveSpeed = 5.0f;

    //���콺 ȸ�� �ӵ�
    [SerializeField] float angleSpeed = 3.5f;

    //���ο� ����� x�� ȸ������ ���� ����
    //ī�޶� �� �Ʒ� ����
    [SerializeField] float xRotation;
    
    void Update()
    {
        MouseRotation();
    }

    //���콺 �����ӿ� ���� ī�޶� ȸ�� ��Ű�� �Լ�
    private void MouseRotation()
    {
        //�¿�� ������ ���콺�� �̵��� x �ӵ��� ���� ī�޶� �¿�� ȸ���ϴ� ��
        float ySize = Input.GetAxis("Mouse X") * angleSpeed;

        float y = transform.eulerAngles.y + ySize;

        //���Ϸ� ������ ���콺�� �̵��� x �ӵ��� ���� ī�޶� ���Ϸ� ȸ���ϴ� ��
        float xSize = -Input.GetAxis("Mouse Y") * angleSpeed;

        //-45�� �ϴ� ���� 80�� �Ʒ� ����
        xRotation = Mathf.Clamp(xRotation + xSize, -45, 80);

        transform.eulerAngles = new Vector3(xRotation, y, 0);
    }
}
