using UnityEngine;

public class showufo: MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToShow;

    [SerializeField]
    private Vector3 _showPosition;

    [SerializeField]
    private GameObject _menu; // 把ufo放在面板觸發那層

    private void OnEnable()
    {
        if (_menu != null && _menu.activeSelf && _objectToShow != null)
        {
            _objectToShow.transform.position = _showPosition;
            _objectToShow.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (_objectToShow != null)
        {
            _objectToShow.SetActive(false);
        }
    }

    public void ShowObject()
    {
        if (_objectToShow != null)
        {
            _objectToShow.transform.position = _showPosition;
            _objectToShow.SetActive(true);
        }
    }
}
