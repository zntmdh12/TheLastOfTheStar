using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public int dropDamage = 0; // 회복포션 아이템 드랍할 수 있는 데미지양
    public int totalDamage = 0; // 총 누적 데미지
    public int itemCount = 0; // 아이템 획득 수

    // Start is called before the first frame update
    void Start()
    {
        dropDamage = Random.Range(500, 1001);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount) //더미가 받는 데미지량
    {
        totalDamage += amount; // 누적데미지 + 데미지
        Debug.Log("남은 체력" + totalDamage); // 타겟 남은 체력 콘솔에 표시


        if (dropDamage <= totalDamage) // 만약에 드랍데미지가 누적 데미지보다 작다면
        {
            itemCount++; // 아이템 수 1 증가
            Debug.Log("회복아이템 획득 현재 회복아이템" + itemCount);

            totalDamage = 0; // 누적데미지 값 초기화
            dropDamage = Random.Range(500, 1001); // 아이템 드랍 데미지 랜덤으로 재설성
            Debug.Log("다음 목표 드랍 데미지" + dropDamage);
        }

    }

}
