using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] GameObject arrow;
    [SerializeField] Transform arrowLocation;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI arrowText;

    bool canShoot = true;

    void OnEnable()
    {
        canShoot = true;
    }
    
    void Update()
    {
        DisplayArrow();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    void DisplayArrow()
    {
        int currentArrow = ammoSlot.GetCurrentAmmo();
        arrowText.text = currentArrow.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            InstantiateArrow();
            ammoSlot.ReduceCurrentAmmo();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void InstantiateArrow()
    {        
        // Calculate the rotation to align the arrow with the shooting direction and the world up vector
        Quaternion arrowRotation = Quaternion.LookRotation(FPCamera.transform.forward, Vector3.up);

        // Offset the position to avoid immediate collision with the player
        Vector3 spawnPosition = arrowLocation.position + FPCamera.transform.forward * 0.5f;

        // Instantiate the arrow with the new rotation
        GameObject instantiatedArrow = Instantiate(arrow, spawnPosition, arrowRotation);

        // Set the direction for the arrow to move
        Arrow arrowScript = instantiatedArrow.GetComponent<Arrow>();
        if (arrowScript != null)
        {
            arrowScript.SetDirection(FPCamera.transform.forward);
            arrowScript.SetDamage(damage); // Pass the damage to the arrow
        }
    }
}