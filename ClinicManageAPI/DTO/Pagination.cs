namespace ClinicManageAPI.DTO
{
    public class Pagination
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Pagination()
        {
            this.PageIndex = 1;
            this.PageSize = 15;
        }
        public Pagination(int pageNumber, int pageSize)
        {
            this.PageIndex = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 15 ? 15 : pageSize;
        }
    }
}
