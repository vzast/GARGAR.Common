namespace Email.Models
{
    public struct MultipleEmailModel
    {
        public List<string> Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}