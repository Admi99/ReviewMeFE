namespace ReviewMe.Frontend.Services.Data
{
    public interface IAssessmentService
    {
        Task OpenAssessment(int employeeId, (DateTimeOffset assessmentDueDate, DateTimeOffset performanceReviewDate, IReadOnlyCollection<int> reviewers) assessmentData);
        Task UpdateAssessment(int employeeId, (DateTimeOffset assessmentDueDate, DateTimeOffset performanceReviewDate, IReadOnlyCollection<int> reviewers) assessmentData);
        Task CloseAssessment(int employeeId);
        Task DeleteAssessment(int employeeId);
        Task SaveAdditionalFeedback(int employeeId, string feedback);
    }
}
