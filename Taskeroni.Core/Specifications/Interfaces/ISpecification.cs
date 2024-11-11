namespace Taskeroni.Core.Specifications.Interfaces
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }
}