using Feedback.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Repositories
{
    public class FeedbacksRepository : IFeedbacksRepository
    {
        private readonly FeedbackMgmtContext _feedbackMgmtContext;

        public FeedbacksRepository(FeedbackMgmtContext feedbackMgmtContext)
        {
            _feedbackMgmtContext = feedbackMgmtContext;

        }
        public IEnumerable<Feedbacks> GetAllFeedbacks()
        {
            return _feedbackMgmtContext.Feedbacks.ToList();
        }
        public Feedbacks GetByIdFeedbacks(int id)
        {
            return _feedbackMgmtContext.Feedbacks.Find(id);
        }

        public void AddFeedbacks(Feedbacks feedbacks)
        {
            _feedbackMgmtContext.Feedbacks.Add(feedbacks);
            _feedbackMgmtContext.SaveChanges();
        }
        public void UpdateFeedbacks(Feedbacks feedbacks)
        {
            _feedbackMgmtContext.Entry(feedbacks).State = EntityState.Modified;
            _feedbackMgmtContext.SaveChanges();
        }
        public void DeleteFeedbacks(int id)
        {
            var feedback = _feedbackMgmtContext.Feedbacks.Find(id);
            _feedbackMgmtContext.Feedbacks.Remove(feedback);
            _feedbackMgmtContext.SaveChanges();
        }

        

        

        
    }
}
