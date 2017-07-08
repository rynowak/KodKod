
namespace Microsoft.AspNetCore.Mvc
{
    public class Result<T>
    {
        public Result(T value)
        {
            Value = value;
        }

        public Result(IActionResult actionResult)
        {
            ActionResult = actionResult;
        }
        
        public IActionResult ActionResult { get; set; }

        public T Value { get; set; }

        public static implicit operator Result<T>(T value)
        {
            return new Result<T>(value);
        }

        public static implicit operator Result<T>(ActionResult actionResult)
        {
            return new Result<T>(actionResult);
        }
    }
}
