using System.Collections;
using System;
using UnityEngine;

public class RelaxZone : MonoBehaviour
{
    private bool isInRelaxZone = false;
    private WorkDone workDone;
    private Energy energy;
    private Relaxation relaxation;

    private float relaxationTimeDelay = 6f;

    private bool hasRelaxedBefore = false;
    private Action cbOnFirstTimeRelax;

    private void Start()
    {
        PlayerController pc = FindAnyObjectByType<PlayerController>();
        pc.RegisterOnEnterRelaxZone(OnEnterRelaxZone);
        pc.RegisterOnExitRelaxZone(OnExitRelaxZone);

        workDone = pc.GetComponent<WorkDone>();
        energy = pc.GetComponent<Energy>();
        relaxation = pc.GetComponent<Relaxation>();
    }

    /// <summary>
    /// Relax until exit relax zone
    /// </summary>
    /// <returns></returns>
    private IEnumerator Relax()
    {
        yield return new WaitForEndOfFrame();

        while (isInRelaxZone)
        {
            yield return new WaitForSeconds(relaxationTimeDelay);

            relaxation.IncreaseRelaxation(4);

            workDone.DecreaseWorkDone(2);
            energy.DecreaseEnergy(2);
        }
    }

    private void OnEnterRelaxZone()
    {
        if (hasRelaxedBefore == false)
        {
            hasRelaxedBefore = true;
            cbOnFirstTimeRelax?.Invoke();
        }

        isInRelaxZone = true;
        StartCoroutine(Relax());
    }

    private void OnExitRelaxZone()
    {
        isInRelaxZone = false;
        StopAllCoroutines();
    }

    public void RegisterOnFirstTimeRelax(Action callbackfunc)
    {
        cbOnFirstTimeRelax += callbackfunc;
    }

    public void UnregisterOnFirstTimeRelax(Action callbackfunc)
    {
        cbOnFirstTimeRelax -= callbackfunc;
    }
}
