using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ZDTickets.Service.Middlewares
{
    internal class ResponseBody
    {
        private static readonly JavaScriptEncoder _encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.All);
        public string ErrorType { get; }
        public string ErrorMessage { get; }
        public string? Content { get; }
        public ResponseBody(Exception e, string? content)
        {
            ErrorType = e.GetType().ToString();
            ErrorMessage = e.Message;
            Content = content;
        }

        public override string ToString()
        {
            var jsonOptions = new JsonSerializerOptions()
            {
                Encoder = _encoder,
                WriteIndented = true
            };
            return JsonSerializer.Serialize(this, jsonOptions);
        }
    }
}
