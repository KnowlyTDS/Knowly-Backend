using KnowlyApp.Core.Application.Dtos.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface ICursoService
    {
        Task<CreateCursoResponse> RegisterAsync(CreateCursoRequest vm);
    }
}
