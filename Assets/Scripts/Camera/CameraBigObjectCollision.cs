using UnityEngine;

public class CameraBigObjectCollision : MonoBehaviour
{
    public Transform player;
    public float minDistance = 0.5f;
    public float maxDistance = 3f;
    public float smooth = 10f;
    public LayerMask collisionLayers; // Set this in inspector to BigObjects layer

    private Vector3 dollyDir;
    private float distance;

    void Start()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    void LateUpdate()
    {
        Vector3 desiredCameraPos = player.position + player.TransformDirection(dollyDir * maxDistance);
        RaycastHit hit;

        if (Physics.SphereCast(player.position, 0.2f, desiredCameraPos - player.position, out hit, maxDistance, collisionLayers))
        {
            distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }
}
