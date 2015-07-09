using System.Collections.Generic;
using System.Linq;

namespace BookHelper
{
    internal class Book
    {
        private readonly List<PagesRange> _readPages = new List<PagesRange>();

        public readonly int PagesCount;

        public Book(int pagesCount)
        {
            PagesCount = pagesCount;
        }

        public void AddRange(int from, int to)
        {
            _readPages.Add(new PagesRange(from, to));
        }

        public int HowManyPagesLeft()
        {
            // TODO 3: Improve/fix the code here.
            var readPages = 0;
            var tempList = _readPages.ToList();
            //foreach (var range in tempList)
            //{
            //    if (_readPages.Any(n => (range.To >= n.To && range.From <= n.From)))
            //    {
            //        _readPages.Remove(range);
                    
            //    }

            //}
            foreach (var range in tempList)
            {
                _readPages.Remove(range);
                var toCut = _readPages.Where(n => (n.To <= range.To && n.From <= range.From)).ToList();
                _readPages.Add(range);
                foreach (var item in toCut)
                {
                    var tempItem = new PagesRange(item.From, range.To);
                    _readPages.Remove(item);
                    _readPages.Remove(range);
                    _readPages.Add(tempItem);
                }

            }


            foreach (var item in _readPages)
            {
                readPages += (item.To - item.From + 1);
            }

            var leftPages = PagesCount - readPages;
            return leftPages;
        }
    }
}
