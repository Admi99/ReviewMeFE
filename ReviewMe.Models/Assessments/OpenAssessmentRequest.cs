namespace ReviewMe.Models.Assessments;

public class OpenAssessmentRequest
{
    public DateTimeOffset AssessmentDueDate { get; set; }
    public DateTimeOffset PerformanceReviewDate { get; set; }
    public IReadOnlyCollection<int> Reviewers { get; set; } = new List<int>();
}
