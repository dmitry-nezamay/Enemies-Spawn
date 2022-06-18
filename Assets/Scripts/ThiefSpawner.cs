using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ThiefSpawner : MonoBehaviour
{
    private static Random _random = new Random();

    [SerializeField] private GameObject _pointsObject;
    [SerializeField] private Thief _prefab;
    [SerializeField] private float _periodicity;

    private WaitForSeconds _wait;
    private Coroutine _thiefSpawnerCoroutine;
    private Point[] _points;

    private IEnumerator SpawnThief()
    {
        bool isPlaying = true;

        while (isPlaying)
        {
            int pointIndex = _random.Next(0, _points.Length);
            Vector2 pointPosition = _points[pointIndex].transform.position;
            Thief newThief = Instantiate(_prefab, pointPosition, Quaternion.identity);
            yield return _wait;
        }
    }

    private void Awake()
    {
        _wait = new WaitForSeconds(_periodicity);
        _points = _pointsObject.GetComponentsInChildren<Point>();
        _thiefSpawnerCoroutine = StartCoroutine(SpawnThief());
    }
}
