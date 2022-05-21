using System;

namespace PartySpenderAPI.ServiceModel;
public class PartyDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PartyDate { get; set; }
}

