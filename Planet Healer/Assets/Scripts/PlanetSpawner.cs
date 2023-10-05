using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
	public GameObject planet;
	public float minX;
	public float maxX;
	public float y;
	public float minTime;
	public float maxTime;
	private float time;

	public void Start()
	{
		time = Random.Range(minTime, maxTime);
	}

	public void Update()
	{
		if (time > 0)
		{
			time -= Time.deltaTime;
		}
		else
		{
			Instantiate(planet, new Vector3(Random.Range(minX, maxX), y, 0), Quaternion.identity, transform);
			time = Random.Range(minTime, maxTime);
		}
	}
}
