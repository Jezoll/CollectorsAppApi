using System;
using System.Collections.Generic;

namespace CollectorsAppApi.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string MetaCategory { get; set; } = null!;

    public int CollectionTypeId { get; set; }

    public int CollectionId { get; set; }

    public int OwnerId { get; set; }

    public string? Description { get; set; }

    public byte[]? Attachment { get; set; }

    public virtual Collection Collection { get; set; } = null!;

    public virtual CollectionsDictionary CollectionType { get; set; } = null!;

    public virtual User Owner { get; set; } = null!;

    public class CreateItemRequest{
        public string MetaCategory { get; set; } = null!;

        public int CollectionTypeId { get; set; }

        public int CollectionId { get; set; }

        public int OwnerId { get; set; }

        public string? Description { get; set; }

        public byte[]? Attachment { get; set; }
    }
}
