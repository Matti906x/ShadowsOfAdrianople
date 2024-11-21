using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] float healthThreshold = 30f; // Threshold at which the vignette effect activates (30% in this case)

    //[SerializeField] AudioClip victory;
    [SerializeField] AudioClip victory;
    SceneLoader sceneLoader;
    //AudioManager audioManager;

    [SerializeField] PostProcessVolume postProcessVolume; // Reference to the Post-Processing Volume
    private Vignette vignette; // Reference to the Vignette effect

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        // Get the Vignette effect from the PostProcessVolume
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        
        if (hitPoints <= healthThreshold || hitPoints <= 0)
        {
            // Activate the vignette effect
            vignette.active = true;
        }
        else
        {
            // Deactivate the vignette effect
            vignette.active = false;
        }
        
        if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Finish")
        {
            sceneLoader.Victory();
            AudioSource.PlayClipAtPoint(victory, transform.position);
        }   
    }
}
