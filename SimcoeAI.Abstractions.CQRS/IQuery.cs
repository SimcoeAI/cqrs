namespace SimcoeAI.Abstractions.CQRS
{
	public interface IQuery<in TModel, TResult> : IBaseCQRS<TModel, TResult>
	{
	}
}