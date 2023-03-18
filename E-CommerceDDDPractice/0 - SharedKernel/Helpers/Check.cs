using JetBrains.Annotations;

namespace _0___SharedKernel.Helpers
{
    public static class Check
    {
        public static T NotNull<T>([NoEnumeration] T value, [InvokerParameterName] string parameterName)
        {
            //#pragma warning disable IDE0041 // Use 'is null' check
            if (ReferenceEquals(value, null))
            //#pragma warning restore IDE0041 // Use 'is null' check
            {
                NotEmpty(parameterName, nameof(parameterName));
                throw new ArgumentNullException(parameterName);
            }
            return value;
        }

        public static string NotEmpty(string value, [InvokerParameterName] string parameterName)
        {
            var exception = default(Exception);
            if (value is null)
            {
                exception = new ArgumentNullException(parameterName);
            }
            else if (value.Trim().Length == 0)
            {
                exception = new ArgumentException(ArgumentIsEmpty(parameterName));
            }
            if (exception != null)
            {
                NotEmpty(parameterName, nameof(parameterName));
                throw exception;
            }
            return value;
        }

        private static string ArgumentIsEmpty(string argumentName)
        {
            return $"The string argument '{argumentName}' cannot be empty.";
        }
    }
}
