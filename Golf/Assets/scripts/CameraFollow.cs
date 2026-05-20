using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -4f);

    void LateUpdate()
    {
        if (!target) return;

        transform.position = Vector3.Lerp(
            transform.position,
            target.position + offset,
            5f * Time.deltaTime
        );

        Vector3 lookPos = target.position;
        lookPos.y = transform.position.y;

        transform.LookAt(lookPos);
    }
}
