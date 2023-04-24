using Data.REPARALO.ConnectDB;
using Data.REPARALO.LIstBox;
using Data.REPARALO.RepairOrder;
using SelectPdf;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.RepairOrder
{
    public class RepairOrderRepository : IRepairOrderRepository
    {
        private readonly DBReparalo _dbReparalo;
        public RepairOrderRepository(DBReparalo connectionstring)
        {
            _dbReparalo = connectionstring;
        }
        /*public async Task<string> PostOrdenReparacion(MREPAIRORDER OrdenReparacion)
        {
            try
            {
                var ho = AppDomain.CurrentDomain.BaseDirectory;
                var htmlCode = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "OrdenReparacion\\OrdenReparacion.html");
                //var htmlCode = File.ReadAllText("C:\\Users\\japac\\OneDrive\\Documentos\\PROPIO\\ORDENDESERVICIO.html");

                SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
                converter.Options.PdfPageSize = PdfPageSize.A5;
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(htmlCode);
                
                doc.Save("C:\\Users\\japac\\OneDrive\\Documentos\\hola.pdf");
                byte[] data = doc.Save();
                var result = Convert.ToBase64String(data);
                
                doc.Close();
                return result;
            }
            catch (Exception ex)
            {
                return "";
            }
            */
        public async Task<IEnumerable<MREPAIRORDER>> GETREPAIRORDER(string? REPAIRORDER)
        {
            try
            {
                if (REPAIRORDER == null)
                {
                    var Listnull = _dbReparalo.MREPAIRORDER.Select(u => new MREPAIRORDER { Id = u.Id});
                    _dbReparalo.SaveChangesAsync();
                    return Listnull;
                }
                var List = _dbReparalo.MREPAIRORDER.Select(u => new MREPAIRORDER { Id = u.Id });
                //var List = _dbReparalo.MCITY.Where(u => u.Description.Contains(REPAIRORDER)).Select(u => new MREPAIRORDER { Id = u.Id, Name = u.Name });
                _dbReparalo.SaveChangesAsync();
                return List;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MREPAIRORDER> POSTREPAIRORDER(MREPAIRORDER REPAIRORDER)
        {
            try
            {
                if (REPAIRORDER.MCLIENTId == 0)
                    REPAIRORDER.MCLIENTId = null;

                    
                _dbReparalo.MREPAIRORDER.Add(REPAIRORDER);
                _dbReparalo.SaveChangesAsync();
                if (REPAIRORDER.Id < 1)
                    return null;
                return REPAIRORDER;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
