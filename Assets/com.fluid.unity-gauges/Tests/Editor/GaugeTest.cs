using NUnit.Framework;

namespace CleverCrow.Fluid.Gauges.Tests {
    public class GaugeTest {
        public class OnCreation {
            [Test]
            public void Sets_the_max_value () {
                var gauge = new Gauge(20);

                Assert.AreEqual(20, gauge.ChargeMax);
            }

            [Test]
            public void Sets_the_value_to_max_value () {
                var gauge = new Gauge(20);

                Assert.AreEqual(20, gauge.Charge);
            }
        }

        public class OnChangeEvent {
            [Test]
            public void Triggers_if_charge_max_changes () {
                var gauge = new Gauge(20);
                var maxValue = -1;

                gauge.OnChange.AddListener((value, max) => maxValue = max);
                gauge.ChargeMax = 10;

                Assert.AreEqual(10, maxValue);
            }

            [Test]
            public void Triggers_if_charge_changes () {
                var gauge = new Gauge(20);
                var newValue = -1;

                gauge.OnChange.AddListener((value, max) => newValue = value);
                gauge.Charge = 2;

                Assert.AreEqual(2, newValue);
            }
        }

        public class ChargeMaxProperty {
            [Test]
            public void Cannot_be_set_less_than_one () {
                var gauge = new Gauge(0);

                Assert.AreEqual(1, gauge.ChargeMax);
            }

            [Test]
            public void Can_be_changed_after_constructing () {
                var gauge = new Gauge(20);
                gauge.ChargeMax = 10;

                Assert.AreEqual(10, gauge.ChargeMax);
            }

            [Test]
            public void Changing_ChargeMax_removes_Charge_overflow () {
                var gauge = new Gauge(20);
                gauge.ChargeMax = 10;

                Assert.AreEqual(10, gauge.Charge);
            }

            [Test]
            public void Changing_ChargeMax_does_not_increase_Charge () {
                var gauge = new Gauge(20);
                gauge.ChargeMax = 10;
                gauge.ChargeMax = 20;

                Assert.AreEqual(10, gauge.Charge);
            }
        }

        public class ChargeProperty {
            [Test]
            public void Changes_when_set () {
                var gauge = new Gauge(20);
                gauge.Charge = 10;

                Assert.AreEqual(10, gauge.Charge);
            }

            [Test]
            public void Cannot_exceed_charge_max_value () {
                var gauge = new Gauge(20);
                gauge.Charge = 21;

                Assert.AreEqual(20, gauge.Charge);
            }

            [Test]
            public void Cannot_drop_below_zero () {
                var gauge = new Gauge(20);
                gauge.Charge = -1;

                Assert.AreEqual(0, gauge.Charge);
            }
        }

        public class IsEmptyProperty {
            [Test]
            public void Returns_true_when_zero () {
                var gauge = new Gauge(20);
                gauge.Charge = 0;

                Assert.IsTrue(gauge.IsEmpty);
            }

            [Test]
            public void Returns_false_when_not_zero () {
                var gauge = new Gauge(20);

                Assert.IsFalse(gauge.IsEmpty);
            }
        }
    }
}
