﻿using NUnit.Framework;
using Shanemat.DotNetUtils.Wpf.ViewModels.Properties;

namespace Shanemat.DotNetUtils.Wpf.Tests.ViewModels.Properties.SimpleViewModelProperty;

/// <summary>
/// Contains tests for <see cref="SimpleViewModelProperty{T}.IsApplicable"/> property
/// </summary>
internal sealed class IsApplicableTests
{
	#region Sources

	private static IEnumerable<Func<bool>> IsApplicableGetters => Sources.BooleanGetters;

	#endregion

	#region Tests

	[Test]
	public void ShouldReturnTrueByDefault()
	{
		var property = new SimpleViewModelProperty<int>();

		Assert.That( property.IsApplicable, Is.True );
	}

	[Test]
	[TestCaseSource( nameof( IsApplicableGetters ) )]
	public void ShouldUseTheGivenGetter( Func<bool> isApplicableGetter )
	{
		var property = new SimpleViewModelProperty<int>
		{
			IsApplicableGetter = isApplicableGetter,
		};

		Assert.That( property.IsApplicable, Is.EqualTo( isApplicableGetter.Invoke() ) );
	}

	[Test]
	public void ShouldNotNeedlesslyQueryTheValue()
	{
		var hasBeenCalled = false;

		var property = new SimpleViewModelProperty<int>
		{
			IsApplicableGetter = IsApplicable,
		};

		Assert.That( property.IsApplicable, Is.False );
		Assert.That( property.IsApplicable, Is.False );

		bool IsApplicable()
		{
			if( !hasBeenCalled )
				return hasBeenCalled;

			hasBeenCalled = true;

			throw new InvalidOperationException();
		}
	}

	#endregion
}