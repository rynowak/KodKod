
namespace Microsoft.AspNetCore.Mvc
{
    public class ActionResult<T>
    {
        public ActionResult(T value)
        {
            Value = value;
        }

        public ActionResult(IActionResult result)
        {
            Result = result;
        }
        
        public IActionResult Result { get; set; }

        public T Value { get; set; }

        public static implicit operator ActionResult<T>(T value)
        {
            return new ActionResult<T>(value);
        }

        public static implicit operator ActionResult<T>(ActionResult result)
        {
            return new ActionResult<T>(result);
        }
    }
}
