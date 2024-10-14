using AutoMapper;
using VibePass.Core.Entities;
using VibePass.Core.Models.Eventy;
using VibePass.Core.Repository;
using VibePass.Core.Service;

namespace VibePass.Service.Services;

public class EventyService : IEventyService
{
    private readonly IEventyRepository _eventyRepository;
    private readonly IMapper _mapper;

    public EventyService(IEventyRepository eventyRepository, IMapper mapper)
    {
        _eventyRepository = eventyRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateEventyRequest createEventyRequest)
    {
        Eventy entity = _mapper.Map<Eventy>(createEventyRequest);
        await _eventyRepository.CreateAsync(entity);
    }

    public async Task<int> DeleteByIdAsync(string id)
    {
        return await _eventyRepository.DeleteByIdAsync(id);
    }

    public async Task<List<EventyResponse>> GetAllAsync()
    {
        return await _eventyRepository.GetAllAsync();
    }

    public async Task<EventyResponse> GetByIdAsync(string id)
    {
        return await _eventyRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(string id, UpdateEventyRequest updateEventyRequest)
    {
        var eventy = await _eventyRepository.GetByIdAsync(id);
        if (eventy == null)
        {
            throw new Exception("Event not found.");
        }
        Eventy entity = _mapper.Map<Eventy>(eventy);
        entity.Title = updateEventyRequest.Title;
        entity.Description = updateEventyRequest.Description;
        entity.StartDate = updateEventyRequest.StartDate;
        entity.EndDate = updateEventyRequest.EndDate;
        entity.Location = updateEventyRequest.Location;
        entity.ImageUrl = updateEventyRequest.ImageUrl;

        await _eventyRepository.UpdateAsync(id, entity);
    }
}