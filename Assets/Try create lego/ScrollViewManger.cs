using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewManager : MonoBehaviour
{
    public GameObject[] scrollViews; // 存儲所有的ScrollView

    void Start()
    {
        // 初始化，隱藏所有ScrollView，只顯示第一個
        ShowScrollView(0);
    }

    // 顯示指定的ScrollView
    public void ShowScrollView(int index)
    {
        for (int i = 0; i < scrollViews.Length; i++)
        {
            scrollViews[i].SetActive(i == index);
        }
    }
}
