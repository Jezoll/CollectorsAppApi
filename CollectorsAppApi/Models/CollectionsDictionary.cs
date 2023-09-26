using System;
using System.Collections.Generic;

namespace CollectorsAppApi.Models;

public partial class CollectionsDictionary
{
    public int CollectionTypeId { get; set; }

    public string MetaCategory { get; set; } = null!;

    public string Collection { get; set; } = null!;

    public virtual ICollection<Collection> CaaCollections { get; set; } = new List<Collection>();

    public virtual ICollection<Item> CaaCollectorsItems { get; set; } = new List<Item>();

    public virtual ICollection<Events> CaaEventsCalendars { get; set; } = new List<Events>();
}
