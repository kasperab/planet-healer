using UnityEngine;

public class Laser : MonoBehaviour
{
	public float speed;
	public float maxY;

	public void Update()
	{
		transform.Translate(Vector3.up * speed * Time.deltaTime);
		if (transform.position.y > maxY)
		{
			Destroy(gameObject);
		}
	}
}
