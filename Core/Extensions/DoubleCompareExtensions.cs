namespace Shanemat.DotNetUtils.Core.Extensions;

/// <summary>
/// Contains extension methods for comparison of <see cref="double"/> values
/// </summary>
public static class DoubleCompareExtensions
{
	#region Constants

	/// <summary>
	/// The standard precision used for comparison
	/// </summary>
	private const double StandardEpsilon = 1e-9;

	#endregion

	#region Methods

	#region IsEqualTo

	/// <summary>
	/// Returns a value indicating whether the given values are equal (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare this value to</param>
	/// <param name="tolerance">The tolerance to use (<see cref="StandardEpsilon"/> by default)</param>
	/// <exception cref="ArgumentException">Thrown in case supplied tolerance is negative</exception>
	public static bool IsEqualTo( this double value, double otherValue, double tolerance = StandardEpsilon )
	{
		CheckTolerance( tolerance );

		return Math.Abs( value - otherValue ) <= tolerance;
	}

	/// <summary>
	/// Returns a value indicating whether the given values are equal (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare this value to</param>
	/// <param name="tolerance">The tolerance to use (<see cref="StandardEpsilon"/> by default)</param>
	/// <exception cref="ArgumentException">Thrown in case supplied tolerance is negative</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if one of the values (but not both) is <see langword="null"/></remarks>
	public static bool IsEqualTo( this double? value, double? otherValue, double tolerance = StandardEpsilon )
	{
		CheckTolerance( tolerance );

		return value.IsEqualTo( otherValue, ( x, y ) => x.IsEqualTo( y, tolerance ) );
	}

	#endregion

	#region IsGreaterThan

	/// <summary>
	/// Returns a value indicating whether the first value is greater than the second one (within specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <exception cref="ArgumentException">Thrown in case supplied tolerance is negative</exception>
	public static bool IsGreaterThan( this double value, double otherValue, double tolerance = StandardEpsilon )
	{
		CheckTolerance( tolerance );

		return value - otherValue >= tolerance;
	}

	/// <summary>
	/// Returns a value indicating whether the first value is greater than the second one (within specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <exception cref="ArgumentException">Thrown in case supplied tolerance is negative</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if either (or both) of the values is <see langword="null"/></remarks>
	public static bool IsGreaterThan( this double? value, double? otherValue, double tolerance = StandardEpsilon )
	{
		CheckTolerance( tolerance );

		return value - otherValue >= tolerance;
	}

	#endregion

	#region Helpers

	/// <summary>
	/// Checks whether the given value can be used as a tolerance
	/// </summary>
	/// <param name="tolerance">The value to check</param>
	/// <exception cref="ArgumentException">Thrown in case supplied tolerance is negative</exception>
	private static void CheckTolerance( double tolerance )
	{
		if( tolerance < 0.0 )
			throw new ArgumentException( "Tolerance must be non-negative!", nameof( tolerance ) );
	}

	#endregion

	#endregion
}
