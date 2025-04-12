using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ссылка на трансформ игрока
    public float smoothSpeed = 0.125f; // Скорость сглаживания (чем меньше, тем плавнее)
    public Vector3 offset; // Смещение камеры относительно игрока (обычно z = -10)

    void Start()
    {
        // Если offset не задан, установим его по умолчанию (z = -10 для камеры)
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 0, -10);
        }
    }

    void LateUpdate()
    {
        // Желаемая позиция камеры (позиция игрока + смещение)
        Vector3 desiredPosition = target.position + offset;
        // Плавный переход к желаемой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Применяем новую позицию к камере
        transform.position = smoothedPosition;
    }
}