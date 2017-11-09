namespace RecyclingStation.BusinestLayer.Attributes
{
    using System;
    using RecyclingStation.WasteDisposal.Attributes;

  public class BurnableStrategyAttribute:DisposableAttribute
    {
        public BurnableStrategyAttribute(Type correspondingStrategyType) : base(correspondingStrategyType)
        {
        }
    }
}
