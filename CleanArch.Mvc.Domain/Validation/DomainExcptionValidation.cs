using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Validation
{
    internal class DomainExcptionValidation : Exception  //classe usada para validar o dominio
    {
        public DomainExcptionValidation(string error) : base(error)
        {}

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExcptionValidation(error);
        }
    }
}
