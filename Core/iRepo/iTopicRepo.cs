using ProjectHUB.Models;

namespace ProjectHUB.Core.iRepo
{
    public interface iTopicRepo
    {
        ICollection<TopicModel> GetTopics();
        ICollection<AOKModel> GetAOKS();

        TopicModel FindTopicById(Guid id);
        TopicModel FindTopicByShortTitle(string shortTitle);
        TopicModel UpdateTopic(TopicModel topic);
        void CreateTopic(TopicModel topic);
        void DeleteTopic(Guid id);    
    }
}
