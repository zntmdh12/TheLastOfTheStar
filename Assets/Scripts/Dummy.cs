using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public int dropDamage = 0; // ȸ������ ������ ����� �� �ִ� ��������
    public int totalDamage = 0; // �� ���� ������
    public int itemCount = 0; // ������ ȹ�� ��

    // Start is called before the first frame update
    void Start()
    {
        dropDamage = Random.Range(500, 1001);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount) //���̰� �޴� ��������
    {
        totalDamage += amount; // ���������� + ������
        Debug.Log("���� ü��" + totalDamage); // Ÿ�� ���� ü�� �ֿܼ� ǥ��


        if (dropDamage <= totalDamage) // ���࿡ ����������� ���� ���������� �۴ٸ�
        {
            itemCount++; // ������ �� 1 ����
            Debug.Log("ȸ�������� ȹ�� ���� ȸ��������" + itemCount);

            totalDamage = 0; // ���������� �� �ʱ�ȭ
            dropDamage = Random.Range(500, 1001); // ������ ��� ������ �������� �缳��
            Debug.Log("���� ��ǥ ��� ������" + dropDamage);
        }

    }

}
