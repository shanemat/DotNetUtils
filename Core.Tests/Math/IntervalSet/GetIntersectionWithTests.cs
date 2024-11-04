﻿using NUnit.Framework;
using Shanemat.DotNetUtils.Core.Math;

namespace Shanemat.DotNetUtils.Core.Tests.Math.IntervalSet;

/// <summary>
/// Contains tests for <see cref="IntervalSet.GetIntersectionWith"/> method
/// </summary>
internal sealed class GetIntersectionWithTests
{
	#region Sources

	private static IEnumerable<double> Tolerances => Sources.Tolerances;

	#endregion

	#region Tests

	[Test]
	public void ShouldThrowWhenToleranceIsNotANumber()
	{
		var set = Core.Math.IntervalSet.Create();

		Assert.Throws<ArgumentException>( () => set.GetIntersectionWith( set, tolerance: double.NaN ) );
	}

	[Test]
	public void ShouldThrowWhenToleranceIsNegative()
	{
		var set = Core.Math.IntervalSet.Create();

		Assert.Throws<ArgumentException>( () => set.GetIntersectionWith( set, tolerance: -1.0 ) );
	}

	[Test]
	public void ShouldReturnEmptySetWhenTheOtherSetIsNull()
	{
		var set = Core.Math.IntervalSet.Create( [Core.Math.Interval.Open( double.NegativeInfinity, double.PositiveInfinity )] );

		Assert.That( set.GetIntersectionWith( null ).Intervals, Has.Count.Zero );
	}

	[Test]
	public void ShouldReturnEmptySetWhenEitherSetIsEmpty()
	{
		var emptySet = Core.Math.IntervalSet.Create();
		var set = Core.Math.IntervalSet.Create( [Core.Math.Interval.Open( double.NegativeInfinity, double.PositiveInfinity )] );

		Assert.Multiple( () =>
		{
			Assert.That( set.GetIntersectionWith( emptySet ), Is.EqualTo( emptySet ) );
			Assert.That( emptySet.GetIntersectionWith( set ), Is.EqualTo( emptySet ) );
		} );
	}

	[Test]
	public void ShouldReturnEmptySetWhenTheSetsDoNotIntersect()
	{
		var oneSet = Core.Math.IntervalSet.Create( [Core.Math.Interval.Open( double.NegativeInfinity, -2 ), Core.Math.Interval.Closed( 0, 2 )] );
		var otherSet = Core.Math.IntervalSet.Create( [Core.Math.Interval.ClosedOpen( -2, 0 ), Core.Math.Interval.Open( 2, double.PositiveInfinity )] );

		Assert.That( oneSet.GetIntersectionWith( otherSet ).Intervals, Has.Count.Zero );
	}

	[Test]
	public void ShouldReturnCorrectIntersection()
	{
		var oneSet = Core.Math.IntervalSet.Create( [
			Core.Math.Interval.OpenClosed( double.NegativeInfinity, -2 ),
			Core.Math.Interval.Closed( 0, 1 ),
			Core.Math.Interval.Closed( 2, 4 ),
			Core.Math.Interval.Open( 5, 6 ),
			Core.Math.Interval.ClosedOpen( 7, double.PositiveInfinity ),
		] );

		var otherSet = Core.Math.IntervalSet.Create( [
			Core.Math.Interval.Open( double.NegativeInfinity, -10 ),
			Core.Math.Interval.Open( -8, -6 ),
			Core.Math.Interval.Closed( -4, 0 ),
			Core.Math.Interval.OpenClosed( 3, 8 ),
			Core.Math.Interval.ClosedOpen( 10, double.PositiveInfinity ),
		] );

		var expectedResult = Core.Math.IntervalSet.Create( [
			Core.Math.Interval.Open( double.NegativeInfinity, -10 ),
			Core.Math.Interval.Open( -8, -6 ),
			Core.Math.Interval.Closed( -4, -2 ),
			Core.Math.Interval.Closed( 0, 0 ),
			Core.Math.Interval.OpenClosed( 3, 4 ),
			Core.Math.Interval.Open( 5, 6 ),
			Core.Math.Interval.Closed( 7, 8 ),
			Core.Math.Interval.ClosedOpen( 10, double.PositiveInfinity ),
		] );

		Assert.That( oneSet.GetIntersectionWith( otherSet ), Is.EqualTo( expectedResult ) );
	}

	[Test]
	[TestCaseSource( nameof( Tolerances ) )]
	public void ShouldUseProvidedTolerance( double tolerance )
	{
		const double minimum = -5.0;
		const double middle = 2.0;
		const double maximum = 7.0;

		var lowerWiderSet = Core.Math.IntervalSet.Create( [Core.Math.Interval.Closed( minimum, middle - tolerance * 0.25 )] );
		var lowerNarrowerSet = Core.Math.IntervalSet.Create( [Core.Math.Interval.Closed( minimum, middle - tolerance * 0.75 )] );
		var upperWiderSet = Core.Math.IntervalSet.Create( [Core.Math.Interval.Closed( middle + tolerance * 0.25, maximum )] );
		var upperNarrowerSet = Core.Math.IntervalSet.Create( [Core.Math.Interval.Closed( middle + tolerance * 0.75, maximum )] );

		var expectedIntersection = Core.Math.IntervalSet.Create( [Core.Math.Interval.Closed( middle - tolerance * 0.25, middle + tolerance * 0.25 )] );

		Assert.Multiple( () =>
		{
			Assert.That( lowerWiderSet.GetIntersectionWith( upperWiderSet, tolerance ), Is.EqualTo( expectedIntersection ) );
			Assert.That( lowerNarrowerSet.GetIntersectionWith( upperNarrowerSet, tolerance ).Intervals, Has.Count.Zero );
		} );
	}

	#endregion
}
