namespace ReviewMe.Models.Reviewers
{
    public class Reviewer
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
        public bool IsProjectManager { get; set; }

    }
}
