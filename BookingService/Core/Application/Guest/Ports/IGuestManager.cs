using Application.Guest.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports
{
    public interface IGuestManager
    {
        Task<Response> CreateGuest(CreateGuestRequest request);
    }
}
