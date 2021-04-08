using UnityEngine;
using UnityEngine.Events;

namespace CleverCrow.Fluid.Gauges {
    public class GaugeChangeEvent : UnityEvent<int, int>, IGaugeChangeEvent {
    }

    public class Gauge : IGauge {
        private readonly GaugeChangeEvent _onChange = new GaugeChangeEvent();
        private int _chargeMax;
        private int _charge;

        public int ChargeMax {
            get => _chargeMax;
            set {
                _chargeMax = Mathf.Max(1, value);

                if (Charge > _chargeMax) {
                    Charge = _chargeMax;
                }

                _onChange.Invoke(Charge, ChargeMax);
            }
        }

        public int Charge {
            get => _charge;
            set {
                _charge = Mathf.Clamp(value, 0, ChargeMax);
                _onChange.Invoke(Charge, ChargeMax);
            }
        }

        public float ChargePercent => Charge / (float)ChargeMax;
        public GaugeChangeEvent OnChange => _onChange;

        public bool IsEmpty => _charge == 0;

        public Gauge (int chargeMax) {
            ChargeMax = chargeMax;
            Charge = chargeMax;
        }
    }
}
