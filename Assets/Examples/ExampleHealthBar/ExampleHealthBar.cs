using CleverCrow.Fluid.Gauges;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExampleHealthBar : MonoBehaviour {
    private readonly Gauge _health = new Gauge(10);

    [SerializeField]
    private Slider _healthBar;

    [SerializeField]
    private UnityEvent _onChange;

    private void Start () {
        _healthBar.maxValue = _health.ChargeMax;
        _healthBar.value = 5;
        _healthBar.onValueChanged.AddListener((changeValue) => _onChange.Invoke());
    }

    public void AddHealth (int health) {
        _healthBar.value += health;
    }

    public void RemoveHealth (int health) {
        _healthBar.value -= health;
    }
}
