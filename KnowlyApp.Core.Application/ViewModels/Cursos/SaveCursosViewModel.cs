using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowlyApp.Core.Application.ViewModels.Cursos
{
    public class SaveCursosViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public int MaestroId {get; set;}
        public string Horario { get; set; }

    }

}
