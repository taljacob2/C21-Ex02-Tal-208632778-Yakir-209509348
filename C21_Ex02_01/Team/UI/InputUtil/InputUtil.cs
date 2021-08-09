﻿#region

using System;
using System.ComponentModel;
using MiscUtil;

#endregion

namespace C21_Ex02_01.Team.UI.InputUtil
{
    public static class InputUtil
    {
        /// <summary>
        ///     Converts a generic input string to an object.
        /// </summary>
        public static T Convert<T>(string i_Message)
        {
            Console.Out.WriteLine(i_Message);
            string input = Console.ReadLine();
            try
            {
                // Create converter
                TypeConverter converter =
                    TypeDescriptor.GetConverter(typeof(T));

                // Cast ConvertFromString(string text) : object to (T)
                return (T)converter.ConvertFromString(input);
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Bad input. Please try again...");
                return Convert<T>(i_Message);
            }
        }

        /// <summary>
        ///     Converts a generic input string to an object, with a given range.
        /// </summary>
        public static T Convert<T>(string i_Message, T i_MinimumRange,
            T i_MaximumRange)
        {
            T converted = Convert<T>(i_Message);
            if (!isConvertedInRange(converted, i_MinimumRange, i_MaximumRange)
            )
            {
                Console.Out.WriteLine("Bad input. Please try again...");
                return Convert(i_Message, i_MinimumRange, i_MaximumRange);
            }

            return converted;
        }

        /// <summary>
        ///     Generic comparison by range.
        ///     <see cref="Operator" />
        ///     <seealso cref="MiscUtil" />
        /// </summary>
        /// <param name="i_Converted" />
        /// <param name="i_MinimumRange" />
        /// <param name="i_MaximumRange" />
        /// <typeparam name="T">must be Comparable</typeparam>
        /// <returns />
        private static bool isConvertedInRange<T>(T i_Converted,
            T i_MinimumRange, T i_MaximumRange)
        {
            return Operator.LessThanOrEqual(i_Converted, i_MaximumRange) &&
                   Operator
                       .GreaterThanOrEqual(i_Converted, i_MinimumRange);
        }
    }
}
