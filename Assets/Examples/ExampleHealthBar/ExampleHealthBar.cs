using UnityEngine;
using UnityEngine.UI;

namespace CleverCrow.Fluid.Gauges {
    public class ExampleHealthBar : MonoBehaviour {
        private readonly Gauge _health = new Gauge(10);

        [SerializeField]
        private Slider _healthBar;

        private void Start () {
            _healthBar.maxValue = _health.ChargeMax;
            _healthBar.value = 5;
        }

        public void AddHealth (int health) {
            _healthBar.value += health;
        }

        public void RemoveHealth (int health) {
            _healthBar.value -= health;
        }
    }
}
