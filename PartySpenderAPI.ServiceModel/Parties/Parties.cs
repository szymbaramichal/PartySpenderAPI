using ServiceStack;
using System;
using System.Collections.Generic;

namespace PartySpenderAPI.ServiceModel.Parties;

[Route("/parties/getAll", "GET")]
public class GetAllParties : IReturn<List<PartyDTO>> { }


[Route("/parties/getParty/{Id}", "GET")]
public class GetParty : IReturn<PartyDTO>
{
    public int Id { get; set; }
}

[Route("/parties/create", "POST")]
public class CreateParty : IReturn<PartyDTO>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PartyDate { get; set; }
}

[Route("/parties/update/{Id}", "PUT")]
public class UpdateParty : IReturn<PartyDTO>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PartyDate { get; set; }
}

[Route("/parties/delte/{Id}")]
public class DeleteParty : IReturnVoid
{
    public int Id { get; set; }
}



