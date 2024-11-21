using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Rendering;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    void Start()
    {
        gameOverCanvas.enabled = false;
    }
    
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        //stop time
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        //unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        //make cursor visible
        Cursor.visible = true;
        FindObjectOfType<FirstPersonController>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false;
        
    }
}
