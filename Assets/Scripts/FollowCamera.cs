using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    public Transform player; // 따라갈 대상

    public Vector3 offset = new Vector3(0f, 10f, -10f); // 위에서 살짝 대각선

    void LateUpdate()
    {
        // 카메라 위치 = 플레이어 위치 + 오프셋
        transform.position = player.position + offset;

        // 항상 아래를 내려다보게 고정
        transform.LookAt(player.position + new Vector3(0, 0, 1));
    }
}

