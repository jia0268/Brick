using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOutfit : MonoBehaviour
{
    // ���@�ܼơA�Ω�󴫧���
    public Renderer Rhand_change;
    public Material newRhandMaterial;

    public Renderer Lhand_change;
    public Material newLhandMaterial;

    public Renderer waist_change;
    public Material newWaistMaterial;

    public Renderer R_leg_change;
    public Material newRLegMaterial;

    public Renderer L_leg_change;
    public Material newLLegMaterial;

    // ���@�ܼơA�Ω�R������
    public Transform head1Transform; // �ؼб�����������]legorun/nurbsCircle2/main/waist/neck/head/head1�^

    // Prefab�A�Ω��ҤƷs����]�窫/�t��^
    public GameObject newPrefab;       // �窫 Prefab
    public GameObject accessoryPrefab; // �t�� Prefab
    public GameObject headgearPrefab;  // �Y�� Prefab

    // ���@�ܼơA����s���󪺦�m
    public Vector3 clothingPosition = new Vector3(0, -0.012f, 0);
    public Vector3 accessoryPosition = new Vector3(0, -0.012f, 0);
    public Vector3 headgearPosition = new Vector3(0, -0.012f, 0);

    // �I�����s�ɽեΪ���k
    public void WhenSelect()
    {
        // �R�� head1Transform ���U���Ҧ��l����
        if (head1Transform != null)
        {
            foreach (Transform child in head1Transform)
            {
                Destroy(child.gameObject);
            }
        }

        // �󴫥k�⪺����
        if (Rhand_change != null && newRhandMaterial != null)
        {
            Rhand_change.material = newRhandMaterial;
        }

        // �󴫥��⪺����
        if (Lhand_change != null && newLhandMaterial != null)
        {
            Lhand_change.material = newLhandMaterial;
        }

        // �󴫸y��������
        if (waist_change != null && newWaistMaterial != null)
        {
            waist_change.material = newWaistMaterial;
        }

        // �󴫥k�L������
        if (R_leg_change != null && newRLegMaterial != null)
        {
            R_leg_change.material = newRLegMaterial;
        }

        // �󴫥��L������
        if (L_leg_change != null && newLLegMaterial != null)
        {
            L_leg_change.material = newLLegMaterial;
        }

        // ��Ҥƨñ����s���窫����
        if (newPrefab != null && head1Transform != null)
        {
            GameObject newObject = Instantiate(newPrefab, head1Transform);
            newObject.transform.localPosition = clothingPosition;  // �ϥΤ��@�ܼƨӱ���窫��m
        }

        // ��Ҥƨñ����t�󪫥�
        if (accessoryPrefab != null && head1Transform != null)
        {
            GameObject newAccessory = Instantiate(accessoryPrefab, head1Transform);
            newAccessory.transform.localPosition = accessoryPosition; // �ϥΤ��@�ܼƨӱ���t���m
        }

        // ��Ҥƨñ����Y������
        if (headgearPrefab != null && head1Transform != null)
        {
            GameObject newHeadgear = Instantiate(headgearPrefab, head1Transform);
            newHeadgear.transform.localPosition = headgearPosition; // �ϥΤ��@�ܼƨӱ����Y����m
        }
    }
}
