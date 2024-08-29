using UnityEngine;

public class ToggleObject: MonoBehaviour
{
    // ��Prefab
    [SerializeField]
    private GameObject _objectPrefab;

    // ��l��m
    [SerializeField]
    private Vector3 _showPosition;

    // �P�_���ʪ��~�t��
    [SerializeField]
    private float _movementThreshold = 0.1f;

    // �ͦ�������
    private GameObject _currentObjectInstance;

    public static GameObject SelectedObject { get; private set; }  // �s�W���R�A�ܼơA�ΨӫO�s��e��ܪ�����

    public void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            // �p�G�w������
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

            // �ͦ��s������A�ñ���y�b90��
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            _currentObjectInstance = Instantiate(_objectPrefab, _showPosition, rotation);
            SelectedObject = _currentObjectInstance;  // �O�s��e��ܪ�����
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
