namespace SimcoeAI.Abstractions.CQRS
{
	public interface ICommand<in TModel, TResult> : IBaseCQRS<TModel, TResult>
	{
	}
}