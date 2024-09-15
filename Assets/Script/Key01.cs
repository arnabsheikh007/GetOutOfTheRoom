using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key01 : MonoBehaviour
{
    public float rotationSpeed; // Set collectible's rotation speed.
    public GameObject onCollectEffect; // Set collectible's effect on collection.
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the collectible
            Destroy(key);

            AudioManager.Instance.playSound("KeyCollect");

            // instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);

            // Call the RightKeyCollected method from the GameManager script.
            GameManager.Instance.RightKeyCollected();
        }

    }
}
