using System.Collections;
using UnityEngine;

public class NetController : MonoBehaviour
{
    public float swingAngle = -36f;
    public float swingDuration = 0.5f;

    private Quaternion originalRotation;
    public bool swinging = false;

    private NetFollower netFollower;

    private Collider netTriggerCollider;

    void Start()
    {
        netFollower = GetComponent<NetFollower>();
        originalRotation = transform.localRotation;


        Collider[] colliders = GetComponentsInChildren<Collider>();
        Debug.Log($"Found {colliders.Length} colliders on net and children:");
        foreach (var col in colliders)
        {
            Debug.Log($"- {col.gameObject.name} enabled={col.enabled} isTrigger={col.isTrigger}");
        }

        if (netTriggerCollider == null)
        {
            netTriggerCollider = GetComponentInChildren<Collider>();
        }

        if (netTriggerCollider != null)
        {
            netTriggerCollider.enabled = false;
        }
        else
        Debug.LogError("Net trigger collider not found!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !swinging)
        {
            StartCoroutine(SwingNet());
        }
    }

    IEnumerator SwingNet()
    {
        swinging = true;
        float elapsed = 0f;

        if (netTriggerCollider != null)
        {
            Debug.Log("Enabling net collider for swing");
            netTriggerCollider.enabled = true;
        }

        //Quaternion targetRotation = Quaternion.Euler(transform.localEulerAngles + new Vector3(swingAngle, 0, 0));
        Quaternion startLocalRot = netFollower.netTransform.localRotation;
        Quaternion targetLocalRot = startLocalRot * Quaternion.Euler(swingAngle, 0f, 0f); 

        while (elapsed < swingDuration)
        {
            float t = elapsed / swingDuration;
            Quaternion swingRotation = Quaternion.Slerp(startLocalRot, targetLocalRot, t);

            netFollower.SetTemporaryRotation(swingRotation);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Return to original
        netFollower.SetTemporaryRotation(originalRotation);

        yield return new WaitForSeconds(0.05f); // small pause for visual
        netFollower.ResetRotation();

        swinging = false;

        if (netTriggerCollider != null)
        {
            netTriggerCollider.enabled = false;
        }
    }
}
