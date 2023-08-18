using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _rb;
    [SerializeField]
    private float _risingSpeed = 0.5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            _rb.velocity += Vector2.up * _risingSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameController.Instance.GameOver();
        }
    }
}
