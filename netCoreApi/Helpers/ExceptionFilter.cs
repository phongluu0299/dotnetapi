using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog.Context;

namespace netCoreApi.Helpers
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            string logId = Guid.NewGuid().ToString("N");
            using (LogContext.PushProperty("CorrelationId", logId))
            {
                _logger.LogError(context.Exception,
                                 $"Lỗi hệ thống (Tracking ID: {logId})"
                                 );
            }

            var errorResult = new Result
            {
                Code = ResultCode.Error,
                Message = $"Đã có lỗi xảy ra. Vui lòng cung cấp mã lỗi này {logId} cho Admin để được hỗ trợ.",
                Data = logId
            };

            var response = new ObjectResult(errorResult)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.Result = response;
            context.ExceptionHandled = true;
        }
    }
}
