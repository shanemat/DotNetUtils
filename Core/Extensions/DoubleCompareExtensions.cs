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

	#endregion
}
