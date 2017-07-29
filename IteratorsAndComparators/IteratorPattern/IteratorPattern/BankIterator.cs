using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IteratorPattern
{
    public class BankIterator : IEnumerable
    {
        private IList _list = new ArrayList();

        public BankIterator(Bank bank)
        {
            _list.Add(bank.Manager);
            _list.Add(bank.Accountant);
            _list.Add(bank.Cashier);
        }

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
