using ReviewMe.Models.Reviewers;

namespace ReviewMe.Frontend.Services.Data
{
    public class ReviewersFeedbackService : IReviewersFeedbackService
    {
        private readonly IHttpClientService _httpClientService;

        public ReviewersFeedbackService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<ReviewerFeedback>> GetByEmployeeId(int employeeId)
        {
            var result =
              await _httpClientService.GetJsonAsync<GetReviewersFeedbackResponse>($"Reviewers/Feedback/employee/{employeeId}")
                ?? new GetReviewersFeedbackResponse();

            return result.Feedbacks;
        }
    }
}
