using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    public class Detalle : CrudEntities
    {
        [Key]
        public long IdDetalle { get; set; }
        public long? IdFicha { get; set; }
        public FichaSintoma FichaSintoma { get; set; }
        public int Fiebre { get; set; }
        public int Adelgazamiento { get; set; }
        public int Anorexia { get; set; }
        public int Debilidad { get; set; }
        public int Alopecia { get; set; }
        public int HemorragiasNasales { get; set; }
        public int AumentoOrinaEliminada { get; set; }
        public int AumentoIngestaAgua { get; set; }
        public int AlteracionesOculares { get; set; }
        public int TranstornoNeuronales { get; set; }
        public int Anemia { get; set; }
        public int Tos { get; set; }
        public int DificultadesRespiratorias { get; set; }
    }
}
