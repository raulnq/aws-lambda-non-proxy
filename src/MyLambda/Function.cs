using Amazon.Lambda.Core;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MyLambda;

public class Function
{
    public record RegisterPetRequest(string Name, string ThrowError);
    public record RegisterPetResponse(Guid PetId, string Name);

    public RegisterPetResponse FunctionHandler(RegisterPetRequest input, ILambdaContext context)
    {
        if (!string.IsNullOrEmpty(input.ThrowError))
        {
            throw new ApplicationException("An error was thrown");
        }


        return new RegisterPetResponse(Guid.NewGuid(), input.Name);
    }
}
