namespace School.Mvc.Models.ClassModel
{
    public class ApiClassUpdateModel
    {
        public ClassUpdateModel Data { get; set; }
        public object ValidationErrors { get; set; }
        public string Message { get; set; }
        public int ResponseType { get; set; }
    }
}
