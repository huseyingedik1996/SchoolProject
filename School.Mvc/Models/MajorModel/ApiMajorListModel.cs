using School.Mvc.Models.ClassModel;

namespace School.Mvc.Models.MajorModel
{
	public class ApiMajorListModel
	{
		public List<MajorUpdateModel> Data { get; set; }
		public object ValidationErrors { get; set; }
		public string Message { get; set; }
		public int ResponseType { get; set; }
	}
}
