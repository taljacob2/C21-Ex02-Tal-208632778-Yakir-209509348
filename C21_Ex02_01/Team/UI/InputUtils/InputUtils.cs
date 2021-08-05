#region

using System;
using System.ComponentModel;

#endregion

namespace C21_Ex02_01.Team.UI.InputUtils
{
    /// <summary>
    ///     Converts a generic input string to an object.
    /// </summary>
    public static class InputUtils
    {
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
                return (T) converter.ConvertFromString(input);
            }
            catch (Exception)
            {
                return Convert<T>(i_Message);
            }
        }

        // public static T Convert<T>(string i_Message, T i_MinimumRange,
        //     T i_MaximumRange)
        // {
        //     T converted = Convert<T>(i_Message);
        // }
        //
        // private static bool isConvertedInRange<T>(T i_Converted,
        //     T i_MinimumRange, T i_MaximumRange)
        // {
        //     return (i_Converted. <= i_MaximumRange) &&
        //            (i_Converted >= i_MinimumRange);
        // }
    }
}
