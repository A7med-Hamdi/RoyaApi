namespace Roya.Errors
{
    public class ApiErroeResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMsg { get; set; }
        public ApiErroeResponse(int statusCode, string errorMsg = null)
        {
            StatusCode = statusCode;
            ErrorMsg = errorMsg ?? GetDefaultStatusMassage(statusCode);
        }
        private string GetDefaultStatusMassage(int statusCode)
         => statusCode switch
         {
             400 => "A Bad Request ,  You Have Made",
             401 => "Authorized ,  You Are Not",
             404 => "Resourse Is Not Found ",
             500 => "Errore Are path to the dark side , anger is path to dath ",
             _ => null
         };
    }
}
