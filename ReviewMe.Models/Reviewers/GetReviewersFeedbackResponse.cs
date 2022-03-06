namespace ReviewMe.Models.Reviewers;

public class GetReviewersFeedbackResponse
{
    public List<ReviewerFeedback> Feedbacks { get; set; } = new();
}