namespace StudentApi.DTOs
{
    // Used for the POST request
    public class StudentCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

}