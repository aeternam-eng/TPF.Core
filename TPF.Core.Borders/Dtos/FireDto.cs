using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPF.Core.Borders.Dtos
{
    public class FireDto
    {
        public Guid Id { get; init; }
        public Guid Device_Id { get; init; }
        public bool Is_fogo_bicho { get; init; }
        public decimal Image_Fire_Probability { get; init; }
        public DateTime Date { get; init; }
    }
}
