using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using FluentValidationResult = FluentValidation.Results.ValidationResult;

namespace PostApp.Api.Contract
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
    public abstract class BaseEndpoint
    {
        protected Ok<ApiResponse> Ok(string message)
          => TypedResults.Ok(new ApiResponse(message));

        protected IResult Ok(object? data)
            => TypedResults.Ok(new ApiResponse(data));

        protected IResult Ok(object data, string message)
            => TypedResults.Ok(new ApiResponse(data, message));

        protected IResult BadRequest(string message)
            => TypedResults.BadRequest(new ApiResponse(message, HttpStatusCode.BadRequest));

        protected IResult BadRequest(string[] messages)
            => TypedResults.BadRequest(new ApiResponse(messages));

        protected IResult BadRequest(FluentValidationResult result)
            => BadRequest(result.Errors.Select(e => e.ErrorMessage).ToArray());

        protected IResult NotFound(string message)
            => TypedResults.NotFound(new ApiResponse(message, HttpStatusCode.NotFound));

        protected IResult Unauthorized(string message = "Unauthorized")
            => TypedResults.Unauthorized();
    }
    public class ApiResponse
    {
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public int StatusCode { get; set; }
        public object? Data { get; set; }

        public ApiResponse()
        {
            Errors = Array.Empty<string>();
        }

        public ApiResponse(string message, HttpStatusCode status = HttpStatusCode.OK)
        {
            Errors = Array.Empty<string>();

            if (status == HttpStatusCode.OK)
            {
                Message = message;
            }
            else
            {
                Message = null;
                Errors = new[] { message };
            }

            StatusCode = (int)status;
        }

        public ApiResponse(object? data)
        {
            Errors = Array.Empty<string>();
            Data = data;
            StatusCode = (int)HttpStatusCode.OK;
        }

        public ApiResponse(object data, string message)
        {
            Errors = Array.Empty<string>();
            Data = data;
            Message = message;
            StatusCode = (int)HttpStatusCode.OK;
        }

        public ApiResponse(string[] errors)
        {
            Errors = errors ?? Array.Empty<string>();
            StatusCode = (int)HttpStatusCode.BadRequest;
        }

        public ApiResponse(string message, HttpStatusCode status, string[] errors, object data)
        {
            Message = status == HttpStatusCode.OK ? message : null;
            StatusCode = (int)status;
            Errors = errors ?? Array.Empty<string>();
            Data = data;
        }
    }

}
