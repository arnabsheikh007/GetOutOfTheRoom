using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Duration of a full day in seconds
    [SerializeField]
    private float dayDuration = 120f;

    private void Update()
    {
        // Calculate the rotation angle per second
        float rotationAngle = 360f / dayDuration * Time.deltaTime;

        // Apply rotation to the light
        transform.Rotate(new Vector3(rotationAngle, 0, 0));
    }
}
