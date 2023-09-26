using System;
using System.Collections.Generic;

namespace CollectorsAppApi.Models;

public partial class ForumPost
{
    public int PostId { get; set; }

    public int TopicId { get; set; }

    public int CreatorId { get; set; }

    public DateTime DateOfCreation { get; set; }

    public string PostBody { get; set; } = null!;

    public byte[]? Attachment { get; set; }

    public virtual User Creator { get; set; } = null!;

    public virtual ForumTopic Topic { get; set; } = null!;

    public class AddForumPostRequest
    {
        public int TopicId { get; set; }

        public int CreatorId { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string PostBody { get; set; } = null!;

        public byte[]? Attachment { get; set; }
    }    
    
}
