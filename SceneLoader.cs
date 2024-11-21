using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Camera cameraController;
    [SerializeField] Canvas mainMenuCanvas;
    [SerializeField] Canvas creditsCanvas;
    [SerializeField] Canvas victoryCanvas;
    
    public void Start()
    {
        BackToStart();
        victoryCanvas.enabled = false;
    }

    public void BackToStart()
    {
        creditsCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
        //stop time
        Time.timeScale = 0;
        //FindObjectOfType<WeaponSwitcher>().enabled = false;
        //unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        //make cursor visible
        Cursor.visible = true;
        FindObjectOfType<FirstPersonController>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false;
    }

    public void StartGame()
    {
        mainMenuCanvas.enabled = false;
        //stop time
        Time.timeScale = 1;
        //unlock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        //make cursor visible
        Cursor.visible = false;
        FindObjectOfType<FirstPersonController>().enabled = true;
        FindObjectOfType<Weapon>().enabled = true;
    }
    
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        FindObjectOfType<FirstPersonController>().enabled = true;
        FindObjectOfType<Weapon>().enabled = true;
    }

    public void ShowCredits()
    {
        mainMenuCanvas.enabled = false;
        creditsCanvas.enabled = true;
    }

    public void Victory()
    {
        victoryCanvas.enabled = true;
        //stop time
        Time.timeScale = 0;
        //unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        //make cursor visible
        Cursor.visible = true;
        FindObjectOfType<FirstPersonController>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
