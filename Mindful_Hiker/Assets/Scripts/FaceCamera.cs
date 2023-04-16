using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    private void Update()
    {
        Vector3 worldPos =
            transform.position
            + Camera.main.transform.rotation * Vector3.forward;

        transform.LookAt(worldPos, Vector3.up);
    }

}