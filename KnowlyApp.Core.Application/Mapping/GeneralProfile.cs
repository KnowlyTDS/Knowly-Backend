using AutoMapper;
using KnowlyApp.Core.Application.DTOs.Account;
using KnowlyApp.Core.Application.ViewModels.Cursos;
using KnowlyApp.Core.Application.ViewModels.Entregas;
using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using KnowlyApp.Core.Application.ViewModels.Maestros;
using KnowlyApp.Core.Application.ViewModels.Tareas;
using KnowlyApp.Core.Application.ViewModels.Users;
using KnowlyApp.Core.Domain.Entities;

namespace KnowlyApp.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveAdminViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, EditUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Tareas, SaveTareaViewModel>()
                .ReverseMap();

            CreateMap<Entregas, SaveEntregaViewModel>()
                .ReverseMap();

            CreateMap<SaveEstudianteViewModel, Estudiantes>()
                .ReverseMap()
      .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.Tel, opt => opt.MapFrom(src => src.Tel))
    .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
    .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
    .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
    .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => src.Foto))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.isActive))
    .ForMember(dest => dest.CantidadTareas, opt => opt.MapFrom(src => src.CantidadTareas));



            CreateMap<Maestros, MaestroViewModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
        .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
        .ForMember(dest => dest.Tel, opt => opt.MapFrom(src => src.Tel))
        .ForMember(dest => dest.Especialidad, opt => opt.MapFrom(src => src.Especialidad))
        .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
        .ForMember(dest => dest.Email, opt => opt.Ignore()) // Esta propiedad no está en Maestros, ignórala
        .ForMember(dest => dest.isActive, opt => opt.Ignore()) // Esta propiedad no está en Maestros, ignórala
        .ForMember(dest => dest.cantCursosImpartidos, opt => opt.Ignore()); // Esta propiedad no está en Maestros, ignórala


            CreateMap<SaveCursosViewModel, Cursos>()
                .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // El Id se generará automáticamente en la base de datos
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
               .ForMember(dest => dest.Horario, opt => opt.MapFrom(src => src.Horario))// No mapeamos las tareas aquí, podríamos hacerlo en una operación separada
               .ForMember(dest => dest.MaestroId, opt => opt.MapFrom(src => src.MaestroId));// No mapeamos los estudiantes aquí, podríamos hacerlo en una operación separada

            CreateMap<EstudiantesCursos, EstudiantesViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.estudiante.Id));


        }
    }
}