using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelaxZone : MonoBehaviour
{
    private bool isInRelaxZone = false;
    private WorkDone workDone;
    private Energy energy;
    private Relaxation relaxation;

    private float relaxationTimeDelay = 6f;

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

            relaxation.IncreaseRelaxation(6);

            workDone.DecreaseWorkDone(2);
            energy.DecreaseEnergy(2);
        }
    }

    private void OnEnterRelaxZone()
    {
        isInRelaxZone = true;
        StartCoroutine(Relax());
    }

    private void OnExitRelaxZone()
    {
        isInRelaxZone = false;
        StopAllCoroutines();
    }

}
