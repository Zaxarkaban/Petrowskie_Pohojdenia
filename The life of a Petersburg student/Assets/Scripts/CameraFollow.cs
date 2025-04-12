using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ������ �� ��������� ������
    public float smoothSpeed = 0.125f; // �������� ����������� (��� ������, ��� �������)
    public Vector3 offset; // �������� ������ ������������ ������ (������ z = -10)

    void Start()
    {
        // ���� offset �� �����, ��������� ��� �� ��������� (z = -10 ��� ������)
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 0, -10);
        }
    }

    void LateUpdate()
    {
        // �������� ������� ������ (������� ������ + ��������)
        Vector3 desiredPosition = target.position + offset;
        // ������� ������� � �������� �������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // ��������� ����� ������� � ������
        transform.position = smoothedPosition;
    }
}