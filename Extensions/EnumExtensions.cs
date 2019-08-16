using System.ComponentModel;
using System.Reflection;

namespace Supermercado.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<TEnum>(this TEnum @enum) //generic method that receives enum as an argument
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString()); //gets the type of information(class, interface, enum or struct) of the paramater
            //GetField(@enum.ToString()) gets the specific enumeration value(kg, g or lb)
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false); //finds all Description attributes applied over the enumeration value and stores their data into an array (we can specify multiple attributes for a same property in some cases).

            return attributes?[0].Description ?? @enum.ToString(); // shorter syntax to check if we have at least one description attribute for the enumeration type. If we have, we return the Description value provided by this attribute. If not, we return the enumeration as a string, using the default casting.
            //The ?. operator (a null-conditional operator) checks if the value is null before accessing its property.
            //The ?? operator (a null-coalescing operator) tells the application to return the value at the left if it’s not empty, or the value at right otherwise.
        }
    }
}