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


using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using System.Reflection;
using Google.Protobuf.WellKnownTypes;
using static System.Net.Mime.MediaTypeNames;
using Data.REPARALO.Clients;
using Data.REPARALO.Users;
using Data.REPARALO.OrdenReparacion;
//using ApiRestREPARALO.JSON;


//using Data.REPARALO.JSON;

namespace Data.REPARALO.RepairOrder
{
    public class RepairOrderRepository : IRepairOrderRepository
    {
        //public DEFAULT VDEFAULT = new DEFAULT();
        private readonly DBReparalo _dbReparalo;
        private readonly IListBoxRepository _IListBoxRepository;
        public RepairOrderRepository(DBReparalo connectionstring)
        {
            _IListBoxRepository = new ListBoxRepository(connectionstring);
            _dbReparalo = connectionstring;
        }
        
        public async Task<IEnumerable<MREPAIRORDER>> GETREPAIRORDER(string? REPAIRORDER)
        {
            try
            {
                if (REPAIRORDER == null)
                {
                    var Listnull = _dbReparalo.MREPAIRORDER.Where(u => u.Active == true).Select(u => new MREPAIRORDER{
                        Id = u.Id,
                        Date = u.Date,
                        MORDENTYPEId = u.MORDENTYPEId,
                        MORDENTYPE = u.MORDENTYPE,
                        MUSERAssignedId = u.MUSERAssignedId,
                        MUSERAssigned = u.MUSERAssigned,
                        MUSERCreatedId = u.MUSERCreatedId,
                        MUSERCreated = u.MUSERCreated,
                        DeadLine = u.DeadLine,
                        MCLIENTId = u.MCLIENTId,
                        MCLIENT = u.MCLIENT,
                        MTRADEMARKId = u.MTRADEMARKId,
                        MTRADEMARK = u.MTRADEMARK,
                        Model = u.Model,
                        MEQUIPMENTTYPEId = u.MEQUIPMENTTYPEId,
                        MEQUIPMENTTYPE = u.MEQUIPMENTTYPE,
                        IMEI1 = u.IMEI1,
                        IMEI2 = u.IMEI2,
                        Accessories = u.Accessories,
                        Symptoms = u.Symptoms,
                        State = u.State,
                        Active = u.Active

                });



                    _dbReparalo.SaveChangesAsync();
                    return Listnull;
                }
                var List = _dbReparalo.MREPAIRORDER.Where(u => u.Active == true).Select(u => u);
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

                _dbReparalo.MREPAIRORDER.Add(REPAIRORDER);
                _dbReparalo.SaveChangesAsync();
                if (REPAIRORDER.Id < 1)
                    return null;
                /*var objet = VDEFAULT.Read();
                objet.REPAIRORDER = REPAIRORDER.Id;
                objet.CLIENT = REPAIRORDER.MCLIENTId;
                objet.ORDENTYPE = REPAIRORDER.MORDENTYPEId;
                objet.TRADEMARK = REPAIRORDER.MTRADEMARKId;
                objet.EQUIPMENTTYPE = REPAIRORDER.MEQUIPMENTTYPEId;
                VDEFAULT.Write(objet);*/
                return REPAIRORDER;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<byte[]> GETPDFREPAIRORDER(int? Id_REPAIRORDER)
        {
            try
            {
                var REPAIRORDER = _dbReparalo.MREPAIRORDER.Where(a => a.Id == Id_REPAIRORDER).Select(a => new MREPAIRORDER{
                    Id = a.Id,
                    Date = a.Date,
                    MCLIENTId = a.MCLIENTId,
                    MCLIENT = _dbReparalo.MCLIENT.Where(e => e.Id == a.MCLIENTId).Select(e => new MCLIENT
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        SecondName = e.SecondName,
                        FirstLastName = e.FirstLastName,
                        SecondLastName = e.SecondLastName,
                        PhoneNumber1 = e.PhoneNumber1,
                        PhoneNumber2 = e.PhoneNumber2,
                        DocumentNumber = e.DocumentNumber,
                        MCITYId = e.MCITYId,
                        MCITY = _dbReparalo.MCITY.Where(i => i.Id == e.MCITYId).FirstOrDefault(),
                    }).FirstOrDefault(),
                }).FirstOrDefault();
                if (REPAIRORDER == null)
                    return null;
                var data = QuestPDF.Fluent.Document.Create(document =>
                {
                    document.Page(page =>
                    {
                        var ruteImage = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), "Files\\reparalo.png");
                        byte[] imageData = System.IO.File.ReadAllBytes(ruteImage);
                        var h1 = 14;
                        var h2 = 11;
                        var h3 = 10;
                        var h4 = 9;

                        var TTConstantItem1 = 50;
                        var TTConstantItem2 = 135;
                        var TTPaddingRight = 3;

                        var IOConstantItem1 = 70;
                        var IOConstantItem2 = 110;

                        var ICCPaddingVertical = 4;
                        var TTABorder = 1;
                        var TTAPaddingV = 2;
                        var TTAPaddingH = 4;
                        var TAMaxHeight = 50;
                        var TAMinHeight = 50;
                        var TAPadding = 2;
                        var TAPaddingContentH = 10;
                        var TAPaddingContentV = 4;



                        page.Size(PageSizes.A5);
                        page.MarginVertical(30);
                        page.MarginHorizontal(20);
                        page.Header().Row(a => {
                            a.RelativeItem().StopPaging().Column(e => {
                                e.Item().Text("REPÁRALO").Bold().FontSize(h1);
                                e.Item().Text("Soluciones Integrales Tecnológicas").Bold().FontSize(h2);
                                e.Item().Text("Telf.: 0980952474 - 0962626968").FontSize(h4);
                                e.Item().Text("Email: reparalosolutions@gmail.com").FontSize(h4);
                                e.Item().Text("Dirección: Av.Simón Plata Torres y Gustavo Becerra").FontSize(h4);
                            });
                            //a.RelativeItem().Width(150).Image(imageData);
                            a.RelativeItem().AlignRight().Width(150).Image(imageData);
                        });
                        //page.Header().Height(100).Border(1).BorderColor(Colors.Red.Medium);
                        //page.Content().Border(1).BorderColor(Colors.Red.Medium);
                        page.Content().Padding(2).StopPaging().Column(i =>
                        {
                            i.Item().Padding(10).Text(text =>
                            {
                                text.AlignCenter();
                                text.Span("ORDEN DE SERVICIO TÉCNICO").Bold().FontSize(h1);
                            });
                            i.Item().PaddingVertical(ICCPaddingVertical).StopPaging().Column(EE =>
                            {
                                EE.Item().Padding(TAPadding).StopPaging().Column(a =>
                                {
                                    a.Item().Row(e =>
                                    {

                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(IOConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("Orden #:").Bold().FontSize(h2);

                                            });
                                            i.ConstantItem(IOConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.Id.ToString()).FontSize(h2);

                                            });
                                        });
                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(IOConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("Fecha:").Bold().FontSize(h2);

                                            });
                                            i.ConstantItem(IOConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.Date.ToString()).FontSize(h2);

                                            });
                                        });
                                    });

                                });
                            });
                            i.Item().PaddingVertical(ICCPaddingVertical).StopPaging().Column(EE =>
                            {
                                EE.Item().Border(TTABorder).StopPaging().BorderBottom(0).PaddingHorizontal(TTAPaddingH).PaddingVertical(TTAPaddingV).Text(text =>
                                {
                                    text.AlignCenter();
                                    text.Span("DATOS DEL CLIENTE").Bold().FontSize(h2);
                                });
                                EE.Item().Border(TTABorder).StopPaging().Padding(TAPadding).Column(a =>
                                {
                                    a.Item().Row(i =>
                                    {
                                        i.ConstantItem(TTConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                        {
                                            t.AlignRight();
                                            t.Span("Nombre:").Bold().FontSize(h4);

                                        });
                                        i.RelativeItem().Text(t =>
                                        {
                                            t.AlignLeft();
                                            t.Span(REPAIRORDER.MCLIENT.FirstName+" "+REPAIRORDER.MCLIENT.SecondName + " " + REPAIRORDER.MCLIENT.FirstLastName + " " + REPAIRORDER.MCLIENT.SecondLastName).FontSize(h4);

                                        });
                                    });

                                    a.Item().Row(e =>
                                    {

                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(TTConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("RUC/CI:").Bold().FontSize(h4);

                                            });
                                            i.ConstantItem(TTConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.MCLIENT.DocumentNumber).FontSize(h4);

                                            });
                                        });
                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(TTConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("Teléfono:").Bold().FontSize(h4);

                                            });
                                            i.ConstantItem(TTConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.MCLIENT.PhoneNumber1).FontSize(h4);

                                            });
                                        });
                                    });
                                    a.Item().Row(e =>
                                    {

                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(TTConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("Ciudad:").Bold().FontSize(h4);

                                            });
                                            i.ConstantItem(TTConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.MCLIENT.MCITYId == null ? "" : REPAIRORDER.MCLIENT.MCITY.Name).FontSize(h4);

                                            });
                                        });
                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(TTConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("Teléfono:").Bold().FontSize(h4);

                                            });
                                            i.ConstantItem(TTConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.MCLIENT.PhoneNumber2).FontSize(h4);

                                            });
                                        });
                                    });
                                });
                            });
                            i.Item().StopPaging().PaddingVertical(ICCPaddingVertical).Column(EE =>
                            {
                                EE.Item().Border(TTABorder).BorderBottom(0).PaddingHorizontal(TTAPaddingH).PaddingVertical(TTAPaddingV).Text(text =>
                                {
                                    text.AlignCenter();
                                    text.Span("DATOS DEL EQUIPO").Bold().FontSize(h2);
                                });
                                EE.Item().StopPaging().Border(TTABorder).Padding(TAPadding).Column(a =>
                                {
                                    a.Item().Row(e =>
                                    {

                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(TTConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("Marca:").Bold().FontSize(h4);

                                            });
                                            i.ConstantItem(TTConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.MTRADEMARKId == null? "":REPAIRORDER.MTRADEMARK.Name ).FontSize(h4);

                                            });
                                        });
                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(TTConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("IMEI 1:").Bold().FontSize(h4);

                                            });
                                            i.ConstantItem(TTConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.IMEI1).FontSize(h4);

                                            });
                                        });
                                    });
                                    a.Item().Row(e =>
                                    {

                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(TTConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("Modelo:").Bold().FontSize(h4);

                                            });
                                            i.ConstantItem(TTConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.Model).FontSize(h4);

                                            });
                                        });
                                        e.RelativeItem().Row(i =>
                                        {
                                            i.ConstantItem(TTConstantItem1).PaddingRight(TTPaddingRight).Text(t =>
                                            {
                                                t.AlignRight();
                                                t.Span("IMEI 2:").Bold().FontSize(h4);

                                            });
                                            i.ConstantItem(TTConstantItem2).Text(t =>
                                            {
                                                t.AlignLeft();
                                                t.Span(REPAIRORDER.IMEI2).FontSize(h4);

                                            });
                                        });
                                    });
                                });
                            });
                            i.Item().StopPaging().PaddingVertical(ICCPaddingVertical).Column(EE =>
                            {
                                EE.Item().Border(TTABorder).PaddingHorizontal(TTAPaddingH).PaddingVertical(TTAPaddingV).Text(text =>
                                {
                                    text.AlignLeft();
                                    text.Span("ACCESORIOS DEL EQUIPO").Bold().FontSize(h2);
                                });
                                EE.Item().Border(TTABorder).MaxHeight(TAMaxHeight).MinHeight(TAMinHeight).PaddingVertical(TAPaddingContentV).PaddingHorizontal(TAPaddingContentH).Text(text =>
                                {
                                    text.AlignLeft();
                                    text.Span(REPAIRORDER.Accessories).FontSize(h4);
                                });
                            });
                            i.Item().StopPaging().PaddingVertical(ICCPaddingVertical).Column(EE =>
                            {
                                EE.Item().Border(TTABorder).PaddingHorizontal(TTAPaddingH).PaddingVertical(TTAPaddingV).Text(text =>
                                {
                                    text.AlignLeft();
                                    text.Span("SINTOMAS DEL EQUIPO").Bold().FontSize(h2);
                                });
                                EE.Item().Border(TTABorder).MaxHeight(TAMaxHeight).MinHeight(TAMinHeight).PaddingVertical(TAPaddingContentV).PaddingHorizontal(TAPaddingContentH).Text(text =>
                                {
                                    text.AlignLeft();
                                    text.Span(REPAIRORDER.Symptoms).FontSize(h4);
                                });
                            });
                            i.Item().StopPaging().PaddingVertical(ICCPaddingVertical).Column(EE =>
                            {
                                EE.Item().Border(TTABorder).PaddingHorizontal(TTAPaddingH).PaddingVertical(TTAPaddingV).Text(text =>
                                {
                                    text.AlignLeft();
                                    text.Span("ESTADO DEL EQUIPO").Bold().FontSize(h2);
                                });
                                EE.Item().Border(TTABorder).MaxHeight(TAMaxHeight).MinHeight(TAMinHeight).PaddingVertical(TAPaddingContentV).PaddingHorizontal(TAPaddingContentH).Text(text =>
                                {
                                    text.AlignLeft();
                                    text.Span(REPAIRORDER.State).FontSize(h4);
                                });
                            });


                        });
                    });
                }).GeneratePdf();
                return data;
                //Stream stream = new MemoryStream(data);
                //return FileStreamOptions(stream,"application/pdf","detalleventa.pdf");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
