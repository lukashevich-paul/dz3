using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _delay = 0.5f;

    private int _counter;
    private bool _isEnable = false;

    public int Counter { get { return _counter; } }

    public event Action CounterChanged;

    private void Start()
    {
        _counter = 0;

        StartCoroutine(IncreaseCounter(_delay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isEnable = !_isEnable;
        }
    }

    private void ChangeCounter()
    {
        _counter++;

        CounterChanged?.Invoke();
    }

    private IEnumerator IncreaseCounter(float _delay)
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            if (_isEnable)
            {
                ChangeCounter();
            }

            yield return wait;
        }
    }
}
