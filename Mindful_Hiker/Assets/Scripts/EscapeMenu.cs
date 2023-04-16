using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    private PlayerController pc;
    private MouseCameraController mcc;

    private void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();
        mcc = FindAnyObjectByType<MouseCameraController>();
        menu.SetActive(false);   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            pc.EnableMovement();
            mcc.EnableLooking();
        }
        else
        {
            menu.SetActive(true);
            pc.DisableMovement();
            mcc.DisableLooking();
        }
    }

}
