namespace RecyclingStation.BusinestLayer.Attributes
{
    using System;
    using RecyclingStation.WasteDisposal.Attributes;

   public class RecyclableStrategyAttribute:DisposableAttribute
    {
        public RecyclableStrategyAttribute(Type correspondingStrategyType) : base(correspondingStrategyType)
        {
        }
    }
}
