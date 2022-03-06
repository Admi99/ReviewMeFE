using ReviewMe.Models.Reviewers;

namespace ReviewMe.Frontend.Services.Data
{
    public class ReviewersService : IReviewersService
    {
        private readonly IHttpClientService _httpClientService;

        public ReviewersService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<Dictionary<string, List<Reviewer>>> GetReviewers(int id)
            => (await _httpClientService
                    .GetJsonAsync<GetAssessmentReviewersResponse>($"Reviewers/employee/{id}")
                ?? new GetAssessmentReviewersResponse())
                .AssessmentReviewers;
    }
}
