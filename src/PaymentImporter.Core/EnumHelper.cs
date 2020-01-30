using System;

namespace PaymentImporter.Core
{
    public partial class EnumHelper
    {
        public static bool IsDefined<T>(string strEnumText)
        {
            string s = strEnumText.Trim().ToLower();
            string[] names = Enum.GetNames(typeof(T));
            foreach (string n in names)
            {
                if (n.ToLower() == s)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsDefined<T>(int iEnumValue)
        {
            int[] vals = (int[])Enum.GetValues(typeof(T));
            foreach (int i in vals)
            {
                if (iEnumValue == i)
                {
                    return true;
                }
            }
            return false;
        }

        public static T Parse<T>(string strEnumText) where T : struct
        {
            if (IsDefined<T>(strEnumText))
            {
                T pm = (T)Enum.Parse(typeof(T), strEnumText, true);
                return pm;
            }
            else
            {
                return GetDefault<T>();
            }
        }

        public static T GetDefault<T>()
        {
            if (IsDefined<T>("None"))
            {
                return (T)Enum.Parse(typeof(T), "None", true);
            }
            else if (IsDefined<T>(0))
            {
                return (T)Enum.ToObject(typeof(T), 0);
            }
            else
            {
                throw new ArgumentException("No default value found for type " + typeof(T).FullName);
            }
        }
    }
}
