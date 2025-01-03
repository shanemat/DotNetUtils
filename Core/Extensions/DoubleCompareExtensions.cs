﻿using Shanemat.DotNetUtils.Core.Math;

namespace Shanemat.DotNetUtils.Core.Extensions;

/// <summary>
/// Contains extension methods for comparison of <see cref="double"/> values
/// </summary>
public static class DoubleCompareExtensions
{
	#region Methods

	#region IsEqualTo

	/// <summary>
	/// Returns a value indicating whether the given values are equal (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare this value to</param>
	/// <param name="tolerance">The tolerance to use (<see cref="Tolerance.Standard"/> by default)</param>
	/// <returns>A value indicating whether the given values are equal (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsEqualTo( this double value, double otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return System.Math.Abs( value - otherValue ) <= tolerance;
	}

	/// <summary>
	/// Returns a value indicating whether the given values are equal (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare this value to</param>
	/// <param name="tolerance">The tolerance to use (<see cref="Tolerance.Standard"/> by default)</param>
	/// <returns>A value indicating whether the given values are equal (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if one of the values (but not both) is <see langword="null"/></remarks>
	public static bool IsEqualTo( this double? value, double? otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsEqualTo( otherValue, ( x, y ) => x.IsEqualTo( y, tolerance ) );
	}

	#endregion

	#region IsGreaterThan

	/// <summary>
	/// Returns a value indicating whether the first value is greater than the second one (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the first value is greater than the second one (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsGreaterThan( this double value, double otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value - otherValue >= tolerance;
	}

	/// <summary>
	/// Returns a value indicating whether the first value is greater than the second one (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the first value is greater than the second one (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if either (or both) of the values is <see langword="null"/></remarks>
	public static bool IsGreaterThan( this double? value, double? otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value - otherValue >= tolerance;
	}

	#endregion

	#region IsGreaterThanOrEqualTo

	/// <summary>
	/// Returns a value indicating whether the first value is greater than or equal to the second one (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the first value is greater than or equal to the second one (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsGreaterThanOrEqualTo( this double value, double otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value - otherValue >= -tolerance;
	}

	/// <summary>
	/// Returns a value indicating whether the first value is greater than or equal to the second one (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the first value is greater than or equal to the second one (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if either (or both) of the values is <see langword="null"/></remarks>
	public static bool IsGreaterThanOrEqualTo( this double? value, double? otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value - otherValue >= -tolerance;
	}

	#endregion

	#region IsLessThan

	/// <summary>
	/// Returns a value indicating whether the first value is less than the second one (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the first value is less than the second one (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsLessThan( this double value, double otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return otherValue - value >= tolerance;
	}

	/// <summary>
	/// Returns a value indicating whether the first value is less than the second one (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the first value is less than the second one (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if either (or both) of the values is <see langword="null"/></remarks>
	public static bool IsLessThan( this double? value, double? otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return otherValue - value >= tolerance;
	}

	#endregion

	#region IsLessThenOrEqualTo

	/// <summary>
	/// Returns a value indicating whether the first value is less than or equal to the second one (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the first value is less than or equal to the second one (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsLessThanOrEqualTo( this double value, double otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return otherValue - value >= -tolerance;
	}

	/// <summary>
	/// Returns a value indicating whether the first value is less than or equal to the second one (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to compare</param>
	/// <param name="otherValue">The value to compare the first value to</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the first value is less than or equal to the second one (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if either (or both) of the values is <see langword="null"/></remarks>
	public static bool IsLessThanOrEqualTo( this double? value, double? otherValue, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return otherValue - value >= -tolerance;
	}

	#endregion

	#region IsNegative

	/// <summary>
	/// Returns a value indicating whether the value is negative (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is negative (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsNegative( this double value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsLessThan( 0.0, tolerance );
	}

	/// <summary>
	/// Returns a value indicating whether the value is negative (within specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is negative (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if the value is <see langword="null"/></remarks>
	public static bool IsNegative( this double? value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsLessThan( 0.0, tolerance );
	}

	#endregion

	#region IsNonNegative

	/// <summary>
	/// Returns a value indicating whether the value is non-negative (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is non-negative (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsNonNegative( this double value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsGreaterThanOrEqualTo( 0.0, tolerance );
	}

	/// <summary>
	/// Returns a value indicating whether the value is non-negative (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is non-negative (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if the value is <see langword="null"/></remarks>
	public static bool IsNonNegative( this double? value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsGreaterThanOrEqualTo( 0.0, tolerance );
	}

	#endregion

	#region IsNonPositive

	/// <summary>
	/// Returns a value indicating whether the value is non-positive (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is non-positive (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsNonPositive( this double value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsLessThanOrEqualTo( 0.0, tolerance );
	}

	/// <summary>
	/// Returns a value indicating whether the value is non-positive (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is non-positive (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if the value is <see langword="null"/></remarks>
	public static bool IsNonPositive( this double? value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsLessThanOrEqualTo( 0.0, tolerance );
	}

	#endregion

	#region IsPositive

	/// <summary>
	/// Returns a value indicating whether the value is positive (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is positive (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsPositive( this double value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsGreaterThan( 0.0, tolerance );
	}

	/// <summary>
	/// Returns a value indicating whether the value is positive (within the specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is positive (within the specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if the value is <see langword="null"/></remarks>
	public static bool IsPositive( this double? value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsGreaterThan( 0.0, tolerance );
	}

	#endregion

	#region IsZero

	/// <summary>
	/// Returns a value indicating whether the value is zero (within specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is zero (within specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	public static bool IsZero( this double value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsEqualTo( 0.0, tolerance );
	}

	/// <summary>
	/// Returns a value indicating whether the value is zero (within specified tolerance)
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="tolerance">The tolerance to use</param>
	/// <returns>A value indicating whether the value is zero (within specified tolerance)</returns>
	/// <exception cref="ArgumentException">Thrown in case the supplied tolerance is not valid</exception>
	/// <remarks>Please note that this method will return <see langword="false"/> if the value is <see langword="null"/></remarks>
	public static bool IsZero( this double? value, double tolerance = Tolerance.Standard )
	{
		Tolerance.Validate( tolerance );

		return value.IsEqualTo( 0.0, tolerance );
	}

	#endregion

	#endregion
}
