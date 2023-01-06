using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace NotificationEntityModels.CustomException
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class InvalidDataException : Exception
    {
        public InvalidDataException() { }

        public InvalidDataException(string name)
            : base(String.Format(name))
        {

        }
    }
}
