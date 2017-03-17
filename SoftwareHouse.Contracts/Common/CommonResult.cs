namespace SoftwareHouse.Contracts.Common
{

    public class CommonResult
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public CommonResult()
        {
            IsSuccess = true;
        }

        public CommonResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public static CommonResult Success() => new CommonResult();

        public static CommonResult Failure(string errorMessage ) => new CommonResult(errorMessage);
    }

    public class CommonResult<TResultData> : CommonResult
    {
        public TResultData ResultData { get; }

        public CommonResult(TResultData resultData)
        {
            ResultData = resultData;
        }

        public CommonResult(TResultData resultData, string errorMessage) : base(errorMessage)
        {
            ResultData = resultData;
        }

        private CommonResult(string errorMessage) : base(errorMessage)
        {
            
        }

        public new static CommonResult<TResultData> Failure(string errorMessage) 
            => new CommonResult<TResultData>(errorMessage);

        public static CommonResult<TResultData> Failure(TResultData resultData, string errorMessage) =>
            new CommonResult<TResultData>(resultData, errorMessage);

        public static CommonResult<TResultData> Success(TResultData resultData) => 
            new CommonResult<TResultData>(resultData);
    }
}