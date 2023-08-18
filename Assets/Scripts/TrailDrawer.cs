using System.Collections.Generic;
using UnityEngine;

public class TrailDrawer : MonoBehaviour
{
    public float lifetime = 1f; // Lifetime of a point on the trail

    public float minimumVertexDistance = 1f; // Minimum distance moved before a new point is solidified

    public Vector3 velocity = new Vector3(10,0,0); // Direction and speed for points moving

    private LineRenderer _lineRenderer;

    private List<Vector3> _points;
    private Queue<float> _spawnTimes = new Queue<float>(); // List of spawn times, to simulate lifetime. Back of the queue is vertex 1, front of the queue is the end of the trail.
                                                           // Length of this queue is one less than the number of positions in the linerenderer, since the linerenderer always has a non-solidified vertex at the object's position.

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.useWorldSpace = true;
        _points = new List<Vector3>() { transform.position }; // Indices 1 - end are solidified points, index 0 is always transform.position
        _lineRenderer.SetPositions(_points.ToArray());
    }

    private void AddPoint(Vector3 position)
    {
        _points.Insert(1, position);
        _spawnTimes.Enqueue(Time.time);
    }

    private void RemovePoint()
    {
        _spawnTimes.Dequeue();
        _points.RemoveAt(_points.Count - 1); // Remove corresponding oldest point at the end
    }

    private void Update()
    {

        // Cull based on lifetime
        while (_spawnTimes.Count > 0 && _spawnTimes.Peek() + lifetime < Time.time)
        {
            RemovePoint();
        }

        // Move positions
        Vector3 diff = -velocity * Time.deltaTime;
        for (int i = 1; i < _points.Count; i++)
        {
            _points[i] += diff;
        }

        // Add new point
        if (_points.Count < 2 || Vector3.Distance(transform.position, _points[1]) > minimumVertexDistance)
        {
            // If we have no solidified points, or we’ve moved enough for a new point
            AddPoint(transform.position);
        }

        // Update index 0;
        _points[0] = transform.position;

        // Save result
        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPositions(_points.ToArray());
    }
}

