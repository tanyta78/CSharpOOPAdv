namespace StrategyPattern
{
    using System.Collections.Generic;

    public interface ISortStrategy
    {
        void Sort(IList<object> list);
    }
}
