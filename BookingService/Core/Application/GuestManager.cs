using Application.Guest.DTO;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Application.Ports;
using Domain.Ports;

namespace Application
{
    public class GuestManager : IGuestManager
    {
        private readonly IGuestRepository _guestRepository;

        public GuestManager(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Response> CreateGuest(CreateGuestRequest request)
        {
            try
            {
                var guest = GuestDTO.MapToEntity(request.Data);

                request.Data.Id = await _guestRepository.Create(guest);
                return new GuestResponse
                {
                    Data = request.Data,
                    Success = true,
                };
            } catch(Exception e)
            {
                return new GuestResponse
                {
                    Message = e.Message,
                    ErrorCodes = ErrorCodes.COULD_NOT_STORE_DATA,
                    Success = false,
                };
            }
        }
    }
}
