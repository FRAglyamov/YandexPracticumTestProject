using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstacle;
    [SerializeField]
    private GameObject _scorePoint;

    [SerializeField]
    private Transform _spawnPoint;

    [SerializeField]
    private float _timeTillNextWave = 5f;
    private float _timer = 0f;
    [SerializeField]
    private int _obstacleSpawnAmount = 1;

    [SerializeField]
    private float _verticalOffset = 5f;
    [SerializeField]
    private float _horizontalOffset = 2f;

    private void Start()
    {
        SpawnWave();
    }

    private void Update()
    {
        if(_timer > _timeTillNextWave)
        {
            SpawnWave();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnWave()
    {
        GameObject newScorePoint = Instantiate(_scorePoint);
        newScorePoint.transform.position = _spawnPoint.position + GetRandomOffset();

        _obstacleSpawnAmount = 1 + ((GameController.Instance.GetScorePoints() + 1) / 2); // Increase amount of obstacles every 2 score starting from score 1

        for (int i = 0; i < _obstacleSpawnAmount; i++)
        {
            GameObject newObstacle = Instantiate(_obstacle);
            newObstacle.transform.position = _spawnPoint.position + GetRandomOffset();
        }
    }

    private Vector3 GetRandomOffset()
    {
        return new Vector3(Random.Range(-_horizontalOffset, _horizontalOffset), Random.Range(-_verticalOffset, _verticalOffset), 0);
    }

    // Draw a spawning area in the editor for visualisation
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_spawnPoint.position, new Vector3(_horizontalOffset * 2, _verticalOffset * 2));
    }
}
