using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    public Transform player; // ���� ���

    public Vector3 offset = new Vector3(0f, 10f, -10f); // ������ ��¦ �밢��

    void LateUpdate()
    {
        // ī�޶� ��ġ = �÷��̾� ��ġ + ������
        transform.position = player.position + offset;

        // �׻� �Ʒ��� �����ٺ��� ����
        transform.LookAt(player.position + new Vector3(0, 0, 1));
    }
}

