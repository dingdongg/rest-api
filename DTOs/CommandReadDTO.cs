namespace APIProject.DTOs
{
    public class CommandReadDTO
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        // In this DTO, Platform is considered "sensitive information" 
        // that shouldn't be transmitted back to the clients of this API
        // public string Platform { get; set; }
    }
}