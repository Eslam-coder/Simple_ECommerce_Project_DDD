namespace _0___SharedKernel.CQRS
{
    public class GetByIdQuery<T> : IQuery<T> where T : class
    {
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
