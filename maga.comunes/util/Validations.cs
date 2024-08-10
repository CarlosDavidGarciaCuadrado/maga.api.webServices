
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

        public static bool IsUInt(string? value)
        {
            bool response = true;

            try
            {
                Convert.ToUInt32(value?.ToString().Trim());
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

        public static uint GetUIntFromString(string value, uint defaultValue)
        {
            try
            {
                if (IsUInt(value.Trim()))

                    return Convert.ToUInt32(value.Trim());

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
