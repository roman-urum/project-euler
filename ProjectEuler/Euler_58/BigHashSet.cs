using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Euler_58
{
    public class BigHashSet<T>
    {
        private List<HashSet<T>> hashSets;

        public int Count
        {
            get
            {
                return hashSets.Count;
            }
        }

        public int TotalCount
        {
            get
            {
                return hashSets.Sum(h => h.Count);
            }
        }

        public BigHashSet()
        {
            this.hashSets = new List<HashSet<T>>();
        }

        public void Add(T item)
        {
            if (!hashSets.Any())
            {
                hashSets.Add(new HashSet<T>());
            }

            if (hashSets[hashSets.Count - 1].Count >= 10000000)
            {
                hashSets.Add(new HashSet<T>());
            }

            hashSets[hashSets.Count - 1].Add(item);
        }

        public bool Contains(T item)
        {
            return hashSets.Any(h => h.Contains(item));
        }
    }
}
