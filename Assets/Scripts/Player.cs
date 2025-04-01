using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Animator anim; // 애니메이터 선언

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseClick(); // 마우스 클릭 확인 함수 호출
        IsMoving(); // 마우스 포인트로 이동 함수 호출
        PlayerAttack(); // 플레이어 공격함수 호출
    }

    void CheckMouseClick() // 마우스 클릭했는지 확인하는 함수
    {
        if (Input.GetMouseButtonDown(0)) // 왼쪽 마우스 버튼을 눌렀다면
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 클릭 방향으로 Ray 쏘기
            RaycastHit hit; // 충돌 정보 저장소
            if (Physics.Raycast(ray, out hit)) // ray가 뭔가에 부딪혔다면
            {
                if (hit.collider.CompareTag("Ground")) // 그게 Ground 태그를 가지고 있다면
                {
                    if (agent.isOnNavMesh)
                    {
                        agent.SetDestination(hit.point); // 경로 자동 계산!
                    }
                }
            }
        }
    }

    void IsMoving() // 이동함수 호출
    {
        if (agent.velocity.magnitude > 0.1f)
        {
            anim.SetBool("isMoving", true); //isMoving 애니메이션 시작
        }
        else
        {
            anim.SetBool("isMoving", false); //isMoving애니메이션 중단
        }
    }

    void PlayerAttack() // 플레이어 공격 함수
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭 시
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스우클릭방향
            RaycastHit hit; // 거리정보 hit에 저장

            float attackRange = 10f;

            if (Physics.Raycast(ray, out hit, attackRange))//만약에 10근처까지 검사를 했다면 그걸 hit에 저장하고
            {

                Debug.Log("맞은 대상: " + hit.collider.name);
                if (hit.collider.CompareTag("Dummy")) // 부딪힌 콜라이더의 태그가 Dummy라면
                {
                    Dummy dummy = hit.collider.GetComponent<Dummy>(); // Dummy의 Dummy 태그 붙은 콜라이더 가져오기

                    dummy.TakeDamage(100); // Dummy 스크립트에 TakeDamage 값 100으로 주기
                }
            }

        }
    }
}
