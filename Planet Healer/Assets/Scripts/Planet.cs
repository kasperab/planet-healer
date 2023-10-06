using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Planet : MonoBehaviour
{
	public float speed;
	public float minY;
	public float minScale;
	public float maxScale;
	public int maxHurt;
	private int hurt;
	public Sprite[] sprites;
	public SpriteRenderer skull;

	public void Start()
	{
		GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
		float scale = Random.Range(minScale, maxScale);
		transform.localScale = new Vector3(scale, scale, scale);
		hurt = Random.Range(0, maxHurt) + 1;
	}

	public void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if (transform.position.y < minY)
		{
			if (hurt > 0)
			{
				Die();
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Die();
		}
		else if (other.tag == "Laser")
		{
			if (hurt > 0)
			{
				hurt -= 1;
				if (hurt <= 0)
				{
					skull.enabled = false;
				}
				transform.parent.GetComponent<PlanetSpawner>().AddPoints(1);
			}
			Destroy(other.gameObject);
		}
	}

	private void Die()
	{
		transform.parent.GetComponent<PlanetSpawner>().LoseHealth();
		Destroy(gameObject);
	}
}
