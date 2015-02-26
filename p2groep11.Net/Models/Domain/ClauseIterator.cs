using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.Domain
{
    public class ClauseIterator : IEnumerable<ClauseComponent>
    {
        private Stack<IEnumerable<ClauseComponent>> stack = new Stack<IEnumerable<ClauseComponent>>();

        public ClauseIterator(IEnumerable<ClauseComponent> iterator) {
            stack.Push(iterator);
        }

        public IEnumerator<ClauseComponent> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}