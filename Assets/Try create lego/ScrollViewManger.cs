using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewManager : MonoBehaviour
{
    public GameObject[] scrollViews; // �s�x�Ҧ���ScrollView

    void Start()
    {
        // ��l�ơA���éҦ�ScrollView�A�u��ܲĤ@��
        ShowScrollView(0);
    }

    // ��ܫ��w��ScrollView
    public void ShowScrollView(int index)
    {
        for (int i = 0; i < scrollViews.Length; i++)
        {
            scrollViews[i].SetActive(i == index);
        }
    }
}
