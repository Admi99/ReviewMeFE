using ReviewMe.Models.Reviewers;

namespace ReviewMe.Frontend.Services.Data
{
    public interface IReviewersFeedbackService
    {
        Task<List<ReviewerFeedback>> GetByEmployeeId(int employeeId);

    }
}
