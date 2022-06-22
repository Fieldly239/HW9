using Feedback.Models;

namespace Feedback.Repositories
{
    public interface IFeedbacksRepository
    {
        IEnumerable<Feedbacks> GetAllFeedbacks();
        Feedbacks GetByIdFeedbacks(int id);
        void AddFeedbacks(Feedbacks feedbacks);
        void UpdateFeedbacks(Feedbacks feedbacks);
        void DeleteFeedbacks(int id);
    }
}
