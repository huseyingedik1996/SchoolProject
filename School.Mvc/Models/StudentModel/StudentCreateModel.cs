namespace School.Mvc.Models.StudentModel
{
    public class StudentCreateModel
    {
		public string Name { get; set; }
		public string Surname { get; set; }
		public string TCNumber { get; set; }
		public int StudentNumber { get; set; } = 10;
		public string Address { get; set; }
		public string City { get; set; }
		public string Region { get; set; }
		public DateTime BirthDay { get; set; }
		public int Age { get; set; } = 10;
		public string Contact { get; set; }
		public DateTime LastUpdate { get; set; } = DateTime.Now;
		public DateTime RegisterDate { get; set; } = DateTime.Now;

		public string Email { get; set; } = "deneme";

		public string Password { get; set; } = "deneme";



	}
}
