using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    private Transform _playerTransform;
    private float _distanceToPlayer;
    [SerializeField]
    private float _distanceToFollow = 4f; // Distance to start moving towards the player

    [SerializeField]
    private float _speed = 20f;
    [SerializeField]
    private float _followSpeed = 15f;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        _distanceToPlayer = Vector2.Distance(transform.position, _playerTransform.position);

        if (_distanceToPlayer < _distanceToFollow)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _followSpeed * Time.deltaTime);
        }

        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.Instance.AddScorePoint();
        Destroy(gameObject);
    }

    // Draw a sphere in editor with _distanceToFollow radius for convenience
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _distanceToFollow);
    }
}
