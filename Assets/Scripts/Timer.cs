using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const int LeftMouseButtonNumber = 0;

    [SerializeField, Min(0.1f)] private float _delay = 0.5f;

    private int _counter;
    private bool _isEnable = false;
    private Coroutine _coroutine = null;

    public event Action CounterChanged;

    public int Counter { get { return _counter; } }

    private void Start()
    {
        _counter = 0;
        _coroutine = StartCoroutine(IncreaseCounter(_delay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButtonNumber))
        {
            _isEnable = !_isEnable;
        }

        if (_isEnable && _coroutine == null)
        {
            _coroutine = StartCoroutine(IncreaseCounter(_delay));
        }
        else if (!_isEnable && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
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

        while (_isEnable)
        {
            ChangeCounter();
            yield return wait;
        }
    }
}
