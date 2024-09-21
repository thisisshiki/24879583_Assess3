using UnityEngine;

public class PacManMovement : MonoBehaviour
{
    public float speed = 2f; // Movement speed
    public Transform[] waypoints; // Array of waypoints defining the path
    private int currentWaypointIndex = 0; // Current waypoint Pac-Man is moving towards
    private Animator animator; // Animator component for movement animation
    private AudioSource audioSource; // AudioSource component for movement sound

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        PlayMovementAnimationAndSound(); // Play animation and sound initially
    }

    void Update()
    {
        MovePacMan(); // Handle movement each frame
    }

    private void MovePacMan()
    {
        if (waypoints.Length == 0) return; // Exit if no waypoints are set

        // Get the target waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        // Calculate the direction and movement step
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        float step = speed * Time.deltaTime;

        // Move Pac-Man towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

        // Check if Pac-Man has reached the target waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Move to the next waypoint, looping back to the start if needed
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        // Set Pac-Man's orientation to face the movement direction
        SetPacManRotation(direction);
    }

    private void SetPacManRotation(Vector3 direction)
    {
        // Set the rotation based on the movement direction
        if (direction.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0); // Face right
        else if (direction.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0); // Face left
        else if (direction.y > 0)
            transform.rotation = Quaternion.Euler(0, 0, 90); // Face up
        else if (direction.y < 0)
            transform.rotation = Quaternion.Euler(0, 0, -90); // Face down
    }

    private void PlayMovementAnimationAndSound()
    {
        // Play movement animation if Animator is assigned
        if (animator != null)
        {
            animator.SetBool("isMoving", true); // Assuming you have a bool parameter "isMoving" for the animation
        }

        // Play movement sound if AudioSource is assigned
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // Play the audio clip assigned to the AudioSource
        }
    }
}
