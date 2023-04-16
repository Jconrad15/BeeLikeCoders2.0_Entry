using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMessageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject popup1;
    [SerializeField]
    private GameObject popup2;
    [SerializeField]
    private GameObject door1;

    [SerializeField]
    private GameObject popup3;
    [SerializeField]
    private GameObject popup4;
    [SerializeField]
    private GameObject door2;
    [SerializeField]
    private GameObject door3;

    [SerializeField]
    private GameObject popup5;

    [SerializeField]
    private GameObject popup6;

    private void Start()
    {
        WorkZone workZone = FindAnyObjectByType<WorkZone>();
        workZone.RegisterOnThreeTimesWorked(OnThreeTimesWorked);

        SleepZone sleepZone = FindAnyObjectByType<SleepZone>();
        sleepZone.RegisterOnFirstTimeSleep(OnFirstTimeSleep);

        RelaxZone relaxZone = FindAnyObjectByType<RelaxZone>();
        relaxZone.RegisterOnFirstTimeRelax(OnFirstTimeRelax);

        popup3.SetActive(false);
        popup4.SetActive(false);
        popup5.SetActive(false);
        popup6.SetActive(false);
    }

    private void OnThreeTimesWorked()
    {
        Destroy(popup1);
        Destroy(popup2);
        Destroy(door1);
        popup3.SetActive(true);
        popup4.SetActive(true);
    }

    private void OnFirstTimeSleep()
    {
        Destroy(popup3);
        Destroy(popup4);
        Destroy(door2);
        Destroy(door3);
        popup5.SetActive(true);
    }

    private void OnFirstTimeRelax()
    {
        Destroy(popup5);
        StartCoroutine(ShowLastPopupMessage());
    }

    private IEnumerator ShowLastPopupMessage()
    {
        yield return new WaitForEndOfFrame();
        popup6.SetActive(true);
        yield return new WaitForSeconds(10f);
        Destroy(popup6);
    }
}
