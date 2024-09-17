using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class TargetGroup
{
    public Transform[] targets;
}

public class ObjectTarget : MonoBehaviour
{
    public GameObject carRoot; // 根物件car1
    public GameObject[] objects; // 放置的物件
    public List<TargetGroup> targetGroups; // 用來放目標位置們
    private int currentIndex = 0;
    public float Threshold = 0.0001f; // 敏感度
    public GameObject celebreate; // 結尾慶祝

    // 用來定義每一步可以放的物件們
    private Dictionary<int, List<int>> Objects = new Dictionary<int, List<int>>()
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
        // 初始顯示第一步
        ShowNext();
    }

    void Update()
    {
        if (currentIndex < targetGroups.Count)
        {
            // 是否已放置對應物件
            foreach (var objectIndex in Objects[currentIndex])
            {
                foreach (var target in targetGroups[currentIndex].targets)
                {
                    float distance = Vector3.Distance(objects[objectIndex].transform.position, target.position);

                    if (distance < Threshold)
                    {
                        // 當物件接近目標位置時，觸發下一步
                        AttachObjectToRoot(objects[objectIndex]);
                        currentIndex++;
                        ShowNext();
                        break;
                    }
                }
            }
        }else
        {
            // 所有積木拼完，顯示慶祝
            StartCoroutine(Delay(1f)); // 延遲1秒顯示
        }
    }

    void AttachObjectToRoot(GameObject obj)
    {
        // 將物件設置為根物件的子物件
        obj.transform.SetParent(carRoot.transform);

        // 一起 移動 旋轉 放大 縮小
        obj.transform.localPosition = obj.transform.position - carRoot.transform.position;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;

        // 隱藏 use 裡的手勢辨識
        Transform useTransform = obj.transform.Find("Visuals/Root/use");
        if (useTransform != null)
        {
            useTransform.gameObject.SetActive(false);
        }

        // 禁用物件的重力並啟用 is Kinematic
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero; // 停止物件的移動
        }
    }

    void ShowNext()
    {
        // 隱藏所有提示
        foreach (var group in targetGroups)
        {
            foreach (var target in group.targets)
            {
                target.gameObject.SetActive(false);
            }
        }

        if (currentIndex < targetGroups.Count)
        {
            // 顯示目前的提示
            foreach (var target in targetGroups[currentIndex].targets)
            {
                target.gameObject.SetActive(true);
            }
        }
    }
    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 顯示結尾慶祝
        if (celebreate != null)
        {
            celebreate.SetActive(true);
        }
    }
}
