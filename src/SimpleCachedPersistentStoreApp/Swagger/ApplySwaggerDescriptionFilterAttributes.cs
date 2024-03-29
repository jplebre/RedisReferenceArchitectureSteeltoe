using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SimpleCachedPersistentStoreApp.Swagger
{
    public class ApplySwaggerDescriptionFilterAttributes : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            foreach (var attr in context.MethodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes(true))
            {
                if (attr is SwaggerNotesAttribute)
                {
                    operation.Description = ((SwaggerNotesAttribute)attr).Description;
                }

                if (attr is SwaggerSummaryAttribute)
                {
                    operation.Summary = ((SwaggerSummaryAttribute)attr).Summary;
                }
            }
        }
    }
}