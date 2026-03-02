

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class OutputDto<T> : BaseOutputDto where T : class
    {
        public T Entity { get; set; }
    }
}
