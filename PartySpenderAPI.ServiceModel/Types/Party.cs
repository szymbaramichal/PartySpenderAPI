using ServiceStack.DataAnnotations;
using System;

namespace PartySpenderAPI.ServiceModel.Types;
public class Party
{
    [AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PartyDate { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

}

