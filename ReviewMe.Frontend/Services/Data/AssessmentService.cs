using Microsoft.AspNetCore.Components;
using ReviewMe.Frontend.Services.Notification;
using ReviewMe.Models.Assessments;

namespace ReviewMe.Frontend.Services.Data
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly INotificationService _notificationService;
        private readonly NavigationManager _navigationManager;

        public AssessmentService(IHttpClientService httpClientService, INotificationService notificationService, NavigationManager navigationManager)
        {
            _httpClientService = httpClientService;
            _notificationService = notificationService;
            _navigationManager = navigationManager;
        }

        public async Task OpenAssessment(int employeeId, (DateTimeOffset assessmentDueDate, DateTimeOffset performanceReviewDate, IReadOnlyCollection<int> reviewers) assessmentData)
        {
            var (assessmentDueDate, performanceReviewDate, reviewers) = assessmentData;
            var request = new OpenAssessmentRequest
            {
                AssessmentDueDate = assessmentDueDate,
                PerformanceReviewDate = performanceReviewDate,
                Reviewers = reviewers
            };

            try
            {
                await _httpClientService.PostJsonAsync($"Assessments/employee/{employeeId}/Open", request);
                _navigationManager.NavigateTo("reviews/employees");

                _notificationService.DisplayNotification("Assessment opened successfully", NotificationType.Success);
            }
            catch (Exception exception)
            {
                _notificationService.DisplayNotification($"Cannot open assessment: {exception.Message}", NotificationType.Error);
            }
        }

        public async Task UpdateAssessment(int employeeId, (DateTimeOffset assessmentDueDate, DateTimeOffset performanceReviewDate, IReadOnlyCollection<int> reviewers) assessmentData)
        {
            var (assessmentDueDate, performanceReviewDate, reviewers) = assessmentData;
            var request = new UpdateAssessmentRequest
            {
                AssessmentDueDate = assessmentDueDate,
                PerformanceReviewDate = performanceReviewDate,
                Reviewers = reviewers
            };

            try
            {
                await _httpClientService.PostJsonAsync($"Assessments/employee/{employeeId}/Update", request);
                _navigationManager.NavigateTo("reviews/employees");

                _notificationService.DisplayNotification("Assessment updated successfully", NotificationType.Success);
            }
            catch (Exception exception)
            {
                _notificationService.DisplayNotification($"Cannot update assessment: {exception.Message}", NotificationType.Error);
            }
        }

        public async Task CloseAssessment(int employeeId)
        {
            try
            {
                await _httpClientService.PostJsonAsync($"Assessments/employee/{employeeId}/Close", new { });
                _navigationManager.NavigateTo("reviews/employees");

                _notificationService.DisplayNotification("Assessment closed successfully", NotificationType.Success);
            }
            catch (Exception exception)
            {
                _notificationService.DisplayNotification($"Cannot close assessment: {exception.Message}", NotificationType.Error);
            }

        }

        public async Task DeleteAssessment(int employeeId)
        {
            try
            {
                await _httpClientService.DeleteAsync($"Assessments/employee/{employeeId}");
                _navigationManager.NavigateTo("reviews/employees");

                _notificationService.DisplayNotification("Assessment deleted successfully", NotificationType.Success);
            }
            catch (Exception exception)
            {
                _notificationService.DisplayNotification($"Cannot delete assessment: {exception.Message}", NotificationType.Error);
            }
        }

        public async Task SaveAdditionalFeedback(int employeeId, string feedback)
        {
            var request = new SaveAdditionalFeedbackRequest
            {
                Feedback = feedback
            };

            try
            {
                await _httpClientService.PostJsonAsync($"Assessments/employee/{employeeId}/AdditionalFeedback", request);

                _notificationService.DisplayNotification("Additional feedback saved successfully", NotificationType.Success);
            }
            catch (Exception exception)
            {
                _notificationService.DisplayNotification($"Cannot save additional feedback: {exception.Message}", NotificationType.Error);
            }
        }
    }
}
