using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkZone : MonoBehaviour
{
    private bool isInWorkZone = false;
    private WorkDone workDone;
    private Energy energy;
    private Relaxation relaxation;

    private int workedCount = 0;
    private Action cbOnThreeTimesWorked;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip workClip;

    private void Start()
    {
        PlayerController pc = FindAnyObjectByType<PlayerController>();
        pc.RegisterOnEnterWorkZone(OnEnterWorkZone);
        pc.RegisterOnExitWorkZone(OnExitWorkZone);

        audioSource = GetComponent<AudioSource>();

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
        audioSource.PlayOneShot(workClip);

        if (workedCount <= 3)
        {
            workedCount++;
            if (workedCount == 3)
            {
                cbOnThreeTimesWorked?.Invoke();
            }
        }

        workDone.IncreaseWorkDone(20);

        energy.DecreaseEnergy(10);
        relaxation.DecreaseRelaxation(10);
    }

    private void OnEnterWorkZone()
    {
        isInWorkZone = true;
    }

    private void OnExitWorkZone()
    {
        isInWorkZone = false;
    }

    public void RegisterOnThreeTimesWorked(Action callbackfunc)
    {
        cbOnThreeTimesWorked += callbackfunc;
    }

    public void UnregisterOnThreeTimesWorked(Action callbackfunc)
    {
        cbOnThreeTimesWorked -= callbackfunc;
    }

}
