using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -4f);

    void LateUpdate()
    {
        if (!target) return;

        Vector3 rotatedOffset = target.rotation * offset;
        transform.position = Vector3.Lerp(
            transform.position,
            target.position + rotatedOffset,
            5f * Time.deltaTime
        );

        Vector3 lookPos = target.position;
        lookPos.y = transform.position.y;

        transform.LookAt(lookPos);
    }
}
