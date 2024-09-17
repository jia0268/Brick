using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class TargetGroupOB
{
    public Transform[] targets;
}

public class ObjectTargetOB: MonoBehaviour
{
    public GameObject OBRoot; // �ڪ���
    public GameObject[] objects; // ��m������
    public List<TargetGroupOB> targetGroups; // �Ψө�ؼЦ�m��
    private int currentIndex = 0;
    public float Threshold = 0.0001f; // �ӷP��
    public GameObject celebreate; // �����y��

    // �Ψөw�q�C�@�B�i�H�񪺪����
    private Dictionary<int, List<int>> Objects = new Dictionary<int, List<int>>()
    {
        { 0, new List<int> { 0, 1 } },
        { 1, new List<int> { 0, 1 } },
        { 2, new List<int> { 2, 3 } },
        { 3, new List<int> { 2, 3 } },
        { 4, new List<int> { 4, 5 } },
        { 5, new List<int> { 4, 5 } },
        { 6, new List<int> { 6, 7, 8, 9 } },
        { 7, new List<int> { 6, 7, 8, 9 } },
        { 8, new List<int> { 6, 7, 8, 9 } },
        { 9, new List<int> { 6, 7, 8, 9 } },
        { 10, new List<int> { 10 } },
        { 11, new List<int> { 11 } },
        { 12, new List<int> { 12, 50 } },
        { 13, new List<int> { 13 } },
        { 14, new List<int> { 14 } },
        { 15, new List<int> { 15 } },
        { 16, new List<int> { 16 } },
        { 17, new List<int> { 17 } },
        { 18, new List<int> { 18 } },
        { 19, new List<int> { 19 } },
        { 20, new List<int> { 20 } },
        { 21, new List<int> { 21 } },
        { 22, new List<int> { 22, 23 } },
        { 23, new List<int> { 22, 23 } },
        { 24, new List<int> { 24, 25 } },
        { 25, new List<int> { 24, 25 } },
        { 26, new List<int> { 26, 27 } },
        { 27, new List<int> { 26, 27 } },
        { 28, new List<int> { 28, 29 } },
        { 29, new List<int> { 28, 29 } },
        { 30, new List<int> { 30, 31, 32 } },
        { 31, new List<int> { 30, 31, 32 } },
        { 32, new List<int> { 30, 31, 32 } },
        { 33, new List<int> { 33 } },
        { 34, new List<int> { 34, 35 } },
        { 35, new List<int> { 34, 35 } },
        { 36, new List<int> { 36, 37, 40, 41 } },
        { 37, new List<int> { 36, 37, 40, 41 } },
        { 38, new List<int> { 38, 39, 42 } },
        { 39, new List<int> { 38, 39, 42} },
        { 40, new List<int> { 36, 37, 40, 41 } },
        { 41, new List<int> { 36, 37, 40, 41 } },
        { 42, new List<int> { 38, 39, 42 } },
        { 43, new List<int> { 43 } },
        { 44, new List<int> { 44 } },
        { 45, new List<int> { 45 } },
        { 46, new List<int> { 46, 47, 48, 49 } },
        { 47, new List<int> { 46, 47, 48, 49 } },
        { 48, new List<int> { 46, 47, 48, 49 } },
        { 49, new List<int> { 46, 47, 48, 49 } },
        { 50, new List<int> { 12, 50 } },
        { 51, new List<int> { 51 } },
        { 52, new List<int> { 52 } },
        { 53, new List<int> { 53 } },
        { 54, new List<int> { 54 } },
    };

    void Start()
    {
        // ��l��ܲĤ@�B
        ShowNext();
    }

    void Update()
    {
        if (currentIndex < targetGroups.Count)
        {
            // �O�_�w��m��������
            foreach (var objectIndex in Objects[currentIndex])
            {
                foreach (var target in targetGroups[currentIndex].targets)
                {
                    float distance = Vector3.Distance(objects[objectIndex].transform.position, target.position);

                    if (distance < Threshold)
                    {
                        // ���󱵪�ؼЦ�m�ɡAĲ�o�U�@�B
                        AttachObjectToRoot(objects[objectIndex]);
                        currentIndex++;
                        ShowNext();
                        break;
                    }
                }
            }
        }else
        {
            // �Ҧ��n������A��ܼy��
            StartCoroutine(Delay(1f)); // ����1�����
        }
    }

    void AttachObjectToRoot(GameObject obj)
    {
        // �N����]�m���ڪ��󪺤l����
        obj.transform.SetParent(OBRoot.transform);

        // �@�_ ���� ���� ��j �Y�p
        obj.transform.localPosition = obj.transform.position - OBRoot.transform.position;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;

        // ���� use �̪���տ���
        Transform useTransform = obj.transform.Find("Visuals/Root/use");
        if (useTransform != null)
        {
            useTransform.gameObject.SetActive(false);
        }

        // �T�Ϊ��󪺭��O�ñҥ� is Kinematic
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero; // ����󪺲���
        }
    }

    void ShowNext()
    {
        // ���éҦ�����
        foreach (var group in targetGroups)
        {
            foreach (var target in group.targets)
            {
                target.gameObject.SetActive(false);
            }
        }

        if (currentIndex < targetGroups.Count)
        {
            // ��ܥثe������
            foreach (var target in targetGroups[currentIndex].targets)
            {
                target.gameObject.SetActive(true);
            }
        }
    }
    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // ��ܵ����y��
        if (celebreate != null)
        {
            celebreate.SetActive(true);
        }
    }
}
