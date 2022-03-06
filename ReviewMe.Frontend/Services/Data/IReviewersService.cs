using ReviewMe.Models.Reviewers;

namespace ReviewMe.Frontend.Services.Data
{
    public interface IReviewersService
    {
        Task<Dictionary<string, List<Reviewer>>> GetReviewers(int id);
    }
}
