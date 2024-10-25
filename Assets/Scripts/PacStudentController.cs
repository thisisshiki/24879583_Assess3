using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector2 targetPosition;
    private bool isMoving = false;
    private Vector2 inputDirection;

    

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (!isMoving)
        {
            GetInput();
            if (inputDirection != Vector2.zero)
            {
                Vector2 newPosition = (Vector2)transform.position + inputDirection;
                if (IsPositionWalkable(newPosition))
                {
                    StartCoroutine(MoveToPosition(newPosition));
                }
            }
        }
    }

    // Check if the position is walkable
    private bool IsPositionWalkable(Vector2 position)
    {
        // Check if the position is inside the grid
        return true;
    }

    // Get input from the player
    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            inputDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputDirection = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputDirection = Vector2.right;
        }
        else
        {
            inputDirection = Vector2.zero;
        }
    }

    // Move the player to the new position
    private IEnumerator MoveToPosition(Vector2 newPosition)
    {
        isMoving = true;
        float elapsedTime = 0.0f;
        Vector2 startingPosition = transform.position;

        while (elapsedTime < 1.0f)
        {
            elapsedTime += Time.deltaTime * moveSpeed;
            transform.position = Vector2.Lerp(startingPosition, newPosition, elapsedTime);
            yield return null;
        }

        transform.position = newPosition;
        targetPosition = newPosition;
        isMoving = false;
    }
}

