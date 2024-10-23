
namespace DocStats.Persistence
{
    [Serializable]
    internal class FileManagerException : Exception
    {
        public FileManagerException()
        {
        }

        public FileManagerException(string? message) : base(message)
        {
        }

        public FileManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}