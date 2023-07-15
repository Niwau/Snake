using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    public float speed = 2f;
    public List<GameObject> segments = new List<GameObject>();
    public GameObject tail;
    private System.Random randomizer = new System.Random();

    void PlayScoreSound() {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.Play();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Food":
                PlayScoreSound();
                Grow();
            break;
            case "Wall":
            case "Snake":
                Die();
            break;
        }
    }

    void FixedUpdate()
    {
        MoveSegments();
        MoveHead();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
    }

    void MoveHead()
	{
		transform.position = new Vector3(transform.position.x + direction.x, transform.position.y + direction.y, 0);
	}

    void Die() {
        foreach (GameObject segment in segments) {
            Destroy(segment);
        }
        segments.Clear();
        transform.position = Vector2.zero;
    }

    void MoveSegments()
    {
        // make the segments follow your next segment
        for (int i = segments.Count - 1; i >= 1; i--)
        {
            segments[i].transform.position = segments[i - 1].transform.position;
        }

        // make the segment before the head follow the head;
        if (segments.Count > 0)
        {
            segments[0].transform.position = transform.position;
        }
    }

    void Grow()
    {
        segments.Add(Instantiate(tail));
    }

}
