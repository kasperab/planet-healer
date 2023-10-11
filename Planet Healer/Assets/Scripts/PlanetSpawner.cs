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
	private float minTimeStart;
	private float maxTimeStart;
	private float time;
	public Image[] hearts;
	private int health;
	public Text scoreText;
	private int score;
	public Text highscoreText;
	private int highscore;
	public AudioSource healAudio;
	public AudioSource explosionAudio;
	public AudioSource music;
	public Player player;
	public GameObject gameOver;

	public void Start()
	{
		minTimeStart = minTime;
		maxTimeStart = maxTime;
		time = Random.Range(minTime, maxTime);
		health = hearts.Length;
		score = 0;
		highscore = 0;
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
		health--;
		for (int index = 0; index < hearts.Length; index++)
		{
			hearts[index].enabled = health > index;
		}
		explosionAudio.Play();
		if (health <= 0)
		{
			gameOver.SetActive(true);
			if (score > highscore)
			{
				highscore = score;
				highscoreText.text = highscore.ToString();
			}
			player.Pause();
			music.Stop();
			foreach (Planet planet in GetComponentsInChildren<Planet>())
			{
				planet.Die();
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
			maxTime -= (float)points / 100;
		}
		healAudio.Play();
	}

	public void Reset()
	{
		gameOver.SetActive(false);
		health = hearts.Length;
		foreach (Image heart in hearts)
		{
			heart.enabled = true;
		}
		minTime = minTimeStart;
		maxTime = maxTimeStart;
		time = Random.Range(minTime, maxTime);
		score = 0;
		scoreText.text = score.ToString();
		player.Reset();
		music.Play();
	}
}
