using System;
using System.Collections.Generic;

namespace CollectorsAppApi.Models;

public partial class ForumTopic
{
    public int TopicId { get; set; }

    public int CreatorId { get; set; }

    public int? AssociatedCollection { get; set; }

    public DateTime DateOfCreation { get; set; }

    public bool Active { get; set; }
    public string? TopicName { get; set; }

    public virtual ICollection<Events> CaaEventsCalendars { get; set; } = new List<Events>();

    public virtual ICollection<ForumPost> CaaForumPosts { get; set; } = new List<ForumPost>();

    public virtual User Creator { get; set; } = null!;
    
    public class AddForumTopicRequest
    {
        public int CreatorId { get; set; }

        public int? AssociatedCollection { get; set; }

        public DateTime DateOfCreation { get; set; }

        public bool Active { get; set; }
        
        public string? TopicName  {get; set; }    
    }
    
}
