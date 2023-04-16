using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepZone : MonoBehaviour
{
    private bool isInSleepZone = false;
    private WorkDone workDone;
    private Energy energy;
    private Relaxation relaxation;

    private bool hasSleptBefore = false;
    private Action cbOnFirstTimeSleep;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip sleepClip;

    private void Start()
    {
        PlayerController pc = FindAnyObjectByType<PlayerController>();
        pc.RegisterOnEnterSleepZone(OnEnterSleepZone);
        pc.RegisterOnExitSleepZone(OnExitSleepZone);

        audioSource = GetComponent<AudioSource>();

        workDone = pc.GetComponent<WorkDone>();
        energy = pc.GetComponent<Energy>();
        relaxation = pc.GetComponent<Relaxation>();
    }

    private void Update()
    {
        if (isInSleepZone == false)
        {
            return;
        }

        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sleep();
        }
    }

    private void Sleep()
    {
        audioSource.PlayOneShot(sleepClip);

        if (hasSleptBefore == false)
        {
            hasSleptBefore = true;
            cbOnFirstTimeSleep?.Invoke();
        }

        energy.IncreaseEnergy(100);

        workDone.DecreaseWorkDone(40);
        relaxation.DecreaseRelaxation(20);
    }

    private void OnEnterSleepZone()
    {
        isInSleepZone = true;
    }

    private void OnExitSleepZone()
    {
        isInSleepZone = false;
    }

    public void RegisterOnFirstTimeSleep(Action callbackfunc)
    {
        cbOnFirstTimeSleep += callbackfunc;
    }

    public void UnregisterOnFirstTimeSleep(Action callbackfunc)
    {
        cbOnFirstTimeSleep -= callbackfunc;
    }
}
