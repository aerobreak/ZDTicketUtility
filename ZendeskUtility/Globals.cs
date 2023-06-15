namespace ZendeskUtility
{
    internal class Globals
    {
        //read from file APIKEY.txt
        public static string API_KEY;
            
        public static HttpClient client = new();
        public static string url = "https://dhecs.zendesk.com/api/v2/tickets/";
        public static readonly string PersistenceFilePath = "persistence.txt";

        public static int RedColor { get;  set; }
        public static int GreenColor { get;  set; }
        public static int BlueColor { get;  set; }
        public static int ColorIncrement = 17;
        public static int ColorMode = 1;
        //1: red 0-255
        //2: red 255, green 0-255
        //3: green 255, red 255-0
        //4: green 255, blue 0-255
        //5: blue 255, green 255-0
        //6: blue 255, red 0-255
        //7: red 255, blue 255-0
        //go to mode 2

    }
}
