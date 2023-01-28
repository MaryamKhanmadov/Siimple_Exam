namespace Siimple_Template_Exam.Helpers
{
    public class PaginatedList<T> :List<T>
    {
        public PaginatedList(List<T> values , int count , int pagesize , int activepage)
        {
            AddRange(values);
            ActivePage = activepage;
            TotalPageCount = (int)Math.Ceiling((double)count / pagesize);
        }
        public int TotalPageCount { get; set; }
        public int ActivePage { get; set; }
        public bool HasNext { get => ActivePage<TotalPageCount; }
        public bool HasPrevious { get => ActivePage > 1 ; }

        public static PaginatedList<T> Create(IQueryable<T> values, int pagesize, int activepage)
        {
            return new PaginatedList<T>(values.Skip((activepage - 1) * pagesize).Take(pagesize).ToList(), values.Count(), pagesize, activepage);
        }
    }
}
