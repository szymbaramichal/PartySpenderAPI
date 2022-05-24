using PartySpenderAPI.ServiceModel.Parties;
using PartySpenderAPI.ServiceModel.Types;
using ServiceStack;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartySpenderAPI.ServiceInterface;
public class PartiesService : Service
{
    public async Task<object> Get(GetParty getParty)
    {
        var party = await Db.SingleByIdAsync<Party>(getParty.Id);
        if (party == null) return HttpError.NotFound("Party not found.");
        return party.ConvertTo<PartyDTO>();
    }
    public async Task<object> Get(GetAllParties getAllParties) 
    {
        var parties = await Db.SelectAsync<Party>();
        List<PartyDTO> partiesDto = new List<PartyDTO>();
        foreach (var party in parties)
        {
            partiesDto.Add(party.ConvertTo<PartyDTO>());
        }
        return partiesDto;
    }
    public async Task<object> Post(CreateParty createParty) 
    {
        Party party = new Party()
        {
            Name = createParty.Name,
            Description = createParty.Description,
            PartyDate = createParty.PartyDate
        };

        await Db.SaveAsync(party);

        return party.ConvertTo<PartyDTO>();
    }
    public async Task<object> Put(UpdateParty updateParty) 
    {
        var partyToUpdate = await Db.SingleByIdAsync<Party>(updateParty.Id);
        if (partyToUpdate == null) return HttpError.NotFound("Party not found.");

        partyToUpdate.Name = updateParty.Name;
        partyToUpdate.Description = updateParty.Description;
        partyToUpdate.PartyDate = updateParty.PartyDate;

        await Db.UpdateAsync(partyToUpdate);
        return partyToUpdate.ConvertTo<PartyDTO>();
    }
    public async Task<object> Delete(DeleteParty deleteParty) 
    {
        var partyExists = await Db.ExistsAsync<Party>(x => x.Id == deleteParty.Id);
        if (!partyExists) return HttpError.NotFound("Party not found.");

        await Db.DeleteByIdAsync<Party>(deleteParty.Id);
        return new { };
    }
}
