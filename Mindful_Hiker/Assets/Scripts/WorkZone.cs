using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkZone : MonoBehaviour
{
    private bool isInWorkZone = false;
    private WorkDone workDone;
    private Energy energy;
    private Relaxation relaxation;

    private void Start()
    {
        PlayerController pc = FindAnyObjectByType<PlayerController>();
        pc.RegisterOnEnterWorkZone(OnEnterWorkZone);
        pc.RegisterOnExitWorkZone(OnExitWorkZone);

        workDone = pc.GetComponent<WorkDone>();
        energy = pc.GetComponent<Energy>();
        relaxation = pc.GetComponent<Relaxation>();
    }

    private void Update()
    {
        if (isInWorkZone == false)
        {
            return;
        }

        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Work();
        }
    }

    private void Work()
    {
        workDone.IncreaseWorkDone(5);

        energy.DecreaseEnergy(5);
        relaxation.DecreaseRelaxation(5);
    }

    private void OnEnterWorkZone()
    {
        isInWorkZone = true;
    }

    private void OnExitWorkZone()
    {
        isInWorkZone = false;
    }

}
