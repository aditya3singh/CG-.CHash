namespace APIDTODEMO.DTO
{
    public class StudentCreateRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal CourseFeePaid { get; internal set; }
    }
}
