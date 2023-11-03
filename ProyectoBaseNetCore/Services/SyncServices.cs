using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.DTOs;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;


namespace ProyectoBaseNetCore.Services
{
    public class SyncServices
    {
        private static string _usuario;
        private static ExcelHelperService _ExelHelper = new ExcelHelperService();
        private static string _ip;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        public SyncServices(ApplicationDbContext context, IConfiguration configuration, string ip, string usuario)
        {
            _context = context;
            this.configuration = configuration;
            _ip = ip;
            _usuario = usuario;
        }
        public async Task<ImportResponseDTO> MultipleCheckList(IFormFile file)
        {
            try
            {
                using var stream = file.OpenReadStream();
                IWorkbook workbook = new XSSFWorkbook(stream);
                ISheet sheet = workbook.GetSheetAt(0); // Selecciona la hoja de trabajo

                string[] expectedHeaders = new string[] {
            "cod.Cliente","NOMBRES","CEDULA","DIRECCION","TELEFONO","CORREO","cod.Mascota","NOMBRE","RAZA","PESO","SEXO","FECH.NAC"
        };

                Dictionary<string, object> result = await _ExelHelper.ValidarFormatoArchivo(sheet, expectedHeaders);

                if ((bool)result["hasError"] == true)
                {
                    throw new Exception(result["messageError"] as string);
                }

                bool hasError = false;
                StringBuilder messageError = new StringBuilder();
                long IdCurrent = 0;
                // List<CheckListAlistamientoDTO> CheckList = new List<CheckListAlistamientoDTO>();
                for (int row = sheet.FirstRowNum + 1; row <= sheet.LastRowNum; row++)
                {
                    IRow excelRow = sheet.GetRow(row);

                    if (excelRow != null)
                    {
                        string CodigoC = excelRow.GetCell(0)?.ToString();
                        string Nombres = excelRow.GetCell(1)?.ToString();
                        string Cedula = excelRow.GetCell(2)?.ToString();
                        string Direccion = excelRow.GetCell(3)?.ToString();
                        string Celular = excelRow.GetCell(4)?.ToString();
                        string Correo = excelRow.GetCell(5)?.ToString();
                        string CodigoM = excelRow.GetCell(6)?.ToString();
                        string NombreM = excelRow.GetCell(7)?.ToString();
                        string Raza = excelRow.GetCell(8)?.ToString();
                        string Peso = excelRow.GetCell(9)?.ToString();
                        string Sexo = excelRow.GetCell(10)?.ToString();
                        string FNac = excelRow.GetCell(11)?.ToString();

                        // Realizar validaciones y procesamiento de datos de acuerdo a tus requisitos
                        if (string.IsNullOrEmpty(Cedula) || Cedula.Length < 10)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row +1}: No se ha proporcionado un Número de cedula o la cedula {Cedula} es inválida.");
                        }

                        if (string.IsNullOrEmpty(Nombres) || Nombres.Length < 3)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row +1}: No se ha proporcionado un Nombre o {Nombres} no es válido.");
                        }
                        if (string.IsNullOrEmpty(Direccion) || Direccion.Length < 3)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row +1}: No se ha proporcionado una Direccion o  {Direccion} no es válido.");
                        }
                        if (string.IsNullOrEmpty(Celular) || Celular.Length < 10)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row + 1}: No se ha proporcionado un número Celular o  {Celular} no es válido.");
                        }
                        if (string.IsNullOrEmpty(NombreM) || NombreM.Length < 3)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row + 1}: No se ha proporcionado un Nombre Para la mascota o  {NombreM} no es válido.");
                        }
                        if (string.IsNullOrEmpty(Raza) || Raza.Length < 3)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row + 1}: No se ha proporcionado la raza o  {Raza} no es válido.");
                        }
                        // Continúa procesando las demás columnas y aplicando tus lógicas
                    }
                }

                return new ImportResponseDTO
                {
                    HasError = hasError,
                    Message = messageError.ToString()
                };
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }


    }
}