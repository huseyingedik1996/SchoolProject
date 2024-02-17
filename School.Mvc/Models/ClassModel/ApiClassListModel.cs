namespace School.Mvc.Models.ClassModel
{
    public class ApiClassListModel
    {
        public List<ClassListModel> Data { get; set; }
        public object ValidationErrors { get; set; }
        public string Message { get; set; }
        public int ResponseType { get; set; }
    }
}
