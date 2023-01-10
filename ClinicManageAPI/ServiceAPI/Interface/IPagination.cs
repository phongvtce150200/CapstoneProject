namespace ClinicManageAPI.ServiceAPI.Interface
{
    public interface IPagination
    {
        public int PageIndex { get; }

        public int PageSize { get; }
    }
}
