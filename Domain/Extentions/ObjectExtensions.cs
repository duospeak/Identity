namespace System
{
    public static class ObjectExtensions
    {
        public static T NotNull<T>(this T obj, string parameterName)
            where T : class
        {
            if (obj is null)
            {
                parameterName.NotNull(nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            return obj;
        }
    }
}
