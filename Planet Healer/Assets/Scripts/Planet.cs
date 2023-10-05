using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Planet : MonoBehaviour
{
	public float speed;
	public float minY;
	public float minScale;
	public float maxScale;
	public Sprite[] sprites;

	public void Start()
	{
		GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
		float scale = Random.Range(minScale, maxScale);
		transform.localScale = new Vector3(scale, scale, scale);
	}

	public void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if (transform.position.y < minY)
		{
			Destroy(gameObject);
		}
	}
}
