using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
	public float speed;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public GameObject laser;
	public Transform laserParent;
	private AudioSource laserAudio;

	public void Start()
	{
		laserAudio = GetComponent<AudioSource>();
	}

	public void Update()
	{
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
}
