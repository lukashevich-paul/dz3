using TMPro;
using UnityEngine;

public class CountViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.CounterChanged += ShowCount;
    }

    private void OnDisable()
    {
        _timer.CounterChanged -= ShowCount;
    }

    private void ShowCount()
    {
        _text.text = _timer.Counter.ToString("");
    }
}
