using AutoMapper;
using KnowlyApp.core.Domain.Entities;
using KnowlyApp.Core.Application.Dtos.Cursos;
using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _icursoRepository;
        private readonly IMapper _mapper;
        public CursoService(ICursoRepository icursoRepository, IMapper mapper)
        {
            _icursoRepository = icursoRepository;
            _mapper = mapper;
        }

        public async Task<CreateCursoResponse> RegisterAsync(CreateCursoRequest vm)
        {
            Curso entity = _mapper.Map<Curso>(vm);
            entity = await _icursoRepository.AddAsync(entity);
            CreateCursoResponse svm = _mapper.Map<CreateCursoResponse>(entity);
            return svm;
        }
    }
}
