using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                // The character to follow
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Camera offset from the target
    public float smoothSpeed = 0.125f;      // How smooth the camera moves

    void LateUpdate()
    {
        if (target != null)
        {
            // Rotate offset to match the character's rotation
            Vector3 rotatedOffset = target.rotation * offset;

            // Calculate desired camera position
            Vector3 desiredPosition = target.position + rotatedOffset;

            // Smooth the camera position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Look at the character
            transform.LookAt(target.position + Vector3.up * 1.5f); // Look slightly above the target
        }
    }
}
