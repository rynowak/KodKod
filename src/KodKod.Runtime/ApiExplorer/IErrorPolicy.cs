
namespace Microsoft.AspNetCore.Mvc.ApiExplorer
{
    public interface IErrorPolicy
    {
        void ApplyDescription(ErrorPolicyContext context);
    }
}
