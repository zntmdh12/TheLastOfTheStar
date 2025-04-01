using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Animator anim; // �ִϸ����� ����

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // �ִϸ����� ������Ʈ ��������
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseClick(); // ���콺 Ŭ�� Ȯ�� �Լ� ȣ��
        IsMoving(); // ���콺 ����Ʈ�� �̵� �Լ� ȣ��
        PlayerAttack(); // �÷��̾� �����Լ� ȣ��
    }

    void CheckMouseClick() // ���콺 Ŭ���ߴ��� Ȯ���ϴ� �Լ�
    {
        if (Input.GetMouseButtonDown(0)) // ���� ���콺 ��ư�� �����ٸ�
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���콺 Ŭ�� �������� Ray ���
            RaycastHit hit; // �浹 ���� �����
            if (Physics.Raycast(ray, out hit)) // ray�� ������ �ε����ٸ�
            {
                if (hit.collider.CompareTag("Ground")) // �װ� Ground �±׸� ������ �ִٸ�
                {
                    if (agent.isOnNavMesh)
                    {
                        agent.SetDestination(hit.point); // ��� �ڵ� ���!
                    }
                }
            }
        }
    }

    void IsMoving() // �̵��Լ� ȣ��
    {
        if (agent.velocity.magnitude > 0.1f)
        {
            anim.SetBool("isMoving", true); //isMoving �ִϸ��̼� ����
        }
        else
        {
            anim.SetBool("isMoving", false); //isMoving�ִϸ��̼� �ߴ�
        }
    }

    void PlayerAttack() // �÷��̾� ���� �Լ�
    {
        if (Input.GetMouseButton(1)) // ���콺 ������ ��ư Ŭ�� ��
        {
            Ray ray = new Ray(transform.position + Vector3.up * 0.5f, transform.forward); // ���� ����
            RaycastHit hit; // �Ÿ����� hit�� ����


            if (Physics.Raycast(ray, out hit, 10f)) //���࿡ 10��ó���� �˻縦 �ߴٸ� �װ� hit�� �����ϰ�
            {
                if (hit.collider.CompareTag("Dummy")) // �ε��� �ݶ��̴��� �±װ� Dummy���
                {
                    Dummy dummy = hit.collider.GetComponent<Dummy>(); // Dummy�� Dummy �±� ���� �ݶ��̴� ��������

                    dummy.TakeDamage(100); // Dummy ��ũ��Ʈ�� TakeDamage �� 100���� �ֱ�
                }
            }

        }
    }
}
