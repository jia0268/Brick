using UnityEngine;
using System.Collections.Generic;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject carRoot; // 根物件car1
    public GameObject[] objects; // 放置的物件
    public Transform[] targets; // 目標位置
    private int currentIndex = 0;
    public float placementThreshold = 0.1f; // 放置的距離閾值

    // 用來定義可以放置在當前目標位置的物件
    private Dictionary<int, List<int>> targetObjectMap = new Dictionary<int, List<int>>()
    {
        { 0, new List<int> { 0 } },
        { 1, new List<int> { 1, 2, 3, 4, 31, 32 } },
        { 2, new List<int> { 1, 2, 3, 4, 31, 32 } },
        { 3, new List<int> { 1, 2, 3, 4, 31, 32 } },
        { 4, new List<int> { 1, 2, 3, 4, 31, 32 } },
        { 5, new List<int> { 5 } },
        { 6, new List<int> { 6, 7, 8, 9 } },
        { 7, new List<int> { 6, 7, 8, 9 } },
        { 8, new List<int> { 6, 7, 8, 9 } },
        { 9, new List<int> { 6, 7, 8, 9 } },
        { 10, new List<int> { 10, 11 } },
        { 11, new List<int> { 10, 11 } },
        { 12, new List<int> { 12, 14, 16, 18 } },
        { 13, new List<int> { 13, 15, 17, 19, 27, 28, 29, 30 } },
        { 14, new List<int> { 12, 14, 16, 18 } },
        { 15, new List<int> { 13, 15, 17, 19, 27, 28, 29, 30 } },
        { 16, new List<int> { 12, 14, 16, 18 } },
        { 17, new List<int> { 13, 15, 17, 19, 27, 28, 29, 30 } },
        { 18, new List<int> { 12, 14, 16, 18 } },
        { 19, new List<int> { 13, 15, 17, 19, 27, 28, 29, 30 } },
        { 20, new List<int> { 20 } },
        { 21, new List<int> { 21 } },
        { 22, new List<int> { 22 } },
        { 23, new List<int> { 23 } },
        { 24, new List<int> { 24 } },
        { 25, new List<int> { 25, 26 } },
        { 26, new List<int> { 25, 26 } },
        { 27, new List<int> { 13, 15, 17, 19, 27, 28, 29, 30 } },
        { 28, new List<int> { 13, 15, 17, 19, 27, 28, 29, 30 } },
        { 29, new List<int> { 13, 15, 17, 19, 27, 28, 29, 30 } },
        { 30, new List<int> { 13, 15, 17, 19, 27, 28, 29, 30 } },
        { 31, new List<int> { 1, 2, 3, 4, 31, 32 } },
        { 32, new List<int> { 1, 2, 3, 4, 31, 32 } },
        { 33, new List<int> { 33 } },
        { 34, new List<int> { 34, 35, 39 } },
        { 35, new List<int> { 34, 35, 39 } },
        { 36, new List<int> { 36 } },
        { 37, new List<int> { 37 } },
        { 38, new List<int> { 38 } },
        { 39, new List<int> { 34, 35, 39 } },
        { 40, new List<int> { 40 } },
        { 41, new List<int> { 41, 42 } },
        { 42, new List<int> { 41, 42 } },
        { 43, new List<int> { 43, 44 } },
        { 44, new List<int> { 43, 44 } },
        { 45, new List<int> { 45, 47 } },
        { 46, new List<int> { 46, 48 } },
        { 47, new List<int> { 45, 47 } },
        { 48, new List<int> { 46, 48 } },
        { 49, new List<int> { 49 } },
        { 50, new List<int> { 50 } },
        { 51, new List<int> { 51, 52 } },
        { 52, new List<int> { 51, 52 } },
        { 53, new List<int> { 53 } },
    };

    void Start()
    {
        // 初始顯示第一個目標位置
        ShowNextTarget();
    }

    void Update()
    {
        if (currentIndex < targets.Length)
        {
            // 不斷偵測當前目標位置是否已放置對應物件
            foreach (var objectIndex in targetObjectMap[currentIndex])
            {
                float distance = Vector3.Distance(objects[objectIndex].transform.position, targets[currentIndex].position);

                if (distance < placementThreshold)
                {
                    // 當物件接近目標位置時，觸發下一個目標位置
                    AttachObjectToRoot(objects[objectIndex]);
                    currentIndex++;
                    ShowNextTarget();
                    break;
                }
            }
        }
    }

    void AttachObjectToRoot(GameObject obj)
    {
        // 將物件設置為根物件的子物件
        obj.transform.SetParent(carRoot.transform);

        // 選擇是否重置物件的變換（位置、旋轉、縮放）
        obj.transform.localPosition = obj.transform.position - carRoot.transform.position;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;

        // 找到並隱藏子物件 "use"
        Transform useTransform = obj.transform.Find("Visuals/Root/use");
        if (useTransform != null)
        {
            useTransform.gameObject.SetActive(false);
        }
    }


    void ShowNextTarget()
    {
        // 隱藏所有目標位置提示
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].gameObject.SetActive(false);
        }

        if (currentIndex < targets.Length)
        {
            // 顯示當前目標位置提示
            targets[currentIndex].gameObject.SetActive(true);
        }
    }
}