namespace GraphQL_HotChocolate.Model
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            this.IsSuccessful = true;
        }

        public bool IsSuccessful { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }
    }
}
