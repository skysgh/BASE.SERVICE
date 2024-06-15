using App.Modules.Core.Application.Interfaces.APIs.Services;

namespace App.Modules.Core.Application.Interfaces.APIs.Services.Implementations
{
    /// <inheritdoc/>
    public class ExampleService : IExampleService
    {
        /// <inheritdoc/>
        public bool Do()
        {
            return true;
        }

        /// <inheritdoc/>
        public string Hello()
        {
            // TODO: change to use Resource string.
            return "Hello";
        }
    }
}
