using Microsoft.Extensions.Logging;

namespace SimcoeAI.Abstractions.CQRS
{
	public abstract class Query<TModel, TResult> : BaseCQRS<TModel, TResult>, IQuery<TModel, TResult>
		where TModel : class
	{
		protected Query(ILoggerProvider loggerProvider)
			: base(loggerProvider)
		{
		}
	}
}
