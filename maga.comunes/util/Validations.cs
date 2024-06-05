
namespace maga.commons.util
{
    public static class Validations
    {
        public static bool IsDecimal(string? value)
        {
            bool response = true;

            try
            {
                Convert.ToDecimal(value?.ToString().Trim());
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }

        public static bool IsUlong(string? value)
        {
            bool response = true;

            try
            {
                Convert.ToUInt64(value?.ToString().Trim());
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }
        public static decimal GetDecimalFromString(string value, decimal defaultValue)
        {
            try
            {
                if (IsDecimal(value.Trim()))

                    return Convert.ToDecimal(value.Trim());

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static ulong GetUlongFromString(string value, ulong defaultValue)
        {
            try
            {
                if (IsUlong(value.Trim()))

                    return Convert.ToUInt64(value.Trim());

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
