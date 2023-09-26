using System;
using System.Collections.Generic;

namespace CollectorsAppApi.Models;

public partial class Events
{
    public int EventId { get; set; }

    public int OrganizerId { get; set; }

    public int? AssociatedCollection { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfEvent { get; set; }

    public string? EventAdress { get; set; }

    public bool TookPlace { get; set; }

    public bool Verified { get; set; }

    public int? ForumTopicId { get; set; }

    public virtual CollectionsDictionary? AssociatedCollectionNavigation { get; set; }

    public virtual ForumTopic? ForumTopic { get; set; }

    public virtual User Organizer { get; set; } = null!;
    public class AddEventRequest
    {
        public int OrganizerId { get; set; }

        public int? AssociatedCollection { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime? DateOfEvent { get; set; }

        public string? EventAdress { get; set; }

        public bool TookPlace { get; set; }

        public bool Verified { get; set; }

        public int? ForumTopicId { get; set; }
    }
}
