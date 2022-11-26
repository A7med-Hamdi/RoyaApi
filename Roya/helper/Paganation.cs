using Roya.DTO;

namespace Roya.helper
{
    public class Paganation<T>
    {
       

        public Paganation(int pageIndex, int pageSize, int count,IReadOnlyList<T> data)
        {
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
            Count = count;
            Data = data;
        }



        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}
