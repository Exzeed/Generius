using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//4:45pm oct.5
public class SpaceController : MonoBehaviour
{
    public float horizontalSpeed;
    public float resetPosition;
    public float resetPoint;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method moves the background to the left of the screen by horizontalSpeed
    /// </summary>
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the background to the resetPosition
    /// </summary>
    void Reset()
    {
        transform.position = new Vector2(resetPosition, 0.0f);
    }

    /// <summary>
    /// This method checks if the space background reaches the farthest left boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if (transform.position.x <= resetPoint)
        {
            Reset();
        }
    }
}
