using System;
using System.Collections.Generic;

namespace CollectorsAppApi.Models;

public partial class Collection
{
    public int CollectionId { get; set; }

    public int OwnerId { get; set; }

    public int CollectionTypeId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Item> CollectorsItems { get; set; } = new List<Item>();

    public virtual CollectionsDictionary CollectionType { get; set; } = null!;

    public virtual User Owner { get; set; } = null!;

    public class AddCollectionRequest
    {
        public int OwnerId { get; set; }

        public int CollectionTypeId { get; set; }

        public string? Description { get; set; }
    }
}
