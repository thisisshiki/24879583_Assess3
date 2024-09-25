
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    public Transform pacman;
    public float speed = 2.0f;
    public AudioSource movementAudioSource;
    public Animator pacmanAnimator;

    // Define positions of the four corners
    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 pointC;
    private Vector3 pointD;
    private Vector3 targetPosition;

    void Start()
    {
        // Initialize positions of the four corners
        pointA = new Vector3(-4.5f, 1.5f, 0);  // Top-left corner
        pointB = new Vector3(0.5f, 1.5f, 0);   // Top-right corner
        pointC = new Vector3(0.5f, -2.5f, 0);  // Bottom-right corner
        pointD = new Vector3(-4.5f, -2.5f, 0); // Bottom-left corner
        
        // Set initial target position to point A
        targetPosition = pointB;

        // Start movement
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        // Set the direction parameter based on the target position
        SetDirection(targetPosition);

        pacmanAnimator.SetBool("isMoving", true);
        movementAudioSource.Play();

        // Start the tweening coroutine
        StartCoroutine(MovePacman());
    }

    void SetDirection(Vector3 target)
    {
        Vector3 direction = target - pacman.position;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Horizontal movement
            if (direction.x > 0)
                pacmanAnimator.SetInteger("direction", 1); // Right
            else
                pacmanAnimator.SetInteger("direction", 3); // Left
        }
        else
        {
            // Vertical movement
            if (direction.y > 0)
                pacmanAnimator.SetInteger("direction", 0); // Up
            else
                pacmanAnimator.SetInteger("direction", 2); // Down
        }
    }

    System.Collections.IEnumerator MovePacman()
    {
        Vector3 startPosition = pacman.position;
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (Vector3.Distance(pacman.position, targetPosition) > 0.01f)
        {
            // Calculate the distance covered based on time
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;

            // Interpolate position
            pacman.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

            yield return null;
        }

        // Ensure the final position is set to the target position
        pacman.position = targetPosition;

        // Stop audio and animation when Pac-Man reaches the target
        pacmanAnimator.SetBool("isMoving", false);
        movementAudioSource.Stop();

        // Decide the next target point to move towards clockwise
        if (targetPosition == pointB)
            targetPosition = pointC;
        else if (targetPosition == pointC)
            targetPosition = pointD;
        else if (targetPosition == pointD)
            targetPosition = pointA;
        else if (targetPosition == pointA)
            targetPosition = pointB;

        // Call this method to continue the loop
        MoveToNextPoint();
    }
}