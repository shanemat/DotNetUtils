using NUnit.Framework;
using Shanemat.DotNetUtils.Wpf.Commands;

namespace Shanemat.DotNetUtils.Wpf.Tests.Commands.AsyncCommand;

/// <summary>
/// Contains tests for <see cref="AsyncCommand.Execute()"/> method
/// </summary>
internal sealed class ExecuteParameterlessTests
{
	#region Tests

	[Test]
	public void ShouldExecuteTheCommand()
	{
		var flag = false;
		var command = new Wpf.Commands.AsyncCommand( () => flag = true );

		command.Execute();

		Assert.That( flag, Is.True );
	}

	[Test]
	public void ShouldThrowIfTheCommandCannotBeExecuted()
	{
		var command = new Wpf.Commands.AsyncCommand( () => { }, () => false );

		Assert.Throws<InvalidOperationException>( () => command.Execute() );
	}

	#endregion
}
