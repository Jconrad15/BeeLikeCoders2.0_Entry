using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepZone : MonoBehaviour
{
    private bool isInSleepZone = false;
    private WorkDone workDone;
    private Energy energy;
    private Relaxation relaxation;

    private void Start()
    {
        PlayerController pc = FindAnyObjectByType<PlayerController>();
        pc.RegisterOnEnterSleepZone(OnEnterSleepZone);
        pc.RegisterOnExitSleepZone(OnExitSleepZone);

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
}
