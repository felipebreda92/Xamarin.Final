using System;
using System.Collections.Generic;
using System.Text;
using XF.BlocoNotas.Models;

namespace XF.BlocoNotas.Validations
{
    public static class NotaValidation
    {
        public static string ErrorMessage { get; set; }

        public static bool ValidaNotas(Nota nota)
        {
            var isValid = true;
            if (string.IsNullOrEmpty(nota.Titulo))
            {
                isValid = false;
                ErrorMessage = "Título da nota inválido";
            }

            if (string.IsNullOrEmpty(nota.Dados))
            {
                isValid = false;
                ErrorMessage = "Dados da nota inválidos";
            }

            return isValid;
        }
    }
}
