namespace ReviewMe.Models.Reviewers
{
    public class GetAssessmentReviewersResponse
    {
        public Dictionary<string, List<Reviewer>> AssessmentReviewers { get; set; } = new();
    }
}
