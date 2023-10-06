using UnityEngine;
using UnityEngine.UI;

public class PlanetSpawner : MonoBehaviour
{
	public GameObject planet;
	public float minX;
	public float maxX;
	public float y;
	public float minTime;
	public float maxTime;
	private float time;
	public Image[] hearts;
	private int health;
	public Text scoreText;
	private int score;

	public void Start()
	{
		time = Random.Range(minTime, maxTime);
		health = hearts.Length;
		score = 0;
	}

	public void Update()
	{
		if (time > 0)
		{
			time -= Time.deltaTime;
		}
		else if (health > 0)
		{
			Instantiate(planet, new Vector3(Random.Range(minX, maxX), y, 0), Quaternion.identity, transform);
			time = Random.Range(minTime, maxTime);
		}
	}

	public void LoseHealth()
	{
		if (health > 0)
		{
			health--;
			for (int index = 0; index < hearts.Length; index++)
			{
				hearts[index].enabled = health > index;
			}
		}
	}

	public void AddPoints(int points)
	{
		score += points * 10;
		scoreText.text = score.ToString();
		if (minTime > 0)
		{
			minTime -= (float)points / 100;
		}
	}
}
