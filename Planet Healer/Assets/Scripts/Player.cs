using UnityEngine;
using System;

public class Player : MonoBehaviour
{
	public float speed;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public GameObject laser;
	public Transform laserParent;
	public AudioSource laserAudio;
	private bool paused = false;
	private Vector3 startPosition;

	public void Start()
	{
		startPosition = transform.position;
	}

	public void Update()
	{
		if (paused)
		{
			return;
		}
		Vector3 direction = new Vector3(0, 0, 0);
		if (Input.GetKey("up") || Input.GetKey("w"))
		{
			direction.y += 1;
		}
		if (Input.GetKey("down") || Input.GetKey("s"))
		{
			direction.y -= 1;
		}
		if (Input.GetKey("right") || Input.GetKey("d"))
		{
			direction.x += 1;
		}
		if (Input.GetKey("left") || Input.GetKey("a"))
		{
			direction.x -= 1;
		}
		direction.Normalize();
		transform.Translate(direction * speed * Time.deltaTime);
		Vector3 position = transform.position;
		position.x = Math.Clamp(position.x, minX, maxX);
		position.y = Math.Clamp(position.y, minY, maxY);
		transform.position = position;
		if (Input.GetKeyDown("space") || Input.GetKeyDown("return"))
		{
			Instantiate(laser, transform.position, Quaternion.identity, laserParent);
			laserAudio.Play();
		}
	}

	public void Pause()
	{
		paused = true;
	}

	public void Reset()
	{
		paused = false;
		transform.position = startPosition;
	}
}
