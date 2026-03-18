
namespace Bl.BLServices
{
    [Serializable]
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException()
        {
        }

       

        public ObjectNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}