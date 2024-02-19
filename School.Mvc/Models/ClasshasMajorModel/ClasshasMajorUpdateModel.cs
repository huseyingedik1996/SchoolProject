namespace School.Mvc.Models.ClasshasMajorModel
{
    public class ClasshasMajorUpdateModel
    {
        public int Id { get; set; }
        public int ClassesId { get; set; }
        public int MajorsId { get; set; }
        public string MajorName { get; set; }
        public string ClassName { get; set; }
    }
}
