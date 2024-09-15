using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator doorAnimator;
    public bool isCorrectDoor;

    void Start()
    {
        // Get the Animator component attached to the same GameObject as this script
        doorAnimator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (or another specified object)
        if (other.CompareTag("Player")) // Make sure the player GameObject has the tag "Player"
        {
            if(GameManager.Instance.IsRightKeyCollected())
            {
                if (doorAnimator != null)
                {
                    // Trigger the Door_Open animation
                    doorAnimator.SetTrigger("Door_Open");
                    AudioManager.Instance.playSound("DoorOpen");
                }
                // Call the LevelUp function from the GameManager script
                if (isCorrectDoor)
                {
                    GameManager.Instance.LevelUp();
                }
                else
                {
                    Animator playerAnimator = other.GetComponent<Animator>();
                    if (playerAnimator != null)
                    {
                        // Set the "isDead" parameter to true
                        playerAnimator.SetBool("IsDead", true);
                        AudioManager.Instance.playSound("Blast");
                    }
                    GameManager.Instance.GameOver();
                }
            }
        }
    }
}
