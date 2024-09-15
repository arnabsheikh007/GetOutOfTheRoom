using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombBlast : MonoBehaviour
{
    public GameObject onPressEffect; // Set collectible's effect on collection.
    public GameObject KeyToDestroy;
    public GameObject player;
    public GameObject Bomb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameObject effect = Instantiate(onPressEffect, transform.position, transform.rotation);

            // Ensure the particle effect only plays once
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
                Destroy(effect, ps.main.duration);  // Destroy the effect after its duration
            }
            Destroy(Bomb); ;
            Destroy(KeyToDestroy);

            Debug.Log("Player has been killed by the bomb blast");
            // Get the Animator component from the player object and set the "isDead" parameter to true
            Animator playerAnimator = other.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                // Set the "isDead" parameter to true
                playerAnimator.SetBool("IsDead", true);
                AudioManager.Instance.playSound("Blast");
            }
            // Disable the player control script 
            //ThirdPersonController playerController = other.GetComponent<ThirdPersonController>();
            //if (playerController != null)
            //{
            //    Debug.Log("Player controller has been disabled");
            //    playerController.enabled = false;  // Disable the player control script
            //}

            // Call the GameOver function from the GameManager script
            GameManager.Instance.GameOver();
        }

    }

}
