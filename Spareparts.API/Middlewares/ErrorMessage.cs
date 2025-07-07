namespace Spareparts.API.Middlewares {
    internal class ErrorMessage {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}