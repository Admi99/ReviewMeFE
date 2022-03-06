using ReviewMe.Models.ReviewerTasks;

namespace ReviewMe.Frontend.Services.Data
{
    public interface IReviewerTaskService
    {
        Task<List<ReviewerTask>> Get();
        Task<ReviewerTask> Get(int assessmentId);
        Task Decline(int assessmentId, string reason);
        Task Draft(int assessmentId, string feedback, string areasForImprovements);
        Task Submit(int assessmentId, string feedback, string areasForImprovements);
    }
}
