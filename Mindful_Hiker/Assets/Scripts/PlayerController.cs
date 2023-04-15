using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Action cbOnEnterWorkZone;
    private Action cbOnExitWorkZone;

    private Action cbOnEnterSleepZone;
    private Action cbOnExitSleepZone;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            cbOnEnterWorkZone?.Invoke();
            Debug.Log("Enter work zone");
        }
        else if (other.gameObject.layer == 7)
        {
            cbOnEnterSleepZone?.Invoke();
            Debug.Log("Enter sleep zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            cbOnExitWorkZone?.Invoke();
            Debug.Log("Exit work zone");
        }
        else if (other.gameObject.layer == 7)
        {
            cbOnExitSleepZone?.Invoke();
            Debug.Log("Exit sleep zone");
        }
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
}
