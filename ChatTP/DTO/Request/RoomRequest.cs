using ChatTP.Models;
using System.ComponentModel.DataAnnotations;

namespace ChatTP.DTO.Request
{
    public class RoomRequest
    {
       
            public string? idTransmitter { get; set; }
            public string? TransmitterName { get; set; }
            public string? idArrival { get; set; }
            public string? ArrivalName { get; set; }
        }

    }

