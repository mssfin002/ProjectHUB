using Microsoft.EntityFrameworkCore;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Data;
using ProjectHUB.Models;

namespace ProjectHUB.Core.Repo
{
    public class TopicRepo : iTopicRepo
    {
        private readonly ProjectHUBContext _context;

        public TopicRepo(ProjectHUBContext context)
        {
            _context = context;
        }
        public void CreateTopic(TopicModel topic)
        {
            _context.Topics.Add(topic);
            _context.SaveChanges();
        }

        public void DeleteTopic(Guid id)
        {
            _context.Topics.Remove(_context.Topics.First(t => t.Id == id));
            _context.SaveChanges();

        }

        public TopicModel FindTopicById(Guid id)
        {
            return _context.Topics.FirstOrDefault(x => x.Id == id);   
        }

        public TopicModel FindTopicByShortTitle(string shortTitle)
        {
            return _context.Topics.FirstOrDefault(x => x.ShortTitle == shortTitle);
        }

        public ICollection<AOKModel> GetAOKS()
        {
            return _context.AreasOfKnowledge.ToList();
        }

        public ICollection<TopicModel> GetTopics()
        {
            return _context.Topics
                .Include(x => x.AreaOfKnowledge).ToList();
        }

        public TopicModel UpdateTopic(TopicModel topic)
        {
            _context.Topics.Update(topic);
            _context.SaveChanges();

            return topic;

        }
    }
}
