using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
   /// <summary>
   /// Used to handle our custom enums that contain a description string.
   /// </summary>
    public static class EnumExtensions
    {
      /// <summary>
      /// Returns the description of a specified enum in a string.
      /// https://stackoverflow.com/questions/2905342/how-can-i-internationalize-strings-representing-c-sharp-enum-values
      /// </summary>
      /// <param name="value">The specified enum</param>
      /// <returns></returns>
      public static string GetEnumDescription(Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
