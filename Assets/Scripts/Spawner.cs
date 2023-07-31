using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
	[SerializeField] float _interval;
	[SerializeField] bool _decreasingInterval;
    [SerializeField] bool _spawnInTime = true;
	[SerializeField] bool _topSpawnOnly;
    float _timeSpent = 20;

	private void FixedUpdate()
	{
		if (GameManager.Single.GameActive)
		{
			if (_spawnInTime)
			{
				_timeSpent += Time.deltaTime;
				if (_timeSpent > (_decreasingInterval ? GameManager.Single.Interval : _interval))
				{
					_timeSpent = 0;

					Spawn();
				}
			}
		}
	}

	private void Spawn()
	{
		var newGO = Instantiate(prefabs[Random.Range(0, prefabs.Length)], SetPosition(), Quaternion.identity);
		newGO.transform.SetParent(transform, true);
	}

	private Vector3 SetPosition()
	{
		if (_topSpawnOnly)
		{
            return new Vector3(Random.Range(-GameManager.Single.RightUpperCorner.x + 1, GameManager.Single.RightUpperCorner.x - 1), GameManager.Single.RightUpperCorner.y + 1, 0);
        }

		if (Random.value > 0.5f)
		{
            return new Vector3(Random.Range(-GameManager.Single.RightUpperCorner.x + 1, GameManager.Single.RightUpperCorner.x - 1),
            Random.value > 0.5f ? -GameManager.Single.RightUpperCorner.y - 1 : GameManager.Single.RightUpperCorner.y + 1, 0);
        }
		else
		{
            return new Vector3(Random.value > 0.5f ? -GameManager.Single.RightUpperCorner.x + 1 : GameManager.Single.RightUpperCorner.x - 1,
            Random.Range(-GameManager.Single.RightUpperCorner.y - 1, GameManager.Single.RightUpperCorner.y + 1), 0);
        }
    }
}
