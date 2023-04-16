using UnityEngine;

public class MouseCameraController : MonoBehaviour
{
    private float xSensitivity = 2.0f;
    private float ySensitivity = 1.5f;
    private float smoothing = 2.0f;

    private GameObject playerGO;
    private Vector2 mouseLook;

    private bool lookingEnabled = true;

    private void Start()
    {
        playerGO = transform.parent.gameObject;
    }

    private void Update()
    {
        if (lookingEnabled == false) { return; }

        Vector2 mouseDelta = new Vector2(
            Input.GetAxisRaw("Mouse X") * xSensitivity,
            Input.GetAxisRaw("Mouse Y") * ySensitivity);

        mouseDelta *= smoothing;
        // Note: Lerp isn't quite correct here since this is in update
        Vector2 smoothV = new Vector2();
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
        
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(
            -mouseLook.y, Vector3.right);
        playerGO.transform.localRotation = Quaternion.AngleAxis(
            mouseLook.x, playerGO.transform.up);
    }


    public void EnableLooking()
    {
        lookingEnabled = true;
    }

    public void DisableLooking()
    {
        lookingEnabled = false;
    }
}