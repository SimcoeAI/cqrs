using Microsoft.Extensions.Logging;

namespace SimcoeAI.Abstractions.CQRS
{
	public abstract class Command<TModel, TResult> : BaseCQRS<TModel, TResult>, ICommand<TModel, TResult>
		where TModel : class
	{
		protected Command(ILoggerProvider loggerProvider) : base(loggerProvider) { }
	}
}
