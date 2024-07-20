using JoaoHong.APICollection.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Domain.Port.Application.Services
{
    public interface IPiadaService
    {
        Task<string> FindJoke(ConsultarPiada model);
    }
}
