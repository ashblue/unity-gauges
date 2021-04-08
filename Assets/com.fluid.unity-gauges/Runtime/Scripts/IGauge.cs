namespace CleverCrow.Fluid.Gauges {
    public interface IGauge {
        int Charge { get; set; }
        int ChargeMax { get; set; }
        float ChargePercent { get; }
        GaugeChangeEvent OnChange { get; }
        bool IsEmpty { get; }
    }
}
