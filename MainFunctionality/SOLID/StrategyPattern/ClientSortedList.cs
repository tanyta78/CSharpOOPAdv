namespace StrategyPattern
{
    using System.Collections;
    using System.Collections.Generic;

    public class ClientSortedList
    {
        private IList<object> list = new List<object>();

        public void Sort(ISortStrategy strategy)
        {
            strategy.Sort(list);
        }
    }
}
