namespace Siimple_Template_Exam.Helpers
{
    public class PaginatedList<T> :List<T>
    {
        public PaginatedList(PaginatedList<T> values , int count , int pagesize , int activepage)
        {
            AddRange(values);
            ActivePageCount = activepage;
            TotalPageCount = (int)Math.Ceiling((double)count / pagesize);
        }
        public int TotalPageCount { get; set; }
        public int ActivePageCount { get; set; }
        public bool HasNext { get => ActivePageCount<TotalPageCount; }
        public bool HasPrevious { get => ActivePageCount > 1 ; }

        //public PaginatedList<T> Create(IQueryable<T> values , int pagesize,int activepage)
        //{
        //    return new PaginatedList<T>(values.Skip())
        //}
    }
}
