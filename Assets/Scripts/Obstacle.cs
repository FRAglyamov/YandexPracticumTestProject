using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20f;
    [SerializeField]
    private float _frequency = 1f; // How fast it moves up and down
    [SerializeField]
    private float _amplitude = 2f; // How far it move up and down
    private float _startYPos;
    private float _randomVerticalSeed; // Value to randomize initial vertical movement

    private void Start()
    {
        Destroy(gameObject, 5f);
        _startYPos = transform.position.y;
        _randomVerticalSeed = Random.Range(0, 2 * Mathf.PI);
    }

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        float newYPos = _startYPos + Mathf.Sin((Time.time + _randomVerticalSeed) * _frequency) * _amplitude;
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
    }
}
