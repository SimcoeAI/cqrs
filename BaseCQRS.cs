using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace SimcoeAI.Abstractions.CQRS
{
	public abstract class BaseCQRS<TModel,TResult> : IBaseCQRS<TModel, TResult>
		where TModel : class
	{
		public const int NonInitializedId = -1;
		protected readonly ILogger _logger;
		protected readonly ILoggerProvider _loggerProvder;

		protected BaseCQRS(ILoggerProvider loggerProvider)
		{
			_logger = loggerProvider?.CreateLogger(GetType().Name);
			_loggerProvder = loggerProvider;
		}

		public abstract Task<TResult> ExecuteAsync(TModel model, CancellationToken cancellationToken);
	}
}
