using System.Collections;
using UnityEngine;

public class NetController : MonoBehaviour
{
    public float swingAngle = -36f;
    public float swingDuration = 0.5f;

    private Quaternion originalRotation;
    private bool swinging = false;

    private NetFollower netFollower;

    void Start()
    {
        netFollower = GetComponent<NetFollower>();
        originalRotation = transform.localRotation;
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

        Quaternion targetRotation = Quaternion.Euler(transform.localEulerAngles + new Vector3(swingAngle, 0, 0));

        while (elapsed < swingDuration)
        {
            float t = elapsed / swingDuration;
            Quaternion swingRotation = Quaternion.Slerp(originalRotation, targetRotation, t);
            netFollower.SetTemporaryRotation(swingRotation);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Return to original
        netFollower.SetTemporaryRotation(originalRotation);

        yield return new WaitForSeconds(0.05f); // small pause for visual
        netFollower.ResetRotation();

        swinging = false;
    }
}
