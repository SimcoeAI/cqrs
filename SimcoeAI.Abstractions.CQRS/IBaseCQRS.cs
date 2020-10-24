using System.Threading;
using System.Threading.Tasks;

namespace SimcoeAI.Abstractions.CQRS
{
	public interface IBaseCQRS<in TModel, TResult> : IBaseCQRS
	{
		Task<TResult> ExecuteAsync(TModel model, CancellationToken cancellationToken);
	}
}