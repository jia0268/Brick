using UnityEngine;

public class ToggleObject: MonoBehaviour
{
    // 放Prefab
    [SerializeField]
    private GameObject _objectPrefab;

    // 初始位置
    [SerializeField]
    private Vector3 _showPosition;

    // 判斷移動的誤差值
    [SerializeField]
    private float _movementThreshold = 0.1f;

    // 生成的物件
    private GameObject _currentObjectInstance;

    public static GameObject SelectedObject { get; private set; }  // 新增的靜態變數，用來保存當前選擇的物件

    public void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            // 如果已有物件
            if (_currentObjectInstance != null)
            {
                bool hasMoved = Vector3.Distance(_currentObjectInstance.transform.position, _showPosition) >= _movementThreshold;

                if (hasMoved)
                {
                    Rigidbody rb = _currentObjectInstance.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.useGravity = true;
                        rb.isKinematic = false;
                    }
                }
                else
                {
                    _currentObjectInstance.SetActive(false);
                }
            }

            // 生成新的物件，並旋轉y軸90度
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            _currentObjectInstance = Instantiate(_objectPrefab, _showPosition, rotation);
            SelectedObject = _currentObjectInstance;  // 保存當前選擇的物件
            Rigidbody newRb = _currentObjectInstance.GetComponent<Rigidbody>();

            if (newRb != null)
            {
                newRb.useGravity = false;
                newRb.isKinematic = true;
            }
        }
        else
        {
            if (_currentObjectInstance != null)
            {
                Rigidbody rb = _currentObjectInstance.GetComponent<Rigidbody>();

                bool hasMoved = Vector3.Distance(_currentObjectInstance.transform.position, _showPosition) >= _movementThreshold;

                if (hasMoved)
                {
                    if (rb != null)
                    {
                        rb.useGravity = true;
                        rb.isKinematic = false;
                    }
                }
                else
                {
                    _currentObjectInstance.SetActive(false);
                }
            }
        }
    }
}
