[![Build Status](https://dev.azure.com/simcoeai/ArchitectureLibrary/_apis/build/status/SimcoeAI.cqrs?branchName=main)](https://dev.azure.com/simcoeai/ArchitectureLibrary/_build/latest?definitionId=12&branchName=main)

# CQRS classes
This project contains a few C# classes and interfaces to define the concept of CQRS pattern. Each concrete class derived from the base class should serve only a business purpose, e.g. writing to a file or reading from a database table, etc.

## Example 1 - A command definition to clear a queue

```csharp
public class QueueModel
{
   public string QueueName { get; set; }
   public string ConnectionString { get; set; }
}

public class ClearQueueCommand : Command<QueueModel, bool>
{
}
```

## Example 2 - A query definition to peek into a queue

```csharp
public class PeekModel
{
		public int MessageCount { get; set; }
}

public class QueueQueryResult<T> : IResultProvider
{
		public IEnumerable<T> Messages { get; set; } = new List<T>();
}
  
public class PeekQuery<T> : Query<PeekModel, QueueQueryResult<T>>
{
}

```

## Being a bit more ambitious with these simple classes

Just imagine that your project has tens or hundreds of such command and query classes, and you'd like to employ Dependency Injection to wire them up in your DI container. You can simply have [Scrutor](https://github.com/khellang/Scrutor) take care of this tedious and non-trivial task for you.

### Wiring up commands and queries using Scrutor

```csharp
  public static class Extensions
	{
		public static IServiceCollection AddScopedLifetimeCQRS<T>(this IServiceCollection services)
			=> services.Scan(scan => scan
					.FromAssemblyOf<T>()
					.AddClasses(classes => classes.AssignableTo<IBaseCQRS>())
					.AsImplementedInterfaces()
					.WithScopedLifetime());

		public static IServiceCollection AddSingletonLifetimeCQRS<T>(this IServiceCollection services)
			=> services.Scan(scan => scan
				.FromAssemblyOf<T>()
				.AddClasses(classes => classes.AssignableTo<IBaseCQRS>())
				.AsImplementedInterfaces()
				.WithSingletonLifetime());

		public static IServiceCollection AddTransientLifetimeCQRS<T>(this IServiceCollection services)
			=> services.Scan(scan => scan
				.FromAssemblyOf<T>()
				.AddClasses(classes => classes.AssignableTo<IBaseCQRS>())
				.AsImplementedInterfaces()
				.WithTransientLifetime());
	}
```
