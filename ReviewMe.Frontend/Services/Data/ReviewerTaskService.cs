using Microsoft.AspNetCore.Components;
using ReviewMe.Frontend.Services.Notification;
using ReviewMe.Models.ReviewerTasks;

namespace ReviewMe.Frontend.Services.Data
{
    public class ReviewerTaskService : IReviewerTaskService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly NavigationManager _navigationManager;
        private readonly INotificationService _notificationService;

        public ReviewerTaskService(IHttpClientService httpClientService, NavigationManager navigationManager,
            INotificationService notificationService)
        {
            _httpClientService = httpClientService;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public async Task<List<ReviewerTask>> Get()
        {
            return (await _httpClientService.GetJsonAsync<GetReviewerTasksResponse>("ReviewerTasks"))?.ReviewerTasks ??
                   new List<ReviewerTask>();
        }

        public async Task<ReviewerTask> Get(int assessmentId)
        {
            try
            {
                var result =
                    await _httpClientService.GetJsonAsync<GetReviewerTaskResponse>
                        ($"ReviewerTasks/assessment/{assessmentId}");
                if (result?.ReviewerTask == null)
                {
                    _notificationService.DisplayNotification("Cannot get the task",
                        NotificationType.Error);
                    return new ReviewerTask();
                }

                return result.ReviewerTask;
            }

            catch (Exception exception)
            {
                _notificationService.DisplayNotification($"Cannot get task: {exception.Message}", NotificationType.Error);
                return new ReviewerTask();
            }
        }

        public async Task Draft(int assessmentId, string feedback, string areasForImprovements)
        {
            var request = new DraftRequest
            {
                Feedback = feedback,
                AreasForImprovements = areasForImprovements
            };

            try
            {
                await _httpClientService.PostJsonAsync($"ReviewerTasks/assessment/{assessmentId}/Draft", request);
                _navigationManager.NavigateTo("reviews");
            }
            catch (Exception exception)
            {
                _notificationService.DisplayNotification($"Cannot Draft task: {exception.Message}",
                    NotificationType.Error);
            }
        }

        public async Task Submit(int assessmentId, string feedback, string areasForImprovements)
        {
            var request = new SubmitRequest
            {
                Feedback = feedback,
                AreasForImprovements = areasForImprovements
            };

            try
            {
                await _httpClientService.PostJsonAsync($"ReviewerTasks/assessment/{assessmentId}/Submit", request);
                _navigationManager.NavigateTo("reviews");
            }
            catch (Exception exception)
            {
                _notificationService.DisplayNotification($"Cannot Submit task: {exception.Message}",
                    NotificationType.Error);
            }
        }

        public async Task Decline(int assessmentId, string reason)
        {
            var request = new DeclineRequest
            {
                Reason = reason
            };

            try
            {
                await _httpClientService.PostJsonAsync($"ReviewerTasks/assessment/{assessmentId}/Decline", request);
                _navigationManager.NavigateTo("reviews");
            }
            catch (Exception exception)
            {
                _notificationService.DisplayNotification($"Cannot Decline task: {exception.Message}",
                    NotificationType.Error);
            }
        }
    }
}