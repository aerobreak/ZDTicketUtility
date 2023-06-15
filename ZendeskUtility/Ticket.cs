namespace ZendeskUtility
{
    public class Ticket
    {
        public Comment? comment { get; set; }
        public string? status { get; set; }
        public List<Custom_Fields>? custom_fields { get; set; }

    }
}
