using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
//6:45pm oct.5
//9:00pm oct.6
public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;

    public GameController gameController;

    // private instance variables
    //private AudioSource _thunderSound;
    //private AudioSource _yaySound;

    // Start is called before the first frame update
    /*void Start()
    {
        _thunderSound = gameController.audioSources[(int)SoundClip.THUNDER];
        _yaySound = gameController.audioSources[(int)SoundClip.YAY];
    }*/

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method reads player input and moves the player character accordingly
    /// </summary>
    public void Move()
    {
        Vector2 newPosition = transform.position;

        //move right
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            newPosition += new Vector2(speed.max, 0.0f);
        }

        //move left
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            newPosition += new Vector2(speed.min, 0.0f);
        }

        //move down
        if (Input.GetAxis("Vertical") < 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.min);
        }

        //move up
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.max);
        }

        transform.position = newPosition;
    }

    public void CheckBounds()
    {
        // check right boundary
        if (transform.position.x > boundary.Right)
        {
            transform.position = new Vector2(boundary.Right, transform.position.y);
        }

        // check left boundary
        if (transform.position.x < boundary.Left)
        {
            transform.position = new Vector2(boundary.Left, transform.position.y);
        }

        //check bottom boundary
        if (transform.position.y < boundary.Bottom)
        {
            transform.position = new Vector2(transform.position.x, boundary.Bottom);
        }

        //check top boundary
        if (transform.position.y > boundary.Top)
        {
            transform.position = new Vector2(transform.position.x, boundary.Top);
        }
    }

    /// <summary>
    /// this method performs actions when player collider interacts with another collider
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
             //   _thunderSound.Play();
                gameController.Lives -= 1;
                break;
            case "Planet":
                //_yaySound.Play();
                gameController.Score += 100;
                break;
        }
    }
}
