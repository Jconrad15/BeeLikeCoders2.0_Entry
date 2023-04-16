using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Action cbOnEnterWorkZone;
    private Action cbOnExitWorkZone;

    private Action cbOnEnterSleepZone;
    private Action cbOnExitSleepZone;

    private Action cbOnEnterRelaxZone;
    private Action cbOnExitRelaxZone;

    private float speed = 5.0f;
    private bool movementEnabled = true;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (movementEnabled == false) { return; }

        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
        }

        float translation =
            Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float straffe =
            Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            cbOnEnterWorkZone?.Invoke();
        }
        else if (other.gameObject.layer == 7)
        {
            cbOnEnterSleepZone?.Invoke();
        }
        else if(other.gameObject.layer == 8)
        {
            cbOnEnterRelaxZone?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            cbOnExitWorkZone?.Invoke();
        }
        else if (other.gameObject.layer == 7)
        {
            cbOnExitSleepZone?.Invoke();
        }
        else if (other.gameObject.layer == 8)
        {
            cbOnExitRelaxZone?.Invoke();
        }
    }

    public void EnableMovement()
    {
        movementEnabled = true;
    }

    public void DisableMovement()
    {
        movementEnabled = false;
    }

    public void RegisterOnEnterWorkZone(Action callbackfunc)
    {
        cbOnEnterWorkZone += callbackfunc;
    }

    public void UnregisterOnEnterWorkZone(Action callbackfunc)
    {
        cbOnEnterWorkZone -= callbackfunc;
    }

    public void RegisterOnExitWorkZone(Action callbackfunc)
    {
        cbOnExitWorkZone += callbackfunc;
    }

    public void UnregisterOnExitWorkZone(Action callbackfunc)
    {
        cbOnExitWorkZone -= callbackfunc;
    }

    public void RegisterOnEnterSleepZone(Action callbackfunc)
    {
        cbOnEnterSleepZone += callbackfunc;
    }

    public void UnregisterOnEnterSleepZone(Action callbackfunc)
    {
        cbOnEnterSleepZone -= callbackfunc;
    }

    public void RegisterOnExitSleepZone(Action callbackfunc)
    {
        cbOnExitSleepZone += callbackfunc;
    }

    public void UnregisterOnExitSleepZone(Action callbackfunc)
    {
        cbOnExitSleepZone -= callbackfunc;
    }

    public void RegisterOnEnterRelaxZone(Action callbackfunc)
    {
        cbOnEnterRelaxZone += callbackfunc;
    }

    public void UnregisterOnEnterRelaxZone(Action callbackfunc)
    {
        cbOnEnterRelaxZone -= callbackfunc;
    }

    public void RegisterOnExitRelaxZone(Action callbackfunc)
    {
        cbOnExitRelaxZone += callbackfunc;
    }

    public void UnregisterOnExitRelaxZone(Action callbackfunc)
    {
        cbOnExitRelaxZone -= callbackfunc;
    }
}
