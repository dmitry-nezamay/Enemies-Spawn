using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Instantiate : MonoBehaviour
{
    private static Random _random = new Random();

    [SerializeField] private GameObject _pointsObject;
    [SerializeField] private Thief _thiefPrefab;
    [SerializeField] private float _instantiatePeriod;

    private WaitForSeconds _wait;
    private Coroutine _createInstanceCoroutine;
    private Point[] _points;

    private IEnumerator CreateInstance()
    {
        bool isPlaying = true;

        while (isPlaying)
        {
            int pointIndex = _random.Next(0, _points.Length);
            Vector2 pointPosition = _points[pointIndex].transform.position;
            Thief newThief = Instantiate(_thiefPrefab, pointPosition, Quaternion.identity);
            yield return _wait;
        }
    }

    private void Awake()
    {
        _wait = new WaitForSeconds(_instantiatePeriod);
        _points = _pointsObject.GetComponentsInChildren<Point>();
        _createInstanceCoroutine = StartCoroutine(CreateInstance());
    }
}
