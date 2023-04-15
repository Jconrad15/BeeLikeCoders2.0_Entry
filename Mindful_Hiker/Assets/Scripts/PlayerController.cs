using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;

    private void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        float translation =
            Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float straffe =
            Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }

}
