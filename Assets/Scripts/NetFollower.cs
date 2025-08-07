using System.Collections;
using UnityEngine;

public class NetFollower : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform netTransform;
    [SerializeField] private Vector3 netLocalOffset = new Vector3(0f, -0.5f, 1f);

    private Quaternion originalLocalRotation;
    private Quaternion overrideRotation;
    private bool useOverrideRotation = false;

    void Start()
    {
        netTransform.SetParent(cameraTransform);
        netTransform.localPosition = netLocalOffset;

        originalLocalRotation = netTransform.localRotation;
        overrideRotation = originalLocalRotation;
    }

    void LateUpdate()
    {
        if (useOverrideRotation)
        {
            netTransform.localRotation = overrideRotation;
        }
        else
        {
            netTransform.localRotation = originalLocalRotation;
        }
    }

    public void SetTemporaryRotation(Quaternion rotation)
    {
        overrideRotation = rotation;
        useOverrideRotation = true;
    }

    public void ResetRotation()
    {
        useOverrideRotation = false;
    }
}
