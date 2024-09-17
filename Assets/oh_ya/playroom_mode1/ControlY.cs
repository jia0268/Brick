using UnityEngine;

public class ControlY : MonoBehaviour
{
    public float minY = 0.0f;
    private Rigidbody rb;

    void Start()
    {
        // �ˬd�����Rigidbody�A�p�G�s�b
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // �����e���󪺦�m
        Vector3 now = transform.position;

        // �ˬd����Y�b�O�_�C��minY�A�Y�C��h�NY�b�ȳ]�m��minY
        if (now.y < minY)
        {
            now.y = minY;
            transform.position = now;

            // �p�G��Rigidbody�A�åB��������z�v�T�A�h�N��t�׭��m
            if (rb != null)
            {
                rb.velocity = Vector3.zero;  // ������B��
            }
        }
    }
}
