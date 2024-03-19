//using Administracion.Classes.global
using FtpLib;
using System;
using System.Collections;
//using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
//using Microsoft.VisualBasic;
//using WS_Integrador.Classes.model;
//using GP_AdminDll.Classes.global.util;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WS_Integrador_MeLoLLevo.Utils;
using WS_Integrador_GP_BSALE.Utils;
//using WS_Integrador_MeLoLLevo.Classes.enterprise;
using WS_Integrador_MeLoLLevo;
using System.Net;
//using System.Globalization;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WS_Integrador.Classes.model;

namespace WS_itec2
{
    public partial class Service1 : ServiceBase
    {
        //private IContainer components = null;
        private Timer tmServicio1 = null;
        //private int minutos = 0;
        //private int minutosSF = 0;
        //private string mensaje2;
        //private string gBD_GETPOINT;
        //private int gEmpId;

        #region ClasesParaEjecutarAPIs
        public class Integracion
        {
            public string Key { get; set; }
            public string EmpId { get; set; }
            public string Archivo { get; set; }
            public string TXT { get; set; }
        }

        public partial class Cab_ConfirmaRecepcionINET
        {
            public Cab2_ConfirmaRecepcionINET SIWMSSDTRecepcion { get; set; }
        }

        [DataContract]
        public class Cab2_ConfirmaRecepcionINET
        {
            [DataMember(Order = 1)]
            public long REC_MovTpo { get; set; }

            [DataMember(Order = 2)]
            public long REC_MovIden { get; set; }

            [DataMember(Order = 3)]
            public string REC_MovNumRef { get; set; }

            [DataMember(Order = 4)]
            public DateTime REC_MovFecRef { get; set; }

            [DataMember(Order = 5)]
            public long REC_MovTipRef { get; set; }

            [DataMember(Order = 6)]
            public string REC_MovNomRef { get; set; }

            [DataMember(Order = 7)]
            public long REC_MovRutSec { get; set; }

            [DataMember(Order = 8)]
            public string REC_MovRutDig { get; set; }

            [DataMember(Order = 9)]
            public long REC_MovRutRef { get; set; }

            [DataMember(Order = 10)]
            public string SOL_MovIdenWMS { get; set; }

            [DataMember(Order = 11)]
            public long SOL_MovIden { get; set; }

            [DataMember(Order = 12)]
            public long SOL_MovTpo { get; set; }

            //[DataMember(Order = 13)]
            //public string REC_MovRegJsonRes { get; set; }

            //[DataMember(Order = 14)]
            //public string REC_MovRegJson { get; set; }

            //[DataMember(Order = 15)]
            //public string REC_MovRegSin { get; set; }

            //[DataMember(Order = 16)]
            //public string REC_MovRegHor { get; set; }

            //[DataMember(Order = 17)]
            //public DateTime REC_MovRegFec { get; set; }

            //[DataMember(Order = 18)]
            //public string REC_MovRegUsu { get; set; }

            //[DataMember(Order = 19)]
            //public long REC_SIIMon { get; set; }

            [DataMember(Order = 20)]
            public DateTime REC_SIIFec { get; set; }

            [DataMember(Order = 21)]
            public string REC_SIINum { get; set; }

            [DataMember(Order = 22)]
            public long REC_SIITip { get; set; }

            [DataMember(Order = 23)]
            public DateTime REC_Mov_RecFec { get; set; }

            [DataMember(Order = 24)]
            public string REC_Mov_BodDes { get; set; }

            [DataMember(Order = 25)]
            public string REC_Mov_BodOri { get; set; }

            //[DataMember(Order = 26)]
            //public long REC_MovAno { get; set; }

            //[DataMember(Order = 27)]
            //public long REC_MovMes { get; set; }

            [DataMember(Order = 28)]
            public long REC_MovRefWMS { get; set; }

            [DataMember(Order = 99)]

            public List<Det_ConfirmaRecepcionINET> CONDET = new List<Det_ConfirmaRecepcionINET>();
        }

        [DataContract]
        public class Det_ConfirmaRecepcionINET
        {
            [DataMember(Order = 1)]
            public long REC_MovLinId { get; set; }

            [DataMember(Order = 2)]
            public string REC_MovLin_ProdId { get; set; }

            [DataMember(Order = 3)]
            public string REC_MovLin_ProdNam { get; set; }

            [DataMember(Order = 4)]
            public string REC_MovLin_UnMe { get; set; }

            [DataMember(Order = 5)]
            public string REC_MovLin_CantWMS { get; set; }

            [DataMember(Order = 6)]
            public string REC_MovLin_Estado { get; set; }

            [DataMember(Order = 7)]
            public long SOL_MovTpo { get; set; }

            [DataMember(Order = 8)]
            public long SOL_MovIden { get; set; }

            [DataMember(Order = 9)]
            public long SOL_MovLinId { get; set; }

            [DataMember(Order = 99)]

            public List<Det_Lote_ConfirmaRecepcionINET> LOTSER = new List<Det_Lote_ConfirmaRecepcionINET>();
        }

        [DataContract]
        public class Det_Lote_ConfirmaRecepcionINET
        {
            [DataMember(Order = 1)]
            public string REC_MovLinLSNum { get; set; }

            [DataMember(Order = 2)]
            public string REC_MovLinLSDes { get; set; }

            [DataMember(Order = 3)]
            public DateTime REC_MovLinLSFVig { get; set; }

            [DataMember(Order = 4)]
            public DateTime REC_MovLinLSFVen { get; set; }

            [DataMember(Order = 5)]
            public decimal REC_MovLinLSCant { get; set; }

            [DataMember(Order = 6)]
            public string REC_MovLinLSIndi { get; set; }

            [DataMember(Order = 7)]
            public string REC_MovLinLSIUbic { get; set; }

            [DataMember(Order = 99)]

            public List<Det_Lote_Ubi_ConfirmaRecepcionINET> LOTSERUBI = new List<Det_Lote_Ubi_ConfirmaRecepcionINET>();
        }
        public class Det_Lote_Ubi_ConfirmaRecepcionINET
        {
            public string REC_MovLinLotUbic { get; set; }
            public decimal REC_MovLinLotCant { get; set; }
        }
        public partial class Cab_SolicitudINET
        {
            public Cab2_SolicitudINET SDTSolicitud { get; set; }
        }

        [DataContract]
        public class Cab2_SolicitudINET
        {
            [DataMember(Order = 1)]
            public long SOL_MovTpo { get; set; }

            [DataMember(Order = 2)]
            public string SOL_MovNumRef { get; set; }

            [DataMember(Order = 3)]
            public DateTime SOL_MovFecRef { get; set; }

            [DataMember(Order = 4)]
            public long SOL_MovTipRef { get; set; }

            [DataMember(Order = 5)]
            public long SOL_MovRutRef { get; set; }

            [DataMember(Order = 6)]
            public string SOL_MovRutDig { get; set; }

            [DataMember(Order = 7)]
            public long SOL_MovRutSec { get; set; }

            [DataMember(Order = 8)]
            public string SOL_MovNomRef { get; set; }

            [DataMember(Order = 9)]
            public string SOL_MovDirRef { get; set; }

            [DataMember(Order = 10)]
            public string SOL_MovCiuRef { get; set; }

            [DataMember(Order = 11)]
            public string SOL_MovComRef { get; set; }

            [DataMember(Order = 12)]
            public string SOL_MovRegRef { get; set; }

            [DataMember(Order = 13)]
            public string SOL_MovTelRef { get; set; }

            [DataMember(Order = 14)]
            public string SOL_MovMaiRef { get; set; }

            [DataMember(Order = 15)]
            public string SOL_MovNomCon { get; set; }

            [DataMember(Order = 16)]
            public decimal SOL_MovTca { get; set; }

            [DataMember(Order = 17)]
            public long SOL_MovMonCod { get; set; }

            [DataMember(Order = 18)]
            public long SOL_MovIdenWMS { get; set; }

            [DataMember(Order = 19)]
            public string SOL_MovRefWMSTipDoc { get; set; }

            [DataMember(Order = 20)]
            public string SOL_MovBodDes { get; set; }

            [DataMember(Order = 21)]
            public string SOL_MovBodOri { get; set; }

            [DataMember(Order = 99)]

            public List<Det_SolicitudINET> SolDetalle = new List<Det_SolicitudINET>();
        }

        [DataContract]
        public class Det_SolicitudINET
        {
            [DataMember(Order = 1)]
            public long SOL_MovLinId { get; set; }

            [DataMember(Order = 2)]
            public string SOL_MovLin_ProdId { get; set; }

            [DataMember(Order = 3)]
            public string SOL_MovLin_ProdNam { get; set; }

            [DataMember(Order = 4)]
            public string SOL_MovLin_UnMe { get; set; }

            [DataMember(Order = 5)]
            public string SOL_MovLin_ReqAdi { get; set; }

            [DataMember(Order = 6)]
            public decimal SOL_MovLin_CantWMS { get; set; }

            [DataMember(Order = 7)]
            public decimal SOL_MovLin_PreWMS { get; set; }

            [DataMember(Order = 8)]
            public decimal SOL_MovLin_Centro { get; set; }

            [DataMember(Order = 99)]

            public List<Det_Lote_SolicitudINET> SOLLOTESERIE = new List<Det_Lote_SolicitudINET>(); 
        }

        [DataContract]
        public class Det_Lote_SolicitudINET
        {
            [DataMember(Order = 1)]
            public string SOL_MovLinLSNum { get; set; }

            [DataMember(Order = 2)]
            public string SOL_MovLinLSDes { get; set; }

            [DataMember(Order = 3)]
            public DateTime SOL_MovLinLSFVig { get; set; }

            [DataMember(Order = 4)]
            public DateTime SOL_MovLinLSFVen { get; set; }

            [DataMember(Order = 5)]
            public decimal SOL_MovLinLSCant { get; set; }

            [DataMember(Order = 6)]
            public string SOL_MovLinLSIndi { get; set; }

            [DataMember(Order = 7)]
            public string SOL_MovLinLSIUbic { get; set; }

            [DataMember(Order = 99)]

            public List<Det_Lote_Ubi_SolicitudINET> SOLLOTEUBI = new List<Det_Lote_Ubi_SolicitudINET>();
        }
        public class Det_Lote_Ubi_SolicitudINET
        {
            public decimal SOL_MovLinLotCant { get; set; }
            public string SOL_MovLinLotUbic { get; set; }
        }

        //-----------------------------------------------------------

        [DataContract]
        public partial class Cab_Confirmacion_SDR
        {
            [DataMember(Order = 1)]
            public long count { get; set; }

            [DataMember(Order = 2)]
            public bool resultado { get; set; }

            [DataMember(Order = 3)]
            public string resultado_descripcion { get; set; }

            [DataMember(Order = 4)]
            public long resultado_codigo { get; set; }

            [DataMember(Order = 5)]
            public long limit { get; set; }

            [DataMember(Order = 6)]
            public long rowset { get; set; }

            [DataMember(Order = 99)]
            public List<Cab2_Confirmacion_SDR> cabeceras = new List<Cab2_Confirmacion_SDR>();
        }

        [DataContract]
        public partial class Cab2_Confirmacion_SDR
        {
            [DataMember(Order = 1)]
            public int Id { get; set; }

            [DataMember(Order = 2)]
            public Nullable<int> RecepcionId { get; set; }

            [DataMember(Order = 3)]
            public string INT_NAME { get; set; }

            [DataMember(Order = 4)]
            public string FECHA_HORA { get; set; }

            [DataMember(Order = 5)]
            public long SolRecepId { get; set; }

            [DataMember(Order = 6)]
            public string FechaProceso { get; set; }

            [DataMember(Order = 7)]
            public string TipoDocumento { get; set; }

            [DataMember(Order = 8)]
            public string NumeroDocto { get; set; }

            [DataMember(Order = 9)]
            public string FechaDocto { get; set; }

            [DataMember(Order = 10)]
            public string TipoReferencia { get; set; }

            [DataMember(Order = 11)]
            public string NumeroReferencia { get; set; }

            [DataMember(Order = 12)]
            public string FechaReferencia { get; set; }

            [DataMember(Order = 13)]
            public string RutProveedor { get; set; }

            [DataMember(Order = 14)]
            public string GlosaRdm { get; set; }

            [DataMember(Order = 15)]
            public int TipoSolicitud { get; set; }

            [DataMember(Order = 99)]
            public List<Det_Confirmacion_SDR> items = new List<Det_Confirmacion_SDR>();
        }
        public partial class Det_Confirmacion_SDR
        {
            public int Linea { get; set; }
            public string CodigoArticulo { get; set; }
            public string CodigoOriginal { get; set; }
            public string UnidadCompra { get; set; }
            public decimal CantidadSolicitada { get; set; }
            public int ItemReferencia { get; set; }
            public string LoteSerie { get; set; }
            public string FechaVencto { get; set; }
            public decimal CantidadRecibida { get; set; }
            public long HuId { get; set; }
            public int Estado { get; set; }
        }

        [DataContract]
        public partial class Cab_Confirmacion_SDD
        {
            [DataMember(Order = 1)]
            public long count { get; set; }

            [DataMember(Order = 2)]
            public bool resultado { get; set; }

            [DataMember(Order = 3)]
            public string resultado_descripcion { get; set; }

            [DataMember(Order = 4)]
            public long resultado_codigo { get; set; }

            [DataMember(Order = 5)]
            public long limit { get; set; }

            [DataMember(Order = 6)]
            public long rowset { get; set; }

            [DataMember(Order = 99)]
            public List<Cab2_Confirmacion_SDD> cabeceras = new List<Cab2_Confirmacion_SDD>();
        }

        [DataContract]
        public partial class Cab2_Confirmacion_SDD
        {
            [DataMember(Order = 1)]
            public int Id { get; set; }

            [DataMember(Order = 2)]
            public Nullable<int> ColaPickId { get; set; }

            [DataMember(Order = 3)]
            public string INT_NAME { get; set; }

            [DataMember(Order = 4)]
            public string FECHA_HORA { get; set; }

            [DataMember(Order = 5)]
            public long SolDespId { get; set; }

            [DataMember(Order = 6)]
            public string FechaProceso { get; set; }

            [DataMember(Order = 7)]
            public int TipoDocumento { get; set; }

            [DataMember(Order = 8)]
            public string NumeroDocto { get; set; }

            [DataMember(Order = 9)]
            public string FechaDocto { get; set; }

            [DataMember(Order = 10)]
            public string TipoReferencia { get; set; }

            [DataMember(Order = 11)]
            public string NumeroReferencia { get; set; }

            [DataMember(Order = 12)]
            public string FechaReferencia { get; set; }

            [DataMember(Order = 13)]
            public string RutCliente { get; set; }

            [DataMember(Order = 14)]
            public int TipoSolicitud { get; set; }

            [DataMember(Order = 99)]
            public List<Det_Confirmacion_SDD> Items = new List<Det_Confirmacion_SDD>();
        }
        public partial class Det_Confirmacion_SDD
        {
            public int Linea { get; set; }
            public string CodigoArticulo { get; set; }
            public string CodigoOriginal { get; set; }
            public string UnidadVenta { get; set; }
            public decimal CantidadSolicitada { get; set; }
            public int ItemReferencia { get; set; }
            public string LoteSerieSol { get; set; }
            public string FecVenctoSol { get; set; }
            public decimal CantidadDespachada { get; set; }
            public string LoteSerieDesp { get; set; }
            public string FecVectoDesp { get; set; }
            public int Estado { get; set; }
        }

        public class ActualizaStockWoocomerceMasivo
        {
            [DataMember(Order = 1)]

            public List<Detalle_ActualizaStockWoocomerceMasivo> update = new List<Detalle_ActualizaStockWoocomerceMasivo>();
        }

        public class Detalle_ActualizaStockWoocomerceMasivo
        {
            [DataMember(Order = 1)]
            public long id { get; set; }

            [DataMember(Order = 2)]
            public decimal stock_quantity { get; set; }
        }

        //clase para BigCommerce

        //{
        //    "reason": "Monthly arrival delivered.",
        //    "items": [
        //                {
        //                    "location_id": 1,
        //                    "sku": "RE-130",
        //                    "quantity": 10
        //                }
        //            ]
        //}
        public class ActualizaStockBigCommerce
        {
            [DataMember(Order = 1)]
            public string reason { get; set; }

            [DataMember(Order = 99)]

            public List<Detalle_ActualizaStockBigCommerce> items = new List<Detalle_ActualizaStockBigCommerce>();
        }

        public class Detalle_ActualizaStockBigCommerce
        {
            [DataMember(Order = 1)]
            public int location_id { get; set; }

            [DataMember(Order = 2)]
            public string sku { get; set; }

            [DataMember(Order = 3)]
            public int quantity { get; set; }
        }


        #endregion

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && this.components != null)
        //    {
        //        this.components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        //private void InitializeComponent()
        //{
        //    base.CanPauseAndContinue = true;
        //    base.ServiceName = "WS-Itec2";
        //}f

        public Service1()
        {
            this.InitializeComponent();
            this.tmServicio1 = new Timer(double.Parse(ConfigurationManager.AppSettings["Timer"]));
            this.tmServicio1.Elapsed += new ElapsedEventHandler(this.tmServicio1_Elapsed);
        }
        protected override void OnStart(string[] args)
        {
            this.tmServicio1.Start();
        }
        protected override void OnStop()
        {
            this.tmServicio1.Stop();
        }

        //Evento principal que genera todos los procesos ------------------
        private void tmServicio1_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                this.tmServicio1.Stop();
                LogInfo("tmServicio1_Elapsed", "Inicio", true);

                if (ConfigurationManager.AppSettings["Activa_BSALE_Saldo"].ToString() == "True")
                {
                    //OfficeId_Baja_Saldos = ConfigurationManager.AppSettings["BSALE_OfficeId_Baja_Saldos"].ToString();

                    string[] Palabras = ConfigurationManager.AppSettings["BSALE_OfficeId_Baja_Saldos"].ToString().Trim().Split(',');
                    string OfficeId_Bodega = "";

                    for (int i = 0; i < Palabras.Length; i++)
                    {
                        OfficeId_Bodega = Palabras[i].Trim();

                        // 1 EXTRAE SALDO DE BSALE
                        BSALE_Saldo(OfficeId_Bodega);
                    }
                }

                if (ConfigurationManager.AppSettings["Activa_BSALE_ExtraeMaestraArticulos"].ToString() == "True")
                {
                    // 2 EXTRAE MAESTRA DE ARTICULOS
                    BSALE_ExtraeMaestraArticulos();
                }

                if (ConfigurationManager.AppSettings["Activa_ConsultaPedidosDoctoLegal"].ToString() == "True")
                {
                    // 3 Descarga documentos Venta desde BSALE
                    // Descarga documentos BSALE definidos en la config (BSALE_DocType). Baja documentos que no envió por WebHook

                    if (ConfigurationManager.AppSettings["BSALE_ReprocesaDoctos"].ToString() == "SI")
                    {
                        #region Codigo para reprocesar datos desde una fecha en adelante hasta el dia de hoy, descomentar si se necesita
                        DateTime fecha;
                        DateTime fechaFin;
                        string fechaUnix;

                        //fecha = new DateTime(2023, 6, 19);
                        //fechaFin = new DateTime(2023, 6, 20);

                        fecha = new DateTime(int.Parse(ConfigurationManager.AppSettings["BSALE_ReprocesaDoctosDesde"].ToString().Substring(6, 4)),
                                             int.Parse(ConfigurationManager.AppSettings["BSALE_ReprocesaDoctosDesde"].ToString().Substring(3, 2)),
                                             int.Parse(ConfigurationManager.AppSettings["BSALE_ReprocesaDoctosDesde"].ToString().Substring(0, 2)));

                        fechaFin = new DateTime(int.Parse(ConfigurationManager.AppSettings["BSALE_ReprocesaDoctosHasta"].ToString().Substring(6, 4)),
                                                int.Parse(ConfigurationManager.AppSettings["BSALE_ReprocesaDoctosHasta"].ToString().Substring(3, 2)),
                                                int.Parse(ConfigurationManager.AppSettings["BSALE_ReprocesaDoctosHasta"].ToString().Substring(0, 2)));

                        while (fecha <= fechaFin)
                        {
                            LogInfo("ConsultaPedidosDoctoLegal", "===== DESCARGANDO FECHA:" + fecha.ToString("dd/MM/yyyy"));
                            fechaUnix = fecha.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString(); //convierte fecha a formato UNIX 

                            ConsultaPedidosDoctoLegal(fechaUnix);

                            fecha = fecha.AddDays(1);
                        }

                        //fecha = new DateTime(2023, 6, 11);

                        //LogInfo("ConsultaPedidosDoctoLegal", "===== DESCARGANDO FECHA:" + fecha.ToString("dd/MM/yyyy"));
                        //fechaUnix = fecha.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();

                        //ConsultaPedidosDoctoLegal(fechaUnix);

                        #endregion
                    }
                    else
                    {
                        ConsultaPedidosDoctoLegal(""); //parametro fecha en formato UNIX opcional
                    }
                   
                }

                if (ConfigurationManager.AppSettings["Activa_ConsultaPedidosDoctoLegal2"].ToString() == "True")
                {// 4 BSALE envia todos los documentos generados via WebHook hacia Getpoint por la API WebhookBsale y se guardan a la tabla L_WebhookBSale
                 //   Se leen los documentos desde la tabla y se lee el resto de sus datos desde las APIs de BSale para poder integrarlos como Pedidos
                    DescargaDoctosWebhook_BSALE(); 
                    
                    //ex ConsultaPedidosDoctoLegal2();
                }

                if (ConfigurationManager.AppSettings["Activa_RecepcionDoctoLegal"].ToString() == "True")
                {
                    // 5 Informa confirmaciones de Recepciones de Mercaderia de WMS a BSALE
                    RecepcionMercaderiaWMS_to_BSALE();
                }

                if (ConfigurationManager.AppSettings["Activa_RecepcionDoctoLegalSDD"].ToString() == "True")
                {
                    // 6 Informa confirmaciones de despachos de mercaderia de WMS a BSALE 
                    ConfirmaSDD_WMS_to_BSALE();
                }

                if (ConfigurationManager.AppSettings["Activa_ConfirmacionPickingEComm"].ToString() == "True")
                {
                    // 7 Informa a Woocommerce el termino de Picking
                    ConfirmacionPickingEComm();
                }

                if (ConfigurationManager.AppSettings["Activa_ActualizaStockEComm"].ToString() == "True")
                {
                    // 8 Actualiza stocks en Woocommerce 
                    ActualizaStockEComm();
                }

                if (ConfigurationManager.AppSettings["Activa_ConfirmacionRevision"].ToString() == "True")
                {
                    // 9 Confirma Revisión en Woocomerce, genera el Envio en Enviame y retorna la etiqueta
                    ConfirmacionRevision();
                }

                if (ConfigurationManager.AppSettings["Activa_CambiaEstadoSolicitudDespachoEcommerce"].ToString() == "True")
                {
                    // 10 Informa a Woocommerce los cambios de estado de la Solicitud de Despacho en WMS
                    CambiaEstadoSolicitudDespachoEcommerce();
                }

                if (ConfigurationManager.AppSettings["Activa_IntegraReubicacionesOffline"].ToString() == "True")
                {
                    // 11 Integra reubicaciones efectuadas de manera offline para FASTPACK
                    IntegraReubicacionesOffline();
                }

                if (ConfigurationManager.AppSettings["Activa_GeneraGuiaTrasladoBSale"].ToString() == "True")
                {
                    // 12 Genera Guias de Traslado en BSALE
                    GeneraGuiaTrasladoBSale();
                }

                if (ConfigurationManager.AppSettings["Activa_ObtieneTokenRipley"].ToString() == "True")
                {
                    // 13 Obtiene Token para llamar APIS de Ripley 
                    ObtieneTokenRipley();
                }

                if (ConfigurationManager.AppSettings["Activa_IntegraOrdenesRipley"].ToString() == "True")
                {
                    // 14 Integra Ordenes de Ripley a WMS
                    IntegraOrdenesRipley();
                }

                if (ConfigurationManager.AppSettings["Activa_GeneraEtiquetasRipley"].ToString() == "True")
                {
                    // 15 Genera Etiquetas de Ripley
                    GeneraEtiquetasRipley();
                }

                if (ConfigurationManager.AppSettings["Activa_DescargaEtiquetasRipley"].ToString() == "True")
                {
                    // 16 Descarga Etiquetas de Ripley
                    DescargaEtiquetasRipley();
                }

                if (ConfigurationManager.AppSettings["Activa_ConfirmacionRecepcionINET"].ToString() == "True")
                {
                    // 17 Servicio WEB integracion Confirmacion Recepcion INET - SIWMS_WSRecepcionConfirmacion

                    //ConfirmacionRecepcionINET("CONFIRMACION_RECEPCION_INET");
                    ConfirmacionRecepcionINET_RDM("CONFIRMACION_RECEPCION_INET");
                }

                if (ConfigurationManager.AppSettings["Activa_ConfirmacionDespachoINET"].ToString() == "True")
                {
                    // 18 Servicio WEB integracion Confirmacion Despacho INET - SIWMS_WSRecepcionConfirmacion
                    ConfirmacionRecepcionINET("CONFIRMACION_DESPACHO_INET");

                    //especial para VIGAFLOW, se enviaran algunas confirmaciones por ruta de test 
                    //ConfirmacionRecepcionINET("CONFIRMACION_DESPACHO_TEST_INET");
                }

                if (ConfigurationManager.AppSettings["Activa_GuiaTrasladoINET"].ToString() == "True")
                {
                    // 19 Servicio WEB integracion Solicitud INET - SIWMS_WSSolicitud 
                    SolicitudINET("GUIA_TRASLADO_INET");
                }

                if (ConfigurationManager.AppSettings["Activa_WebHook_INGRESO_COMPRAS"].ToString() == "True")
                {
                    // 20 WebHook SIKSA, INGRESO_COMPRAS
                    ConfirmacionIngresoWebHook("INGRESO_COMPRAS");
                }

                if (ConfigurationManager.AppSettings["Activa_WebHook_INGRESO_TRASLADO"].ToString() == "True")
                {
                    // 21 WebHook SIKSA, INGRESO_TRASLADO
                    ConfirmacionIngresoWebHook("INGRESO_TRASLADO");
                }

                if (ConfigurationManager.AppSettings["Activa_WebHook_INGRESO_TRASLADO_CENTRO"].ToString() == "True")
                {
                    // 22 WebHook SIKSA, INGRESO_TRASLADO_CENTRO
                    ConfirmacionIngresoWebHook("INGRESO_TRASLADO_CENTRO");
                }

                if (ConfigurationManager.AppSettings["Activa_WebHook_NOTIFICACION_OF"].ToString() == "True")
                {
                    // 23 WebHook SIKSA, NOTIFICACION_OF
                    ConfirmacionIngresoWebHook("NOTIFICACION_OF");
                }

                if (ConfigurationManager.AppSettings["Activa_WebHook_SALIDA_VENTA"].ToString() == "True")
                {
                    // 24 WebHook SIKSA, SALIDA_VENTA
                    ConfirmacionSalidaWebHook("SALIDA_VENTA");
                }

                if (ConfigurationManager.AppSettings["Activa_WebHook_SALIDA_TRASLADO"].ToString() == "True")
                {
                    // 25 WebHook SIKSA, SALIDA_TRASLADO
                    ConfirmacionSalidaWebHook("SALIDA_TRASLADO");
                }

                if (ConfigurationManager.AppSettings["Activa_WebHook_CONSUMO_INTERNO"].ToString() == "True")
                {
                    // 26 WebHook SIKSA, CONSUMO_INTERNO
                    ConfirmacionSalidaWebHook("CONSUMO_INTERNO");
                }

                if (ConfigurationManager.AppSettings["Activa_ActualizaStockEComm_BigCommerce"].ToString() == "True")
                {
                    // 27 Actualiza stocks en BigCommerce - actualizacion masiva por SKU
                    ActualizaStockEComm_BigCommerce();
                }                

                this.tmServicio1.Start();
            }
            catch (Exception ex)
            {
                LogInfo("WS_Integrador_GP_BSALE", "Error en tmServicio1_Elapsed: " + ex.Message.Trim() + ". Se reinicia el servicio de integracion.", true);

                Environment.Exit(1); //reinicia el servicio 
            }
        }

        //Descarga Saldos desde BSale ----------
        public static bool BSALE_Saldo(string OfficeId_Baja_Saldos)
        {
            LogInfo("BSALE_Saldo", "Inicio proceso");

            int hora = DateTime.Now.Hour;
            int minuto = DateTime.Now.Minute;
            //if (hora == 23 && minuto >= 50 )
            //{

            string resultado = WS_Integrador.Classes.model.InfF_Generador.ValEjecutaProceso("INT-SALDOS-NOCTURNO;" + OfficeId_Baja_Saldos.Trim());

            if (resultado == "0")
            {
                LogInfo("BSALE_Saldo", "No es horario de procesar. FIN proceso");
                return false;
            }

            LogInfo("BSALE_Saldo", "Esta en horario de procesar, continua proceso SALDOS");

            //string OfficeId_Baja_Saldos;
            //OfficeId_Baja_Saldos = ConfigurationManager.AppSettings["BSALE_OfficeId_Baja_Saldos"].ToString();

            string url = "https://api.bsale.cl/v1/stocks.json?officeid=" + OfficeId_Baja_Saldos.Trim();

            string token = ConfigurationManager.AppSettings["TokenBsale"].ToString();
            string s = "";
            string linea = "";
            string linea0 = "";
            int Count = 0;
            int limit = 0;
            int offset = 0; //variantcount = 0;

            s = EjecutaAPI_BSale(url, token, 0, "BSALE_Saldo");

            dynamic json = JsonConvert.DeserializeObject(s);
            JObject rss = JObject.Parse(s);

            Count = (Int32)rss["count"];
            limit = (Int32)rss["limit"];
            offset = (Int32)rss["offset"];
            var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));

            //var total = 0;
            //var k = 1;

            for (Int32 w = 0; w < veces; w++)
            {
                if (w > 0)
                {
                    s = EjecutaAPI_BSale(url, token, offset, "BSALE_Saldo");

                    //Func.log(s);
                    json = JsonConvert.DeserializeObject(s);
                    rss = JObject.Parse(s);
                }

                for (Int32 i = 0; i < rss["items"].Count(); i++)
                {
                    //Si trae cantidades negativas no lo incluye en la carga de Saldos porque da error ----
                    if (int.Parse(rss["items"][i]["quantity"].ToString()) >= 0 &&
                        int.Parse(rss["items"][i]["quantityReserved"].ToString()) >= 0 &&
                        int.Parse(rss["items"][i]["quantityAvailable"].ToString()) >= 0)
                    {
                        linea = "INT-SALDOS-NOCTURNO";
                        linea += ";" + rss["items"][i]["id"].ToString(); //productid
                        linea += ";" + rss["items"][i]["variant"]["id"].ToString(); //variantid
                        linea += ";" + rss["items"][i]["quantity"].ToString(); //quantity
                        linea += ";" + rss["items"][i]["quantityReserved"].ToString(); //quantity
                        linea += ";" + rss["items"][i]["quantityAvailable"].ToString(); //quantity
                        linea += ";" + OfficeId_Baja_Saldos.Trim();

                        linea0 += linea + System.Environment.NewLine;
                    }
                    else
                    {
                        LogInfo("BSALE_Saldo", @"El producto id:" + rss["items"][i]["id"].ToString().Trim() +
                                               @", variante:" +
                                               rss["items"][i]["variant"]["id"].ToString().Trim() +
                                               @", tiene cantidades negativas");
                    }
                }

                offset = offset + limit;
            }

            Integracion p = new Integracion();
            string URL = "";
            string NombreArchivo = "";

            NombreArchivo = "Saldo_Bsale_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";

            p = new Integracion
            {
                Key = "2121",
                EmpId = "1",
                Archivo = NombreArchivo,
                TXT = linea0,
            };

            var DATA = JsonConvert.SerializeObject(p);
            //para llamado de ws
            URL = ConfigurationManager.AppSettings["URL_API"].ToString() + "/api/INTEGRACIONES/CREAR";
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.Timeout = TimeSpan.FromMinutes(5);
            client.BaseAddress = new System.Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //Begin 2: Parametros para Header
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("X-GPOINT-API-TOKEN", ConfigurationManager.AppSettings["TOKEN_API"].ToString());
            client.DefaultRequestHeaders.TryAddWithoutValidation("X-GPOINT-API-SECRET", ConfigurationManager.AppSettings["SECRET_API"].ToString());

            System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");

            LogInfo("BSALE_Saldo", DATA);

            try
            {
                HttpResponseMessage messge = client.PostAsync(URL, content).Result;

                LogInfo("BSALE_Saldo", "despues del llamado API");

                if (messge.IsSuccessStatusCode)
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    string mensaje1 = "Ocurrio el siguiente error: " + respuesta;

                    LogInfo("BSALE_Saldo", mensaje1, true);
                }

                content.Dispose();
                client.Dispose();
            }

            catch (Exception ex1)
            {
                string mensaje1 = "Ocurrio el siguiente error: " + ex1.Message;

                LogInfo("BSALE_Saldo", mensaje1, true);
            }
            //}
            return true;
        }

        //Informa las solicitudes de despacho confirmadas en WMS a BSALE
        private void ConfirmaSDD_WMS_to_BSALE()
        {
            string stNumeroReferencia = "",
                   ColaPickId = "",
                   mensaje1 = "",
                   stTipoReferencia = "",
                   stColaPicking = "",
                   stSolDespId = "";

            string URL = "",
                   result = "",
                   result2 = "";

            //TipoRef = "", NumRef = "", note = "";
            //string SolDespId = "", ColaPickId = "", EmpId = "", NumeroReferencia = ""; 

            string documentTypeId = "",
                   emissionDate = "",
                   shippingTypeId = "",
                   municipality = "",
                   city = "",
                   address = "",
                   declareSii = "",
                   recipient = "",
                   code = "",
                   activity = "",
                   company = "",
                   email = ""; //,detailId="", quantity=""
                               //string detalle = "";

            DateTime _date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Int32 unixTimestamp = (Int32)(_date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            int officeId = 1; //por defecto 
            var model_DATA = new Object();
            var DATA2 = "";

            DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_SDD();

            if (myDataSet.Tables[0].Rows.Count <= 0)
            {
                return; //Si no hay SDD que procesar sale del proceso
            }

            List<detailsConsumo> details = new List<detailsConsumo>();

            //Recorre SDD confirmadas -----------------------------------------
            for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
            {
                //Cuando cambie de Numero Referencia -----------------
                if ((myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() != stNumeroReferencia) & (stNumeroReferencia != ""))
                {
                    DATA2 = JsonConvert.SerializeObject(model_DATA);
                    //para llamado de ws
                    URL = "https://api.bsale.cl/v1/shippings.json";
                    System.Net.Http.HttpClient client2 = new System.Net.Http.HttpClient();
                    client2.BaseAddress = new System.Uri(URL);
                    client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //Begin 2: Parametros para Header
                    client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    client2.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                    System.Net.Http.HttpContent content2 = new StringContent(DATA2, UTF8Encoding.UTF8, "application/json");

                    try
                    {
                        mensaje1 = "Ejecutara Integración SDD confirmada, NumeroReferencia: " + stNumeroReferencia;
                        LogInfo("RecepcionDoctoLegalSDD", mensaje1);

                        HttpResponseMessage messge = client2.PostAsync(URL, content2).Result;

                        if (messge.IsSuccessStatusCode)
                        {
                            mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Integración SDD confirmada Exitosa";
                            LogInfo("RecepcionDoctoLegalSDD", mensaje1);

                            string respuesta = messge.Content.ReadAsStringAsync().Result;
                            RespGuiaIntegracion respGuia = JsonConvert.DeserializeObject<RespGuiaIntegracion>(respuesta);
                            
                            string guideRef = respGuia.guide.href.Trim();

                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP("", 
                                                                                                   "0",
                                                                                                   ColaPickId, 
                                                                                                   guideRef);
                        }
                        else
                        {
                            string respuesta = messge.Content.ReadAsStringAsync().Result;
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaPickingRechazado("", 
                                                                                                          ColaPickId);

                            //para guardar el error de BSALE -------
                            result2 = WS_Integrador.Classes.model.InfF_Generador.GuardaPickingErrorBSALE(ColaPickId, 
                                                                                                         respuesta.Trim());

                            mensaje1 = "Integración SDD confirmada Fallida : " + respuesta.Trim() +
                                       ". TipoReferencia: " + stTipoReferencia.Trim() +
                                       ", NumeroReferencia: " + stNumeroReferencia.Trim() +
                                       ", ColaPicking: " + stColaPicking.Trim() +
                                       ", SolDespId: " + stSolDespId.Trim();

                            LogInfo("RecepcionDoctoLegalSDD", mensaje1, true);
                            LogInfo("RecepcionDoctoLegalSDD", "JSON: " + DATA2);
                        }
                        content2.Dispose();
                        client2.Dispose();
                    }
                    catch (Exception ex1)
                    {
                        string mensajeError = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error" + ex1.Message;
                        // this.EscribeLog(mensaje1);
                    }
                }

                //Si cambio de SDR genera nuevo archivo
                //if (stNumeroReferencia != "" /*(myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() != stNumeroReferencia) & (stNumeroReferencia != "")*/)

                ColaPickId = myDataSet.Tables[0].Rows[i]["ColaPickId"].ToString().Trim();
                officeId = int.Parse(myDataSet.Tables[0].Rows[i]["officeId"].ToString().Trim());
                documentTypeId = myDataSet.Tables[0].Rows[i]["documentTypeId"].ToString().Trim();
                emissionDate = myDataSet.Tables[0].Rows[i]["emissionDate"].ToString().Trim();
                shippingTypeId = myDataSet.Tables[0].Rows[i]["shippingTypeId"].ToString().Trim();
                municipality = myDataSet.Tables[0].Rows[i]["municipality"].ToString().Trim();
                city = myDataSet.Tables[0].Rows[i]["city"].ToString().Trim();
                address = myDataSet.Tables[0].Rows[i]["address"].ToString().Trim();
                declareSii = myDataSet.Tables[0].Rows[i]["declareSii"].ToString().Trim();
                recipient = myDataSet.Tables[0].Rows[i]["recipient"].ToString().Trim();
                code = myDataSet.Tables[0].Rows[i]["code"].ToString().Trim();
                activity = myDataSet.Tables[0].Rows[i]["activity"].ToString().Trim();
                company = myDataSet.Tables[0].Rows[i]["company"].ToString().Trim();
                email = myDataSet.Tables[0].Rows[i]["email"].ToString().Trim();

                var cliente = new
                {
                    code = code,
                    municipality = municipality,
                    activity = activity,
                    company = company,
                    city = city,
                    email = email,
                    address = address,
                };

                stNumeroReferencia = myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();
                stTipoReferencia = myDataSet.Tables[0].Rows[i]["TipoReferencia"].ToString().Trim();
                stColaPicking = myDataSet.Tables[0].Rows[i]["ColaPickId"].ToString().Trim();
                stSolDespId = myDataSet.Tables[0].Rows[i]["SolDespId"].ToString().Trim();

                details = new List<detailsConsumo>();

                for (int item = 0; item < myDataSet.Tables[0].Rows.Count; item++)
                {
                    if (myDataSet.Tables[0].Rows[item]["NumeroReferencia"].ToString().Trim() == stNumeroReferencia)
                    {
                        detailsConsumo myDetalleSDD = new detailsConsumo();
                        myDetalleSDD.quantity = int.Parse(myDataSet.Tables[0].Rows[item]["quantity"].ToString().Trim());
                        myDetalleSDD.detailId = myDataSet.Tables[0].Rows[item]["detailId"].ToString().Trim();
                        details.Add(myDetalleSDD);
                    }
                }

                model_DATA = new
                {
                    documentTypeId = documentTypeId,
                    officeId = officeId,
                    emissionDate = unixTimestamp.ToString(),
                    shippingTypeId = shippingTypeId,
                    municipality = municipality,
                    city = city,
                    address = address,
                    declareSii = declareSii,
                    recipient = recipient,
                    details,
                    client = cliente,
                };
            } //FIN ciclo 

            DATA2 = JsonConvert.SerializeObject(model_DATA);
            //para llamado de ws
            URL = "https://api.bsale.cl/v1/shippings.json";
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //Begin 2: Parametros para Header
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

            System.Net.Http.HttpContent content = new StringContent(DATA2, UTF8Encoding.UTF8, "application/json");

            try
            {
                mensaje1 = "Ejecutara Integración SDD confirmada, NumeroReferencia: " + stNumeroReferencia;
                LogInfo("RecepcionDoctoLegalSDD", mensaje1);

                HttpResponseMessage messge = client.PostAsync(URL, content).Result;

                if (messge.IsSuccessStatusCode)
                {
                    mensaje1 = "Integración SDD confirmada Exitosa";
                    LogInfo("RecepcionDoctoLegalSDD", mensaje1);

                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    RespGuiaIntegracion respGuia = JsonConvert.DeserializeObject<RespGuiaIntegracion>(respuesta);

                    string guideRef = respGuia.guide.href.Trim();
                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP("", 
                                                                                           "0", 
                                                                                           ColaPickId, 
                                                                                           guideRef);
                }
                else
                {
                    result = "";
                    result2 = "";

                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaPickingRechazado("",
                                                                                                  ColaPickId);

                    //para guardar el error de BSALE -------
                    result2 = WS_Integrador.Classes.model.InfF_Generador.GuardaPickingErrorBSALE(ColaPickId,
                                                                                                 respuesta.Trim());
                    mensaje1 = "Integración SDD confirmada Fallida: " + respuesta.Trim() +
                               ". TipoReferencia: " + stTipoReferencia.Trim() +
                               ", NumeroReferencia: " + stNumeroReferencia.Trim() +
                               ", ColaPicking: " + stColaPicking.Trim() +
                               ", SolDespId: " + stSolDespId.Trim();

                    LogInfo("RecepcionDoctoLegalSDD", mensaje1, true);
                    LogInfo("RecepcionDoctoLegalSDD", "JSON Enviado:" + DATA2.Trim(), true);
                }
                content.Dispose();
                client.Dispose();
            }
            catch (Exception ex1)
            {
                string mensajeError = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error" + ex1.Message;
                // this.EscribeLog(mensaje1);
                LogInfo("RecepcionDoctoLegalSDD", mensajeError, true);
            }
        }

        //Informa a BSALE las recepciones de mercaderia confirmadas en WMS
        private void RecepcionMercaderiaWMS_to_BSALE()
        {
            string stNumeroReferencia = "";
            string stIdDocto = "";
            string mensaje1 = "";
            string URL = "";
            string result = "";
            string TipoRef = "";
            string NumRef = "";
            string note = "";
            //string detalle = "";
            int officeId = 1;

            DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_SRD();
            if (myDataSet.Tables[0].Rows.Count <= 0)
            {
                return;
            }

            //Reception p = new Reception();
            List<details> details = new List<details>();

            for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
            {
                //Empresa = myDataSet.Tables[0].Rows[i]["Empresa"].ToString().Trim();


                //Si cambio de SDR genera nuevo archivo
                if ((myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() != stNumeroReferencia) & (stNumeroReferencia != ""))
                {
                    TipoRef = myDataSet.Tables[0].Rows[i]["TipoReferencia"].ToString().Trim();
                    NumRef = myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();

                    note = myDataSet.Tables[0].Rows[i]["Nota"].ToString().Trim();
                    officeId = int.Parse(myDataSet.Tables[0].Rows[i]["officeId"].ToString().Trim());

                    stIdDocto = myDataSet.Tables[0].Rows[i]["RecepcionId"].ToString().Trim();

                    //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP(BD_GETPOINT, stIdDocto);

                    //ENVIAR  A LA API 

                    var model_DATA = new
                    {
                        document = TipoRef,
                        officeId = officeId,
                        documentNumber = NumRef,
                        note = note,
                        details
                    };
                    details = new List<details>();

                    //string DATA2 = new JavaScriptSerializer().Serialize(p);
                    var DATA2 = JsonConvert.SerializeObject(model_DATA);
                    //para llamado de ws
                    URL = "https://api.bsale.cl/v1/stocks/receptions.json";
                    System.Net.Http.HttpClient client2 = new System.Net.Http.HttpClient();
                    client2.BaseAddress = new System.Uri(URL);
                    client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //Begin 2: Parametros para Header
                    client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    client2.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());
                    //client2.DefaultRequestHeaders.TryAddWithoutValidation("target", "beta"); //prueba fabian

                    System.Net.Http.HttpContent content2 = new StringContent(DATA2, UTF8Encoding.UTF8, "application/json");

                    try
                    {
                        mensaje1 = "Ejecutara Integración SDR, NumeroReferencia: " + stNumeroReferencia;
                        LogInfo("RecepcionMercaderiaWMS_to_BSALE", mensaje1);

                        HttpResponseMessage messge = client2.PostAsync(URL, content2).Result;

                        if (messge.IsSuccessStatusCode)
                        {
                            mensaje1 = "Integración SDR Exitosa";
                            LogInfo("RecepcionMercaderiaWMS_to_BSALE", mensaje1);

                            string respuesta = messge.Content.ReadAsStringAsync().Result;
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP("", 
                                                                                                   stIdDocto, 
                                                                                                   "0", 
                                                                                                   "");
                        }
                        else
                        {
                            string respuesta = messge.Content.ReadAsStringAsync().Result;

                            mensaje1 = "Integración SDR Fallida : " + respuesta.Trim();
                            LogInfo("RecepcionMercaderiaWMS_to_BSALE", mensaje1);
                        }
                        content2.Dispose();
                        client2.Dispose();
                    }

                    catch (Exception ex1)
                    {
                        string mensajeError = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error" + ex1.Message;
                        // this.EscribeLog(mensaje1);

                    }
                    //ENVIAR  A LA API                     
                }

                stNumeroReferencia = myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();
                TipoRef = myDataSet.Tables[0].Rows[i]["TipoReferencia"].ToString().Trim();
                NumRef = myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();
                note = myDataSet.Tables[0].Rows[i]["Nota"].ToString().Trim();
                officeId = int.Parse(myDataSet.Tables[0].Rows[i]["officeId"].ToString().Trim());
                stIdDocto = myDataSet.Tables[0].Rows[i]["RecepcionId"].ToString().Trim();

                details myDetalle = new details();
                myDetalle.quantity = int.Parse(myDataSet.Tables[0].Rows[i]["Cantidad"].ToString().Trim());
                myDetalle.variantId = int.Parse(myDataSet.Tables[0].Rows[i]["IdVariante"].ToString().Trim());
                //myDetalle.serialNumber = myDataSet.Tables[0].Rows[i]["NumeroSerie"].ToString().Trim(); //prueba fabian
                myDetalle.cost = int.Parse(myDataSet.Tables[0].Rows[i]["Costo"].ToString().Trim());
                details.Add(myDetalle);

                /*CREAR DETALLLE DE LA INTEGRACION*/
            }

            var model_DATA2 = new
            {
                document = TipoRef,
                officeId = officeId,
                documentNumber = NumRef,
                note = note,
                details
            };

            var DATA = JsonConvert.SerializeObject(model_DATA2);
            URL = "https://api.bsale.cl/v1/stocks/receptions.json";
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //Begin 2: Parametros para Header
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());
            //client.DefaultRequestHeaders.TryAddWithoutValidation("target", "beta"); //prueba fabian

            System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");

            try
            {
                mensaje1 = "Integración2 SDR, NumeroReferencia: " + stNumeroReferencia;
                LogInfo("RecepcionMercaderiaWMS_to_BSALE", mensaje1);

                HttpResponseMessage messge = client.PostAsync(URL, content).Result;

                if (messge.IsSuccessStatusCode)
                {
                    mensaje1 = "Integración2 SDR Exitosa";
                    LogInfo("RecepcionMercaderiaWMS_to_BSALE", mensaje1);

                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP("", stIdDocto, "0", "");

                }
                else
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    mensaje1 = "Integración2 SDR Fallida: " + respuesta.Trim();
                    LogInfo("RecepcionMercaderiaWMS_to_BSALE", mensaje1, true);
                }
                content.Dispose();
                client.Dispose();
            }

            catch (Exception ex1)
            {
                string mensajeError = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error" + ex1.Message;
                // this.EscribeLog(mensaje1);
            }

            mensaje1 = "Termina Proceso RecepcionDoctoLegal";
            LogInfo("RecepcionMercaderiaWMS_to_BSALE", mensaje1);
        }

        //Descarga Productos desde BSale
        public static bool BSALE_ExtraeMaestraArticulos()
        {
            LogInfo("BSALE_ExtraeMaestraArticulos", "Inicio Proceso", true);

            try
            {
                string stEmpId = ConfigurationManager.AppSettings["EmpId"].ToString();

                string stArchivo = "";
                string stUserName = "";
                string stFechaProcesoInt = "";
                string result = "";

                //string sqlQuery = "";
                int stLinea = 0;
                int ContadorProductos = 1;

                string Datos = "";
                string Resultado = "";
                string SeparadorCampo = "¬"; //alt 170
                string SeparadorLinea = "«"; //alt 174

                int CantidadRegistrosInsercion = int.Parse(ConfigurationManager.AppSettings["CantidadRegistrosInsercion"].ToString());

                #region Declaracion Variables de Textos
                string stTexto1 = "";
                string stTexto2 = "";
                string stTexto3 = "";
                string stTexto4 = "";
                string stTexto5 = "";
                string stTexto6 = "";
                string stTexto7 = "";
                string stTexto8 = "";
                string stTexto9 = "";
                string stTexto10 = "";
                string stTexto11 = "";
                string stTexto12 = "";
                string stTexto13 = "";
                string stTexto14 = "";
                string stTexto15 = "";
                string stTexto16 = "";
                string stTexto17 = "";
                string stTexto18 = "";
                string stTexto19 = "";
                string stTexto20 = "";
                string stTexto21 = "";
                string stTexto22 = "";
                string stTexto23 = "";
                string stTexto24 = "";
                string stTexto25 = "";
                string stTexto26 = "";
                string stTexto27 = "";
                string stTexto28 = "";
                string stTexto29 = "";
                string stTexto30 = "";
                string stTexto31 = "";
                string stTexto32 = "";

                string stdecripArt = "";
                #endregion

                result = WS_Integrador.Classes.model.InfF_Generador.ValEjecutaProceso("INT-ARTICULOS");
                if (result == "0")
                {
                    LogInfo("BSALE_ExtraeMaestraArticulos", "No es hora de ejecutar, sale del proceso");
                    return false;
                }

                LogInfo("BSALE_ExtraeMaestraArticulos", "Es hora de descargar maestro de productos (" + DateTime.Now.Hour.ToString().Trim() + " hrs), continua ejecucion del proceso >>>");

                string url = "https://api.bsale.cl/v1/products.json?&expand=[variants,pack_details,attribute_values,attributes,product_type]&state=0";
                string token = ConfigurationManager.AppSettings["TokenBsale"].ToString();   //"4ea9ab77ab57a01ecc18e4591b9efe68c4d461e5";
                string s = "";
                string linea = "";
                string linea0 = "";
                int Count = 0;
                int limit = 0;
                int offset = 0;
                int variantcount = 0;
                int offsetvariant = 0;
                int limitvariant = 0;
                int Countvariant = 0;
                int variantKit = 0;
                string s2 = "";
                string s3 = "";
                int Atribucount = 0;
                string idattribute = "";
                string nameattribute = "";
                int CountattributeV = 0;
                int limitattributeV = 0;
                int offsetattributeV = 0;

                stArchivo = "BSALE_SKU_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                stUserName = "Integrado_BSALE";
                stFechaProcesoInt = DateTime.Now.ToString("yyyyMMdd");

                LogInfo("BSALE_ExtraeMaestraArticulos", "Antes primer llamado API");

                s = EjecutaAPI_BSale(url, token, 0, "BSALE_ExtraeMaestraArticulos");

                LogInfo("BSALE_ExtraeMaestraArticulos", "Despues de primer llamado API"); //, cantidad productos: " + Count.ToString());

                dynamic json = JsonConvert.DeserializeObject(s);
                JObject rss = JObject.Parse(s);

                Count = (Int32)rss["count"];
                limit = (Int32)rss["limit"];
                offset = (Int32)rss["offset"];
                var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));

                //var total = 0;
                //var k = 1;

                LogInfo("BSALE_ExtraeMaestraArticulos", "Total de Elementos: " + Count.ToString());

                //Ciclo que recorre cantidad de paginas de datos leidos -----
                for (Int32 w = 0; w < veces; w++)
                {
                    if (w > 0)
                    {
                        s = EjecutaAPI_BSale(url, token, offset, "BSALE_ExtraeMaestraArticulos");

                        //Func.log(s);

                        if (s.Trim() != "")
                        {
                            json = JsonConvert.DeserializeObject(s);
                            rss = JObject.Parse(s);
                        }
                    }

                    //----------------------------------------------------------------------------------------------------------------------------------------------
                    //Si la ultima lectura a BSALE retornó datos sigue procesando, sino hace una PAUSA de 10 segundos a la espera que el servicio de BSale responda
                    //----------------------------------------------------------------------------------------------------------------------------------------------
                    if (s.Trim() != "")
                    {
                        //Ciclo que recorre la pagina de Articulos -----
                        for (Int32 i = 0; i < rss["items"].Count(); i++)
                        {
                            ContadorProductos = ContadorProductos + 1; //contador de productos padre leidos (no las variedades)

                            LogInfo("BSALE_ExtraeMaestraArticulos", "Procesando posicion: " + ContadorProductos.ToString() + " (offset:" + offset.ToString() + ", limit:" + limit.ToString() + ", item:" + i.ToString() + ")");

                            try
                            {
                                if (rss["items"][i]["state"].ToString() == "0") //Estado 0=Activo
                                {
                                    stTexto29 = "";
                                    stTexto1 = "INT-ARTICULOS";
                                    stTexto2 = stEmpId;
                                    stdecripArt = rss["items"][i]["name"].ToString().Replace("'", ""); //descrip
                                                                                                       //stTexto4 = rss["items"][i]["name"].ToString().Replace("'", ""); //descrip
                                                                                                       //stTexto5 = rss["items"][i]["name"].ToString().Replace("'", ""); //descrip
                                                                                                       //stTexto6 = rss["items"][i]["name"].ToString().Replace("'", ""); //descrip
                                    stTexto7 = "UN";
                                    stTexto8 = rss["items"][i]["product_type"]["id"].ToString(); //lineaproducto
                                    stTexto9 = "1"; //tipomodelo
                                    stTexto10 = ""; //version
                                    stTexto11 = rss["items"][i]["product_type"]["name"].ToString(); //origen
                                    stTexto12 = ""; //rtacion
                                    stTexto13 = ""; //fabrica
                                    stTexto14 = ""; //marca

                                    if (rss["items"][i]["classification"].ToString() != "3") //No es tipo KIT
                                    {
                                        stTexto15 = "1"; //tipo 1:Articulo;2:Servicio;3:Kit
                                    }
                                    else 
                                    {
                                        if (rss["items"][i]["classification"].ToString() == "3") // si es tipo KIT
                                        {
                                            stTexto15 = "3"; //tipo 1:Articulo;2:Servicio;3:Kit

                                            variantKit = (Int32)rss["items"][i]["pack_details"].Count();

                                            //Recorre los componentes del Kit
                                            for (Int32 i_kit = 0; i_kit < variantKit; i_kit++)
                                            {
                                                stTexto30 = rss["items"][i]["pack_details"][i_kit]["quantity"].ToString();  //quantity pack

                                                if (rss["items"][i]["pack_details"][i_kit]["multipleVariant"].ToString() == "0")
                                                {
                                                    //pregunta si viene el campo variant en el detalle de pack_details, para controlar NullReferenceException -----
                                                    if (rss["items"][i]["pack_details"].Parent.ToString().Contains("variant") == true)
                                                    {
                                                        stTexto31 = rss["items"][i]["pack_details"][i_kit]["variant"]["id"].ToString(); // Id variante Pack
                                                    }
                                                    else
                                                    {
                                                        stTexto31 = "";
                                                    }
                                                }
                                                else
                                                {
                                                    stTexto15 = "1"; //tipo 1:Articulo;2:Servicio;3:Kit
                                                }

                                                //Concatena componentes del Kit -----------------------
                                                stTexto29 += stTexto30 + "#" + stTexto31 + ";";
                                            }
                                        }
                                    }

                                    stTexto16 = "0"; //usa serie
                                    stTexto17 = "0";  //usa lote
                                    stTexto19 = ""; //dun
                                    stTexto20 = "01-01-2021"; //vigencia
                                    stTexto21 = "31-12-2050";

                                    stTexto22 = "UN";
                                    stTexto23 = "UN";
                                    stTexto24 = ""; //codigprov
                                    stTexto25 = ""; //bod
                                    stTexto26 = ""; //ubic

                                    stTexto27 = rss["items"][i]["id"].ToString(); //productid

                                    linea0 = linea;

                                    if (1 == 1) //VALIDAR ATRIBUTOS DEL ARTICULO
                                    {
                                        string stDoc_Attribute = ConfigurationManager.AppSettings["BSALE_Attributes"].ToString();
                                        Atribucount = (Int32)rss["items"][i]["product_type"]["attributes"]["count"];

                                        if (Atribucount < 26)
                                        {
                                            for (Int32 i_atri = 0; i_atri < Atribucount; i_atri++)
                                            {
                                                idattribute = "";
                                                nameattribute = rss["items"][i]["product_type"]["attributes"]["items"][i_atri]["name"].ToString();  //Nombre del Atributo
                                                if (stDoc_Attribute.IndexOf("'" + nameattribute + "'") >= 0)
                                                {
                                                    idattribute = rss["items"][i]["product_type"]["attributes"]["items"][i_atri]["id"].ToString();  //Nombre del Atributo
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            idattribute = "";
                                        }

                                        #region Myattributte - esta todo comentado
                                        //else
                                        //{

                                        //    string urlattribute = "https://api.bsale.cl/v1/variants.json?productid=" + rss["items"][i]["id"].ToString();

                                        //    s2 = EjecutaAPI_BSale(urlattribute, token, 0);
                                        //    LogInfo("BSALE_ExtraeMaestraArticulos", "Despues de API " + Count.ToString());

                                        //    dynamic jsonvariant = JsonConvert.DeserializeObject(s2);
                                        //    JObject rssvariant = JObject.Parse(s2);

                                        //    Countvariant = (Int32)rssvariant["count"];
                                        //    limitvariant = (Int32)rssvariant["limit"];
                                        //    offsetvariant = (Int32)rssvariant["offset"];

                                        //    var vecesvariant = Math.Ceiling(Convert.ToDouble(variantcount) / limitvariant);

                                        //    for (Int32 q = 0; q < vecesvariant; q++)
                                        //    {
                                        //        if (q > 0)
                                        //        {
                                        //            s2 = EjecutaAPI_BSale(urlvariant, token, offsetvariant);

                                        //            //Func.log(s);
                                        //            jsonvariant = JsonConvert.DeserializeObject(s2);
                                        //            rssvariant = JObject.Parse(s2);

                                        //        }
                                        //        for (Int32 i_var = 0; i_var < rssvariant["items"].Count(); i_var++)
                                        //        {
                                        //            stTexto3 = rssvariant["items"][i_var]["code"].ToString().Replace(",", "").Replace("'", "");  //sku
                                        //            stTexto28 = rssvariant["items"][i_var]["id"].ToString();  //variantid
                                        //            stTexto18 = rssvariant["items"][i_var]["barCode"].ToString().Replace("'", "");  //barcode
                                        //            stTexto4 = stdecripArt + " " + rss["items"][i]["variants"]["items"][i_var]["description"].ToString(); //descrip
                                        //            stTexto5 = stdecripArt + " " + rss["items"][i]["variants"]["items"][i_var]["description"].ToString(); //descrip
                                        //            stTexto6 = stdecripArt + " " + rss["items"][i]["variants"]["items"][i_var]["description"].ToString(); //descrip
                                        //            stTexto30 = rssvariant["items"][i_var]["state"].ToString();
                                        //            stTexto31 = rssvariant["items"][i_var]["description"].ToString();
                                        //            //MessageBox.Show(linea);
                                        //            stLinea = stLinea + 1;
                                        //            sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
                                        //            sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9 , Texto10,";
                                        //            sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
                                        //            sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29, Texto30,";
                                        //            sqlQuery += "Texto31) values (";

                                        //            sqlQuery += "'" + stArchivo.Trim() + "'";
                                        //            sqlQuery += ",'" + stUserName.Trim() + "'";
                                        //            sqlQuery += ",'" + stFechaProcesoInt + "'";
                                        //            sqlQuery += ",'" + stLinea + "'";
                                        //            sqlQuery += ",'" + stTexto1.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto2.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto3.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto4.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto5.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto6.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto7.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto8.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto9.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto10.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto11.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto12.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto13.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto14.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto15.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto16.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto17.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto18.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto19.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto20.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto21.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto22.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto23.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto24.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto25.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto26.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto27.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto28.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto29.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto30.Trim() + "'";
                                        //            sqlQuery += ",'" + stTexto31.Trim() + "'";
                                        //            sqlQuery += ")";

                                        //            result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
                                        //        }
                                        //        offsetvariant = offsetvariant + limitvariant;
                                        //    }
                                        //}

                                        #endregion
                                    }

                                    variantcount = (Int32)rss["items"][i]["variants"]["count"];

                                    //Recorre Variantes (variedades) del producto (ej. producto Mouse optico, variantes negro, rojo, verde)
                                    if (variantcount < 26) //si tiene menos de 25 variedades
                                    {
                                        for (Int32 i_var = 0; i_var < variantcount; i_var++)
                                        {
                                            stTexto32 = "";
                                            stTexto3 = rss["items"][i]["variants"]["items"][i_var]["code"].ToString().Replace(",", "").Replace("'", "");  //sku
                                            stTexto28 = rss["items"][i]["variants"]["items"][i_var]["id"].ToString();  //variantid
                                            stTexto18 = rss["items"][i]["variants"]["items"][i_var]["barCode"].ToString().Replace("'", "");  //barcode
                                            stTexto4 = stdecripArt + " " + rss["items"][i]["variants"]["items"][i_var]["description"].ToString(); //descrip
                                            stTexto5 = stdecripArt + " " + rss["items"][i]["variants"]["items"][i_var]["description"].ToString(); //descrip
                                            stTexto6 = stdecripArt + " " + rss["items"][i]["variants"]["items"][i_var]["description"].ToString(); //descrip
                                            stTexto30 = rss["items"][i]["variants"]["items"][i_var]["state"].ToString();
                                            stTexto31 = rss["items"][i]["variants"]["items"][i_var]["description"].ToString();

                                            #region Myattribute_values

                                            if (idattribute != "")
                                            {
                                                try
                                                {
                                                    //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
                                                    for (Int32 intentos_variante = 1; intentos_variante <= 3; intentos_variante++)
                                                    {
                                                        s3 = EjecutaAPI_BSale(rss["items"][i]["variants"]["items"][i_var]["attribute_values"]["href"].ToString(), token, 0, "BSALE_ExtraeMaestraArticulos");

                                                        //Si la respuesta es un json y no un html
                                                        if (s3.Contains("attribute_values.json") == true &&
                                                            s3.Contains("{") == true &&
                                                            s3.Contains("<html>") == false &&
                                                            s3.Contains("502 Bad Gateway") == false)
                                                        {
                                                            //LogInfo("BSALE_ExtraeMaestraArticulos", "(A)Respuesta S3: " + s3);

                                                            dynamic jsonattributeV = JsonConvert.DeserializeObject(s3);
                                                            JObject rssattributeV = JObject.Parse(s3);

                                                            CountattributeV = (Int32)rssattributeV["count"];
                                                            limitattributeV = (Int32)rssattributeV["limit"];
                                                            offsetattributeV = (Int32)rssattributeV["offset"];

                                                            var vecesattributeV = Math.Ceiling(Convert.ToDouble(CountattributeV) / Convert.ToDouble(limitattributeV));

                                                            for (Int32 wv = 0; wv < vecesattributeV; wv++)
                                                            {
                                                                if (wv > 0)
                                                                {
                                                                    s3 = EjecutaAPI_BSale(url, token, offset, "BSALE_ExtraeMaestraArticulos");

                                                                    //Func.log(s);
                                                                    jsonattributeV = JsonConvert.DeserializeObject(s3);
                                                                    rssattributeV = JObject.Parse(s3);
                                                                }

                                                                for (Int32 iv = 0; iv < rssattributeV["items"].Count(); iv++)
                                                                {
                                                                    if (idattribute == rssattributeV["items"][iv]["attribute"]["id"].ToString())
                                                                    {
                                                                        stTexto32 = rssattributeV["items"][iv]["description"].ToString(); //atributo
                                                                        break;
                                                                    }
                                                                }

                                                                offsetattributeV = offsetattributeV + limitattributeV;
                                                            }

                                                            break; //sale del for
                                                        }
                                                        else
                                                        {
                                                            LogInfo("BSALE_ExtraeMaestraArticulos", "Error llamado variante a BSALE. Intento: " + intentos_variante.ToString().Trim() +
                                                                                                    "Variante id: " + stTexto28.Trim() +
                                                                                                    ",variante descripcion:" + stTexto31.Trim() +
                                                                                                    ",Producto: " + stdecripArt.Trim() +
                                                                                                    ",producto id:" + stTexto27.Trim() +
                                                                                                    ",respuesta BSALE: " + s3.Trim());
                                                        }
                                                    }

                                                }
                                                catch (Exception error_)
                                                {
                                                    LogInfo("BSALE_ExtraeMaestraArticulos", "Error(A):" + error_.Message +
                                                                                            "Variante id: " + stTexto28.Trim() +
                                                                                            ",variante descripcion:" + stTexto31.Trim() +
                                                                                            ",Producto: " + stdecripArt.Trim() +
                                                                                            ",producto id:" + stTexto27.Trim());
                                                }

                                                #region codigo comentariado
                                                //dynamic jsonattributeV = JsonConvert.DeserializeObject(s3);
                                                //JObject rssattributeV = JObject.Parse(s3);

                                                //CountattributeV = (Int32)rssattributeV["count"];
                                                //limitattributeV = (Int32)rssattributeV["limit"];
                                                //offsetattributeV = (Int32)rssattributeV["offset"];

                                                //var vecesattributeV = Math.Ceiling(Convert.ToDouble(CountattributeV) / Convert.ToDouble(limitattributeV));

                                                //for (Int32 wv = 0; wv < vecesattributeV; wv++)
                                                //{

                                                //    if (wv > 0)
                                                //    {
                                                //        s3 = EjecutaAPI_BSale(url, token, offset);

                                                //        //Func.log(s);
                                                //        jsonattributeV = JsonConvert.DeserializeObject(s3);
                                                //        rssattributeV = JObject.Parse(s3);

                                                //    }
                                                //    for (Int32 iv = 0; iv < rssattributeV["items"].Count(); iv++)
                                                //    {
                                                //        if (idattribute == rssattributeV["items"][iv]["attribute"]["id"].ToString())
                                                //        {
                                                //            stTexto32 = rssattributeV["items"][iv]["description"].ToString(); //atributo
                                                //            break;
                                                //        }

                                                //    }
                                                //    offsetattributeV = offsetattributeV + limitattributeV;

                                                //}
                                                #endregion
                                            }
                                            #endregion

                                            //MessageBox.Show(linea);
                                            stLinea = stLinea + 1;

                                            #region Insert directo comentariado
                                            //sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
                                            //sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9 , Texto10,";
                                            //sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
                                            //sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29, Texto30,";
                                            //sqlQuery += "Texto31, Texto32) values (";

                                            //sqlQuery += "'" + stArchivo.Trim() + "'";
                                            //sqlQuery += ",'" + stUserName.Trim() + "'";
                                            //sqlQuery += ",'" + stFechaProcesoInt + "'";
                                            //sqlQuery += ",'" + stLinea + "'";
                                            //sqlQuery += ",'" + stTexto1.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto2.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto3.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto4.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto5.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto6.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto7.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto8.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto9.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto10.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto11.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto12.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto13.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto14.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto15.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto16.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto17.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto18.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto19.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto20.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto21.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto22.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto23.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto24.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto25.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto26.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto27.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto28.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto29.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto30.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto31.Trim() + "'";
                                            //sqlQuery += ",'" + stTexto32.Trim() + "'";
                                            //sqlQuery += ")";

                                            //result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
                                            #endregion

                                            //=========================================================================================================
                                            //Si ya tiene lineas previas agrega caracter separador de Lineas
                                            if (Datos.Trim() != "")
                                            {
                                                Datos = Datos.Trim() + SeparadorLinea.Trim();
                                            }

                                            //Envia Linea + Texto1 + ..... + Texto100
                                            Datos = Datos.Trim() +
                                                    stLinea.ToString() + SeparadorCampo.Trim() +
                                                    stTexto1.Trim() + SeparadorCampo.Trim() +
                                                    stTexto2.Trim() + SeparadorCampo.Trim() +
                                                    stTexto3.Trim() + SeparadorCampo.Trim() +
                                                    stTexto4.Trim() + SeparadorCampo.Trim() +
                                                    stTexto5.Trim() + SeparadorCampo.Trim() +
                                                    stTexto6.Trim() + SeparadorCampo.Trim() +
                                                    stTexto7.Trim() + SeparadorCampo.Trim() +
                                                    stTexto8.Trim() + SeparadorCampo.Trim() +
                                                    stTexto9.Trim() + SeparadorCampo.Trim() +
                                                    stTexto10.Trim() + SeparadorCampo.Trim() +
                                                    stTexto11.Trim() + SeparadorCampo.Trim() +
                                                    stTexto12.Trim() + SeparadorCampo.Trim() +
                                                    stTexto13.Trim() + SeparadorCampo.Trim() +
                                                    stTexto14.Trim() + SeparadorCampo.Trim() +
                                                    stTexto15.Trim() + SeparadorCampo.Trim() +
                                                    stTexto16.Trim() + SeparadorCampo.Trim() +
                                                    stTexto17.Trim() + SeparadorCampo.Trim() +
                                                    stTexto18.Trim() + SeparadorCampo.Trim() +
                                                    stTexto19.Trim() + SeparadorCampo.Trim() +
                                                    stTexto20.Trim() + SeparadorCampo.Trim() +
                                                    stTexto21.Trim() + SeparadorCampo.Trim() +
                                                    stTexto22.Trim() + SeparadorCampo.Trim() +
                                                    stTexto23.Trim() + SeparadorCampo.Trim() +
                                                    stTexto24.Trim() + SeparadorCampo.Trim() +
                                                    stTexto25.Trim() + SeparadorCampo.Trim() +
                                                    stTexto26.Trim() + SeparadorCampo.Trim() +
                                                    stTexto27.Trim() + SeparadorCampo.Trim() +
                                                    stTexto28.Trim() + SeparadorCampo.Trim() +
                                                    stTexto29.Trim() + SeparadorCampo.Trim() +
                                                    stTexto30.Trim() + SeparadorCampo.Trim() +
                                                    stTexto31.Trim() + SeparadorCampo.Trim() +
                                                    stTexto32.Trim();

                                            //Si salio del ciclo y quedaron Items por insertar en tabla de integracion --------------------------------
                                            if (stLinea % CantidadRegistrosInsercion == 0)
                                            {
                                                LogInfo("BSALE_ExtraeMaestraArticulos", "Graba lineas (1). Corte linea: " + stLinea.ToString());

                                                Resultado = Tmpt_SolImportDespacho.Inserta_Integraciones_Masivo(stArchivo,
                                                                                                                stUserName.Trim(),
                                                                                                                DateTime.Now,
                                                                                                                Datos);
                                                Datos = "";
                                            }
                                        }
                                    }
                                    else //si tiene mas de 25 variedades ejecuta api que trae lista de variedades
                                    {
                                        //llamado api producto BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
                                        for (Int32 intentos_producto = 1; intentos_producto <= 3; intentos_producto++)
                                        {
                                            string urlvariant = "https://api.bsale.cl/v1/variants.json?productid=" + rss["items"][i]["id"].ToString();

                                            s2 = EjecutaAPI_BSale(urlvariant, token, 0, "BSALE_ExtraeMaestraArticulos");
                                            //LogInfo("BSALE_ExtraeMaestraArticulos", "Despues de API " + Count.ToString());

                                            //Si la respuesta es un json valido y no un html
                                            if (s2.Contains("{") == true &&
                                                s2.Contains("<html>") == false &&
                                                s2.Contains("502 Bad Gateway") == false)
                                            {
                                                dynamic jsonvariant = JsonConvert.DeserializeObject(s2);
                                                JObject rssvariant = JObject.Parse(s2);

                                                Countvariant = (Int32)rssvariant["count"];
                                                limitvariant = (Int32)rssvariant["limit"];
                                                offsetvariant = (Int32)rssvariant["offset"];

                                                var vecesvariant = Math.Ceiling(Convert.ToDouble(variantcount) / limitvariant);

                                                //Recorre variantes producto
                                                for (Int32 q = 0; q < vecesvariant; q++)
                                                {
                                                    if (q > 0)
                                                    {
                                                        s2 = EjecutaAPI_BSale(urlvariant, token, offsetvariant, "BSALE_ExtraeMaestraArticulos");

                                                        //Func.log(s);
                                                        jsonvariant = JsonConvert.DeserializeObject(s2);
                                                        rssvariant = JObject.Parse(s2);
                                                    }

                                                    for (Int32 i_var = 0; i_var < rssvariant["items"].Count(); i_var++)
                                                    {
                                                        stTexto32 = "";
                                                        stTexto3 = rssvariant["items"][i_var]["code"].ToString().Replace(",", "").Replace("'", "");  //sku
                                                        stTexto28 = rssvariant["items"][i_var]["id"].ToString();  //variantid
                                                        stTexto18 = rssvariant["items"][i_var]["barCode"].ToString().Replace("'", "");  //barcode
                                                        stTexto4 = stdecripArt + " " + rssvariant["items"][i_var]["description"].ToString(); //descrip
                                                        stTexto5 = stdecripArt + " " + rssvariant["items"][i_var]["description"].ToString(); //descrip
                                                        stTexto6 = stdecripArt + " " + rssvariant["items"][i_var]["description"].ToString(); //descrip
                                                        stTexto30 = rssvariant["items"][i_var]["state"].ToString();
                                                        stTexto31 = rssvariant["items"][i_var]["description"].ToString();

                                                        #region Myattribute_values

                                                        try
                                                        {
                                                            //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
                                                            for (Int32 intentos_variante = 1; intentos_variante <= 3; intentos_variante++)
                                                            {
                                                                s3 = EjecutaAPI_BSale(rss["items"][i]["variants"]["items"][i_var]["attribute_values"]["href"].ToString(), token, 0, "BSALE_ExtraeMaestraArticulos");

                                                                //Si la respuesta es un json y no un html
                                                                if (s3.Contains("attribute_values.json") == true &&
                                                                    s3.Contains("{") == true &&
                                                                    s3.Contains("<html>") == false &&
                                                                    s3.Contains("502 Bad Gateway") == false)
                                                                {
                                                                    //LogInfo("BSALE_ExtraeMaestraArticulos", "(B)Respuesta S3: " + s3);

                                                                    dynamic jsonattributeV = JsonConvert.DeserializeObject(s3);
                                                                    JObject rssattributeV = JObject.Parse(s3);

                                                                    CountattributeV = (Int32)rssattributeV["count"];
                                                                    limitattributeV = (Int32)rssattributeV["limit"];
                                                                    offsetattributeV = (Int32)rssattributeV["offset"];

                                                                    var vecesattributeV = Math.Ceiling(Convert.ToDouble(CountattributeV) / Convert.ToDouble(limitattributeV));

                                                                    for (Int32 wv = 0; wv < vecesattributeV; wv++)
                                                                    {

                                                                        if (wv > 0)
                                                                        {
                                                                            s3 = EjecutaAPI_BSale(url, token, offset, "BSALE_ExtraeMaestraArticulos");

                                                                            //Func.log(s);
                                                                            jsonattributeV = JsonConvert.DeserializeObject(s3);
                                                                            rssattributeV = JObject.Parse(s3);

                                                                        }
                                                                        for (Int32 iv = 0; iv < rssattributeV["items"].Count(); iv++)
                                                                        {
                                                                            if (idattribute == rssattributeV["items"][iv]["attribute"]["id"].ToString())
                                                                            {
                                                                                stTexto32 = rssattributeV["items"][iv]["description"].ToString(); //atributo
                                                                                break;
                                                                            }

                                                                        }
                                                                        offsetattributeV = offsetattributeV + limitattributeV;
                                                                    }

                                                                    break; //sale del ciclo 
                                                                }
                                                                else
                                                                {
                                                                    LogInfo("BSALE_ExtraeMaestraArticulos", "Error llamado variante a BSALE. Intento: " + intentos_variante.ToString().Trim() +
                                                                                                            "Variante id: " + stTexto28.Trim() +
                                                                                                            ",variante descripcion:" + stTexto31.Trim() +
                                                                                                            ",Producto: " + stdecripArt.Trim() +
                                                                                                            ",producto id:" + stTexto27.Trim() +
                                                                                                            ",respuesta BSALE: " + s3.Trim());
                                                                }
                                                            }
                                                        }
                                                        catch (Exception error_)
                                                        {
                                                            LogInfo("BSALE_ExtraeMaestraArticulos", "Error(B):" + error_.Message +
                                                                                                    "Variante id: " + stTexto28.Trim() +
                                                                                                    ",variante descripcion:" + stTexto31.Trim() +
                                                                                                    ",Producto: " + stdecripArt.Trim() +
                                                                                                    ",producto id:" + stTexto27.Trim());
                                                        }

                                                        #region codigo comentariado
                                                        //dynamic jsonattributeV = JsonConvert.DeserializeObject(s3);
                                                        //JObject rssattributeV = JObject.Parse(s3);

                                                        //CountattributeV = (Int32)rssattributeV["count"];
                                                        //limitattributeV = (Int32)rssattributeV["limit"];
                                                        //offsetattributeV = (Int32)rssattributeV["offset"];

                                                        //var vecesattributeV = Math.Ceiling(Convert.ToDouble(CountattributeV) / Convert.ToDouble(limitattributeV));

                                                        //for (Int32 wv = 0; wv < vecesattributeV; wv++)
                                                        //{

                                                        //    if (wv > 0)
                                                        //    {
                                                        //        s3 = EjecutaAPI_BSale(url, token, offset);

                                                        //        //Func.log(s);
                                                        //        jsonattributeV = JsonConvert.DeserializeObject(s3);
                                                        //        rssattributeV = JObject.Parse(s3);

                                                        //    }
                                                        //    for (Int32 iv = 0; iv < rssattributeV["items"].Count(); iv++)
                                                        //    {
                                                        //        if (idattribute == rssattributeV["items"][iv]["attribute"]["id"].ToString())
                                                        //        {
                                                        //            stTexto32 = rssattributeV["items"][iv]["description"].ToString(); //atributo
                                                        //            break;
                                                        //        }

                                                        //    }
                                                        //    offsetattributeV = offsetattributeV + limitattributeV;

                                                        //}
                                                        #endregion

                                                        #endregion

                                                        //MessageBox.Show(linea);
                                                        stLinea = stLinea + 1;

                                                        #region Insert directo comentariado
                                                        //sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
                                                        //sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9 , Texto10,";
                                                        //sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
                                                        //sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29, Texto30,";
                                                        //sqlQuery += "Texto31, Texto32) values (";

                                                        //sqlQuery += "'" + stArchivo.Trim() + "'";
                                                        //sqlQuery += ",'" + stUserName.Trim() + "'";
                                                        //sqlQuery += ",'" + stFechaProcesoInt + "'";
                                                        //sqlQuery += ",'" + stLinea + "'";
                                                        //sqlQuery += ",'" + stTexto1.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto2.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto3.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto4.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto5.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto6.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto7.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto8.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto9.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto10.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto11.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto12.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto13.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto14.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto15.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto16.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto17.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto18.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto19.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto20.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto21.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto22.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto23.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto24.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto25.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto26.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto27.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto28.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto29.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto30.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto31.Trim() + "'";
                                                        //sqlQuery += ",'" + stTexto32.Trim() + "'";
                                                        //sqlQuery += ")";

                                                        //result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
                                                        #endregion

                                                        //=========================================================================================================
                                                        //Si ya tiene lineas previas agrega caracter separador de Lineas
                                                        if (Datos.Trim() != "")
                                                        {
                                                            Datos = Datos.Trim() + SeparadorLinea.Trim();
                                                        }

                                                        //Envia Linea + Texto1 + ..... + Texto100
                                                        Datos = Datos.Trim() +
                                                                stLinea.ToString() + SeparadorCampo.Trim() +
                                                                stTexto1.Trim() + SeparadorCampo.Trim() +
                                                                stTexto2.Trim() + SeparadorCampo.Trim() +
                                                                stTexto3.Trim() + SeparadorCampo.Trim() +
                                                                stTexto4.Trim() + SeparadorCampo.Trim() +
                                                                stTexto5.Trim() + SeparadorCampo.Trim() +
                                                                stTexto6.Trim() + SeparadorCampo.Trim() +
                                                                stTexto7.Trim() + SeparadorCampo.Trim() +
                                                                stTexto8.Trim() + SeparadorCampo.Trim() +
                                                                stTexto9.Trim() + SeparadorCampo.Trim() +
                                                                stTexto10.Trim() + SeparadorCampo.Trim() +
                                                                stTexto11.Trim() + SeparadorCampo.Trim() +
                                                                stTexto12.Trim() + SeparadorCampo.Trim() +
                                                                stTexto13.Trim() + SeparadorCampo.Trim() +
                                                                stTexto14.Trim() + SeparadorCampo.Trim() +
                                                                stTexto15.Trim() + SeparadorCampo.Trim() +
                                                                stTexto16.Trim() + SeparadorCampo.Trim() +
                                                                stTexto17.Trim() + SeparadorCampo.Trim() +
                                                                stTexto18.Trim() + SeparadorCampo.Trim() +
                                                                stTexto19.Trim() + SeparadorCampo.Trim() +
                                                                stTexto20.Trim() + SeparadorCampo.Trim() +
                                                                stTexto21.Trim() + SeparadorCampo.Trim() +
                                                                stTexto22.Trim() + SeparadorCampo.Trim() +
                                                                stTexto23.Trim() + SeparadorCampo.Trim() +
                                                                stTexto24.Trim() + SeparadorCampo.Trim() +
                                                                stTexto25.Trim() + SeparadorCampo.Trim() +
                                                                stTexto26.Trim() + SeparadorCampo.Trim() +
                                                                stTexto27.Trim() + SeparadorCampo.Trim() +
                                                                stTexto28.Trim() + SeparadorCampo.Trim() +
                                                                stTexto29.Trim() + SeparadorCampo.Trim() +
                                                                stTexto30.Trim() + SeparadorCampo.Trim() +
                                                                stTexto31.Trim() + SeparadorCampo.Trim() +
                                                                stTexto32.Trim();

                                                        //Si salio del ciclo y quedaron Items por insertar en tabla de integracion --------------------------------
                                                        if (stLinea % CantidadRegistrosInsercion == 0)
                                                        {
                                                            LogInfo("BSALE_ExtraeMaestraArticulos", "Graba lineas (2). Corte linea: " + stLinea.ToString());

                                                            Resultado = Tmpt_SolImportDespacho.Inserta_Integraciones_Masivo(stArchivo,
                                                                                                                            stUserName.Trim(),
                                                                                                                            DateTime.Now,
                                                                                                                            Datos);
                                                            Datos = "";
                                                        }
                                                    }

                                                    offsetvariant = offsetvariant + limitvariant;
                                                }

                                                break; //sale del ciclo
                                            }
                                            else
                                            {
                                                LogInfo("BSALE_ExtraeMaestraArticulos", "Error llamado producto a BSALE. Intento: " + intentos_producto.ToString().Trim() +
                                                                                        ", Producto: " + stdecripArt.Trim() +
                                                                                        ", Producto id: " + stTexto27.Trim() +
                                                                                        ", Respuesta BSALE: " + s3.Trim());
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LogInfo("BSALE_ExtraeMaestraArticulos", "Item con error:" + i.ToString());
                                LogInfo("BSALE_ExtraeMaestraArticulos", "Error:" + ex.Message, true);
                            }

                        } //FIN Ciclo que recorre la pagina de Articulos -----

                    } //FIN Si la ultima lectura a BSALE retornó datos sigue procesando
                    else
                    {
                        LogInfo("BSALE_ExtraeMaestraArticulos", "Pausa de 3 segundos por error de BSale");
                        System.Threading.Thread.Sleep(3000); // pausa de 3 segundos a la espera que el servicio de BSale responda en la siguiente lectura
                        LogInfo("BSALE_ExtraeMaestraArticulos", "Fin Pausa de 3 segundos, continua");

                        ContadorProductos = ContadorProductos + limit;
                    }

                    offset = offset + limit;

                } //FIN Ciclo que recorre cantidad de paginas de datos leidos -----

                //Si salio del ciclo y quedaron Items por insertar en tabla de integracion --------------------------------
                if (Datos != "")
                {
                    Resultado = Tmpt_SolImportDespacho.Inserta_Integraciones_Masivo(stArchivo,
                                                                                    stUserName.Trim(),
                                                                                    DateTime.Now,
                                                                                    Datos);
                    Datos = "";
                }

                if (stLinea > 0)
                {
                    DataSet myDataSet1 = new DataSet();
                    string resultIntegracion = "0";

                    myDataSet1 = Tmpt_SolImportDespacho.GeneraProceso(stArchivo,
                                                                      stUserName,
                                                                      DateTime.Parse(DateTime.Now.ToShortDateString()));
                    if (myDataSet1.Tables.Count > 0)
                    {
                        int tabla1 = myDataSet1.Tables.Count;
                        //resultIntegracion = myDataSet.Tables[tabla - 1].Rows[0]["Generacion"].ToString().Trim();
                        resultIntegracion = myDataSet1.Tables[tabla1 - 1].Rows[0]["Generacion"].ToString().Trim();
                        if (resultIntegracion != "0")
                        {
                            LogInfo("BSALE_ExtraeMaestraArticulos", "PROCESA INTEGRACION DE ARTICULOS OK", true);
                            //Console.WriteLine("PROCESA PEDIDO DE INTEGRACION");
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogInfo("BSALE_ExtraeMaestraArticulos", "Error:" + ex.Message, true);
                return false;
            }
        }

        //Realiza el llamado a una ruta de BSale dada ------------------------------------------------------
        public static string EjecutaAPI_BSale(String URL, String Token, Int32 offset, string Llamado = "")
        {
            if (Llamado == "")
            {
                Llamado = "GetGeneral";
            }

            LogInfo(Llamado, "URL:" + URL + ";Token:" + Token + ";off:" + offset.ToString());

            if (offset > 0)
                URL = URL + @"&offset=" + offset.ToString();

            //if (MostrarURL)
            //    Func.log("->-> " + URL);
            var client = new RestClient(URL);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("access_token", Token);
            //request.AddParameter("application/json", json, ParameterType.RequestBody);

            //IRestResponse response;

            string respuesta = "";

            //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
            for (Int32 intentos = 1; intentos <= 3; intentos++)
            {
                IRestResponse response = client.Execute(request);

                //Si la respuesta es un json válido y no un texto html
                //if (response.Content.ToString().Contains("{") == true &&
                //    response.Content.ToString().Contains("<html>") == false &&
                //    response.Content.ToString().Contains("502 Bad Gateway") == false)

                if (response.StatusCode == HttpStatusCode.OK) // finalizo ok
                {
                    //return response.Content;
                    respuesta = response.Content;
                    break;
                }
                else
                {
                    LogInfo(Llamado, "Error respuesta BSALE. N° intento: " + intentos.ToString().Trim() +
                                       ", URL: " + URL.Trim() +
                                       ", Respuesta BSALE: " + response.Content.ToString().Trim());
                }
            }

            return respuesta;
        }

        public static bool ConsultaPedidosDoctoLegal(string FechaDescarga)
        {
            LogInfo("ConsultaPedidosDoctoLegal", "Inicio proceso", true);
            bool resultCons = false;

            try
            {
                int hora = DateTime.Now.Hour;
                string hora_ejecucion;

                hora_ejecucion = ConfigurationManager.AppSettings["BSALE_Hora_ConsultaPedidosDoctoLegal"].ToString();

                //if (hora == 7) //Para que se ejecute solo de 7:00 a 7:59 
                //Busca la hora como '7'
                if (hora_ejecucion.IndexOf("'" + hora.ToString() + "'") >= 0) //si la hora esta dentro de la key ejecuta el proceso
                {
                    string sqlQuery = "";
                    string stArchivo = "";
                    string stUserName = "";
                    string dtFechaProcesoInt = "1900-01-01";
                    int stLinea = 0;
                    string stTexto1 = "", stTexto2 = "", stTexto3 = "", stTexto4 = "", stTexto5 = "", stTexto6 = "", stTexto7 = "", stTexto8 = "", stTexto9 = "";
                    string stTexto10 = "", stTexto11 = "", stTexto12 = "", stTexto13 = "", stTexto14 = "", stTexto15 = "", stTexto16 = "", stTexto17 = "", stTexto18 = "", stTexto19 = "";
                    string stTexto20 = "", stTexto21 = "", stTexto22 = "", stTexto23 = "", stTexto24 = "", stTexto25 = "", stTexto26 = "", stTexto27 = "", stTexto28 = "", stTexto29 = "";
                    string stTexto30 = "", stTexto31 = "", stTexto32 = "", stTexto33 = "", stTexto34 = "", stTexto35 = "", stTexto36 = "", stTexto37 = "", stTexto38 = "", stTexto39 = "";
                    string stTexto40 = "", stTexto41 = "", stTexto42 = "", stTexto43 = "", stTexto44 = "", stTexto45 = "", stTexto46 = "", stTexto47 = "", stTexto48 = "", stTexto49 = "";
                    string stTexto50 = "", stTexto51 = "", stTexto52 = "", stTexto53 = "", stTexto54 = "", stTexto55 = "", stTexto56 = "", stTexto57 = "", stTexto58 = ""; //stTexto59 = "";

                    string stDoc_Type = ConfigurationManager.AppSettings["BSALE_DocType"].ToString();
                    string stEmpId = ConfigurationManager.AppSettings["EmpId"].ToString();

                    string result = "";
                    int _CantDocto = 0;
                    int _limit = 0;
                    int _CantLineas = 0;
                    int offset = 0;
                    int ContadorOffset = 0;

                    string sUrlRequest = "";
                    string DATA = "";
                    string shipping_type_id = "";
                    string destinationOffice_id = "";

                    DataSet myDataSet = new DataSet();

                    string BSALE_FechaEpoch = ConfigurationManager.AppSettings["BSALE_FechaEpoch"].ToString();
                    string BSALE_Number = ConfigurationManager.AppSettings["BSALE_Number"].ToString();
                    DateTime _date1, _date;
                    Int32 unixTimestamp1, unixTimestamp2;

                    if (FechaDescarga.Trim() != "")
                    {
                        BSALE_FechaEpoch = FechaDescarga;
                    }

                    if (BSALE_FechaEpoch == "")
                    {
                        //para que se ejecute con los documentos del dia
                        _date1 = DateTime.Parse(DateTime.Now.ToShortDateString());

                        //if (hora == 7)
                        //{
                        //    _date1 = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                        //}
                        //else
                        //{
                        //    _date1 = DateTime.Parse(DateTime.Now.ToShortDateString());
                        //}

                        //_date1 = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                        //SE DEJA SOLO LA FECHA DEL DIA ACTUAL

                        _date = DateTime.Parse(DateTime.Now.ToShortDateString());
                        unixTimestamp1 = (Int32)(_date1.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        unixTimestamp2 = (Int32)(_date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else
                    {
                        unixTimestamp1 = Int32.Parse(BSALE_FechaEpoch);
                        unixTimestamp2 = Int32.Parse(BSALE_FechaEpoch);
                    }

                    /*RECUPERA OFFSET DESDE BD*/
                    //result = WS_Integrador.Classes.model.InfF_Generador.ValEjecutaProcesoOffSet();
                    //offset = int.Parse(result);

                    offset = 0;

                Reprocesar:

                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1
                                                                                      //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                                                                      //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                    HttpResponseMessage response = new HttpResponseMessage();

                    PedidoDocumentosBSale PedidoDocumentosBSale;
                    ShippingBSale ShippingBSale1;
                    TaxDocument TaxDocument;
                    DocumentAttributte DocumentAttributte;
                    Variants VariantsDetalle;

                    string datoCourier = string.Empty;
                    string Glosa = string.Empty;
                    string Glosacheckout = string.Empty;
                    string shipping_id = string.Empty;
                    string clientStreetcheckout = string.Empty;
                    string clientCityZonecheckout = string.Empty;
                    string clientState = string.Empty;
                    string clientEmail = string.Empty;
                    string clientPhone = string.Empty;
                    string payProcesscheckout = string.Empty;
                    string idVentaMercadoLibre = string.Empty;
                    string documentEmail = string.Empty;
                    string documentPhone = string.Empty;
                    string documentCity = string.Empty;
                    string documentMunicipality = string.Empty;
                    string documentAddress = string.Empty;
                    string clientAddress = string.Empty;
                    string retiroTienda = "0";
                    string clientNumber = "";
                    bool InsertaIntegracion = false;

                    HttpContent content = new StringContent(DATA);

                    //LogInfo("antes llamado api extrae", "ConsultaPedidosDoctoLegal");
                    stUserName = "Integrado_BSALE";
                    if (BSALE_Number == "")
                    {
                        //TODOS LOS DOCUMENTOS DE VENTAS
                        sUrlRequest = "https://api.bsale.cl/v1/documents.json?emissiondaterange=[" + unixTimestamp1 + "," + unixTimestamp2 + "]&expand=[document_types,details,variant,client]&offset=" + offset + "&limit=50";
                        stUserName = "Integrado_BSALE";

                        //SOLO BOLETAS 
                        //sUrlRequest = "https://api.bsale.cl/v1/documents.json?emissiondaterange=[" + unixTimestamp1 + "," + unixTimestamp2 + "]&expand=[document_types,details,variant,client]&offset=" + offset + "&limit=50&documenttypeid=1";
                        //stUserName = "Integrado_BSALE_BOL";
                    }
                    else
                    {
                        sUrlRequest = "https://api.bsale.cl/v1/documents.json?emissiondaterange=[" + unixTimestamp1 + "," + unixTimestamp2 + "]&expand=[document_types,details,variant,client]&offset=" + offset + "&limit=50&number=" + BSALE_Number;
                    }

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(sUrlRequest);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));

                    //TOKEN DE PRODUCCION
                    client.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                    // List data response.
                    //LogInfo("ConsultaPedidosDoctoLegal_Get", sUrlRequest);
                    //LogInfo("ConsultaPedidosDoctoLegal_GetToken", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                    try
                    {
                        //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
                        //response = client.GetAsync(sUrlRequest).Result; //Ejecuta consulta de documentos 

                        //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
                        for (Int32 intentos_8 = 1; intentos_8 <= 3; intentos_8++)
                        {
                            response = client.GetAsync(sUrlRequest).Result; //Ejecuta consulta de documentos 

                            //Si la respuesta es un json válido y no un texto html
                            //if (response.Content.ToString().Contains("{") == true &&
                            //    response.Content.ToString().Contains("<html>") == false &&
                            //    response.Content.ToString().Contains("502 Bad Gateway") == false)
                            
                            if (response.IsSuccessStatusCode) // finalizo ok
                            {
                                break;
                            }
                            else
                            {
                                LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_8.ToString().Trim() +
                                                                     ", URL: " + sUrlRequest.Trim() +
                                                                     ", Respuesta BSALE: " + response.ToString().Trim());

                            }
                        } // ---------------------------------------------------------------------------------------------
                    }
                    catch (Exception e_)
                    {
                        LogInfo("ConsultaPedidosDoctoLegal_PostGet", "Error: " + e_.ToString(), true);
                    }

                    //Si finalizó correctamente -----
                    if (response.IsSuccessStatusCode)
                    {
                        string valor = response.Content.ReadAsStringAsync().Result;

                        PedidoDocumentosBSale = JsonConvert.DeserializeObject<PedidoDocumentosBSale>(valor);

                        _CantDocto = PedidoDocumentosBSale.count;
                        _limit = PedidoDocumentosBSale.limit;

                        foreach (var Document in PedidoDocumentosBSale.items)
                        {
                            /*CONTADOR DE REGISTROS EXTRAIDOS*/
                            ContadorOffset = ContadorOffset + 1;

                            //Si el tipo de documento esta dentro de los permitidos ==> Integra
                            if (stDoc_Type.IndexOf("'" + Document.document_type.id.ToString() + "'") >= 0)
                            {
                                //LogInfo("va por el documento:", Document.id.ToString()+ " - Tipo Docto: " + Document.document_type.id.ToString());

                                stTexto58 = Document.id.ToString();
                                //LogInfo("Dentro del For document_type:" + Document.document_type.id.ToString() + ", Number:" + Document.number.ToString(), "");

                                //Valida si el docto ya fue integrado, solo procesa documentos no integrados --------
                                if (WS_Integrador.Classes.model.InfF_Generador.ValDoctoIntegrado(Document.urlPublicView.Trim(), 
                                                                                                 Document.document_type.id.ToString(), 
                                                                                                 Document.number.ToString(), 
                                                                                                 Document.emissionDate.ToString()) == "0")
                                {
                                    LogInfo("ConsultaPedidosDoctoLegal", "Documento Por integrar:" + Document.document_type.id.ToString() + ", Number:" + Document.number.ToString());

                                    //Indica si debe concatenar el Tipo Docto Guia + '-' + Tipo de Guia ----- 
                                    if (ConfigurationManager.AppSettings["BSALE_Guia_TipoDespacho"].ToString() == "True")
                                    {
                                        //21.01.2021
                                        //Si el documento es de tipo guia de despacho
                                        //ejecuta api de shipping para obtener tipo de guia y sucursal de destino
                                        if (Document.document_type.id.ToString() == "7")
                                        {
                                            shipping_type_id = ""; destinationOffice_id = "";

                                            //LogInfo("Antes de BaseAddress", "");
                                            sUrlRequest = "https://api.bsale.cl/v1/shippings.json?documentid=" + Document.id.ToString() + "&expand=[guide,document_types,client,office,payments,details]";

                                            HttpClient client2 = new HttpClient();
                                            client2.BaseAddress = new Uri(sUrlRequest);

                                            client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                            client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                                            //TOKEN DE PRODUCCION
                                            client2.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                            try
                                            {
                                                //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
                                                //response = client2.GetAsync(sUrlRequest).Result;

                                                //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
                                                for (Int32 intentos_1 = 1; intentos_1 <= 3; intentos_1++)
                                                {
                                                    response = client2.GetAsync(sUrlRequest).Result;

                                                    //Si la respuesta es un json válido y no un texto html
                                                    //if (response.Content.ToString().Contains("{") == true &&
                                                    //    response.Content.ToString().Contains("<html>") == false &&
                                                    //    response.Content.ToString().Contains("502 Bad Gateway") == false)

                                                    if (response.IsSuccessStatusCode) // finalizo ok
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_1.ToString().Trim() +
                                                                                             ", URL: " + sUrlRequest.Trim() +
                                                                                             ", Respuesta BSALE: " + response.ToString().Trim());

                                                    }
                                                } // ---------------------------------------------------------------------------------------------

                                                valor = response.Content.ReadAsStringAsync().Result;

                                                ShippingBSale1 = JsonConvert.DeserializeObject<ShippingBSale>(valor);

                                                foreach (var ShippingDocument in ShippingBSale1.items)
                                                {
                                                    if (ShippingDocument.shipping_type.id.ToString() != null)
                                                    { shipping_type_id = ShippingDocument.shipping_type.id.ToString(); }
                                                    else
                                                    { shipping_type_id = "0"; }

                                                    //solo cuando es shipping_type_id=5; Traslados internos (no constituye venta)
                                                    destinationOffice_id = "0";
                                                    if (shipping_type_id == "5")
                                                    {
                                                        if (ShippingDocument.destinationOffice.id.ToString() != null)
                                                        { destinationOffice_id = ShippingDocument.destinationOffice.id.ToString(); }
                                                    }
                                                }
                                            }
                                            catch (AggregateException e)
                                            {
                                                LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Shipping. Error:" + e.ToString(), true);
                                                LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Shipping. URL:" + sUrlRequest.ToString(), true);
                                            }

                                            client2.Dispose();
                                        }
                                    }

                                    //OBTENER DATO TIPO COURIER
                                    sUrlRequest = "https://api.bsale.io/v1/markets/checkout/list.json?id_venta_documento_tributario=" + Document.id;

                                    HttpClient client3 = new HttpClient();
                                    client3.BaseAddress = new Uri(sUrlRequest);

                                    client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                    client3.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                                    //TOKEN DE PRODUCCION
                                    client3.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                    try
                                    {
                                        //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
                                        //response = client3.GetAsync(sUrlRequest).Result;

                                        //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
                                        for (Int32 intentos_2 = 1; intentos_2 <= 3; intentos_2++)
                                        {
                                            response = client3.GetAsync(sUrlRequest).Result;

                                            //Si la respuesta es un json válido y no un texto html
                                            //if (response.Content.ToString().Contains("{") == true &&
                                            //    response.Content.ToString().Contains("<html>") == false &&
                                            //    response.Content.ToString().Contains("502 Bad Gateway") == false)

                                            if (response.IsSuccessStatusCode) // finalizo ok
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_2.ToString().Trim() +
                                                                                     ", URL: " + sUrlRequest.Trim() +
                                                                                     ", Respuesta BSALE: " + response.ToString().Trim());

                                            }
                                        } // ---------------------------------------------------------------------------------------------

                                        valor = response.Content.ReadAsStringAsync().Result;

                                        TaxDocument = JsonConvert.DeserializeObject<TaxDocument>(valor);

                                        //Limpia variables -----
                                        clientNumber = "";
                                        clientStreetcheckout = "";
                                        clientCityZonecheckout = "";
                                        clientState = "";
                                        clientEmail = "";
                                        clientPhone = "";
                                        clientAddress = "";
                                        datoCourier = "";
                                        Glosacheckout = "";
                                        payProcesscheckout = "";
                                        retiroTienda = "0";
                                        shipping_id = "";
                                        idVentaMercadoLibre = "0";

                                        if (TaxDocument.data != null)
                                        {
                                            foreach (var item in TaxDocument.data)
                                            {
                                                clientNumber = item.clientBuildingNumber == null ? "" : item.clientBuildingNumber.ToString();
                                                clientStreetcheckout = item.clientStreet == null ? "" : item.clientStreet.ToString();
                                                clientCityZonecheckout = item.clientCityZone == null ? "" : item.clientCityZone.ToString();
                                                clientState = item.clientState == null ? "" : item.clientState.ToString();
                                                clientEmail = item.clientEmail == null ? "" : item.clientEmail.ToString();
                                                clientPhone = item.clientPhone == null ? "" : item.clientPhone.ToString();
                                                clientAddress = clientStreetcheckout + "," + clientNumber + ", " + clientCityZonecheckout;
                                                datoCourier = item.stName == null ? "" : item.stName.ToString();
                                                Glosacheckout = item.shippingComment == null ? "" : item.shippingComment.ToString();
                                                payProcesscheckout = item.payProcess == null ? "" : item.payProcess.ToString();
                                                retiroTienda = item.pickStoreId.ToString() == null ? "0" : item.pickStoreId.ToString();

                                                if (item.integrationDetail != null)
                                                {
                                                    shipping_id = item.integrationDetail.shipping_id == null ? "" : item.integrationDetail.shipping_id.ToString();
                                                    idVentaMercadoLibre = item.integrationDetail.id == null ? "0" : item.integrationDetail.id.ToString();
                                                }
                                                else
                                                {
                                                    shipping_id = "";
                                                }
                                            }
                                        }
                                    }
                                    catch (AggregateException e)
                                    {
                                        LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de TaxDocument. Error:" + e.ToString(), true);
                                        LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de TaxDocument. URL:" + sUrlRequest.ToString(), true);
                                    }
                                    //FIN OBTENER DATO TIPO COURIER

                                    //OBTENER GLOSA
                                    if (!string.IsNullOrEmpty(Document.attributes.href.ToString()))
                                    {
                                        sUrlRequest = Document.attributes.href.ToString();

                                        HttpClient client4 = new HttpClient();
                                        client4.BaseAddress = new Uri(sUrlRequest);

                                        client4.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        client4.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                                        //TOKEN DE PRODUCCION
                                        client4.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                        try
                                        {
                                            //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
                                            //response = client4.GetAsync(sUrlRequest).Result;

                                            //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
                                            for (Int32 intentos_3 = 1; intentos_3 <= 3; intentos_3++)
                                            {
                                                response = client4.GetAsync(sUrlRequest).Result;

                                                //Si la respuesta es un json válido y no un texto html
                                                //if (response.Content.ToString().Contains("{") == true &&
                                                //    response.Content.ToString().Contains("<html>") == false &&
                                                //    response.Content.ToString().Contains("502 Bad Gateway") == false)

                                                if (response.IsSuccessStatusCode) // finalizo ok
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_3.ToString().Trim() +
                                                                                         ", URL: " + sUrlRequest.Trim() +
                                                                                         ", Respuesta BSALE: " + response.ToString().Trim());

                                                }
                                            } // ---------------------------------------------------------------------------------------------

                                            valor = response.Content.ReadAsStringAsync().Result;

                                            DocumentAttributte = JsonConvert.DeserializeObject<DocumentAttributte>(valor);

                                            if (DocumentAttributte.items != null)
                                            {
                                                foreach (var item in DocumentAttributte.items)
                                                {
                                                    if (item.name != null)
                                                    {
                                                        if (item.name.Trim().ToUpper() == "NOTA".Trim().ToUpper())
                                                        {
                                                            Glosa = item.value == null ? "" : item.value.ToString();
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                        catch (AggregateException e)
                                        {
                                            LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de TaxDocument. Error:" + e.ToString(), true);
                                            LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de TaxDocument. URL:" + sUrlRequest.ToString(), true);
                                        }
                                    }

                                    //FIN OBTENER GLOSA

                                    //ASIGNA DATOS PARA INTEGRACION EN WMS
                                    stLinea = 0;
                                    stArchivo = DateTime.Now.ToString(("dd/MM/yyyy HH:mm:ss:fff")) + "_" + Document.emissionDate;
                                    dtFechaProcesoInt = DateTime.Now.ToString("yyyyMMdd");

                                    stTexto1 = "INT-DTE-BSALE";
                                    stTexto2 = DateTime.Now.ToString("yyyyMMdd HHmmss");
                                    stTexto3 = "A";
                                    stTexto4 = Document.urlPublicView == null ? "" : Document.urlPublicView.Trim(); //Dato1
                                    stTexto6 = stEmpId; // "1";
                                    stTexto7 = DateTime.Now.ToString("yyyyMMdd");  //PedidoDetalle.creationDate.ToString();
                                    stTexto8 = "Integrado_BSALE";
                                    stTexto9 = Document.emissionDate.ToString();
                                    stTexto10 = Document.document_type.id.ToString(); // TipoSolicitud

                                    //Indica si debe concatenar el Tipo Docto Guia + '-' + Tipo de Guia ----- 
                                    if (ConfigurationManager.AppSettings["BSALE_Guia_TipoDespacho"].ToString() == "True")
                                    {
                                        if (shipping_type_id.ToString() != "")
                                        { 
                                            stTexto10 = Document.document_type.id.ToString() + "-" + shipping_type_id.ToString();
                                        } // TipoSolicitud 
                                    }

                                    stTexto11 = Document.number.ToString();

                                    //LogInfo("Debug2", "");

                                    if (Document.document_type.useClient.ToString() == "0")
                                    {
                                        stTexto12 = "";
                                        stTexto13 = "";
                                        stTexto20 = "";
                                    }
                                    else if (Document.client == null)
                                    {
                                        stTexto12 = "";
                                        stTexto13 = "";
                                        stTexto20 = "";
                                    }
                                    else
                                    {
                                        if (Document.client.code != null)
                                        {
                                            stTexto12 = Document.client.code.ToString();
                                        }
                                        else
                                        {
                                            stTexto12 = "";
                                        }

                                        stTexto13 = Document.client.firstName == null ? "" : Document.client.firstName + " " + Document.client.lastName;
                                        documentEmail = Document.client.email == null ? "" : Document.client.email.ToString();
                                        // stTexto20 = Document.client.email == null ? "" : Document.client.email.ToString();
                                    }

                                    //LogInfo("Debug3", "");
                                    stTexto16 = "0";

                                    if (Document.client != null)
                                    {
                                        documentCity = Document.client.city == null ? "0" : Document.client.city.ToString();
                                        documentMunicipality = Document.client.municipality == null ? "0" : Document.client.municipality.ToString();
                                        documentPhone = Document.client.phone == null ? "" : Document.client.phone.ToString();
                                    }
                                    else
                                    {
                                        stTexto17 = "0";
                                        stTexto18 = "0";
                                        stTexto49 = "";
                                    }

                                    documentAddress = Document.address == null ? "" : Document.address.ToString() + "," + Document.municipality.ToString();

                                    stTexto17 = documentCity;
                                    stTexto18 = clientCityZonecheckout == string.Empty ? documentMunicipality : clientCityZonecheckout;
                                    stTexto49 = clientPhone == string.Empty ? documentPhone : clientPhone;
                                    stTexto19 = clientAddress == string.Empty ? documentAddress : clientAddress;
                                    stTexto19 = stTexto19.Replace("'", ""); // REEMPLAZAR LA COMILLA EN LA DIRECCION
                                    stTexto20 = clientEmail == string.Empty ? documentEmail : clientEmail;
                                    stTexto21 = datoCourier == null ? "" : datoCourier.ToString(); // datocourier
                                    stTexto22 = "1"; //MONEDA;
                                    stTexto23 = Document.document_type.id.ToString(); //TIPO DOCUMENTO;
                                    stTexto24 = Document.number.ToString(); //NUMERO DOCUMENTO
                                    stTexto25 = Document.emissionDate.ToString(); //FECHA DOCUMENTO
                                    stTexto26 = "BSALE";
                                    stTexto27 = Document.number.ToString();
                                    stTexto28 = Document.emissionDate.ToString();
                                    stTexto29 = "";
                                    stTexto30 = Glosa;//""; //Glosa
                                    stTexto45 = Document.totalAmount.ToString();
                                    stTexto47 = Document.office.id.ToString(); //oficina o bodega
                                    stTexto48 = destinationOffice_id.ToString();
                                    stTexto51 = clientStreetcheckout;
                                    stTexto52 = clientCityZonecheckout;
                                    stTexto53 = Glosacheckout;
                                    stTexto54 = shipping_id;
                                    stTexto55 = payProcesscheckout;
                                    stTexto56 = idVentaMercadoLibre;
                                    stTexto57 = retiroTienda;

                                    //LogInfo("Debug4", "");
                                    _CantLineas = Document.details.count;
                                    //if (_CantLineas >= 1)
                                    //{
                                    //    foreach (var pedidototal in PedidoDocumentosBSale.items[i].details.items)
                                    //    {
                                    //        string pedidototals = pedidototal.ToString();
                                    //        ItemDetalle ListaPedidoTags;
                                    //        ListaPedidoTags = JsonConvert.DeserializeObject<ItemDetalle>(pedidototals);

                                    //    }
                                    //    //stTexto47 = totalvtex.ToString();
                                    //}
                                    if (_CantLineas < 26)
                                    {
                                        foreach (var item in Document.details.items)
                                        {
                                            InsertaIntegracion = true; //Por defecto puede insertar

                                            //Si debe validar state de variante glosa -----
                                            if (ConfigurationManager.AppSettings["BSALE_Valida_Variante_Glosa"].ToString() == "True")
                                            {
                                                try
                                                {
                                                    //CONSULTA VARIANTE Y VALIDA ESTADO DISTINTO  A 55 PARA BAJAR A WMS
                                                    sUrlRequest = item.variant.href.ToString(); ;

                                                    HttpClient client5 = new HttpClient();
                                                    client5.BaseAddress = new Uri(sUrlRequest);

                                                    client5.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                                    client5.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                                                    client5.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                                    //response = client5.GetAsync(sUrlRequest).Result;

                                                    //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
                                                    for (Int32 intentos_4 = 1; intentos_4 <= 3; intentos_4++)
                                                    {
                                                        response = client5.GetAsync(sUrlRequest).Result;

                                                        //Si la respuesta es un json válido y no un texto html
                                                        //if (response.Content.ToString().Contains("{") == true &&
                                                        //    response.Content.ToString().Contains("<html>") == false &&
                                                        //    response.Content.ToString().Contains("502 Bad Gateway") == false)

                                                        if (response.IsSuccessStatusCode) // finalizo ok
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_4.ToString().Trim() +
                                                                                                 ", URL: " + sUrlRequest.Trim() +
                                                                                                 ", Respuesta BSALE: " + response.ToString().Trim());

                                                        }
                                                    } // ---------------------------------------------------------------------------------------------

                                                    valor = response.Content.ReadAsStringAsync().Result;

                                                    VariantsDetalle = JsonConvert.DeserializeObject<Variants>(valor);

                                                    //state <> 55 debe insertar
                                                    if (VariantsDetalle.state.ToString().Trim() != "55")
                                                    {
                                                        InsertaIntegracion = true;
                                                    }
                                                    else
                                                    {
                                                        InsertaIntegracion = false;
                                                    }
                                                }
                                                catch (AggregateException e)
                                                {
                                                    LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Variante. Error:" + e.ToString(), true);
                                                    LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Shipping. URL:" + sUrlRequest.ToString(), true);
                                                }

                                            } //FIN Si debe validar state de variante glosa -----

                                            if (item.variant.description.Trim() != "Costo de Envio" && InsertaIntegracion == true)
                                            {
                                                sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
                                                sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9 , Texto10 ,";
                                                sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
                                                sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29,";
                                                sqlQuery += "Texto30, Texto31, Texto32, Texto33, Texto34, Texto35, Texto36, Texto37, Texto38, Texto39,";
                                                sqlQuery += "Texto40, Texto41, Texto42, Texto43, Texto44, Texto45, Texto46, Texto47, Texto48, Texto49,";
                                                sqlQuery += "Texto50, Texto51, Texto52, Texto53, Texto54, Texto55, Texto56, Texto57) values (";

                                                stLinea = stLinea + 1;
                                                stTexto31 = stLinea.ToString();
                                                stTexto32 = item.variant.code.ToString();
                                                stTexto34 = "UN";
                                                stTexto35 = item.quantity.ToString();
                                                stTexto36 = item.id.ToString();
                                                stTexto38 = item.variant.code.Trim();
                                                stTexto41 = item.netUnitValue.ToString();
                                                stTexto42 = item.totalUnitValue.ToString();
                                                stTexto43 = "";
                                                stTexto44 = item.quantity.ToString();
                                                stTexto46 = item.id.ToString();
                                                stTexto50 = item.relatedDetailId.ToString();

                                                #region Carga Variables Insert

                                                sqlQuery += "'" + stArchivo.Trim() + "'";
                                                sqlQuery += ",'" + stUserName.Trim() + "'";
                                                sqlQuery += ",'" + dtFechaProcesoInt + "'";
                                                sqlQuery += ",'" + stLinea + "'";
                                                sqlQuery += ",'" + stTexto1.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto2.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto3.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto4.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto5.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto6.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto7.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto8.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto9.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto10.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto11.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto12.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto13.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto14.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto15.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto16.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto17.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto18.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto19.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto20.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto21.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto22.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto23.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto24.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto25.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto26.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto27.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto28.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto29.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto30.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto31.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto32.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto33.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto34.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto35.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto36.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto37.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto38.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto39.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto40.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto41.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto42.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto43.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto44.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto45.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto46.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto47.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto48.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto49.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto50.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto51.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto52.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto53.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto54.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto55.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto56.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto57.Trim().Replace("'", "") + "')";
                                                #endregion

                                                result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
                                            }

                                        } //FIN ciclo recorre Items
                                    }
                                    else
                                    {
                                        string s2 = ""; 
                                        //string s3 = "";
                                        //int variantcount = 0; 
                                        int Countvariant = 0, offsetvariant = 0, limitvariant = 0;
                                        string token = ConfigurationManager.AppSettings["TokenBsale"].ToString();
                                        string urlvariant = "https://api.bsale.cl/v1/documents/" + Document.id.ToString() + "/details.json?B";

                                        s2 = EjecutaAPI_BSale(urlvariant, token, 0, "ConsultaPedidosDoctoLegal");

                                        dynamic jsonvariant = JsonConvert.DeserializeObject(s2);
                                        JObject rssvariant = JObject.Parse(s2);

                                        Countvariant = (Int32)rssvariant["count"];
                                        limitvariant = (Int32)rssvariant["limit"];
                                        offsetvariant = (Int32)rssvariant["offset"];

                                        var vecesvariant = Math.Ceiling(Convert.ToDouble(Countvariant) / limitvariant);

                                        for (Int32 q = 0; q < vecesvariant; q++)
                                        {
                                            if (q > 0)
                                            {
                                                s2 = EjecutaAPI_BSale(urlvariant, token, offsetvariant, "ConsultaPedidosDoctoLegal");

                                                jsonvariant = JsonConvert.DeserializeObject(s2);
                                                rssvariant = JObject.Parse(s2);
                                            }

                                            for (Int32 i_var = 0; i_var < rssvariant["items"].Count(); i_var++)
                                            {
                                                InsertaIntegracion = true; //Por defecto puede insertar

                                                if (ConfigurationManager.AppSettings["BSALE_Valida_Variante_Glosa"].ToString() == "True")
                                                {
                                                    //CONSULTA VARIANTE Y VALIDA ESTADO DISTINTO  A 55 PARA BAJAR A WMS
                                                    try
                                                    {
                                                        sUrlRequest = rssvariant["items"][i_var]["variant"]["href"].ToString().Trim();

                                                        HttpClient client5 = new HttpClient();
                                                        client5.BaseAddress = new Uri(sUrlRequest);

                                                        client5.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                                        client5.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                                                        client5.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                                        //response = client5.GetAsync(sUrlRequest).Result;

                                                        //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
                                                        for (Int32 intentos_7 = 1; intentos_7 <= 3; intentos_7++)
                                                        {
                                                            response = client5.GetAsync(sUrlRequest).Result;

                                                            //Si la respuesta es un json válido y no un texto html
                                                            //if (response.Content.ToString().Contains("{") == true &&
                                                            //    response.Content.ToString().Contains("<html>") == false &&
                                                            //    response.Content.ToString().Contains("502 Bad Gateway") == false)

                                                            if (response.IsSuccessStatusCode) // finalizo ok
                                                            {
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_7.ToString().Trim() +
                                                                                                     ", URL: " + sUrlRequest.Trim() +
                                                                                                     ", Respuesta BSALE: " + response.ToString().Trim());

                                                            }
                                                        } // ---------------------------------------------------------------------------------------------

                                                        valor = response.Content.ReadAsStringAsync().Result;

                                                        VariantsDetalle = JsonConvert.DeserializeObject<Variants>(valor);

                                                        //state <> 55 debe insertar
                                                        if (VariantsDetalle.state.ToString().Trim() != "55")
                                                        {
                                                            InsertaIntegracion = true;
                                                        }
                                                        else
                                                        {
                                                            InsertaIntegracion = false;
                                                        }
                                                    }
                                                    catch (AggregateException e)
                                                    {
                                                        LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Variante. Error:" + e.ToString(), true);
                                                        LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Shipping. URL:" + sUrlRequest.ToString(), true);
                                                    }
                                                }

                                                if (rssvariant["items"][i_var]["variant"]["description"].ToString().Trim() != "Costo de Envio" && InsertaIntegracion == true)
                                                {
                                                    sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
                                                    sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9 , Texto10 ,";
                                                    sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
                                                    sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29,";
                                                    sqlQuery += "Texto30, Texto31, Texto32, Texto33, Texto34, Texto35, Texto36, Texto37, Texto38, Texto39,";
                                                    sqlQuery += "Texto40, Texto41, Texto42, Texto43, Texto44, Texto45, Texto46, Texto47, Texto48, Texto49,";
                                                    sqlQuery += "Texto50, Texto51, Texto52, Texto53, Texto54, Texto55, Texto56, Texto57) values (";

                                                    stLinea = stLinea + 1;
                                                    stTexto31 = stLinea.ToString();
                                                    stTexto32 = rssvariant["items"][i_var]["variant"]["code"].ToString();
                                                    stTexto34 = "UN";
                                                    stTexto35 = rssvariant["items"][i_var]["quantity"].ToString();
                                                    stTexto36 = rssvariant["items"][i_var]["id"].ToString();
                                                    stTexto38 = rssvariant["items"][i_var]["variant"]["code"].ToString();
                                                    stTexto41 = stTexto36 = rssvariant["items"][i_var]["netUnitValue"].ToString();
                                                    stTexto42 = stTexto36 = rssvariant["items"][i_var]["totalUnitValue"].ToString();
                                                    stTexto43 = "";
                                                    stTexto44 = rssvariant["items"][i_var]["quantity"].ToString();
                                                    stTexto46 = rssvariant["items"][i_var]["id"].ToString();
                                                    stTexto50 = rssvariant["items"][i_var]["relatedDetailId"].ToString();

                                                    #region CargaVariables
                                                    sqlQuery += "'" + stArchivo.Trim() + "'";
                                                    sqlQuery += ",'" + stUserName.Trim() + "'";
                                                    sqlQuery += ",'" + dtFechaProcesoInt + "'";
                                                    sqlQuery += ",'" + stLinea + "'";
                                                    sqlQuery += ",'" + stTexto1.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto2.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto3.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto4.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto5.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto6.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto7.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto8.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto9.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto10.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto11.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto12.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto13.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto14.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto15.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto16.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto17.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto18.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto19.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto20.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto21.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto22.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto23.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto24.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto25.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto26.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto27.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto28.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto29.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto30.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto31.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto32.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto33.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto34.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto35.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto36.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto37.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto38.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto39.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto40.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto41.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto42.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto43.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto44.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto45.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto46.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto47.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto48.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto49.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto50.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto51.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto52.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto53.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto54.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto55.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto56.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto57.Trim().Replace("'", "") + "')";
                                                    #endregion

                                                    result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
                                                }
                                            }
                                            offsetvariant = offsetvariant + limitvariant;
                                        }
                                    }

                                    DataSet myDataSet1 = new DataSet();
                                    string resultIntegracion = "0";
                                    myDataSet1 = Tmpt_SolImportDespacho.GeneraProceso(stArchivo, 
                                                                                      stUserName, 
                                                                                      DateTime.Parse(DateTime.Now.ToShortDateString()));

                                    if (myDataSet1.Tables.Count > 0)
                                    {
                                        int tabla1 = myDataSet1.Tables.Count;
                                        resultIntegracion = myDataSet1.Tables[tabla1 - 1].Rows[0]["Generacion"].ToString().Trim();
                                        if (resultIntegracion != "0")
                                        {
                                            //Console.WriteLine("PROCESA PEDIDO DE INTEGRACION");
                                            LogInfo("ConsultaPedidosDoctoLegal", "PROCESA PEDIDO DE INTEGRACION OK");
                                        }
                                        //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoWebhook("0", "5", decimal.Parse(stTexto58));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string valor = response.Content.ReadAsStringAsync().Result;
                        LogInfo("ConsultaPedidosDoctoLegal", "Error de Facturacion Api REST BSALE: " + response.Content.ReadAsStringAsync().Result, true);
                    }
                    offset = offset + 50;
                    if (offset < _CantDocto)
                    {
                        response.Dispose();
                        goto Reprocesar;
                    }

                    LogInfo("ConsultaPedidosDoctoLegal", "final proceso");

                    /*ACTUALIZA OFF EN BD*/
                    //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaOffSet(1, "Integrado_BSALE", ContadorOffset.ToString());
                }
            }
            catch (Exception ex)
            {
                LogInfo("ConsultaPedidosDoctoLegal", "Error: " + ex.Message, true);
            }
            return resultCons;

        }

        public static bool DescargaDoctosWebhook_BSALE() //ex ConsultaPedidosDoctoLegal2
        {
            LogInfo("DescargaDoctosWebhook_BSALE", "Inicio proceso", true);

            bool resultCons = false;
            try
            {
                string sqlQuery = "";
                string stArchivo = "";
                string stUserName = "";
                string dtFechaProcesoInt = "1900-01-01";
                int stLinea = 0;
                string stTexto1 = "", stTexto2 = "", stTexto3 = "", stTexto4 = "", stTexto5 = "", stTexto6 = "", stTexto7 = "", stTexto8 = "", stTexto9 = "";
                string stTexto10 = "", stTexto11 = "", stTexto12 = "", stTexto13 = "", stTexto14 = "", stTexto15 = "", stTexto16 = "", stTexto17 = "", stTexto18 = "", stTexto19 = "";
                string stTexto20 = "", stTexto21 = "", stTexto22 = "", stTexto23 = "", stTexto24 = "", stTexto25 = "", stTexto26 = "", stTexto27 = "", stTexto28 = "", stTexto29 = "";
                string stTexto30 = "", stTexto31 = "", stTexto32 = "", stTexto33 = "", stTexto34 = "", stTexto35 = "", stTexto36 = "", stTexto37 = "", stTexto38 = "", stTexto39 = "";
                string stTexto40 = "", stTexto41 = "", stTexto42 = "", stTexto43 = "", stTexto44 = "", stTexto45 = "", stTexto46 = "", stTexto47 = "", stTexto48 = "", stTexto49 = "";
                string stTexto50 = "", stTexto51 = "", stTexto52 = "", stTexto53 = "", stTexto54 = "", stTexto55 = "", stTexto56 = "", stTexto57 = "", stTexto58 = ""; //stTexto59 = "";

                string stDoc_Type = ConfigurationManager.AppSettings["BSALE_DocType"].ToString();
                string stEmpId = ConfigurationManager.AppSettings["EmpId"].ToString();

                string result = "";
                int _CantLineas = 0;

                string sUrlRequest = "";
                string DATA = "";
                string shipping_type_id = "";
                string destinationOffice_id = "";
                bool InsertaIntegracion = false;

                DataSet myDataSet = new DataSet();

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1

                //HttpResponseMessage response = new HttpResponseMessage();

                RestClient client_rest;
                RestRequest request;
                IRestResponse response_rest;

                PedidoBSale PedidoDocumentosBSale;
                ShippingBSale ShippingBSale1;
                TaxDocument TaxDocument;
                DocumentAttributte DocumentAttributte;
                Variants VariantsDetalle;

                HttpContent content = new StringContent(DATA);

                stUserName = "Integrado_BSALE";

                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ValEjecutaWebHooks();
                if (myData.Tables.Count > 0)
                {
                    for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                    {
                        string datoCourier = string.Empty;
                        string Glosa = string.Empty;
                        string Glosacheckout = string.Empty;
                        string shipping_id = string.Empty;
                        string clientStreetcheckout = string.Empty;
                        string clientCityZonecheckout = string.Empty;
                        string clientState = string.Empty;
                        string clientEmail = string.Empty;
                        string clientPhone = string.Empty;
                        string payProcesscheckout = string.Empty;
                        string idVentaMercadoLibre = string.Empty;
                        string documentEmail = string.Empty;
                        string documentPhone = string.Empty;
                        string documentCity = string.Empty;
                        string documentMunicipality = string.Empty;
                        string documentAddress = string.Empty;
                        string clientAddress = string.Empty;
                        string retiroTienda = "0";
                        string clientNumber = "";
                        int _CantLineasProce = 0;

                        sUrlRequest = "https://api.bsale.cl/v1/documents/" + myData.Tables[0].Rows[i]["DocumentBsaleId"].ToString().Trim() + ".json?expand=[document_types,details,variant,client]";
                        stTexto58 = myData.Tables[0].Rows[i]["Id"].ToString().Trim();

                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri(sUrlRequest);

                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                        //TOKEN DE PRODUCCION
                        client.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                        //////try
                        //////{
                        //////    //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
                        //////    response = client.GetAsync(sUrlRequest).Result;
                        //////}
                        //////catch (AggregateException e)
                        //////{
                        //////    LogInfo("ConsultaPedidosDoctoLegal_PostGet", e.ToString(), true);
                        //////}

                        //nuevo llamado a BSALE ----------------------------------------------
                        LogInfo("DescargaDoctosWebhook_BSALE", "nuevo llamado por REST", true);
                        LogInfo("DescargaDoctosWebhook_BSALE", sUrlRequest);
                        LogInfo("DescargaDoctosWebhook_BSALE", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                        string valor_rest = "";
                        string LlamadoOK = "";

                        try
                        {
                            client_rest = new RestClient(sUrlRequest);
                            client_rest.Timeout = -1;
                            request = new RestRequest(Method.GET);
                            request.AddHeader("Content-Type", "application/json");
                            request.AddHeader("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());
                            //IRestResponse response_rest = client_rest.Execute(request);
                            response_rest = client_rest.Execute(request);

                            HttpStatusCode CodigoRetorno = response_rest.StatusCode;
                            JObject rss = JObject.Parse(response_rest.Content); //recupera json de retorno

                            valor_rest = response_rest.Content;

                            //Si no encuentra el documento en BSale lo marca para no volver a procesarlo ---
                            if (response_rest.StatusCode.Equals(HttpStatusCode.NotFound))
                            {
                                LlamadoOK = "";

                                if (rss.ToString().Contains("error") == true)
                                {
                                    if (rss["error"].ToString().Trim() == "document not found")
                                    {
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoWebhook(stTexto58, "5", 0);
                                        LogInfo("DescargaDoctosWebhook_BSALE_llamadoREST", "El Documento id " + myData.Tables[0].Rows[i]["DocumentBsaleId"].ToString().Trim() + 
                                                                                           " no existe en BSale", true);
                                    }
                                }
                            }

                            //--------------------------------------------------------
                            if (response_rest.StatusCode.Equals(HttpStatusCode.OK))
                            {
                                LlamadoOK = "OK";
                            }                                
                            else
                            {
                                LlamadoOK = "";
                            }
                        }
                        catch (AggregateException e)
                        {
                            LogInfo("DescargaDoctosWebhook_BSALE_llamadoREST", e.ToString(), true);
                        }
                        //FIN nuevo llamado a BSALE ----------------------------------------------


                        //HttpStatusCode CodigoRetorno = responseStock.StatusCode;

                        //Si finalizó OK --------------------------
                        if (LlamadoOK == "OK")
                        //if (response_rest.StatusCode.Equals(HttpStatusCode.OK))
                        //if (response_rest.IsSuccessStatusCode)
                        {
                            LogInfo("DescargaDoctosWebhook_BSALE", "nuevo llamado REST OK", true);

                            //string valor = response.Content.ReadAsStringAsync().Result;
                            string valor = valor_rest;

                            PedidoDocumentosBSale = JsonConvert.DeserializeObject<PedidoBSale>(valor);

                            if (stDoc_Type.IndexOf("'" + PedidoDocumentosBSale.document_type.id.ToString().Trim() + "'") >= 0)
                            {
                                // ESTADO DEL PEDIDO 0=ACTIVO ----------------
                                if (PedidoDocumentosBSale.state == 0)
                                {
                                    //if (WS_Integrador.Classes.model.InfF_Generador.ValDoctoIntegrado(PedidoDocumentosBSale.urlPublicView.Trim(), PedidoDocumentosBSale.document_type.id.ToString(), PedidoDocumentosBSale.number.ToString(), PedidoDocumentosBSale.emissionDate.ToString()) == "0")
                                    //{

                                    //Si el documento es de tipo guia de despacho
                                    //ejecuta api de shipping para obtener tipo de guia y sucursal de destino
                                    if (PedidoDocumentosBSale.document_type.id.ToString() == "7")
                                    {
                                        shipping_type_id = ""; destinationOffice_id = "";

                                        sUrlRequest = "https://api.bsale.cl/v1/shippings.json?documentid=" + PedidoDocumentosBSale.id.ToString() + "&expand=[guide,document_types,client,office,payments,details]";

                                        HttpClient client2 = new HttpClient();
                                        client2.BaseAddress = new Uri(sUrlRequest);

                                        client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                                        //TOKEN DE PRODUCCION
                                        client2.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                        try
                                        {
                                            //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
                                            //response = client2.GetAsync(sUrlRequest).Result;
                                            //valor = response.Content.ReadAsStringAsync().Result;

                                            //nuevo llamado ---------
                                            client_rest = new RestClient(sUrlRequest);
                                            client_rest.Timeout = -1;
                                            request = new RestRequest(Method.GET);
                                            request.AddHeader("Content-Type", "application/json");
                                            request.AddHeader("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());
                                            response_rest = client_rest.Execute(request);
                                            valor = response_rest.Content;
                                            //FIN nuevo llamado ---------

                                            ShippingBSale1 = JsonConvert.DeserializeObject<ShippingBSale>(valor);

                                            foreach (var ShippingDocument in ShippingBSale1.items)
                                            {
                                                if (ShippingDocument.shipping_type.id.ToString() != null)
                                                { shipping_type_id = ShippingDocument.shipping_type.id.ToString(); }
                                                else
                                                { shipping_type_id = "0"; }

                                                //solo cuando es shipping_type_id=5; Traslados internos (no constituye venta)
                                                destinationOffice_id = "0";
                                                if (shipping_type_id == "5")
                                                {
                                                    if (ShippingDocument.destinationOffice.id.ToString() != null)
                                                    { destinationOffice_id = ShippingDocument.destinationOffice.id.ToString(); }
                                                }
                                            }
                                        }
                                        catch (AggregateException e)
                                        {
                                            LogInfo("Obteniendo informacion de Shipping. Error:", e.ToString(), true);
                                            LogInfo("Obteniendo informacion de Shipping. URL:", sUrlRequest.ToString(), true);
                                        }

                                        client2.Dispose();
                                    }

                                    //OBTENER DATO TIPO COURIER
                                    sUrlRequest = "https://api.bsale.io/v1/markets/checkout/list.json?id_venta_documento_tributario=" + PedidoDocumentosBSale.id;

                                    HttpClient client3 = new HttpClient();
                                    client3.BaseAddress = new Uri(sUrlRequest);

                                    client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                    client3.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));

                                    //TOKEN DE PRODUCCION
                                    client3.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                    try
                                    {
                                        ////response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
                                        //response = client3.GetAsync(sUrlRequest).Result;
                                        //valor = response.Content.ReadAsStringAsync().Result;

                                        //nuevo llamado ---------
                                        client_rest = new RestClient(sUrlRequest);
                                        client_rest.Timeout = -1;
                                        request = new RestRequest(Method.GET);
                                        request.AddHeader("Content-Type", "application/json");
                                        request.AddHeader("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());
                                        response_rest = client_rest.Execute(request);
                                        valor = response_rest.Content;
                                        //FIN nuevo llamado ---------

                                        //LogInfo("DescargaDoctosWebhook_BSALE", "Ruta error antes de deserializar :" + sUrlRequest);
                                        //LogInfo("DescargaDoctosWebhook_BSALE", valor.ToString());

                                        TaxDocument = JsonConvert.DeserializeObject<TaxDocument>(valor);

                                        //Limpia variables -----
                                        clientNumber = "";
                                        clientStreetcheckout = "";
                                        clientCityZonecheckout = "";
                                        clientState = "";
                                        clientEmail = "";
                                        clientPhone = "";
                                        clientAddress = "";
                                        datoCourier = "";
                                        Glosacheckout = "";
                                        payProcesscheckout = "";
                                        retiroTienda = "0";
                                        shipping_id = "";
                                        idVentaMercadoLibre = "0";

                                        if (TaxDocument.data != null)
                                        {
                                            foreach (var item in TaxDocument.data)
                                            {
                                                clientNumber = item.clientBuildingNumber == null ? "" : item.clientBuildingNumber.ToString();
                                                clientStreetcheckout = item.clientStreet == null ? "" : item.clientStreet.ToString();
                                                clientCityZonecheckout = item.clientCityZone == null ? "" : item.clientCityZone.ToString();
                                                clientState = item.clientState == null ? "" : item.clientState.ToString();
                                                clientEmail = item.clientEmail == null ? "" : item.clientEmail.ToString();
                                                clientPhone = item.clientPhone == null ? "" : item.clientPhone.ToString();
                                                clientAddress = clientStreetcheckout + "," + clientNumber + ", " + clientCityZonecheckout;
                                                datoCourier = item.stName == null ? "" : item.stName.ToString();
                                                Glosacheckout = item.shippingComment == null ? "" : item.shippingComment.ToString();
                                                payProcesscheckout = item.payProcess == null ? "" : item.payProcess.ToString();
                                                retiroTienda = item.pickStoreId.ToString() == null ? "0" : item.pickStoreId.ToString();

                                                if (item.integrationDetail != null)
                                                {
                                                    shipping_id = item.integrationDetail.shipping_id == null ? "" : item.integrationDetail.shipping_id.ToString();
                                                    idVentaMercadoLibre = item.integrationDetail.id == null ? "0" : item.integrationDetail.id.ToString();
                                                }
                                                else
                                                {
                                                    shipping_id = "";
                                                }
                                            }
                                        }
                                    }
                                    catch (AggregateException e)
                                    {
                                        LogInfo("DescargaDoctosWebhook_BSALE", "Obteniendo informacion de TaxDocument. Error:" + e.ToString(), true);
                                        LogInfo("DescargaDoctosWebhook_BSALE", "Obteniendo informacion de TaxDocument. URL:" + sUrlRequest.ToString(), true);
                                    }

                                    //OBTENER DATO TIPO COURIER
                                    // OBTENER GLOSA
                                    if (!string.IsNullOrEmpty(PedidoDocumentosBSale.attributes.href.ToString()))
                                    {
                                        sUrlRequest = PedidoDocumentosBSale.attributes.href.ToString();

                                        HttpClient client4 = new HttpClient();
                                        client4.BaseAddress = new Uri(sUrlRequest);

                                        client4.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        client4.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                                        client4.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                        try
                                        {
                                            ////response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
                                            //response = client4.GetAsync(sUrlRequest).Result;
                                            //valor = response.Content.ReadAsStringAsync().Result;

                                            //nuevo llamado ---------
                                            client_rest = new RestClient(sUrlRequest);
                                            client_rest.Timeout = -1;
                                            request = new RestRequest(Method.GET);
                                            request.AddHeader("Content-Type", "application/json");
                                            request.AddHeader("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());
                                            response_rest = client_rest.Execute(request);
                                            valor = response_rest.Content;
                                            //FIN nuevo llamado ---------

                                            DocumentAttributte = JsonConvert.DeserializeObject<DocumentAttributte>(valor);

                                            if (DocumentAttributte.items != null)
                                            {
                                                foreach (var item in DocumentAttributte.items)
                                                {
                                                    if (item.name != null)
                                                    {
                                                        if (item.name.Trim().ToUpper() == "NOTA".Trim().ToUpper())
                                                        {
                                                            Glosa = item.value == null ? "" : item.value.ToString();
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                        catch (AggregateException e)
                                        {
                                            LogInfo("DescargaDoctosWebhook_BSALE", "Obteniendo informacion de TaxDocument. Error:" + e.ToString(), true);
                                            LogInfo("DescargaDoctosWebhook_BSALE", "Obteniendo informacion de TaxDocument. URL:" + sUrlRequest.ToString(), true);
                                        }
                                    }

                                    //FIN OBTENER GLOSA 

                                    //ASIGNA DATOS PARA INTEGRACION EN WMS
                                    stLinea = 0;
                                    stArchivo = DateTime.Now.ToString(("dd/MM/yyyy HH:mm:ss:fff")) + "_" + PedidoDocumentosBSale.emissionDate;
                                    dtFechaProcesoInt = DateTime.Now.ToString("yyyyMMdd");

                                    stTexto1 = "INT-DTE-BSALE";
                                    stTexto2 = DateTime.Now.ToString("yyyyMMdd HHmmss");
                                    stTexto3 = "A";
                                    stTexto4 = PedidoDocumentosBSale.urlPublicView == null ? "" : PedidoDocumentosBSale.urlPublicView.Trim(); //Dato1
                                    stTexto6 = stEmpId; // "1";
                                    stTexto7 = DateTime.Now.ToString("yyyyMMdd");  //PedidoDetalle.creationDate.ToString();
                                    stTexto8 = "Integrado_BSALE";
                                    stTexto9 = PedidoDocumentosBSale.emissionDate.ToString();
                                    stTexto10 = PedidoDocumentosBSale.document_type.id.ToString(); // TipoSolicitud

                                    if (shipping_type_id.ToString() != "")
                                    { stTexto10 = PedidoDocumentosBSale.document_type.id.ToString() + "-" + shipping_type_id.ToString(); } // TipoSolicitud 

                                    stTexto11 = PedidoDocumentosBSale.number.ToString();

                                    if (PedidoDocumentosBSale.document_type.useClient.ToString() == "0")
                                    {
                                        stTexto12 = "";
                                        stTexto13 = "";
                                        stTexto20 = "";
                                    }
                                    else if (PedidoDocumentosBSale.client == null)
                                    {
                                        stTexto12 = "";
                                        stTexto13 = "";
                                        stTexto20 = "";
                                    }
                                    else
                                    {
                                        if (PedidoDocumentosBSale.client.code != null)
                                        {
                                            stTexto12 = PedidoDocumentosBSale.client.code.ToString();
                                        }
                                        else
                                        {
                                            stTexto12 = "";
                                        }

                                        stTexto13 = PedidoDocumentosBSale.client.firstName == null ? "" : PedidoDocumentosBSale.client.firstName + " " + PedidoDocumentosBSale.client.lastName;
                                        documentEmail = PedidoDocumentosBSale.client.email == null ? "" : PedidoDocumentosBSale.client.email.ToString();
                                    }

                                    stTexto16 = "0";

                                    if (PedidoDocumentosBSale.client != null)
                                    {
                                        documentCity = PedidoDocumentosBSale.client.city == null ? "0" : PedidoDocumentosBSale.client.city.ToString();
                                        documentMunicipality = PedidoDocumentosBSale.client.municipality == null ? "0" : PedidoDocumentosBSale.client.municipality.ToString();
                                        documentPhone = PedidoDocumentosBSale.client.phone == null ? "" : PedidoDocumentosBSale.client.phone.ToString();
                                    }
                                    else
                                    {
                                        stTexto17 = "0";
                                        stTexto18 = "0";
                                        stTexto49 = "";
                                    }

                                    documentAddress = PedidoDocumentosBSale.address == null ? "" : PedidoDocumentosBSale.address.ToString() + "," + PedidoDocumentosBSale.municipality.ToString();

                                    stTexto17 = documentCity;
                                    stTexto18 = clientCityZonecheckout == string.Empty ? documentMunicipality : clientCityZonecheckout;
                                    stTexto49 = clientPhone == string.Empty ? documentPhone : clientPhone;
                                    stTexto19 = clientAddress == string.Empty ? documentAddress : clientAddress;
                                    stTexto19 = stTexto19.Replace("'", ""); // REEMPLAZAR LA COMILLA EN LA DIRECCION
                                    stTexto20 = clientEmail == string.Empty ? documentEmail : clientEmail;
                                    stTexto21 = datoCourier == null ? "" : datoCourier.ToString(); // datocourier
                                    stTexto22 = "1"; //MONEDA;
                                    stTexto23 = PedidoDocumentosBSale.document_type.id.ToString(); //TIPO DOCUMENTO;
                                    stTexto24 = PedidoDocumentosBSale.number.ToString(); //NUMERO DOCUMENTO
                                    stTexto25 = PedidoDocumentosBSale.emissionDate.ToString(); //FECHA DOCUMENTO
                                    stTexto26 = "BSALE";
                                    stTexto27 = PedidoDocumentosBSale.number.ToString();
                                    stTexto28 = PedidoDocumentosBSale.emissionDate.ToString();
                                    stTexto29 = "";
                                    stTexto30 = Glosa;//""; //Glosa
                                    stTexto45 = PedidoDocumentosBSale.totalAmount.ToString();
                                    stTexto47 = PedidoDocumentosBSale.office.id.ToString(); //oficina o bodega
                                    stTexto48 = destinationOffice_id.ToString();
                                    stTexto51 = clientStreetcheckout;
                                    stTexto52 = clientCityZonecheckout;
                                    stTexto53 = Glosacheckout;
                                    stTexto54 = shipping_id;
                                    stTexto55 = payProcesscheckout;
                                    stTexto56 = idVentaMercadoLibre;
                                    stTexto57 = retiroTienda;

                                    //LogInfo("Debug4", "");
                                    _CantLineas = PedidoDocumentosBSale.details.count;

                                    if (_CantLineas < 26)
                                    {
                                        foreach (var item in PedidoDocumentosBSale.details.items)
                                        {
                                            InsertaIntegracion = true; //Por defecto puede insertar

                                            //Si debe validar state de variante glosa, se activa para incluir los costos de envio -----
                                            if (ConfigurationManager.AppSettings["BSALE_Valida_Variante_Glosa"].ToString() == "True")
                                            {
                                                try
                                                {
                                                    //CONSULTA VARIANTE Y VALIDA ESTADO DISTINTO  A 55 PARA BAJAR A WMS
                                                    sUrlRequest = item.variant.href.ToString(); ;

                                                    HttpClient client5 = new HttpClient();
                                                    client5.BaseAddress = new Uri(sUrlRequest);

                                                    client5.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                                    client5.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                                                    client5.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                                    //response = client5.GetAsync(sUrlRequest).Result;
                                                    //valor = response.Content.ReadAsStringAsync().Result;

                                                    //nuevo llamado ---------
                                                    client_rest = new RestClient(sUrlRequest);
                                                    client_rest.Timeout = -1;
                                                    request = new RestRequest(Method.GET);
                                                    request.AddHeader("Content-Type", "application/json");
                                                    request.AddHeader("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());
                                                    response_rest = client_rest.Execute(request);
                                                    valor = response_rest.Content;
                                                    //FIN nuevo llamado ---------

                                                    VariantsDetalle = JsonConvert.DeserializeObject<Variants>(valor);

                                                    //state <> 55 debe insertar
                                                    if (VariantsDetalle.state.ToString().Trim() != "55")
                                                    {
                                                        InsertaIntegracion = true;
                                                    }
                                                    else
                                                    {
                                                        InsertaIntegracion = false;
                                                    }

                                                }
                                                catch (AggregateException e)
                                                {
                                                    LogInfo("DescargaDoctosWebhook_BSALE", "Obteniendo informacion de Variante. Error:" + e.ToString());
                                                    LogInfo("DescargaDoctosWebhook_BSALE", "Obteniendo informacion de Shipping. URL:" + sUrlRequest.ToString());
                                                }

                                            } //FIN Si debe validar state de variante glosa -----

                                            if (item.variant.description.Trim() != "Costo de Envio" && InsertaIntegracion == true)
                                            {
                                                _CantLineasProce = 1;
                                                sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
                                                sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9 , Texto10,";
                                                sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
                                                sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29, Texto30,";
                                                sqlQuery += "Texto31, Texto32, Texto33, Texto34, Texto35, Texto36, Texto37, Texto38, Texto39, Texto40,";
                                                sqlQuery += "Texto41, Texto42, Texto43, Texto44, Texto45, Texto46, Texto47, Texto48, Texto49, Texto50,";
                                                sqlQuery += "Texto51, Texto52, Texto53, Texto54, Texto55, Texto56, Texto57, Texto58) values (";

                                                stLinea = stLinea + 1;
                                                stTexto31 = stLinea.ToString();
                                                stTexto32 = item.variant.code.ToString();
                                                stTexto34 = "UN";
                                                stTexto35 = item.quantity.ToString();
                                                stTexto36 = item.id.ToString();
                                                stTexto38 = item.variant.code.Trim();
                                                stTexto41 = item.netUnitValue.ToString();
                                                stTexto42 = item.totalUnitValue.ToString();
                                                stTexto43 = "";
                                                stTexto44 = item.quantity.ToString();
                                                stTexto46 = item.id.ToString();
                                                stTexto50 = item.relatedDetailId.ToString();

                                                sqlQuery += "'" + stArchivo.Trim() + "'";
                                                sqlQuery += ",'" + stUserName.Trim() + "'";
                                                sqlQuery += ",'" + dtFechaProcesoInt + "'";
                                                sqlQuery += ",'" + stLinea + "'";
                                                sqlQuery += ",'" + stTexto1.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto2.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto3.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto4.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto5.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto6.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto7.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto8.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto9.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto10.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto11.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto12.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto13.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto14.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto15.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto16.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto17.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto18.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto19.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto20.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto21.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto22.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto23.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto24.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto25.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto26.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto27.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto28.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto29.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto30.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto31.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto32.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto33.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto34.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto35.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto36.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto37.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto38.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto39.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto40.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto41.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto42.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto43.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto44.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto45.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto46.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto47.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto48.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto49.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto50.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto51.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto52.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto53.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto54.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto55.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto56.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto57.Trim().Replace("'", "") + "'";
                                                sqlQuery += ",'" + stTexto58.Trim().Replace("'", "") + "')";

                                                result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
                                            }

                                        }  //FIN ciclo recorre Items
                                    }
                                    else
                                    {
                                        string s2 = "";
                                        //string s3 = "";
                                        //int variantcount = 0;
                                        int Countvariant = 0;
                                        int offsetvariant = 0;
                                        int limitvariant = 0;
                                        string token = ConfigurationManager.AppSettings["TokenBsale"].ToString();
                                        string urlvariant = "https://api.bsale.cl/v1/documents/" + PedidoDocumentosBSale.id.ToString() + "/details.json?B";

                                        s2 = EjecutaAPI_BSale(urlvariant, token, 0, "DescargaDoctosWebhook_BSALE");

                                        dynamic jsonvariant = JsonConvert.DeserializeObject(s2);
                                        JObject rssvariant = JObject.Parse(s2);

                                        Countvariant = (Int32)rssvariant["count"];
                                        limitvariant = (Int32)rssvariant["limit"];
                                        offsetvariant = (Int32)rssvariant["offset"];

                                        var vecesvariant = Math.Ceiling(Convert.ToDouble(Countvariant) / limitvariant);

                                        for (Int32 q = 0; q < vecesvariant; q++)
                                        {
                                            if (q > 0)
                                            {
                                                s2 = EjecutaAPI_BSale(urlvariant, token, offsetvariant, "DescargaDoctosWebhook_BSALE");

                                                jsonvariant = JsonConvert.DeserializeObject(s2);
                                                rssvariant = JObject.Parse(s2);

                                            }
                                            for (Int32 i_var = 0; i_var < rssvariant["items"].Count(); i_var++)
                                            {
                                                InsertaIntegracion = true; //Por defecto puede insertar

                                                //Si debe validar state de variante glosa -----
                                                if (ConfigurationManager.AppSettings["BSALE_Valida_Variante_Glosa"].ToString() == "True")
                                                {
                                                    //CONSULTA VARIANTE Y VALIDA ESTADO DISTINTO  A 55 PARA BAJAR A WMS
                                                    try
                                                    {
                                                        sUrlRequest = rssvariant["items"][i_var]["variant"]["href"].ToString().Trim();

                                                        HttpClient client5 = new HttpClient();
                                                        client5.BaseAddress = new Uri(sUrlRequest);

                                                        client5.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                                        client5.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
                                                        client5.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                                        //response = client5.GetAsync(sUrlRequest).Result;
                                                        //valor = response.Content.ReadAsStringAsync().Result;

                                                        //nuevo llamado ---------
                                                        client_rest = new RestClient(sUrlRequest);
                                                        client_rest.Timeout = -1;
                                                        request = new RestRequest(Method.GET);
                                                        request.AddHeader("Content-Type", "application/json");
                                                        request.AddHeader("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());
                                                        response_rest = client_rest.Execute(request);
                                                        valor = response_rest.Content;
                                                        //FIN nuevo llamado ---------

                                                        VariantsDetalle = JsonConvert.DeserializeObject<Variants>(valor);

                                                        //state <> 55 debe insertar
                                                        if (VariantsDetalle.state.ToString().Trim() != "55")
                                                        {
                                                            InsertaIntegracion = true;
                                                        }
                                                        else
                                                        {
                                                            InsertaIntegracion = false;
                                                        }
                                                    }
                                                    catch (AggregateException e)
                                                    {
                                                        LogInfo("DescargaDoctosWebhook_BSALE", "Obteniendo informacion de Variante. Error:" + e.ToString());
                                                        LogInfo("DescargaDoctosWebhook_BSALE", "Obteniendo informacion de Shipping. URL:" + sUrlRequest.ToString());
                                                    }

                                                } //FIN Si debe validar state de variante glosa -----

                                                if (rssvariant["items"][i_var]["variant"]["description"].ToString().Trim() != "Costo de Envio" && InsertaIntegracion == true)
                                                {
                                                    _CantLineasProce = 1;
                                                    sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
                                                    sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9, Texto10,";
                                                    sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
                                                    sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29, Texto30,";
                                                    sqlQuery += "Texto31, Texto32, Texto33, Texto34, Texto35, Texto36, Texto37, Texto38, Texto39, Texto40,";
                                                    sqlQuery += "Texto41, Texto42, Texto43, Texto44, Texto45, Texto46, Texto47, Texto48, Texto49, Texto50,";
                                                    sqlQuery += "Texto51, Texto52, Texto53, Texto54, Texto55, Texto56, Texto57) values (";

                                                    stLinea = stLinea + 1;
                                                    stTexto31 = stLinea.ToString();
                                                    stTexto32 = rssvariant["items"][i_var]["variant"]["code"].ToString();
                                                    stTexto34 = "UN";
                                                    stTexto35 = rssvariant["items"][i_var]["quantity"].ToString();
                                                    stTexto36 = rssvariant["items"][i_var]["id"].ToString();
                                                    stTexto38 = rssvariant["items"][i_var]["variant"]["code"].ToString();
                                                    stTexto41 = stTexto36 = rssvariant["items"][i_var]["netUnitValue"].ToString();
                                                    stTexto42 = stTexto36 = rssvariant["items"][i_var]["totalUnitValue"].ToString();
                                                    stTexto43 = "";
                                                    stTexto44 = rssvariant["items"][i_var]["quantity"].ToString();
                                                    stTexto46 = rssvariant["items"][i_var]["id"].ToString();
                                                    stTexto50 = rssvariant["items"][i_var]["relatedDetailId"].ToString();

                                                    sqlQuery += "'" + stArchivo.Trim() + "'";
                                                    sqlQuery += ",'" + stUserName.Trim() + "'";
                                                    sqlQuery += ",'" + dtFechaProcesoInt + "'";
                                                    sqlQuery += ",'" + stLinea + "'";
                                                    sqlQuery += ",'" + stTexto1.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto2.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto3.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto4.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto5.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto6.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto7.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto8.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto9.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto10.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto11.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto12.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto13.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto14.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto15.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto16.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto17.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto18.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto19.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto20.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto21.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto22.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto23.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto24.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto25.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto26.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto27.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto28.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto29.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto30.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto31.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto32.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto33.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto34.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto35.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto36.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto37.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto38.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto39.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto40.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto41.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto42.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto43.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto44.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto45.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto46.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto47.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto48.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto49.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto50.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto51.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto52.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto53.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto54.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto55.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto56.Trim().Replace("'", "") + "'";
                                                    sqlQuery += ",'" + stTexto57.Trim().Replace("'", "") + "')";

                                                    result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
                                                }
                                            }
                                            offsetvariant = offsetvariant + limitvariant;
                                        }

                                    }

                                    if (_CantLineasProce != 0)
                                    {
                                        DataSet myDataSet1 = new DataSet();
                                        string resultIntegracion = "0";

                                        myDataSet1 = Tmpt_SolImportDespacho.GeneraProceso(stArchivo,
                                                                                          stUserName,
                                                                                          DateTime.Parse(DateTime.Now.ToShortDateString()));
                                        if (myDataSet1.Tables.Count > 0)
                                        {
                                            int tabla1 = myDataSet1.Tables.Count;
                                            resultIntegracion = myDataSet1.Tables[tabla1 - 1].Rows[0]["Generacion"].ToString().Trim();
                                            if (resultIntegracion != "0")
                                            {
                                                //Console.WriteLine("PROCESA PEDIDO DE INTEGRACION");
                                                LogInfo("DescargaDoctosWebhook_BSALE", "PROCESA PEDIDO DE INTEGRACION OK - Webhook");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        /*SIN LINEAS PARA PROCESAR */
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoWebhook(stTexto58, "8", 0);
                                    }
                                    //}
                                }
                                else if (PedidoDocumentosBSale.state == 1)
                                {
                                    //si Estado pedido = 1 (Inactivo) -------------------------
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoWebhook(stTexto58, "9", 0);
                                }
                            }
                            else
                            {
                                //Tipo documento no esta en la lista de Tipos de Documento que se estan descargando desde BSALE--------
                                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoWebhook(stTexto58, "5", 0);
                            }
                        }
                        else
                        {
                            //string valor = response.Content.ReadAsStringAsync().Result;
                            //string valor = ""; // response_rest.Content;

                            //LogInfo("DescargaDoctosWebhook_BSALE", "Error de Facturacin Api REst BSALE: " + response_rest.Content.ReadAsStringAsync().Result, true);
                            LogInfo("DescargaDoctosWebhook_BSALE", "Error de Facturacin Api REst BSALE: " + valor_rest, true);
                            //FIN nuevo llamado ---------
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogInfo("DescargaDoctosWebhook_BSALE", "Error:" + ex.Message, true);
            }
            return resultCons;
        }

        //Este mensaje depende de la configuracion para ocultar o no los mensajes de Log
        //Por defecto los mensajes se ocultaran cuando RegistroArchivoLog = "NO"
        //Si el mensaje se indica MostrarSiempre lo mostrara independiente lo que diga la Key RegistroArchivoLog 
        public static void LogInfo(string sMessage, string motivo, bool MostrarSiempre = false)
        {
            try
            {
                //Si la key indica grabar log o los mensajes debe mostrarlos siempre, graba el log
                if (ConfigurationManager.AppSettings["RegistroArchivoLog"].ToString() == "SI" ||
                    ConfigurationManager.AppSettings["RegistroArchivoLog"].ToString() == "0" ||
                    MostrarSiempre == true)
                {
                    StringBuilder html = new StringBuilder();
                    string FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\Log_Integrador_" + DateTime.Now.ToString("MMdd") + ".txt";

                    html.Append("[" + sMessage.ToString() + "]. Fecha/Hora " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ". " + motivo.Trim());
                    html.Append(Environment.NewLine);
                    StreamWriter strStreamWriter = File.AppendText(FilePath);
                    strStreamWriter.Write(html.ToString());
                    strStreamWriter.Close();
                }
            }
            catch (Exception e)
            {
                LogInfo(e.Message, "Creación de Log.");
            }
        }

        //public static void LogInfo(string sMessage, string motivo)
        //{
        //    try
        //    {
        //        StringBuilder html = new StringBuilder();
        //        string FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\WinConsumeBsale_" + DateTime.Now.ToString("MMdd") + ".txt";
        //        //string FilePath = "C:\\Broadcast\\WinConsumeBsale_MeLoLLevo_" + DateTime.Now.ToShortDateString().Replace("/", "") + ".log";

        //        //html.Append(Environment.NewLine);				
        //        html.Append("- Log Servicio Consumo WebSs [" + sMessage.ToString() + "]. Razón: " + sMessage + " General " + " Lugar: " + motivo + " Fecha y Hora " + DateTime.Now.ToShortDateString() + " a las " + DateTime.Now.ToShortTimeString());
        //        html.Append(Environment.NewLine);
        //        StreamWriter strStreamWriter = File.AppendText(FilePath);
        //        strStreamWriter.Write(html.ToString());
        //        strStreamWriter.Close();

        //    }
        //    catch (Exception e)
        //    {
        //        LogInfo(e.Message, "Creación de Log.");
        //    }
        //}

        public static int Cuenta(string Palabra, string Letra)
        {
            int Lugar = 0;
            int Total = 0;
            long largopalabra;

            var result = from item in Palabra.ToArray()
                         group item by item into g
                         select new
                         {

                             caracter = g.Key,
                             repeticiones = g.Count()
                         };


            largopalabra = Palabra.Length;
            do
            {
                Lugar = Palabra.IndexOf(";");

                Palabra = Palabra.Substring(Lugar + 1, Palabra.Length - (Lugar + 1));
                largopalabra = Palabra.Length;
                Total++;
            } while (Lugar > 0);


            return Total;
        }
        private void EscribeLog(string mensaje)
        {
            string stEscribeLog = "SI";
            StringBuilder myString = new StringBuilder();

            string FilePathE = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\LOG_INTEGRADOR_" + DateTime.Now.ToString("MMdd") + ".txt";

            ////1: no escribe registros de log (para seguimiento)
            if ((ConfigurationManager.AppSettings["RegistroArchivoLog"].ToString() == "1" || ConfigurationManager.AppSettings["RegistroArchivoLog"].ToString() == "NO") & mensaje.Substring(0, 3) == "LOG")
            {
                stEscribeLog = "NO";
            }

            if (stEscribeLog == "SI")
            {
                myString.Append(mensaje);
                myString.Append(Environment.NewLine);
                StreamWriter strStreamWriter = File.AppendText(FilePathE);
                strStreamWriter.Write(myString.ToString());
                strStreamWriter.Close();
            }
        }
        private void FTP_UploadFile(string filetarget2, string nombrearchivo)
        {
            string mensaje = "";
            string fileOK_move;
            string fileERR_move;
            string fileOK = ConfigurationManager.AppSettings["PathFilesINPUT_OK"].ToString();
            string fileERR = ConfigurationManager.AppSettings["PathFilesINPUT_ERR"].ToString();

            string FTP_Host = ConfigurationManager.AppSettings["FTPUPLOAD_Host"];
            int FTP_Port = Int16.Parse(ConfigurationManager.AppSettings["FTPUPLOAD_Port"]);

            string FTP_User = ConfigurationManager.AppSettings["FTPUPLOAD_User"];
            string FTP_Password = ConfigurationManager.AppSettings["FTPUPLOAD_Password"];

            mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Estableciendo conexion FTP ";
            this.EscribeLog(mensaje);
            FtpConnection ftp = new FtpConnection(FTP_Host, FTP_Port, FTP_User, FTP_Password);

            ftp.Open();
            ftp.Login();
            mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " MENSAJE: Conexion Establecida ";
            this.EscribeLog(mensaje);

            try
            {
                fileOK_move = fileOK + "\\" + nombrearchivo;

                ftp.SetCurrentDirectory("/INPUT");
                ftp.PutFile(filetarget2);
                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " MENSAJE: Finalizo Upload archivo " + filetarget2.Trim();
                ftp.Close();
                File.Move(filetarget2, fileOK_move);
                this.EscribeLog(mensaje);
            }
            catch (FtpException ex)
            {
                fileERR_move = fileERR + "\\" + nombrearchivo;
                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " ERROR: Ocurrio el siguiente error " + ex.Message;
                File.Move(filetarget2, fileERR_move);
                this.EscribeLog(mensaje);
            }
        }

        //Informa a Woocommerce el termino de Picking
        private void ConfirmacionPickingEComm() 
        {
            try
            {
                LogInfo("ConfirmacionPickingEComm", "Inicio ejecucion", true);

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpId = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpId, out EmpId);

                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId, "ODP_To_ECOMM"); //ValEjecutaWebHooks();
                if (myData.Tables.Count > 0)
                {
                    for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                    {
                        //Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento --------------------
                        var client = new RestClient(myData.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim().Replace("{NumeroReferencia}", myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim()));

                        client.Timeout = -1;

                        //Indica el metodo de llamado de la API ----
                        var request = new RestRequest(Method.GET);
                        switch (myData.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                        {
                            case "GET":
                                request = new RestRequest(Method.GET); //consulta
                                break;
                            case "POST":
                                request = new RestRequest(Method.POST); //crea
                                break;
                            case "PUT":
                                request = new RestRequest(Method.PUT); //modifica
                                break;
                        }

                        //Trae informacion para headers segun el nombre proceso -------
                        DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myData.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(),2);

                        //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
                        if (myData2.Tables.Count > 0)
                        {
                            for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                            {
                                //agrega key y su valor -----------
                                request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                            }
                        }

                        var body = @"{" + "\n" +
                                   @"    ""status"": ""completed""" + "\n" +
                                   @"}";

                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);

                        LogInfo("ConfirmacionPickingEComm", "Ejecuta api NumeroReferencia " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim());

                        HttpStatusCode CodigoRetorno = response.StatusCode;
                        JObject rss = JObject.Parse(response.Content); //recupera json de retorno

                        //Si finalizó OK --------------------------
                        if (CodigoRetorno.Equals(HttpStatusCode.OK))
                        {
                            LogInfo("ConfirmacionPickingEComm", "Confirmacion OK NumeroReferencia " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim());

                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (1)------
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));

                        }
                        else
                        {
                            LogInfo("ConfirmacionPickingEComm_PostGet", "Error confirmacion Picking, NumeroReferencia: " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() + "," + rss["code"] + " " + rss["message"]);

                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado con Error (2)------
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                LogInfo("ConfirmacionPickingEComm", "Error:" + ex.Message, true);
            }
        }

        //Actualiza stocks en Woocommerce - version original, actualiza 1 a 1
        private void ActualizaStockEComm() 
        {
            try
            {
                LogInfo("ActualizaStockEComm", "Inicio ejecucion proceso", true);

                //agregar para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;
                string id_productoStr;
                string id_productoStr2;
                int id_productoEcommerce;
                int id_productoEcommerce2;
                int CodigoDetCat;

                Int32.TryParse(stEmpÌd, out EmpId);
                DataSet myDataSet = new DataSet();

                //Fase 1: Rescatar id desde Woocommerce para articulos que no lo tienen en Getpoint y guardarlo 

                //Carga tabla de integraciones con Articulos sin id de Woocommerce en bd getpoint -----
                result = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_SinReferencia();

                //Trae Articulos sin id woocommerce desde tabla de integracion ---
                DataSet myDataCons = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId, "CONSULTA_PRODUCTO");
                if (myDataCons.Tables.Count > 0)
                {
                    for (int i = 0; i <= myDataCons.Tables[0].Rows.Count - 1; i++)
                    {
                        //>>> Si existe ruta para la consulta del woocommerce realiza el proceso, sino omite el articulo <<<
                        if (myDataCons.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim() != "")
                        {
                            //Carga ruta de la API de consulta de datos de producto desde Woocommerce segun nombre proceso --------------------
                            var clientCons = new RestClient(myDataCons.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim().Replace("{CodigoArticulo}", myDataCons.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim()));

                            clientCons.Timeout = -1;

                            //Indica el metodo de llamado de la API ----
                            var requestCons = new RestRequest(Method.GET);
                            switch (myDataCons.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                            {
                                case "GET":
                                    requestCons = new RestRequest(Method.GET); //consulta
                                    break;
                                case "POST":
                                    requestCons = new RestRequest(Method.POST); //crea
                                    break;
                                case "PUT":
                                    requestCons = new RestRequest(Method.PUT); //modifica
                                    break;
                            }

                            //Trae informacion para headers de la API segun el nombre proceso -------
                            DataSet myDataCons2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myDataCons.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(), 2);

                            //Carga listado de headers (atributo y valor) necesarios para realizar el llamado a la api ----------------
                            if (myDataCons2.Tables.Count > 0)
                            {
                                for (int k = 0; k <= myDataCons2.Tables[0].Rows.Count - 1; k++)
                                {
                                    //agrega key y su valor -----------
                                    requestCons.AddHeader(myDataCons2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myDataCons2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                }
                            }

                            //Carga variable 
                            var body = @"";

                            requestCons.AddParameter("text/plain", body, ParameterType.RequestBody);

                            LogInfo("ActualizaStockEComm", "Llama API consulta Articulo " + myDataCons.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim());

                            //Ejecuta llamado de la API --------------
                            IRestResponse responseCons = clientCons.Execute(requestCons);
                            HttpStatusCode CodigoRetornoCons = responseCons.StatusCode;

                            //Si finalizó OK --------------------------
                            if (CodigoRetornoCons.Equals(HttpStatusCode.OK))
                            {
                                LogInfo("ActualizaStockEComm", "Consulta OK, Articulo: " + myDataCons.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim());

                                string s;
                                s = responseCons.Content;

                                Int32.TryParse(myDataCons.Tables[0].Rows[i]["Cadena"].ToString().Trim(), out CodigoDetCat);

                                if (s.Trim() != "[]") //Si el solo trae [] como contenido no encontro el producto en el Woocommerce ---
                                {
                                    //quita [ ] inicial y final para poder relizar el parse
                                    s = s.Remove(0, 1);
                                    s = s.Remove(s.LastIndexOf("]"), 1);

                                    JObject rss = JObject.Parse(s);

                                    //Recupera id del Producto en Woocommerce -----
                                    if (rss["parent_id"].ToString() == "0") //No tiene parent_id, es producto normal
                                    {
                                        id_productoStr = rss["id"].ToString();
                                        id_productoStr2 = "0";
                                    }
                                    else //Tiene parent_id, es producto con variantes
                                    {
                                        id_productoStr = rss["parent_id"].ToString();
                                        id_productoStr2 = rss["id"].ToString();
                                    }

                                    Int32.TryParse(id_productoStr, out id_productoEcommerce);
                                    Int32.TryParse(id_productoStr2, out id_productoEcommerce2);

                                    //Actualiza ItemReferencia obtenido desde Woocommerce en getpoint -----
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaItemReferenciaEcommerce(EmpId,
                                                                                                                         myDataCons.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim(),
                                                                                                                         CodigoDetCat,
                                                                                                                         id_productoEcommerce,
                                                                                                                         id_productoEcommerce2);

                                    //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK ------
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                                                                                                          int.Parse(myDataCons.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                          int.Parse(myDataCons.Tables[0].Rows[i]["IdDet"].ToString()));
                                }
                                else
                                {
                                    LogInfo("ActualizaStockEComm", "Error consulta, Articulo: " + myDataCons.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + " no fue encontrado");

                                    //***********//***********//***********//***********//***********
                                    //agregar id -1 por defecto al producto para que no lo vuelva a sacar -----
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaItemReferenciaEcommerce(EmpId,
                                                                                                                         myDataCons.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim(),
                                                                                                                         CodigoDetCat,
                                                                                                                         -1,
                                                                                                                         -1);
                                    //***********//***********//***********//***********//***********

                                    //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado con error ------
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                          int.Parse(myDataCons.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                          int.Parse(myDataCons.Tables[0].Rows[i]["IdDet"].ToString()));
                                }
                            }
                            else
                            {
                                if (responseCons.Content != "")
                                {
                                    JObject rss = JObject.Parse(responseCons.Content);

                                    LogInfo("ActualizaStockEComm", "Error consulta Articulo " + myDataCons.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + ", " + rss["code"] + "," + rss["message"]);
                                }
                                else
                                {
                                    LogInfo("ActualizaStockEComm", "Error consulta Articulo " + myDataCons.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + ", json no retorno datos");
                                }

                                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado con Error ------
                                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                      int.Parse(myDataCons.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                      int.Parse(myDataCons.Tables[0].Rows[i]["IdDet"].ToString()));
                            }
                        } //>>> Si existe ruta para la consulta del woocommerce realiza el proceso, sino omite el articulo <<<
                    }
                }

                //Fase 2: Enviar a Woocommerce saldo de articulos en getpoint ----

                //----------------------------------------------------------------------------------
                //Carga tabla de integraciones con Articulos con id Woocommerce en bd getpoint -----
                //En el procedimiento tiene logica para sacar los datos cada cierta cantidad de minutos 
                result = WS_Integrador.Classes.model.InfF_Generador.IntegraStockWMSToEcomm("STOCK_To_ECOMM");

                //Trae articulos para integracion con Item referencia ---------------
                DataSet myDataUpd = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId, "STOCK_To_ECOMM"); //ValEjecutaWebHooks();
                if (myDataUpd.Tables.Count > 0)
                {
                    for (int i = 0; i <= myDataUpd.Tables[0].Rows.Count - 1; i++)
                    {
                        // Si tiene id Item referencia 
                        if (myDataUpd.Tables[0].Rows[i]["Texto1"].ToString().Trim() != "0" && myDataUpd.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim() != "")
                        {
                            //Divide campo cadena, trae (id producto padre | id producto)   = producto con variante
                            //                          (id_producto | 0)                   = producto normal
                            string[] Palabras = myDataUpd.Tables[0].Rows[i]["Texto1"].ToString().Trim().Split('|');

                            var client = new RestClient(myDataUpd.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim());

                            //Si no tiene id padre no es variante ---
                            if (Palabras[1] == "0")
                            {
                                //Carga ruta de la API para enviar Stock a Woocommerce segun nombre proceso que genero documento --------------------
                                client = new RestClient(myDataUpd.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim().Replace("{ItemReferencia}", Palabras[0].Trim()));
                            }
                            else
                            {
                                //Carga ruta de la API para enviar Stock a Woocommerce segun nombre proceso que genero documento --------------------
                                //Agrega la variante para realizar la actualizacion 
                                client = new RestClient(myDataUpd.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim().Replace("{ItemReferencia}", Palabras[0].Trim() +
                                                        "/variations/" +
                                                        Palabras[1].Trim()));
                            }

                            client.Timeout = -1;

                            //Indica el metodo de llamado de la API ----
                            var request = new RestRequest(Method.GET);
                            switch (myDataUpd.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                            {
                                case "GET":
                                    request = new RestRequest(Method.GET); //consulta
                                    break;
                                case "POST":
                                    request = new RestRequest(Method.POST); //crea
                                    break;
                                case "PUT":
                                    request = new RestRequest(Method.PUT); //modifica
                                    break;
                            }

                            //Trae informacion para headers segun el nombre proceso -------
                            DataSet myDataH2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myDataUpd.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(), 2);

                            //Carga listado de headers (atributo y valor) necesarios para realizar el llamado a la api ----------------
                            if (myDataH2.Tables.Count > 0)
                            {
                                for (int k = 0; k <= myDataH2.Tables[0].Rows.Count - 1; k++)
                                {
                                    //agrega key y su valor -----------
                                    request.AddHeader(myDataH2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myDataH2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                }
                            }

                            var body2 = @"{" + "\n" +
                                        @"    ""stock_quantity"": """ + myDataUpd.Tables[0].Rows[i]["Cantidad"].ToString().Trim() + @"""" + "\n" +
                                        @"}";

                            //LogInfo("ActualizaStockEComm", "Llama API actualiza stock Articulo " + myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim());

                            request.AddParameter("application/json", body2, ParameterType.RequestBody);

                            //Ejecuta llamado de la API --------------
                            IRestResponse responseStock = client.Execute(request);

                            HttpStatusCode CodigoRetorno = responseStock.StatusCode;

                            //Si finalizó OK --------------------------
                            if (CodigoRetorno.Equals(HttpStatusCode.OK))
                            {
                                //LogInfo("ActualizaStockEComm", "Actualiza OK Stock, Articulo: " + myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim());

                                //Actualiza estado de L_IntegraConfirmaciones, deja en estado traspasado (Estado = 2) ------
                                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmaciones(int.Parse(myDataUpd.Tables[0].Rows[i]["IntId"].ToString()));

                                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (Estado = 1)------
                                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                                                                                                      int.Parse(myDataUpd.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                      int.Parse(myDataUpd.Tables[0].Rows[i]["IdDet"].ToString()));
                            }
                            else
                            {
                                if (responseStock.Content != "")
                                {
                                    JObject rss = JObject.Parse(responseStock.Content);
                                    LogInfo("ActualizaStockEComm", "Error actualiza Stock, Articulo: " + myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + ", " + rss["code"] + "," + rss["message"] + 
                                                                   ". JSON: " + body2.ToString());
                                }
                                else
                                {
                                    //JObject rss = JObject.Parse(responseStock.Content);
                                    LogInfo("ActualizaStockEComm", "Error actualiza Stock, Articulo: " + myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + " (json no retorna datos)," + 
                                                                   " error: " + responseStock.ErrorMessage.Trim() + 
                                                                   ". JSON: " + body2.ToString());
                                }

                                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado con Error (Estado = 2)------
                                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                      int.Parse(myDataUpd.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                      int.Parse(myDataUpd.Tables[0].Rows[i]["IdDet"].ToString()));

                            }
                        }

                    }
                }

                LogInfo("ActualizaStockEComm", "FIN ejecucion proceso");
            }
            catch (Exception ex)
            {
                LogInfo("ActualizaStockEComm", "Error: " + ex.Message, true);
            }
        }

        //Confirma Revisión en Woocomerce, genera el Envio en Enviame y retorna la etiqueta
        private void ConfirmacionRevision()
        {
            try
            {
                LogInfo("ConfirmacionRevision", "Inicio ejecucion proceso");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpÌd, out EmpId);
                DataSet myDataSet = new DataSet();

                // ***** revisar en el procedimiento almacenado si hay alguna condicion para desactivar el integrador *****

                //Trae Pedidos Pickeados con revision finalizada (estado = 2) ----- 
                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId, "REV_To_ECOMM");

                if (myData.Tables.Count > 0)
                {
                    for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                    {
                        //Carga ruta de la API segun nombre proceso --------------------
                        var client = new RestClient(myData.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim());

                        client.Timeout = -1;

                        //Indica el metodo de llamado de la API ----
                        var request = new RestRequest(Method.GET); 
                        switch (myData.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                        {
                            case "GET":
                                request = new RestRequest(Method.GET); //consulta
                                break;
                            case "POST":
                                request = new RestRequest(Method.POST); //crea
                                break;
                            case "PUT":
                                request = new RestRequest(Method.PUT); //modifica
                                break;
                        }

                        //Trae informacion para headers segun el nombre proceso -------
                        DataSet myDataH = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myData.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(), 2);

                        //Carga listado de headers (atributo y valor) necesarios para realizar el llamado a la api ----------------
                        if (myDataH.Tables.Count > 0)
                        {
                            for (int k = 0; k <= myDataH.Tables[0].Rows.Count - 1; k++)
                            {
                                //agrega key y su valor -----------
                                request.AddHeader(myDataH.Tables[0].Rows[k]["myKey"].ToString().Trim(), myDataH.Tables[0].Rows[k]["myValue"].ToString().Trim());
                            }
                        }

                        string[] Palabras = myData.Tables[0].Rows[i]["Texto1"].ToString().Trim().Split('|');
                        string[] Glosa = myData.Tables[0].Rows[i]["Cadena"].ToString().Trim().Split('/');

                        var body = @"{" + "\n" +
                                   @" ""shipping_order"": {" + "\n" +
                                   @"      ""n_packages"": " + myData.Tables[0].Rows[i]["Cantidad"].ToString().Trim() + @"," + "\n" +
                                   @"      ""content_description"": """ + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() + @"""," + "\n" +
                                   @"      ""imported_id"": """ + myData.Tables[0].Rows[i]["NumeroReferenciaEtiqueta"].ToString().Trim() + @"""," + "\n" +
                                   @"      ""order_price"": " + myData.Tables[0].Rows[i]["Texto3Cab"].ToString().Trim() + @"," + "\n" +
                                   @"      ""weight"": ""1.0""," + "\n" +
                                   @"      ""volume"": ""1.0""," + "\n" +
                                   @"      ""type"": ""delivery"" " + "\n" +
                                   @" }, " + "\n" +
                                   @" ""shipping_origin"": { " + "\n" +
                                   @"      ""warehouse_code"": """ + Palabras[5].Trim() + @""" " + "\n" +
                                   @" }, " + "\n" +
                                   @" ""shipping_destination"": { " + "\n" +
                                   @"      ""customer"": { " + "\n" +
                                   @"              ""name"": """ + myData.Tables[0].Rows[i]["RazonSocial"].ToString().Trim() + @""", " + "\n" +
                                   @"              ""email"": """ + Palabras[0].Trim() + @""", " + "\n" +
                                   @"              ""phone"": """ + Palabras[1].Trim() + @""" " + "\n" +
                                   @"      }, " + "\n" +
                                   @"      ""delivery_address"": { " + "\n" +
                                   @"              ""home_address"": { " + "\n" +
                                   @"                      ""place"": """ + Palabras[2].Trim() + @""", " + "\n" +
                                   @"                      ""full_address"": """ + Palabras[3].Trim() + @""", " + "\n" +
                                   @"                      ""information"": """ + Glosa[1].Trim() + @""" " + "\n" +
                                   @"              } " + "\n" +
                                   @"      } " + "\n" +
                                   @" }, " + "\n" +
                                   @" ""carrier"": { " + "\n" +
                                   @"      ""carrier_code"": """ + Palabras[4].Trim() + @""", " + "\n" +
                                   @"      ""carrier_service"": """", " + "\n" +
                                   @"      ""tracking_number"": """" " + "\n" +
                                   @"      } " + "\n" +
                                   @" } ";

                        request.AddParameter("application /json", body, ParameterType.RequestBody);

                        LogInfo("ConfirmacionRevision", "Antes llamado API." + 
                                                        " NumeroReferencia: "  + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() +
                                                        ", SDD: "               + myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim() + 
                                                        ", RevisionId: "        + myData.Tables[0].Rows[i]["Folio"].ToString().Trim());                                                            

                        //Ejecuta llamado de la API --------------
                        IRestResponse responseStock = client.Execute(request);
                        HttpStatusCode CodigoRetorno = responseStock.StatusCode;

                        //Si finalizó OK --------------------------
                        if ((CodigoRetorno.Equals(HttpStatusCode.OK)) || (responseStock.StatusCode.ToString()=="Created"))
                        {
                            JObject rss = JObject.Parse(responseStock.Content);

                            LogInfo("ConfirmacionRevision", "Ejecuta API Enviame OK." + 
                                                            "NumeroReferencia: "    + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() +
                                                            ", SDD: "               + myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim() +
                                                            ", RevisionId: "        + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() + 
                                                            ", id Enviame: "        + rss["data"]["identifier"].ToString() + 
                                                            ", tracking Enviame: "   + rss["data"]["tracking_number"].ToString());

                            string etiquetaZPL;
                            if (rss["data"]["label"]["ZPL"].Parent.ToString().Contains("raw") == true) //si trae el campo raw
                            {
                                if (rss["data"]["label"]["ZPL"]["raw"] is null)
                                {
                                    etiquetaZPL = "";
                                }
                                else
                                {
                                    etiquetaZPL = rss["data"]["label"]["ZPL"]["raw"].ToString();
                                }
                            }
                            else
                            {
                                etiquetaZPL = "";
                            }

                            //Se guarda la referencia al Envio generado en el Ecommerce dentro de la Solicitud de Despacho
                            //Se guarda la etiqueta en formato ZPL 
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaSolDespachoReferenciaEnvioEcommerce(int.Parse(myData.Tables[0].Rows[i]["FolioRel"].ToString()),
                                                                                                                             "id:" + rss["data"]["identifier"].ToString() + "|" + 
                                                                                                                             "tracking:" + rss["data"]["tracking_number"].ToString(),
                                                                                                                             etiquetaZPL,
                                                                                                                             rss["data"]["label"]["PDF"].ToString());
                            
                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (1)------
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));

                            //--------------------------------------------------------------------------
                            // Si tiene configuracion para llamar API de Enviame que IMPRIME ETIQUETA -----
                            //--------------------------------------------------------------------------------
                            if (myData.Tables[0].Rows[i]["URL_EndPoint2"].ToString().Trim() != "")
                            {
                                //Carga ruta de la API segun nombre proceso --------------------
                                var client2 = new RestClient(myData.Tables[0].Rows[i]["URL_EndPoint2"].ToString().Trim());

                                client2.Timeout = -1;

                                //Indica el metodo de llamado de la API ----
                                var request2 = new RestRequest(Method.GET);
                                switch (myData.Tables[0].Rows[i]["Metodo2"].ToString().Trim())
                                {
                                    case "GET":
                                        request2 = new RestRequest(Method.GET); //consulta
                                        break;
                                    case "POST":
                                        request2 = new RestRequest(Method.POST); //crea
                                        break;
                                    case "PUT":
                                        request2 = new RestRequest(Method.PUT); //modifica
                                        break;
                                }

                                //Trae informacion para headers segun el nombre proceso -------
                                DataSet myDataH2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myData.Tables[0].Rows[i]["NombreProceso2"].ToString().Trim(), 2);

                                //Carga listado de headers (atributo y valor) necesarios para realizar el llamado a la api ----------------
                                if (myDataH2.Tables.Count > 0)
                                {
                                    for (int k = 0; k <= myDataH2.Tables[0].Rows.Count - 1; k++)
                                    {
                                        //agrega key y su valor -----------
                                        request2.AddHeader(myDataH2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myDataH2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                    }
                                }

                                var body2 = @"{" + "\n" +
                                            @" ""deliveries"" : [" + rss["data"]["identifier"].ToString() + "]," + "\n" +
                                            @" ""type"": ""pdf""," + "\n" +
                                            @" ""labelsPerPage"" : 1" + "\n" +
                                            @"}";

                                request2.AddParameter("application/json", body2, ParameterType.RequestBody);

                                //Ejecuta llamado de la API --------------
                                IRestResponse responseEtiqueta = client2.Execute(request2);
                                HttpStatusCode CodigoRetornoEtiqueta = responseEtiqueta.StatusCode;

                                //Si finalizó OK --------------------------
                                if ((CodigoRetornoEtiqueta.Equals(HttpStatusCode.OK)) || (CodigoRetornoEtiqueta.Equals(HttpStatusCode.Created)))
                                {
                                    JObject rss2 = JObject.Parse(responseEtiqueta.Content);

                                    LogInfo("ConfirmacionRevision", "Ejecuta API Imprime Enviame OK" +
                                                                    ". Proceso: " + myData.Tables[0].Rows[i]["NombreProceso2"].ToString().Trim() +
                                                                    ". NumeroReferencia: " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() +
                                                                    ", SDD: " + myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim() +
                                                                    ", RevisionId: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                    ", id Enviame: " + rss["data"]["identifier"].ToString());
                                }
                                else //Error llamado API 
                                {
                                    LogInfo("ConfirmacionRevision", "Error al ejecutar API Imprime Enviame. " +
                                                                    ". Proceso: " + myData.Tables[0].Rows[i]["NombreProceso2"].ToString().Trim() + 
                                                                    ", NumeroReferencia: " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() +
                                                                    ", SDD: " + myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim() +
                                                                    ", RevisionId: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                    ", id Enviame: " + rss["data"]["identifier"].ToString());
                                }

                            } //FIN Si tiene configuracion para llamar API de Enviame que IMPRIME ETIQUETA -----
                        }
                        else
                        {
                            JObject rss = JObject.Parse(responseStock.Content);

                            LogInfo("ConfirmacionRevision", "Error API Confirma Revision Ecomm NumeroReferencia: " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() + responseStock.Content.ToString(), true);
                            LogInfo("ConfirmacionRevision", "JSON enviado: " + body, true);

                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado con Error (2)------
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));
                        }

                    }
                }

                LogInfo("ConfirmacionRevision", "FIN ejecucion proceso");
            }
            catch (Exception ex)
            {
                LogInfo("ConfirmacionRevision", "Error: " + ex.Message, true);
            }
        }

        //Informa a Woocommerce los cambios de estado de la Solicitud de Despacho en WMS 
        private void CambiaEstadoSolicitudDespachoEcommerce()
        {
            try
            {
                LogInfo("CambiaEstadoSolicitudDespachoEcommerce", "Inicio ejecucion proceso");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpÌd, out EmpId);

                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId, "SDD_To_ECOMM"); 
                if (myData.Tables.Count > 0)
                {
                    for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                    {
                        //Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento --------------------
                        var client = new RestClient(myData.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim().Replace("{NumeroReferencia}", myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim()));

                        client.Timeout = -1;

                        //Indica el metodo de llamado de la API ----
                        var request = new RestRequest(Method.GET);
                        switch (myData.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                        {
                            case "GET":
                                request = new RestRequest(Method.GET); //consulta
                                break;
                            case "POST":
                                request = new RestRequest(Method.POST); //crea
                                break;
                            case "PUT":
                                request = new RestRequest(Method.PUT); //modifica
                                break;
                        }

                        //Trae informacion para headers segun el nombre proceso -------
                        DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myData.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(), 2);

                        //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun Nombre proceso que esta integrando ----------------
                        if (myData2.Tables.Count > 0)
                        {
                            for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                            {
                                //agrega key y su valor -----------
                                request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                            }
                        }

                        var body = @"{" + "\n" +
                                   @"    " + myData.Tables[0].Rows[i]["Texto1"].ToString().Trim() + @" " + "\n" +
                                   @"}";

                        request.AddParameter("application/json", body, ParameterType.RequestBody);

                        LogInfo("CambiaEstadoSolicitudDespachoEcommerce", "Llama API Cambia estado Sol Despacho Ecomm, NumeroReferencia: " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim());

                        //Ejecuta llamado de la API --------------
                        IRestResponse response = client.Execute(request);

                        HttpStatusCode CodigoRetorno = response.StatusCode;

                        //Si finalizó OK --------------------------
                        if (CodigoRetorno.Equals(HttpStatusCode.OK))
                        {
                            JObject rss = JObject.Parse(response.Content);

                            ////////pregunta si viene el campo variant en el detalle de pack_details, para controlar NullReferenceException -----
                            //////if (rss["items"][i]["pack_details"].Parent.ToString().Contains("variant") == true)
                            //////{
                            //////    stTexto31 = rss["items"][i]["pack_details"][i_kit]["variant"]["id"].ToString(); // Id variante Pack
                            //////}
                            //////else
                            //////{
                            //////    stTexto31 = "";
                            //////}

                            LogInfo("CambiaEstadoSolicitudDespachoEcommerce", "Cambio Estado OK, NumeroReferencia: " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim());

                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (1)------
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1, 
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()), 
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));
                        }
                        else
                        {
                            JObject rss = JObject.Parse(response.Content);
                            LogInfo("CambiaEstadoSolicitudDespachoEcommerce", "Error cambio estado, NumeroReferencia: " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() + "," + rss["code"] + " " + rss["message"]);

                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado con Error (2) ------
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()), 
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));
                        }
                    }
                }

                LogInfo("CambiaEstadoSolicitudDespachoEcommerce", "FIN ejecucion proceso");
            }
            catch (Exception ex)
            {
                LogInfo(ex.Message, "Error");
            }
        }

        //Integra reubicaciones efectuadas de manera offline para FASTPACK
        private void IntegraReubicacionesOffline()
        {
            try
            {
                LogInfo("IntegraReubicacionesOffline", "Inicio ejecucion proceso");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS
                
                DataSet myDataSet = new DataSet();
                string result = "";

                //Trae listado de reubicaciones fuera de linea ------
                var client = new RestClient(ConfigurationManager.AppSettings["URL_API"].ToString() + "/API/integracion_confirmaciones_csv/LISTAR");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-GPOINT-API-TOKEN", ConfigurationManager.AppSettings["TOKEN_API"].ToString());
                request.AddHeader("X-GPOINT-API-SECRET", ConfigurationManager.AppSettings["SECRET_API"].ToString());
                request.AddHeader("Content-Type", "application/json");

                var body = @"{" + "\n" +
                           @"""empid"":""1""," + "\n" +
                           @"""nombreproceso"":""INT-REUBICACION-AUTOMATICA"", " + "\n" +
                           @"""limit"":""0""," + "\n" +
                           @"""rowset"":""0"" " + "\n" + 
                           @"}";

                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                HttpStatusCode CodigoRetorno = response.StatusCode;

                //Si finalizó OK --------------------------
                if (CodigoRetorno.Equals(HttpStatusCode.OK))
                {
                    JObject rss = JObject.Parse(response.Content);

                    string NombreArchivo;
                    int TotalItems = 0;

                    for (Int32 i = 0; i < rss["Confirmacion"].Count(); i++)
                    {
                        //Concatena Nombre proceso + fecha sistema
                        NombreArchivo = rss["Confirmacion"][i]["NombreProceso"].ToString().Trim() + @"_" +
                                        rss["Confirmacion"][i]["FechaProceso"].ToString().Trim();

                        TotalItems = (Int32)rss["Confirmacion"][i]["Items"].Count();
                        for (Int32 item = 0; item < TotalItems; item++)
                        {
                            //Guarda datos en tabla de integracion ---------------
                            result = WS_Integrador.Classes.model.InfF_Generador.Inserta_API_Integracion("12345",
                                                                                                        1,
                                                                                                        NombreArchivo,
                                                                                                        rss["Confirmacion"][i]["Items"][item]["Texto1"].ToString().Trim());
                            //Si integra correctamente actualiza estado a 2, en tabla de integracion
                            if (result == "OK")
                            {
                                var client2 = new RestClient(ConfigurationManager.AppSettings["URL_API"].ToString() + "/API/integracion_confirmaciones_upd");
                                client2.Timeout = -1;
                                var request2 = new RestRequest(Method.PUT);
                                request2.AddHeader("X-GPOINT-API-TOKEN", ConfigurationManager.AppSettings["TOKEN_API"].ToString());
                                request2.AddHeader("X-GPOINT-API-SECRET", ConfigurationManager.AppSettings["SECRET_API"].ToString());
                                request2.AddHeader("Content-Type", "application/json");
                                
                                var body2 = @"{" + "\n" +
                                            @"    ""IntId"": " + rss["Confirmacion"][i]["IntId"].ToString().Trim() + @" " + "\n" +
                                            @"}";

                                request2.AddParameter("application/json", body2, ParameterType.RequestBody);

                                IRestResponse response2 = client2.Execute(request2);
                                HttpStatusCode CodigoRetorno2 = response2.StatusCode;

                                //Si finalizó OK --------------------------
                                if (CodigoRetorno2.Equals(HttpStatusCode.OK) != true)
                                {
                                    LogInfo("IntegraReubicacionesOffline", "Problema al guardar en tabla integracion, NombreArchivo: " +
                                                                           NombreArchivo + @",texto: " + 
                                                                           rss["Confirmacion"][i]["Items"][item]["Texto1"].ToString().Trim());
                                }
                            }
                            else
                            {
                                LogInfo("IntegraReubicacionesOffline", "Problema al cambiar estado tabla integracion, IntId: " + 
                                                                       rss["Confirmacion"][i]["IntId"].ToString().Trim());

                            }
                        }
                    }
                }

                LogInfo("IntegraReubicacionesOffline", "FIN ejecucion proceso");
            }
            catch (Exception ex)
            {

                LogInfo(ex.Message, "Error");
            }
        }

        //basado en RecepcionDoctoLegalSDD()
        private void GeneraGuiaTrasladoBSale() 
        {
            try
            { 
                LogInfo("GeneraGuiaBSale", "Inicio ejecucion proceso");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stNumeroReferencia = "";
                //string stIdDocto = "";
                string mensaje1 = "";
                string URL = "";
                string result = "";
                string documentTypeId = "";
                int officeId = 0;
                int destinationOfficeId = 0;
                //string emissionDate = "";
                string shippingTypeId = "";
                string municipality = "";
                string city = "";
                string address = "";
                string declareSii = "";
                string recipient = "";

                //string code = "";
                //string activity = "";
                //string company = "";
                //string email = "";

                //int quantity=0;
                //float netUnitValue = 0;

                string Cliente_code;
                string Cliente_municipality;
                string Cliente_activity;
                string Cliente_company;
                string Cliente_city;
                string Cliente_email;
                string Cliente_address;

                DateTime _date = DateTime.Parse(DateTime.Now.ToShortDateString());
                Int32 unixTimestamp = (Int32)(_date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                var EstructuraJson = new Object();
                var DATA2 = "";

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                int EmpId;

                Int32.TryParse(stEmpÌd, out EmpId);
                DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId, "ODP-TRASPASO-ENTRE-BODEGAS_To_BSALE");

                if (myDataSet.Tables.Count > 0)
                {
                    if (myDataSet.Tables[0].Rows.Count>0)
                    {
                        List<detailsTraspaso> details = new List<detailsTraspaso>();

                        //Recorre solicitudes ------------
                        for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                        {
                            #region comentario
                            //divide el campo Texto1 que trae toda la informacion concatenada:
                            //0  - '8|' + --documentTypeId ==> 8 -- GUÍA DE DESPACHO ELECTRÓNICA
                            //1  - '1|' + --OfficeId
                            //2  - Rtrim(Convert(Int, ts.Valor1)) + '|' + --OfficeDestino
                            //3  - '5|' + --shippingTypeId
                            //4  - IsNull((Select Rtrim(DescripcionCi) from Ciudad ci Where CodigoCi = s.Ciudad), 'SANTIAGO')+'|' + --city ciudad del despacho(String).
                            //5  - IsNull((Select Rtrim(DescripcionCo) from Comuna co Where CodigoCo = s.Comuna), 'SANTIAGO')+'|' + --municipality comuna del despacho(String).
                            //6  - Rtrim(s.Direccion) + '|' + --adress
                            //7  - Rtrim(e.RazonSocial) + '|' + --recipient destinatario del despacho(String).
                            //8  - Rtrim(e.Mail1) + '|' + --email
                            //9  - Rtrim(e.Rut) + '|' + --code RutCliente
                            //10 - 'Santiago' + '|' + --city  ciudad
                            //11 - 'Santiago' + '|' + --municipality2 comuna de direccion del cliente(factura)
                            //12 - 'Santa Lucia 120' + '|' + --address   direccion
                            //13 - 'Venta de Articulos e Insumos Medicos' + '|' + --activity  giro
                            //14 - Rtrim(e.RazonSocial) + '|' + --company   rzonsocial
                            //15 - Rtrim(e.Mail1) + '|'               Texto1--email2 correo
                            #endregion

                            string[] Palabras = myDataSet.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim().Split('|');

                            //cuando cambie de numero referencia, control que no entre la primera vez que ejecuta el ciclo
                            if ((myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() != stNumeroReferencia) && (stNumeroReferencia != ""))
                            {
                                DATA2 = JsonConvert.SerializeObject(EstructuraJson);

                                //llamado de api de bsale ----- 
                                URL = "https://api.bsale.cl/v1/shippings.json";
                                System.Net.Http.HttpClient client2 = new System.Net.Http.HttpClient();
                                client2.BaseAddress = new System.Uri(URL);
                                client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                                //Begin 2: Parametros para Header
                                client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                                client2.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                                System.Net.Http.HttpContent content2 = new StringContent(DATA2, UTF8Encoding.UTF8, "application/json");

                                try
                                {
                                    mensaje1 = "Generando Traspaso n° referencia: " + stNumeroReferencia;
                                    LogInfo("GeneraGuiaTrasladoBSale", mensaje1);

                                    HttpResponseMessage messge = client2.PostAsync(URL, content2).Result;

                                    if (messge.IsSuccessStatusCode)
                                    {
                                        mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "    Generando Traspaso Exitoso";
                                        LogInfo("GeneraGuiaTrasladoBSale", mensaje1);
                                        string respuesta = messge.Content.ReadAsStringAsync().Result;

                                        //RespGuiaIntegracion respGuia = JsonConvert.DeserializeObject<RespGuiaIntegracion>(respuesta);
                                        //string guideRef = respGuia.guide.href.Trim();
                                        //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP("", "0", stIdDocto, guideRef);

                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (1)------
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                                                                                                              int.Parse(myDataSet.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                              int.Parse(myDataSet.Tables[0].Rows[i]["IdDet"].ToString()));
                                    }
                                    else
                                    {
                                        string respuesta = messge.Content.ReadAsStringAsync().Result;

                                        //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaPickingRechazado("", stIdDocto);
                                        mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "    Generando Traspaso fallido: " + respuesta.Trim();
                                        LogInfo("GeneraGuiaTrasladoBSale", mensaje1, true);

                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado con Error (2)------
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                              int.Parse(myDataSet.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                              int.Parse(myDataSet.Tables[0].Rows[i]["IdDet"].ToString()));
                                    }
                                    content2.Dispose();
                                    client2.Dispose();
                                }


                                catch (Exception ex1)
                                {
                                    string mensajeError = " Ocurrio el siguiente error" + ex1.Message;
                                    // this.EscribeLog(mensaje1);
                                }
                            }

                            #region comentario
                            //Si cambio de SDR genera nuevo archivo
                            //if (stNumeroReferencia != "" /*(myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() != stNumeroReferencia) & (stNumeroReferencia != "")*/)

                            // -- json bsale ====================================================
                            //{
                            //    "documentTypeId": 8,
                            //    "officeId": 21,
                            //    "destinationOfficeId":1,
                            //    "emissionDate": 1646146544,
                            //    "shippingTypeId": 5,
                            //    "municipality": "Puerto Varas",
                            //    "city": "Puerto Varas",
                            //    "address": "prueba traspaso",
                            //    "declareSii": 1,
                            //    "recipient": "Edison Packard",
                            //    "details": [
                            //    {
                            //        "quantity": 3,
                            //        "code": "9323",
                            //        "netUnitValue": 1
                            //    }
                            //    ],

                            //    "client": {
                            //                                "code": "1-7",
                            //    "municipality": "Puerto Montt",
                            //    "activity": "Arriendo de maquinaria pesada",
                            //    "company": "Maquinarías Express",
                            //    "city": "PUERTO MONTT",
                            //    "email": "apidespachos@bsale.cl",
                            //    "address": "Los Alamos #122"
                            //    }
                            //}
                            // ====================================================

                            //Carga datos cabecera
                            //stIdDocto = myDataSet.Tables[0].Rows[i]["ColaPickId"].ToString().Trim();
                            //documentTypeId = myDataSet.Tables[0].Rows[i]["documentTypeId"].ToString().Trim();
                            //emissionDate = myDataSet.Tables[0].Rows[i]["emissionDate"].ToString().Trim();
                            //shippingTypeId = myDataSet.Tables[0].Rows[i]["shippingTypeId"].ToString().Trim();
                            //municipality = myDataSet.Tables[0].Rows[i]["municipality"].ToString().Trim();
                            //city = myDataSet.Tables[0].Rows[i]["city"].ToString().Trim();
                            //address = myDataSet.Tables[0].Rows[i]["address"].ToString().Trim();
                            //declareSii = myDataSet.Tables[0].Rows[i]["declareSii"].ToString().Trim();
                            //recipient = myDataSet.Tables[0].Rows[i]["recipient"].ToString().Trim();
                            //code = myDataSet.Tables[0].Rows[i]["code"].ToString().Trim();
                            //activity = myDataSet.Tables[0].Rows[i]["activity"].ToString().Trim();
                            //company = myDataSet.Tables[0].Rows[i]["company"].ToString().Trim();
                            //email = myDataSet.Tables[0].Rows[i]["email"].ToString().Trim();
                            #endregion

                            documentTypeId = Palabras[0].Trim();
                            officeId = int.Parse(Palabras[1].Trim());
                            destinationOfficeId = int.Parse(Palabras[2].Trim());

                            //se homologan bodegas origen y destino para enviar a BSALE -----
                            if (officeId == 1)
                            {
                                officeId = 10;
                            }
                            else
                            {
                                if (officeId == 4)
                                {
                                    officeId = 5;
                                }
                                else
                                {
                                    if (officeId == 7)
                                    {
                                        officeId = 6;
                                    }
                                    else
                                    {
                                        if (officeId == 10)
                                        {
                                            officeId = 1;
                                        }
                                    }
                                }
                            }

                            if (destinationOfficeId == 1)
                            {
                                destinationOfficeId = 10;
                            }
                            else
                            {
                                if (destinationOfficeId == 4)
                                {
                                    destinationOfficeId = 5;
                                }
                                else
                                {
                                    if (destinationOfficeId == 7)
                                    {
                                        destinationOfficeId = 6;
                                    }
                                    else
                                    {
                                        if (destinationOfficeId == 10)
                                        {
                                            destinationOfficeId = 1;
                                        }
                                    }
                                }
                            }

                            //---------------------------------------------------------------

                            shippingTypeId = Palabras[3].Trim();
                            municipality = Palabras[5].Trim();
                            city = Palabras[4].Trim();
                            address = Palabras[6].Trim();
                            declareSii = "1";
                            recipient = Palabras[7].Trim();

                            Cliente_code = Palabras[9].Trim();
                            Cliente_municipality = Palabras[11].Trim();
                            Cliente_activity = Palabras[13].Trim();
                            Cliente_company = Palabras[14].Trim();
                            Cliente_city = Palabras[10].Trim();
                            Cliente_email = Palabras[15].Trim();
                            Cliente_address = Palabras[12].Trim();

                            //crea estructura cliente ----
                            var ClienteJson = new
                            {
                                code = Cliente_code,
                                municipality = Cliente_municipality,
                                activity = Cliente_activity,
                                company = Cliente_company,
                                city = Cliente_city,
                                email = Cliente_email,
                                address = Cliente_address,
                            };


                            stNumeroReferencia = myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();

                            details = new List<detailsTraspaso>();

                            //recorre items relacionados a mismo numero referencia y crea estructura de detalle --------
                            for (int item = 0; item < myDataSet.Tables[0].Rows.Count; item++)
                            {
                                if (myDataSet.Tables[0].Rows[item]["NumeroReferencia"].ToString().Trim() == stNumeroReferencia)
                                {
                                    detailsTraspaso detail = new detailsTraspaso();

                                    detail.quantity = int.Parse(myDataSet.Tables[0].Rows[item]["Cantidad"].ToString().Trim());
                                    detail.code = myDataSet.Tables[0].Rows[item]["CodigoArticulo"].ToString().Trim();
                                    detail.netUnitValue = 1; //precio unitario //float.Parse(myDataSet.Tables[0].Rows[item]["detailId"].ToString().Trim());

                                    details.Add(detail);

                                    //Actualiza estado de L_IntegraConfirmaciones, deja en estado traspasado ------
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmaciones(int.Parse(myDataSet.Tables[0].Rows[i]["IntId"].ToString()));
                                }
                            }

                            //Crea y carga estructura para el JSON
                            EstructuraJson = new
                            {
                                documentTypeId = documentTypeId,
                                officeId = officeId,
                                destinationOfficeId = destinationOfficeId,
                                emissionDate = unixTimestamp.ToString(),
                                shippingTypeId = shippingTypeId,
                                municipality = municipality,
                                city = city,
                                address = address,
                                declareSii = declareSii,
                                recipient = recipient,
                                details,
                                client = ClienteJson,
                            };

                        } // fin ciclo Recorre solicitudes 

                        DATA2 = JsonConvert.SerializeObject(EstructuraJson);

                        //luego que finaliza el ciclo genera el traspaso para lo que haya quedo pendiente -----

                        //llamado a al API de BSALE --------------
                        URL = "https://api.bsale.cl/v1/shippings.json";
                        System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                        client.BaseAddress = new System.Uri(URL);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        //Begin 2: Parametros para Header
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                        client.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

                        System.Net.Http.HttpContent content = new StringContent(DATA2, UTF8Encoding.UTF8, "application/json");

                        try
                        {
                            mensaje1 = "Generando Traspaso n° referencia: " + stNumeroReferencia;
                            LogInfo("GeneraGuiaTrasladoBSale", mensaje1);

                            HttpResponseMessage messge = client.PostAsync(URL, content).Result;

                            if (messge.IsSuccessStatusCode)
                            {
                                mensaje1 = "Generando Traspaso Exitoso";
                                LogInfo("GeneraGuiaTrasladoBSale", mensaje1);
                                string respuesta = messge.Content.ReadAsStringAsync().Result;

                                //RespGuiaIntegracion respGuia = JsonConvert.DeserializeObject<RespGuiaIntegracion>(respuesta);
                                //string guideRef = respGuia.guide.href.Trim();
                                //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP("", "0", stIdDocto, guideRef);

                                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (1)------
                                //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                //                                                                                      int.Parse(myDataSet.Tables[0].Rows[i]["IntId"].ToString()),
                                //                                                                                      int.Parse(myDataSet.Tables[0].Rows[i]["IdDet"].ToString()));
                            }
                            else
                            {
                                string respuesta = messge.Content.ReadAsStringAsync().Result;
                                //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaPickingRechazado("", stIdDocto);

                                mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "    Generando Traspaso fallido: " + respuesta.Trim();
                                LogInfo("", mensaje1);

                                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado con Error (2)------
                                //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                //                                                                                      int.Parse(myDataSet.Tables[0].Rows[i]["IntId"].ToString()),
                                //                                                                                      int.Parse(myDataSet.Tables[0].Rows[i]["IdDet"].ToString()));

                            }
                            content.Dispose();
                            client.Dispose();
                        }
                        catch (Exception ex1)
                        {
                            string mensajeError = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error" + ex1.Message;
                            // this.EscribeLog(mensaje1);
                        }

                    } //FIN rows.count > 0
                }

            }
            catch (Exception ex)
            {
                LogInfo("GeneraGuiaTrasladoBSale", "Error: " + ex.Message, true);
            }
        }

        //Obtiene Token para llamar APIS de Ripley 
        private void ObtieneTokenRipley()
        {
            try
            {
                LogInfo("ObtieneTokenRipley", "Inicio ejecucion proceso");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string result = "";

                //Revisa si la tabla de parametros tiene el token diario para Ripley por cada Ecommerce de Mundosalud
                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.LeeTokenRipley(int.Parse(ConfigurationManager.AppSettings["EmpId"].ToString()));
                if (myData.Tables.Count > 0)
                {
                    for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                    {
                        //Si no hay token para Ripley hay que ejecutar la API que lo trae
                        if (myData.Tables[0].Rows[i]["TOKEN_EndPoint"].ToString().Trim() == "")
                        {
                            //Carga ruta de la API segun nombre proceso --------------------
                            var client = new RestClient(myData.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim());
                            client.Timeout = -1;

                            //Indica el metodo de llamado de la API ----
                            var request = new RestRequest(Method.GET);
                            switch (myData.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                            {
                                case "GET":
                                    request = new RestRequest(Method.GET); //consulta
                                    break;
                                case "POST":
                                    request = new RestRequest(Method.POST); //crea
                                    break;
                                case "PUT":
                                    request = new RestRequest(Method.PUT); //modifica
                                    break;
                            }

                            for (int k = 0; k <= myData.Tables[0].Rows.Count - 1; k++)
                            {
                                if (myData.Tables[0].Rows[i]["NombreProceso"].ToString().Trim() == myData.Tables[0].Rows[k]["NombreProceso"].ToString().Trim())
                                {
                                    //agrega key y su valor -----------
                                    request.AddHeader(myData.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                }
                            }

                            //No envia body
                            //var body = @"{" + "\n" +
                            //           @" } ";
                            //request.AddParameter("application /json", body, ParameterType.RequestBody);

                            //Ejecuta llamado de la API --------------
                            IRestResponse response = client.Execute(request);
                            HttpStatusCode CodigoRetorno = response.StatusCode;

                            //Si finalizó OK --------------------------
                            if (CodigoRetorno.Equals(HttpStatusCode.OK)) // revisar que devuelve esa variable --->> response.StatusCode.ToString() == "Created"))
                            {
                                JObject rss = JObject.Parse(response.Content); //recupera json de retorno

                                if (rss["status_code"].ToString() == "200") //token OK
                                {
                                    //Actualiza nuevo token para las API de Ripley ---------------
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaTokenRipleyEndPoint(int.Parse(ConfigurationManager.AppSettings["EmpId"].ToString()),
                                                                                                                     myData.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(),
                                                                                                                     rss["access_token"].ToString());
                                    if (result != "OK")
                                    {
                                        LogInfo("ObtieneTokenRipley", "Problema al actualizar nuevo token Ripley");
                                    }
                                }
                            }
                            else
                            {
                                LogInfo("ObtieneTokenRipley", "Problema al obtener nuevo token Ripley desde API");
                            }

                        } //fin si tiene token                    
                    }
                } // fin si encontro datos
            }

            catch (Exception ex)
            {
                LogInfo(ex.Message, "Error");
            }

        }

        //Integra Ordenes de Ripley 
        private void IntegraOrdenesRipley()
        {
            try
            {
                LogInfo("IntegraOrdenesRipley", "Inicio ejecucion proceso");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                //string result = "";
                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                int EmpId;
                //string sqlQuery = "";
                string stArchivo = "";
                string stUserName = "";
                string stFechaProceso = "";
                int total = 0;
                int limit = 0;
                int offset = 0;
                int stLinea = 0;

                #region Lista de Variables stTextoXX para tabla integracion
                string stTexto1 = "";
                string stTexto2 = "";
                string stTexto3 = "";
                string stTexto4 = "";
                string stTexto5 = "";
                string stTexto6 = "";
                string stTexto7 = "";
                string stTexto8 = "";
                string stTexto9 = "";
                string stTexto10 = "";
                string stTexto11 = "";
                string stTexto12 = "";
                string stTexto13 = "";
                string stTexto14 = "";
                string stTexto15 = "";
                string stTexto16 = "";
                string stTexto17 = "";
                string stTexto18 = "";
                string stTexto19 = "";
                string stTexto20 = "";
                string stTexto21 = "";
                string stTexto22 = "";
                string stTexto23 = "";
                string stTexto24 = "";
                string stTexto25 = "";
                string stTexto26 = "";
                string stTexto27 = "";
                string stTexto28 = "";
                string stTexto29 = "";
                string stTexto30 = "";
                string stTexto31 = "";
                string stTexto32 = "";
                string stTexto33 = "";
                string stTexto34 = "";
                string stTexto35 = "";
                string stTexto36 = "";
                string stTexto37 = "";
                string stTexto38 = "";
                string stTexto39 = "";
                string stTexto40 = "";
                #endregion

                //-------------------------------------------------------------

                stUserName = "INTEGRADOR_API";

                Int32.TryParse(stEmpÌd, out EmpId);
                DataSet myDataSet = new DataSet();

                //Trae url de API para listado de Ordenes de Ripley ----
                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.LeeRutaAPI(EmpId,
                                                                                       "RIPLEY_LIST_ORDERS");
                if (myData.Tables.Count > 0)
                {
                    for (int p = 0; p <= myData.Tables[0].Rows.Count - 1; p++)
                    {
                        //Carga ruta de la API de consulta de datos de producto desde Woocommerce segun nombre proceso --------------------
                        var client = new RestClient(myData.Tables[0].Rows[p]["URL_EndPoint"].ToString().Trim());

                        client.Timeout = -1;

                        //Indica el metodo de llamado de la API ----
                        var request = new RestRequest(Method.GET);
                        switch (myData.Tables[0].Rows[p]["Metodo"].ToString().Trim())
                        {
                            case "GET":
                                request = new RestRequest(Method.GET); //consulta
                                break;
                            case "POST":
                                request = new RestRequest(Method.POST); //crea
                                break;
                            case "PUT":
                                request = new RestRequest(Method.PUT); //modifica
                                break;
                        }

                        //Trae informacion para headers de la API segun el nombre proceso -------
                        DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId,
                                                                                                                                myData.Tables[0].Rows[p]["NombreProceso"].ToString().Trim(), 
                                                                                                                                2);

                        //Carga listado de headers (atributo y valor) necesarios para realizar el llamado a la api ----------------
                        if (myData2.Tables.Count > 0)
                        {
                            for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                            {
                                //agrega key y su valor -----------
                                request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                            }
                        }

                        //Carga variable body a enviar
                        var body = @"";

                        request.AddParameter("text/plain", body, ParameterType.RequestBody);

                        LogInfo("IntegraOrdenesRipley", "Ejecuta llamado API Ordenes Ripley, " + myData.Tables[0].Rows[p]["NombreProceso"].ToString().Trim());

                        //Ejecuta llamado de la API --------------
                        IRestResponse response = client.Execute(request);
                        HttpStatusCode CodigoRetorno = response.StatusCode;

                        //Si finalizó OK --------------------------
                        if (CodigoRetorno.Equals(HttpStatusCode.OK))
                        {
                            JObject rss = JObject.Parse(response.Content);

                            //Si llamado se realizó OK continúa -----
                            if (rss["message"].ToString() == "OK")
                            {
                                total = (Int32)rss["data"]["total"];
                                limit = (Int32)rss["data"]["limit"];
                                offset = (Int32)rss["data"]["offset"];

                                //Calcula cuantas veces debe ejecutar la API para extraer los datos
                                var ciclos = Math.Ceiling(Convert.ToDouble(total) / Convert.ToDouble(limit));

                                for (Int32 c = 0; c < ciclos; c++)
                                {
                                    if (c > 0) //solo entra si hace mas de 1 llamado a la API
                                    {
                                        //Agrega offset al siguiente llamado ----- 
                                        client = new RestClient(myData.Tables[0].Rows[p]["URL_EndPoint"].ToString().Trim() + @"&offset=" + offset.ToString());

                                        //Ejecuta llamado de la API --------------
                                        response = client.Execute(request);
                                        CodigoRetorno = response.StatusCode;

                                        rss = JObject.Parse(response.Content);
                                    }

                                    //Recorre Ordenes obtenidas desde Ripley -------
                                    for (Int32 i = 0; i < rss["data"]["orders"].Count(); i++)
                                    {
                                        //Valida si la Orden ya se ingresó a la tabla de integracion ==============================
                                        DataSet dsExiste = WS_Integrador.Classes.model.InfF_Generador.Busca_Integracion_Existente(stUserName,
                                                                                                                                  "INT-SOL-PEDIDO",
                                                                                                                                  "OT",
                                                                                                                                  rss["data"]["orders"][i]["order_id"].ToString());
                                        DateTime Fecha;
                                        int Existe;
                                        Existe = 0; //No

                                        if (dsExiste.Tables.Count > 0)
                                        {
                                            if (dsExiste.Tables[0].Rows.Count > 0)
                                            {
                                                Existe = 1; //Si
                                            }
                                        }

                                        //Si la referencia no existe en la tabla de integracion la procesa
                                        if (Existe == 0)
                                        {
                                            stLinea = 0;

                                            stArchivo = "ORDEN_RIPLEY_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + rss["data"]["orders"][i]["order_id"].ToString();
                                            stFechaProceso = DateTime.Now.ToString("yyyyMMdd");

                                            stTexto1 = "INT-SOL-PEDIDO"; //INT-NAME
                                            stTexto2 = DateTime.Now.ToString("yyyyMMdd HHmmss"); //FECHAHORA
                                            stTexto3 = "A"; //TIPO_TRK: Append
                                            stTexto4 = ""; //Dato1 cabecera 
                                            stTexto5 = rss["data"]["orders"][i]["_id"].ToString(); ; //Dato2 cabecera --> guardamos Id interno Solicitud Ripley
                                            stTexto6 = EmpId.ToString(); //Empid
                                            stTexto7 = DateTime.Now.ToString("yyyyMMdd"); //FechaDigitacion
                                            stTexto8 = "INTEGRADOR_API"; //UsuarioDigitacion
                                            stTexto9 = DateTime.Now.ToString("yyyyMMdd"); //FechaProceso
                                            stTexto10 = "7"; //TipoSolicitud= Ripley
                                            stTexto11 = ""; //Comprador
                                            stTexto12 = ""; //RutCliente

                                            //stTexto13 = rss["data"]["orders"][i]["customer"]["billing_address"]["company"].ToString(); //RazonSocial
                                            stTexto13 = rss["data"]["orders"][i]["customer"]["billing_address"]["firstname"].ToString() + " " +
                                                        rss["data"]["orders"][i]["customer"]["billing_address"]["lastname"].ToString();

                                            stTexto14 = rss["data"]["orders"][i]["customer"]["billing_address"]["firstname"].ToString() + " " +
                                                        rss["data"]["orders"][i]["customer"]["billing_address"]["lastname"].ToString(); //Contacto
                                            stTexto15 = rss["data"]["orders"][i]["_vendor_id"].ToString(); //Vendedor

                                            switch (rss["data"]["orders"][i]["customer"]["shipping_address"]["state"].ToString()) //Region 
                                            {
                                                case "I REGION":            stTexto16 = "1"; break;
                                                case "II REGION":           stTexto16 = "2"; break;
                                                case "III REGION":          stTexto16 = "3"; break;
                                                case "IV REGION":           stTexto16 = "4"; break;
                                                case "V REGION":            stTexto16 = "5"; break;
                                                case "VI REGION":           stTexto16 = "6"; break;
                                                case "VII REGION":          stTexto16 = "7"; break;
                                                case "VIII REGION":         stTexto16 = "8"; break;
                                                case "IX REGION":           stTexto16 = "9"; break;
                                                case "X REGION":            stTexto16 = "10"; break;
                                                case "XI REGION":           stTexto16 = "11"; break;
                                                case "XII REGION":          stTexto16 = "12"; break;
                                                case "XIV REGION":          stTexto16 = "14"; break;
                                                case "XV REGION":           stTexto16 = "15"; break;
                                                case "REG.METROPOLITANA":   stTexto16 = "13"; break;
                                            }

                                            stTexto17 = rss["data"]["orders"][i]["customer"]["billing_address"]["city"].ToString(); //Ciudad
                                            stTexto18 = rss["data"]["orders"][i]["customer"]["billing_address"]["city"].ToString(); //Comuna
                                            stTexto19 = rss["data"]["orders"][i]["customer"]["billing_address"]["street_1"].ToString(); //Direccion
                                            stTexto20 = ""; //Email
                                            stTexto21 = ""; //RutaDespId
                                            stTexto22 = ""; //Moneda
                                            stTexto23 = ""; //TipoDocumento
                                            stTexto24 = ""; //NumeroDocumento
                                            stTexto25 = ""; //FechaDocto
                                            stTexto26 = "OT"; //TipoReferencia
                                            stTexto27 = rss["data"]["orders"][i]["order_id"].ToString(); //NumeroReferencia

                                            LogInfo("IntegraOrdenesRipley-Fecha", rss["data"]["orders"][i]["created_date"].ToString());
                                            Fecha = DateTime.Parse(rss["data"]["orders"][i]["created_date"].ToString());
                                            stTexto28 = Fecha.ToString("yyyyMMdd");

                                            //stTexto28 = rss["data"]["orders"][i]["created_date"].ToString().Substring(0,10).Replace("-",""); //FechaReferencia

                                            stTexto29 = ""; //PorcTolerancia
                                            stTexto30 = "Interface Ripley, CREA ORDEN - " + rss["data"]["orders"][i]["shop_name"].ToString(); //Glosa
                                            stTexto31 = ""; //Linea

                                            //realiza ciclo por los items de la orden e inserta
                                            for (Int32 item = 0; item < (Int32)rss["data"]["orders"][i]["order_lines"].Count(); item++)
                                            {
                                                stTexto32 = rss["data"]["orders"][i]["order_lines"][item]["offer_sku"].ToString(); //CodigoArticulo
                                                stTexto33 = ""; //CodigoOriginal
                                                stTexto34 = "UN"; //UnidadCompra
                                                stTexto35 = rss["data"]["orders"][i]["order_lines"][item]["quantity"].ToString(); //Cantidad

                                                //stTexto36 = rss["data"]["orders"][i]["order_lines"][item]["order_line_id"].ToString(); //ItemReferencia 
                                                stTexto36 = rss["data"]["orders"][i]["order_lines"][item]["order_line_index"].ToString(); //ItemReferencia 

                                                stTexto37 = ""; //Lote 
                                                stTexto38 = ""; //Referencia
                                                stTexto39 = ""; //Vencimiento
                                                stTexto40 = "1"; //Estado

                                                stLinea = stLinea + 1;

                                                //inserta en tabla de integracion
                                                WS_Integrador.Classes.model.InfF_Generador.Inserta_Integraciones(stArchivo,
                                                                                                                 stUserName.Trim(),
                                                                                                                 DateTime.Now, //stFechaProceso,
                                                                                                                 stLinea,
                                                                                                                 stTexto1.Trim(),
                                                                                                                 stTexto2.Trim(),
                                                                                                                 stTexto3.Trim(),
                                                                                                                 stTexto4.Trim(),
                                                                                                                 stTexto5.Trim(),
                                                                                                                 stTexto6.Trim(),
                                                                                                                 stTexto7.Trim(),
                                                                                                                 stTexto8.Trim(),
                                                                                                                 stTexto9.Trim(),
                                                                                                                 stTexto10.Trim(),
                                                                                                                 stTexto11.Trim(),
                                                                                                                 stTexto12.Trim(),
                                                                                                                 stTexto13.Trim(),
                                                                                                                 stTexto14.Trim(),
                                                                                                                 stTexto15.Trim(),
                                                                                                                 stTexto16.Trim(),
                                                                                                                 stTexto17.Trim(),
                                                                                                                 stTexto18.Trim(),
                                                                                                                 stTexto19.Trim(),
                                                                                                                 stTexto20.Trim(),
                                                                                                                 stTexto21.Trim(),
                                                                                                                 stTexto22.Trim(),
                                                                                                                 stTexto23.Trim(),
                                                                                                                 stTexto24.Trim(),
                                                                                                                 stTexto25.Trim(),
                                                                                                                 stTexto26.Trim(),
                                                                                                                 stTexto27.Trim(),
                                                                                                                 stTexto28.Trim(),
                                                                                                                 stTexto29.Trim(),
                                                                                                                 stTexto30.Trim(),
                                                                                                                 stTexto31.Trim(),
                                                                                                                 stTexto32.Trim(),
                                                                                                                 stTexto33.Trim(),
                                                                                                                 stTexto34.Trim(),
                                                                                                                 stTexto35.Trim(),
                                                                                                                 stTexto36.Trim(),
                                                                                                                 stTexto37.Trim(),
                                                                                                                 stTexto38.Trim(),
                                                                                                                 stTexto39.Trim(),
                                                                                                                 stTexto40.Trim());
                                                #region llamadoAntiguo
                                                //llamadoAntiguo --------
                                                //sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
                                                //sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9 , Texto10,";
                                                //sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
                                                //sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29, Texto30,";
                                                //sqlQuery += "Texto31, Texto32, Texto33, Texto34, Texto35, Texto36, Texto37, Texto38, Texto39, Texto40) values (";

                                                //sqlQuery += "'" + stArchivo.Trim() + "'";
                                                //sqlQuery += ",'" + stUserName.Trim() + "'";
                                                //sqlQuery += ",'" + stFechaProceso + "'";
                                                //sqlQuery += ",'" + stLinea + "'";
                                                //sqlQuery += ",'" + stTexto1.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto2.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto3.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto4.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto5.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto6.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto7.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto8.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto9.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto10.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto11.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto12.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto13.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto14.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto15.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto16.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto17.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto18.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto19.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto20.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto21.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto22.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto23.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto24.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto25.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto26.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto27.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto28.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto29.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto30.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto31.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto32.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto33.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto34.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto35.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto36.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto37.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto38.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto39.Trim() + "'";
                                                //sqlQuery += ",'" + stTexto40.Trim() + "'";
                                                //sqlQuery += ")";
                                                //result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
                                                #endregion
                                            }

                                            //Termina de recorrer los items de la orden, procesa la linea ------
                                            DataSet myDataSet1 = new DataSet();
                                            string resultIntegracion = "0";

                                            LogInfo("IntegraOrdenesRipley", "Llamado GeneraProceso: " + stArchivo.Trim());

                                            myDataSet1 = Tmpt_SolImportDespacho.GeneraProceso(stArchivo,
                                                                                              stUserName,
                                                                                              new DateTime(DateTime.Now.Year,
                                                                                                           DateTime.Now.Month,
                                                                                                           DateTime.Now.Day));
                                            if (myDataSet1.Tables.Count > 0)
                                            {
                                                int tabla1 = myDataSet1.Tables.Count;
                                                resultIntegracion = myDataSet1.Tables[tabla1 - 1].Rows[0]["Generacion"].ToString().Trim();

                                                if (resultIntegracion != "0")
                                                {
                                                    LogInfo("IntegraOrdenesRipley", "Orden de Ripley integrada correctamente, " + 
                                                                                    "Id Orden: " + stTexto27.Trim() +
                                                                                    ", SDD generada: " + myDataSet1.Tables[0].Rows[0]["Generacion"].ToString().Trim());
                                                                                                                             
                                                }
                                                else
                                                {
                                                    LogInfo("IntegraOrdenesRipley", "Error al integrar Orden de Ripley. " +
                                                                                    "Id Orden: " + stTexto27.Trim() +
                                                                                    ", Error: " + myDataSet1.Tables[0].Rows[0]["GlosaEstado"].ToString().Trim());
                                                }
                                            }
                                            else
                                            {
                                                LogInfo("IntegraOrdenesRipley", "Error luego de GeneraProceso para " + stArchivo.Trim() + ", el proceso no retornó tablas de salida");
                                            }

                                        } //FIN Si No existe

                                    } //FIN Recorre Ordenes obtenidas desde Ripley -------

                                    offset = offset + limit;

                                } //FIN ciclo de llamados a la API 
                            }
                            else
                            {
                                LogInfo("IntegraOrdenesRipley", "Error al ejecutar llamado API Ordenes Ripley. " + rss["message"].ToString().Trim());
                            }
                        }
                        else
                        {
                            LogInfo("IntegraOrdenesRipley", "Error llamado API Integra Ordenes Ripley");
                        }
                    }
                }
                else
                {
                    LogInfo("IntegraOrdenesRipley", "Problema al leer ruta API");
                }

            }
            catch (Exception ex)
            {
                LogInfo(ex.Message, "Error");
            }
        }

        //Generacion Etiquetas Ripley
        private void GeneraEtiquetasRipley()
        {
            try
            {
                LogInfo("GeneraEtiquetasRipley", "Inicio ejecucion");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpÌd, out EmpId);

                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId, "RIPLEY_GEN_LABELS"); 
                if (myData.Tables.Count > 0)
                {
                    for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                    {
                        //Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento --------------------
                        var client = new RestClient(myData.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim().Replace("{NumeroReferencia}", myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim()));

                        client.Timeout = -1;

                        //Indica el metodo de llamado de la API ----
                        var request = new RestRequest(Method.GET);
                        switch (myData.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                        {
                            case "GET":
                                request = new RestRequest(Method.GET); //consulta
                                break;
                            case "POST":
                                request = new RestRequest(Method.POST); //crea
                                break;
                            case "PUT":
                                request = new RestRequest(Method.PUT); //modifica
                                break;
                        }

                        //Trae informacion para headers segun el nombre proceso -------
                        DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myData.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(), 2);

                        //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
                        if (myData2.Tables.Count > 0)
                        {
                            for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                            {
                                //agrega key y su valor -----------
                                request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                            }
                        }

                        //myData.Tables[0].Rows[i]["Cantidad"].ToString().Trim() 

                        //Cantidad = trae la cantidad de bultos 
                        //Texto1 = Trae Dato2, ahi se guarda id interno del pedido de ripley 

                        var body = @"{" + "\n" +
                                   @"   ""label"": {" + "\n" +
                                   @"       ""packages"": """ + myData.Tables[0].Rows[i]["Cantidad"].ToString().Trim() + @"""" + @"\n" +
                                   @"   }," + "\n" +
                                   @"   ""order"": {" + "\n" +
                                   @"       ""_id"": """ + myData.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim() + @"""" + @"\n" +
                                   @"   }" + "\n" +
                                   @"}";

                        ////var a = $"esto es una prueba de {body} y " +
                        ////        $"reemplazar valores por interpolacion";
                        ////var b = string.Format("esto es una prueba de concatenar un {0}, {1}, {2} y {3}","texto1","texto2","texto3","texto4");

                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);

                        LogInfo("GeneraEtiquetasRipley", "Ejecuta api NumeroReferencia " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim());

                        HttpStatusCode CodigoRetorno = response.StatusCode;
                        
                        //No trae JSON de retorno
                        //JObject rss = JObject.Parse(response.Content); //recupera json de retorno

                        //Si finalizó OK retorna Status 202 --------------------------
                        if (CodigoRetorno.Equals(HttpStatusCode.Accepted))
                        {
                            //Actualiza nuevo token para las API de Ripley ---------------
                            result = WS_Integrador.Classes.model.InfF_Generador.IntegraDescargaEtiquetaRipley(int.Parse(myData.Tables[0].Rows[i]["Folio"].ToString().Trim()));
                            if (result == "OK")
                            {
                                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (1)------
                                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                                                                                                      int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                      int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));
                            }
                            else
                            {
                                LogInfo("ObtieneTokenRipley", "Problema al integrar descarga etiqueta Ripley ya generada, IdRevision: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim());
                            } 
                        }
                        else
                        {
                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado con Error (2)------
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));

                            LogInfo("GeneraEtiquetasRipley", "Error al llamar API:" + response.StatusCode.ToString() + 
                                                             ", IdRevision: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogInfo(ex.Message, "Error");
            }
        }

        //Descarga Etiquetas Ripley
        private void DescargaEtiquetasRipley()
        {
            try
            {
                LogInfo("DescargaEtiquetasRipley", "Inicio ejecucion", true);

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpÌd, out EmpId);

                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId, "RIPLEY_DOWNLOAD_LABELS");
                if (myData.Tables.Count > 0)
                {
                    for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                    {
                        //Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento --------------------
                        var client = new RestClient(myData.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim().Replace("{NumeroReferencia}", myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim()));

                        client.Timeout = -1;

                        //Indica el metodo de llamado de la API ----
                        var request = new RestRequest(Method.GET);
                        switch (myData.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                        {
                            case "GET":
                                request = new RestRequest(Method.GET); //consulta
                                break;
                            case "POST":
                                request = new RestRequest(Method.POST); //crea
                                break;
                            case "PUT":
                                request = new RestRequest(Method.PUT); //modifica
                                break;
                        }

                        //Trae informacion para headers segun el nombre proceso -------
                        DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myData.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(), 2);

                        //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
                        if (myData2.Tables.Count > 0)
                        {
                            for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                            {
                                //agrega key y su valor -----------
                                request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                            }
                        }

                        //myData.Tables[0].Rows[i]["Cantidad"].ToString().Trim() 
                        var body = @"{" + "\n" +
                                   @"     ""orders"": [" + "\n" +
                                   @"        {" + "\n" +
                                   @"           ""document_id"": """ + myData.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim() + @"""" + "\n" +
                                   @"        }" + "\n" +
                                   @"     ]" + "\n" +
                                   @"}";

                        ////var a = $"esto es una prueba de {body} y " +
                        ////        $"reemplazar valores por interpolacion";
                        ////var b = string.Format("esto es una prueba de concatenar un {0}, {1}, {2} y {3}","texto1","texto2","texto3","texto4");

                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);

                        LogInfo("DescargaEtiquetasRipley", "Ejecuta api NumeroReferencia " + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim());

                        HttpStatusCode CodigoRetorno = response.StatusCode;
                        JObject rss = JObject.Parse(response.Content); //recupera json de retorno

                        //Si finalizó OK --------------------------
                        if (CodigoRetorno.Equals(HttpStatusCode.OK))
                        {
                            //de retorno trae la siguiente estructura:
                            //{
                            //  "orders_without_labels": [],
                            //  "labels_generated": "JVBERi0xLjMKJeLjz9MKMSAwIG9ia...etc etc etc",
                            //  "orders_with_error": []
                            //}

                            string EtiquetaBase64;
                            string RutaDestino;

                            RutaDestino = ConfigurationManager.AppSettings["RutaEtiquetasRipley"].ToString(); //ruta que apunta a carpeta en el servidor de aplicacion

                            EtiquetaBase64 = rss["labels_generated"].ToString(); //etiqueta generada en base 64 

                            byte[] bytesEtiqueta = Convert.FromBase64String(EtiquetaBase64);

                            //File.WriteAllBytes(@"\\192.168.1.76\c$\Sitios\MUNDOSALUD\uploads\SDR\pruebaBase64aPDF.pdf", bytes_);

                            RutaDestino = RutaDestino + @"\EtiquetaRipley_SDR_" + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() + ".pdf";
                            File.WriteAllBytes(RutaDestino, bytesEtiqueta);

                            LogInfo("DescargaEtiquetasRipley", "Guarda Etiqueta Ripley: " + "EtiquetaRipley_SDR_" + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() + ".pdf");

                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (1)------
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));
                        }
                        else
                        {
                            LogInfo("DescargaEtiquetasRipley", "Error generar Etiqueta Ripley: " + "EtiquetaRipley_SDR_" + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() + ".pdf");

                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado con Error (2)------
                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                  int.Parse(myData.Tables[0].Rows[i]["IdDet"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogInfo(ex.Message, "Error en DescargaEtiquetasRipley", true);
            }
        }

        // Servicio WEB integracion Confirmacion Recepcion - despacho INET - SIWMS_WSRecepcionConfirmacion 
        private void ConfirmacionRecepcionINET(string NombreProceso)
        {
            try
            {
                LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " + "Inicio ejecucion");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpÌd, out EmpId);

                //Trae url de API para confirmar Recepciones ----
                DataSet dsRuta = WS_Integrador.Classes.model.InfF_Generador.LeeRutaAPI(EmpId,
                                                                                       NombreProceso);
                if (dsRuta.Tables.Count > 0)
                {
                    //Extrae RDM (Recepciones de mercancia) que debe integrar a INET ----------
                    DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId,
                                                                                                                   NombreProceso);
                    if (myData.Tables.Count > 0) 
                    {
                        if (myData.Tables[0].Rows.Count > 0)
                        {
                            Cab_ConfirmaRecepcionINET CabJson = new Cab_ConfirmaRecepcionINET();
                            Cab2_ConfirmaRecepcionINET Cabecera = new Cab2_ConfirmaRecepcionINET();
                            Det_ConfirmaRecepcionINET Detalle = new Det_ConfirmaRecepcionINET();
                            Det_Lote_ConfirmaRecepcionINET Lote = new Det_Lote_ConfirmaRecepcionINET();
                            Det_Lote_Ubi_ConfirmaRecepcionINET Ubicacion = new Det_Lote_Ubi_ConfirmaRecepcionINET();

                            //string varREC_MovNumRef = "";
                            string varIdCab = "";

                            //Recorre la confirmaciones de recepcion que retornó --------------
                            for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++) 
                            {
                                //Cuando cambie de ODP de la tabla de integracion debe cargar una nueva estructura con la API -----
                                if (myData.Tables[0].Rows[i]["IdCab"].ToString().Trim() != varIdCab || varIdCab == "")
                                {
                                    //Carga ruta de la API para integrar segun nombre proceso que genero documento ----------
                                    #region Carga ruta de la API para integrar segun nombre proceso que genero documento ----------

                                    var client = new RestClient(dsRuta.Tables[0].Rows[0]["URL_EndPoint"].ToString().Trim());

                                    client.Timeout = -1;

                                    //Indica el metodo de llamado de la API ----
                                    var request = new RestRequest(Method.GET);
                                    switch (dsRuta.Tables[0].Rows[0]["Metodo"].ToString().Trim())
                                    {
                                        case "GET":
                                            request = new RestRequest(Method.GET); //consulta
                                            break;
                                        case "POST":
                                            request = new RestRequest(Method.POST); //crea
                                            break;
                                        case "PUT":
                                            request = new RestRequest(Method.PUT); //modifica
                                            break;
                                    }

                                    //Trae informacion para headers segun el nombre proceso -------
                                    DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId,
                                                                                                                                            NombreProceso,
                                                                                                                                            2);

                                    //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
                                    if (myData2.Tables.Count > 0)
                                    {
                                        for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                                        {
                                            //agrega key y su valor -----------
                                            request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                        }
                                    }
                                    #endregion

                                    //Carga Variable para generar JSON ----------------------------------------------

                                    //Inicializa variable principal
                                    CabJson = new Cab_ConfirmaRecepcionINET();
                                    Cabecera = new Cab2_ConfirmaRecepcionINET();

                                    DateTime fecha;
                                    fecha = DateTime.Now;

                                    //Guarda cabecera de integracion que esta procesando ---------
                                    varIdCab = myData.Tables[0].Rows[i]["IdCab"].ToString().Trim();

                                    Cabecera.REC_MovTpo = int.Parse(myData.Tables[0].Rows[i]["REC_MovTpo"].ToString().Trim());
                                    Cabecera.REC_MovIden = 0; // long.Parse(myData.Tables[0].Rows[i]["REC_MovIden"].ToString().Trim());

                                    //concatena lo siguiente orden_compra_recibida_de_INET;tipo_documento_SII;numero_documento_recepcionado (factura)
                                    //Cabecera.REC_MovNumRef = myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() + ";" +
                                    //                         myData.Tables[0].Rows[i]["TipoDocumento"].ToString().Trim() + ";" +
                                    //                         myData.Tables[0].Rows[i]["NumeroDocto"].ToString().Trim();

                                    Cabecera.REC_MovNumRef = myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();

                                    Cabecera.REC_MovFecRef = DateTime.Parse(myData.Tables[0].Rows[i]["FechaProceso"].ToString().Trim());
                                    Cabecera.REC_MovTipRef = 1; // int.Parse(myData.Tables[0].Rows[i]["REC_MovTipRef"].ToString().Trim());
                                    Cabecera.REC_MovNomRef = myData.Tables[0].Rows[i]["RazonSocial"].ToString().Trim();
                                    Cabecera.REC_MovRutSec = 0; //int.Parse(myData.Tables[0].Rows[i]["REC_MovRutSec"].ToString().Trim());

                                    int LargoRut = myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Length;

                                    //Si el rut tiene mas de 2 caracteres y tiene guion
                                    if (LargoRut >= 3 && myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Contains("-") == true)
                                    {
                                        Cabecera.REC_MovRutRef = long.Parse(myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Substring(0, LargoRut - 2));
                                        Cabecera.REC_MovRutDig = myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Substring(LargoRut - 1, 1);
                                    }
                                    else
                                    {
                                        Cabecera.REC_MovRutRef = 0;
                                        Cabecera.REC_MovRutDig = "";

                                        if (myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().All(char.IsDigit) == true && LargoRut > 0)
                                        {
                                            Cabecera.REC_MovRutRef = long.Parse(myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim());
                                            Cabecera.REC_MovRutDig = "";
                                        }
                                        else
                                        {
                                            Cabecera.REC_MovRutRef = 0;
                                            Cabecera.REC_MovRutDig = "";
                                        }
                                    }

                                    //Cabecera.SOL_MovIdenWMS = myData.Tables[0].Rows[i]["SOL_MovIdenWMS"].ToString().Trim();
                                    //Cabecera.SOL_MovIden = long.Parse(myData.Tables[0].Rows[i]["SOL_MovIden"].ToString().Trim());
                                    //Cabecera.SOL_MovTpo = int.Parse(myData.Tables[0].Rows[i]["SOL_MovTpo"].ToString().Trim());

                                    //Cabecera.REC_MovRegJsonRes = ""; // myData.Tables[0].Rows[i]["REC_MovRegJsonRes"].ToString().Trim();              //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovRegJson = ""; // myData.Tables[0].Rows[i]["REC_MovRegJson"].ToString().Trim();                    //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovRegSin = "N"; // myData.Tables[0].Rows[i]["REC_MovRegSin"].ToString().Trim();                     //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovRegFec = DateTime.Now; //DateTime.Parse(myData.Tables[0].Rows[i]["REC_MovRegFec"].ToString().Trim()); //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovRegUsu = myData.Tables[0].Rows[i]["Username"].ToString().Trim();                                  //20-07-2022: portland pide eliminarlo

                                    //si es una Recepcion envia datos del documento legal de referencia para el SII ---
                                    if (NombreProceso.Trim() == "CONFIRMACION_RECEPCION_INET")
                                    {
                                        Cabecera.REC_SIITip = int.Parse(myData.Tables[0].Rows[i]["TipoDocumento"].ToString().Trim());
                                        Cabecera.REC_SIINum = myData.Tables[0].Rows[i]["NumeroDocto"].ToString().Trim();
                                        Cabecera.REC_SIIFec = DateTime.Parse(myData.Tables[0].Rows[i]["FechaDocto"].ToString().Trim());
                                        //Cabecera.REC_SIIMon = 0; // int.Parse(myData.Tables[0].Rows[i]["REC_SIIMon"].ToString().Trim());              //20-07-2022: portland pide eliminarlo
                                    }
                                    else
                                    {
                                        Cabecera.REC_SIITip = 0;
                                        Cabecera.REC_SIINum = "0";
                                        Cabecera.REC_SIIFec = new DateTime(1900, 1, 1);
                                        //Cabecera.REC_SIIMon = 0;                                                                                      //20-07-2022: portland pide eliminarlo
                                    }

                                    Cabecera.REC_Mov_RecFec = DateTime.Parse(DateTime.Now.ToString());  //DateTime.Parse(myData.Tables[0].Rows[i]["REC_Mov_RecFec"].ToString().Trim()); ;

                                    if (NombreProceso.Trim() == "CONFIRMACION_RECEPCION_INET")
                                    {
                                        Cabecera.REC_Mov_BodDes = myData.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim();
                                        Cabecera.REC_Mov_BodOri = "0"; // myData.Tables[0].Rows[i]["REC_Mov_BodOri"].ToString().Trim();
                                    }
                                    else
                                    {
                                        Cabecera.REC_Mov_BodDes = "0"; //myData.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim();
                                        Cabecera.REC_Mov_BodOri = myData.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim();
                                    }

                                    //Cabecera.REC_MovAno = DateTime.Now.Year; //int.Parse(myData.Tables[0].Rows[i]["REC_MovAno"].ToString().Trim());   //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovMes = DateTime.Now.Month; //int.Parse(myData.Tables[0].Rows[i]["REC_MovMes"].ToString().Trim());  //20-07-2022: portland pide eliminarlo

                                    Cabecera.REC_MovRefWMS = long.Parse(myData.Tables[0].Rows[i]["Folio"].ToString().Trim()); //ODP - Cola picking

                                    //Busca detalles relacionados
                                    string CondicionBusqueda = "IdCab = " + myData.Tables[0].Rows[i]["IdCab"].ToString().Trim();
                                    string _ItemReferencia = "";
                                    string _NroSerieDesp = "";

                                    DataRow[] resultado = myData.Tables[0].Select(CondicionBusqueda);

                                    //Recorre detalles relacionados al Folio -----------
                                    foreach (DataRow fila in resultado)
                                    {
                                        //Si cambia de Item Referencia o es el primero -----
                                        if (fila["ItemReferencia"].ToString().Trim() != _ItemReferencia.Trim())
                                        {
                                            //si no era el primer ItemReferencia agrega el anterior al JSON -----
                                            if (_ItemReferencia.Trim() != "")
                                            {
                                                Cabecera.CONDET.Add(Detalle);
                                            }

                                            _ItemReferencia = fila["ItemReferencia"].ToString().Trim();
                                            _NroSerieDesp = "";

                                            Detalle = new Det_ConfirmaRecepcionINET(); //nuevo detalle
                                            Detalle.REC_MovLinId = int.Parse(fila["Linea"].ToString());
                                            Detalle.REC_MovLin_ProdId = fila["CodigoArticulo"].ToString();
                                            Detalle.REC_MovLin_ProdNam = fila["DescripArt"].ToString();
                                            Detalle.REC_MovLin_UnMe = fila["UnidadMedida"].ToString();
                                            Detalle.REC_MovLin_CantWMS = fila["Cantidad"].ToString();
                                            Detalle.REC_MovLin_Estado = fila["Estado"].ToString();

                                            Detalle.SOL_MovTpo = 0; //long.Parse(fila["SOL_MovTpo"].ToString());
                                            Detalle.SOL_MovIden = 0; //long.Parse(fila["SOL_MovIden"].ToString());

                                            //si el item referencia viene vacio o en cero asigna 1 por defecto --------------------
                                            if (fila["ItemReferencia"].ToString() == "" || fila["ItemReferencia"].ToString() == "0")
                                            {
                                                Detalle.SOL_MovLinId = 1;
                                            }
                                            else
                                            {
                                                Detalle.SOL_MovLinId = int.Parse(fila["ItemReferencia"].ToString());
                                            }

                                        } //FIN Si cambia de Item Referencia -----

                                        //Busca Lotes relacionados
                                        //string CondicionBusqueda2 = "Folio = " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                        //                            " AND Linea = " + fila["Linea"].ToString();

                                        //DataRow[] resultado2 = myData.Tables[0].Select(CondicionBusqueda2);

                                        //Si cambia de Lote o si no informa lote -----
                                        if ((fila["NroSerieDesp"].ToString().Trim() != _NroSerieDesp.Trim()) || (fila["NroSerieDesp"].ToString().Trim() == ""))
                                        {
                                            Lote = new Det_Lote_ConfirmaRecepcionINET();
                                            Lote.REC_MovLinLSNum = fila["NroSerieDesp"].ToString(); //Lote
                                            Lote.REC_MovLinLSDes = fila["NroSerieDesp"].ToString();
                                            Lote.REC_MovLinLSFVig = DateTime.Now; //DateTime.Parse(fila2["REC_MovLinLSFVig"].ToString());
                                            Lote.REC_MovLinLSFVen = DateTime.Parse(fila["FechaVectoDesp"].ToString());
                                            Lote.REC_MovLinLSCant = decimal.Parse(fila["CantidadProc"].ToString());
                                            Lote.REC_MovLinLSIndi = (int.Parse(fila["UsaLote"].ToString()) == 1 ? "S" : "N");
                                            //Lote.REC_MovLinLSIUbic = fila2["REC_MovLinLSIUbic"].ToString();

                                            //Carga campos ubicacion
                                            Ubicacion = new Det_Lote_Ubi_ConfirmaRecepcionINET();
                                            Ubicacion.REC_MovLinLotUbic = fila["CodigoUbicacion"].ToString();
                                            Ubicacion.REC_MovLinLotCant = decimal.Parse(fila["CantidadProc"].ToString());

                                            Lote.LOTSERUBI.Add(Ubicacion); //Agrega ubicacion al Lote
                                            Detalle.LOTSER.Add(Lote); //Agrega lote al detalle

                                            _NroSerieDesp = fila["NroSerieDesp"].ToString().Trim(); //guarda serie que agregó
                                        } 

                                    } //FIN for each detalles relacionados al Folio 

                                    Cabecera.CONDET.Add(Detalle); //Agrega detalle a la cabecera
                                    CabJson.SIWMSSDTRecepcion = Cabecera; //Carga cabecera en la estructura principal

                                    //-------------------------------------------------------------
                                    //Crea body para llamado con estructura de variable cargada ---
                                    var body = JsonConvert.SerializeObject(CabJson);

                                    request.AddParameter("application/json", body, ParameterType.RequestBody);

                                    //EJECUTA LLAMADO API ---------------------------
                                    IRestResponse response = client.Execute(request);

                                    if (NombreProceso.Trim() == "CONFIRMACION_RECEPCION_INET")
                                    {
                                        LogInfo("ConfirmacionRecepcionINET",NombreProceso.Trim() + ". " + 
                                                                            "Ejecutara api con Recepcion n°: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                            ", SDR N°: " + myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim() +
                                                                            ", Referencia INET:" + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() +
                                                                            ". JSON: " + body.ToString());
                                    }
                                    else
                                    {
                                        LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " + 
                                                                             "Ejecutara api con ODP N°: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                             ", SDD N°: " + myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim() +
                                                                             ", Referencia INET:" + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() +
                                                                             ". JSON: " + body.ToString());
                                    }

                                    HttpStatusCode CodigoRetorno = response.StatusCode;
                                    string JSONRetorno = response.Content;
                                    int JSONerror = 0;

                                    //*** parche para JSON erroneo que retorna PORTLAND hasta que lo corrijan ***//
                                    if (JSONRetorno.Contains(@"{""SDTRespuestas"":{""Tipo"":0}}") == true)
                                    {
                                        JSONerror = 1;
                                        JSONRetorno = JSONRetorno.Replace(@"{""SDTRespuestas"":{""Tipo"":0}}", "");
                                    }

                                    //JObject rss = JObject.Parse(response.Content); //recupera json de retorno
                                    JObject rss = JObject.Parse(JSONRetorno); //recupera json de retorno

                                    int Res;
                                    string Respuesta = "";

                                    //Si finalizó OK y el json no es erroneo --------------------------
                                    if (CodigoRetorno.Equals(HttpStatusCode.OK) && JSONerror == 0)
                                    {
                                        //Si retorno sin errores
                                        if (rss["SDTRespuestas"]["Tipo"].ToString() == "0")
                                        {
                                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                     2); //Procesado
                                            //Recorre respuestas ok ----- 
                                            for (Res = 0; Res < (Int32)rss["SDTRespuestas"]["Datos"].Count(); Res++)
                                            {
                                                Respuesta = Respuesta.Trim() + " " + rss["SDTRespuestas"]["Datos"][Res]["NOMBRE"].ToString().Trim() + ": " +
                                                                                     rss["SDTRespuestas"]["Datos"][Res]["DATO"].ToString().Trim() + ".";
                                            }

                                            LogInfo("ConfirmacionRecepcionINET.", NombreProceso.Trim() + ". " + "Integracion OK. " + Respuesta.Trim());
                                        }

                                        //Si retorno Con errores
                                        if (rss["SDTRespuestas"]["Tipo"].ToString() == "1")
                                        {
                                            //Recorre respuestas Error ----- 
                                            for (Res = 0; Res < (Int32)rss["SDTRespuestas"]["Errores"].Count(); Res++)
                                            {
                                                Respuesta = Respuesta.Trim() + " " + rss["SDTRespuestas"]["Errores"][Res]["ErrorDescripcion"].ToString().Trim() + ".";
                                            }

                                            LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". "+ 
                                                                                 "Error api Folio: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                                 ", Error: " + Respuesta.Trim() + 
                                                                                 ". JSON: " + body.ToString(),true);

                                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                     3); //Procesado con error 
                                        }
                                    }
                                    else
                                    {
                                        //Si contiene mensaje de error lo rescata --- 
                                        if (rss.ToString().Contains("message") == true)
                                        {
                                            Respuesta = ". " + rss["error"]["code"].ToString() + " - " + rss["error"]["message"].ToString();
                                        }
                                        else
                                        {
                                            Respuesta = "";
                                        }

                                        LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " + 
                                                                             "Error api Folio: " +
                                                                             myData.Tables[0].Rows[i]["Folio"].ToString().Trim() + Respuesta.Trim() + 
                                                                             ". JSON: " + body.ToString(), true);

                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                 3); //Procesado con error
                                    }
                                } //FIN si cambia de Folio

                            } //FIN ciclo recorre Confirmaciones
                        }
                    }

                } //FIN lee ruta
            }
            catch (Exception ex)
            {
                LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " + "Error: " + ex.Message, true);
            }
        }

        // Servicio WEB integracion Confirmacion Recepcion INET - SIWMS_WSRecepcionConfirmacion 
        private void ConfirmacionRecepcionINET_RDM(string NombreProceso)
        {
            try
            {
                LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " + "Inicio ejecucion");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpÌd, out EmpId);

                //Trae url de API para confirmar Recepciones ----
                DataSet dsRuta = WS_Integrador.Classes.model.InfF_Generador.LeeRutaAPI(EmpId,
                                                                                       NombreProceso);
                if (dsRuta.Tables.Count > 0)
                {
                    //Extrae RDM (Recepciones de mercancia) que debe integrar a INET ----------
                    DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId,
                                                                                                                   NombreProceso);
                    if (myData.Tables.Count > 0)
                    {
                        if (myData.Tables[0].Rows.Count > 0)
                        {
                            Cab_ConfirmaRecepcionINET CabJson = new Cab_ConfirmaRecepcionINET();
                            Cab2_ConfirmaRecepcionINET Cabecera = new Cab2_ConfirmaRecepcionINET();
                            Det_ConfirmaRecepcionINET Detalle = new Det_ConfirmaRecepcionINET();
                            Det_Lote_ConfirmaRecepcionINET Lote = new Det_Lote_ConfirmaRecepcionINET();
                            Det_Lote_Ubi_ConfirmaRecepcionINET Ubicacion = new Det_Lote_Ubi_ConfirmaRecepcionINET();

                            string varIdCab = "";

                            //Recorre la confirmaciones de recepcion que retornó --------------
                            for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                            {
                                //Cuando cambie de RDM, de id de integracion, debe cargar la estructura con la API -----
                                if (myData.Tables[0].Rows[i]["IdCab"].ToString().Trim() != varIdCab || varIdCab == "")
                                {
                                    //Carga ruta de la API para integrar segun nombre proceso que genero documento ----------
                                    #region Carga ruta de la API para integrar segun nombre proceso que genero documento ----------

                                    var client = new RestClient(dsRuta.Tables[0].Rows[0]["URL_EndPoint"].ToString().Trim());

                                    client.Timeout = -1;

                                    //Indica el metodo de llamado de la API ----
                                    var request = new RestRequest(Method.GET);
                                    switch (dsRuta.Tables[0].Rows[0]["Metodo"].ToString().Trim())
                                    {
                                        case "GET":
                                            request = new RestRequest(Method.GET); //consulta
                                            break;
                                        case "POST":
                                            request = new RestRequest(Method.POST); //crea
                                            break;
                                        case "PUT":
                                            request = new RestRequest(Method.PUT); //modifica
                                            break;
                                    }

                                    //Trae informacion para headers segun el nombre proceso -------
                                    DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId,
                                                                                                                                            NombreProceso,
                                                                                                                                            2);

                                    //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
                                    if (myData2.Tables.Count > 0)
                                    {
                                        for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                                        {
                                            //agrega key y su valor -----------
                                            request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                        }
                                    }
                                    #endregion

                                    //Carga Variable para generar JSON ----------------------------------------------

                                    //Inicializa variable principal
                                    CabJson = new Cab_ConfirmaRecepcionINET();
                                    Cabecera = new Cab2_ConfirmaRecepcionINET();

                                    DateTime fecha;
                                    fecha = DateTime.Now;

                                    //Guarda id de cabecera de integracion que esta procesando ---------
                                    varIdCab = myData.Tables[0].Rows[i]["IdCab"].ToString().Trim();

                                    Cabecera.REC_MovTpo = int.Parse(myData.Tables[0].Rows[i]["REC_MovTpo"].ToString().Trim());

                                    Cabecera.REC_MovIden = 0; // long.Parse(myData.Tables[0].Rows[i]["REC_MovIden"].ToString().Trim());

                                    //concatena lo siguiente orden_compra_recibida_de_INET;tipo_documento_SII;numero_documento_recepcionado (factura)
                                    //Cabecera.REC_MovNumRef = myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() + ";" +
                                    //                         myData.Tables[0].Rows[i]["TipoDocumento"].ToString().Trim() + ";" +
                                    //                         myData.Tables[0].Rows[i]["NumeroDocto"].ToString().Trim();

                                    Cabecera.REC_MovNumRef = myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();

                                    Cabecera.REC_MovFecRef = DateTime.Parse(myData.Tables[0].Rows[i]["FechaProceso"].ToString().Trim());
                                    Cabecera.REC_MovTipRef = 1; // int.Parse(myData.Tables[0].Rows[i]["REC_MovTipRef"].ToString().Trim());
                                    Cabecera.REC_MovNomRef = myData.Tables[0].Rows[i]["RazonSocial"].ToString().Trim();
                                    Cabecera.REC_MovRutSec = 0; //int.Parse(myData.Tables[0].Rows[i]["REC_MovRutSec"].ToString().Trim());

                                    int LargoRut = myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Length;

                                    //Si el rut tiene mas de 2 caracteres y tiene guion
                                    if (LargoRut >= 3 && myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Contains("-") == true)
                                    {
                                        Cabecera.REC_MovRutRef = long.Parse(myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Substring(0, LargoRut - 2));
                                        Cabecera.REC_MovRutDig = myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Substring(LargoRut - 1, 1);
                                    }
                                    else
                                    {
                                        if (myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().All(char.IsDigit) == true && LargoRut > 0)
                                        {
                                            Cabecera.REC_MovRutRef = long.Parse(myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim());
                                            Cabecera.REC_MovRutDig = "";
                                        }
                                        else
                                        {
                                            Cabecera.REC_MovRutRef = 0;
                                            Cabecera.REC_MovRutDig = "";
                                        }
                                    }

                                    //Cabecera.SOL_MovIdenWMS = myData.Tables[0].Rows[i]["SOL_MovIdenWMS"].ToString().Trim();
                                    //Cabecera.SOL_MovIden = long.Parse(myData.Tables[0].Rows[i]["SOL_MovIden"].ToString().Trim());
                                    //Cabecera.SOL_MovTpo = int.Parse(myData.Tables[0].Rows[i]["SOL_MovTpo"].ToString().Trim());

                                    //Cabecera.REC_MovRegJsonRes = ""; // myData.Tables[0].Rows[i]["REC_MovRegJsonRes"].ToString().Trim();              //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovRegJson = ""; // myData.Tables[0].Rows[i]["REC_MovRegJson"].ToString().Trim();                    //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovRegSin = "N"; // myData.Tables[0].Rows[i]["REC_MovRegSin"].ToString().Trim();                     //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovRegFec = DateTime.Now; //DateTime.Parse(myData.Tables[0].Rows[i]["REC_MovRegFec"].ToString().Trim()); //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovRegUsu = myData.Tables[0].Rows[i]["Username"].ToString().Trim();                                  //20-07-2022: portland pide eliminarlo

                                    //si es una Recepcion envia datos del documento legal de referencia para el SII ---
                                    if (NombreProceso.Trim() == "CONFIRMACION_RECEPCION_INET")
                                    {
                                        Cabecera.REC_SIITip = int.Parse(myData.Tables[0].Rows[i]["TipoDocumento"].ToString().Trim());
                                        Cabecera.REC_SIINum = myData.Tables[0].Rows[i]["NumeroDocto"].ToString().Trim();
                                        Cabecera.REC_SIIFec = DateTime.Parse(myData.Tables[0].Rows[i]["FechaDocto"].ToString().Trim());
                                        //Cabecera.REC_SIIMon = 0; // int.Parse(myData.Tables[0].Rows[i]["REC_SIIMon"].ToString().Trim());              //20-07-2022: portland pide eliminarlo
                                    }
                                    else
                                    {
                                        Cabecera.REC_SIITip = 0;
                                        Cabecera.REC_SIINum = "0";
                                        Cabecera.REC_SIIFec = new DateTime(1900, 1, 1);
                                        //Cabecera.REC_SIIMon = 0;                                                                                      //20-07-2022: portland pide eliminarlo
                                    }

                                    Cabecera.REC_Mov_RecFec = DateTime.Parse(DateTime.Now.ToString());  //DateTime.Parse(myData.Tables[0].Rows[i]["REC_Mov_RecFec"].ToString().Trim()); ;

                                    if (NombreProceso.Trim() == "CONFIRMACION_RECEPCION_INET")
                                    {
                                        Cabecera.REC_Mov_BodDes = myData.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim();
                                        Cabecera.REC_Mov_BodOri = "0"; // myData.Tables[0].Rows[i]["REC_Mov_BodOri"].ToString().Trim();
                                    }
                                    else
                                    {
                                        Cabecera.REC_Mov_BodDes = "0"; //myData.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim();
                                        Cabecera.REC_Mov_BodOri = myData.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim();
                                    }

                                    //Cabecera.REC_MovAno = DateTime.Now.Year; //int.Parse(myData.Tables[0].Rows[i]["REC_MovAno"].ToString().Trim());   //20-07-2022: portland pide eliminarlo
                                    //Cabecera.REC_MovMes = DateTime.Now.Month; //int.Parse(myData.Tables[0].Rows[i]["REC_MovMes"].ToString().Trim());  //20-07-2022: portland pide eliminarlo

                                    Cabecera.REC_MovRefWMS = long.Parse(myData.Tables[0].Rows[i]["Folio"].ToString().Trim()); //ODP - Cola picking

                                    //Busca detalles relacionados
                                    string CondicionBusqueda = "IdCab = " + myData.Tables[0].Rows[i]["IdCab"].ToString().Trim();
                                    string _ItemReferencia = "";
                                    string _NroSerieDesp = "";

                                    DataRow[] resultado = myData.Tables[0].Select(CondicionBusqueda);

                                    //Recorre detalles relacionados al id cabecera integracion -----
                                    foreach (DataRow fila in resultado)
                                    {
                                        //Si cambia de Item Referencia -----
                                        if (fila["ItemReferencia"].ToString().Trim() != _ItemReferencia.Trim())
                                        {
                                            //si no era el primer ItemReferencia agrega el anterior al JSON -----
                                            if (_ItemReferencia.Trim() != "")
                                            {
                                                Cabecera.CONDET.Add(Detalle);
                                            }

                                            _ItemReferencia = fila["ItemReferencia"].ToString().Trim();
                                            _NroSerieDesp = "";

                                            Detalle = new Det_ConfirmaRecepcionINET();
                                            Detalle.REC_MovLinId = int.Parse(fila["Linea"].ToString());
                                            Detalle.REC_MovLin_ProdId = fila["CodigoArticulo"].ToString();
                                            Detalle.REC_MovLin_ProdNam = fila["DescripArt"].ToString();
                                            Detalle.REC_MovLin_UnMe = fila["UnidadMedida"].ToString();
                                            Detalle.REC_MovLin_CantWMS = fila["Cantidad"].ToString(); //fila["CantidadProc"].ToString();
                                            Detalle.REC_MovLin_Estado = fila["Texto1Det"].ToString(); //fila["Estado"].ToString();

                                            Detalle.SOL_MovTpo = 0; //long.Parse(fila["SOL_MovTpo"].ToString());
                                            Detalle.SOL_MovIden = 0; //long.Parse(fila["SOL_MovIden"].ToString());

                                            //si el item referencia viene vacio o en cero asigna 1 por defecto --------------------
                                            if (fila["ItemReferencia"].ToString() == "" || fila["ItemReferencia"].ToString() == "0")
                                            {
                                                Detalle.SOL_MovLinId = 1;
                                            }
                                            else
                                            {
                                                Detalle.SOL_MovLinId = int.Parse(fila["ItemReferencia"].ToString());
                                            }
                                        }

                                        //Si cambia de Lote -----
                                        if (fila["NroSerieDesp"].ToString().Trim() != _NroSerieDesp.Trim())
                                        {
                                            //Carga campos Lote
                                            Lote = new Det_Lote_ConfirmaRecepcionINET();
                                            Lote.REC_MovLinLSNum = fila["NroSerieDesp"].ToString(); //Lote
                                            Lote.REC_MovLinLSDes = fila["NroSerieDesp"].ToString();
                                            Lote.REC_MovLinLSFVig = DateTime.Parse(fila["Fecha1"].ToString()); //se agrega Fecha elaboracion 17/10/2022
                                            Lote.REC_MovLinLSFVen = DateTime.Parse(fila["FechaVectoDesp"].ToString());
                                            Lote.REC_MovLinLSCant = decimal.Parse(fila["CantidadProc"].ToString());
                                            Lote.REC_MovLinLSIndi = (int.Parse(fila["UsaLote"].ToString()) == 1 ? "S" : "N");
                                            //Lote.REC_MovLinLSIUbic = fila2["REC_MovLinLSIUbic"].ToString();

                                            //Carga campos ubicacion
                                            Ubicacion = new Det_Lote_Ubi_ConfirmaRecepcionINET();
                                            Ubicacion.REC_MovLinLotUbic = fila["CodigoUbicacion"].ToString();
                                            Ubicacion.REC_MovLinLotCant = decimal.Parse(fila["CantidadProc"].ToString());

                                            Lote.LOTSERUBI.Add(Ubicacion); //Agrega ubicacion al Lote
                                            Detalle.LOTSER.Add(Lote); //Agrega lote al detalle

                                            _NroSerieDesp = fila["NroSerieDesp"].ToString().Trim();
                                        }

                                    } //FIN for each detalles del id cabecera de integracion

                                    Cabecera.CONDET.Add(Detalle);
                                    CabJson.SIWMSSDTRecepcion = Cabecera;

                                    //-------------------------------------------------------------
                                    //Crea body para llamado con estructura de variable cargada ---
                                    var body = JsonConvert.SerializeObject(CabJson);

                                    request.AddParameter("application/json", body, ParameterType.RequestBody);

                                    //EJECUTA LLAMADO API ---------------------------
                                    IRestResponse response = client.Execute(request);

                                    if (NombreProceso.Trim() == "CONFIRMACION_RECEPCION_INET")
                                    {
                                        LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " +
                                                                            "Ejecutara api con Recepcion n°: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                            ", SDR N°: " + myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim() +
                                                                            ", Referencia INET:" + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() +
                                                                            ". JSON: " + body.ToString());
                                    }
                                    else
                                    {
                                        LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " +
                                                                             "Ejecutara api con ODP N°: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                             ", SDD N°: " + myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim() +
                                                                             ", Referencia INET:" + myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() +
                                                                             ". JSON: " + body.ToString());
                                    }

                                    HttpStatusCode CodigoRetorno = response.StatusCode;
                                    string JSONRetorno = response.Content;
                                    int JSONerror = 0;

                                    //*** parche para JSON erroneo que retorna PORTLAND hasta que lo corrijan ***//
                                    if (JSONRetorno.Contains(@"{""SDTRespuestas"":{""Tipo"":0}}") == true)
                                    {
                                        JSONerror = 1;
                                        JSONRetorno = JSONRetorno.Replace(@"{""SDTRespuestas"":{""Tipo"":0}}", "");
                                    }

                                    //JObject rss = JObject.Parse(response.Content); //recupera json de retorno
                                    JObject rss = JObject.Parse(JSONRetorno); //recupera json de retorno

                                    int Res;
                                    string Respuesta = "";

                                    //Si finalizó OK y el json no es erroneo --------------------------
                                    if (CodigoRetorno.Equals(HttpStatusCode.OK) && JSONerror == 0)
                                    {
                                        //Si retorno sin errores
                                        if (rss["SDTRespuestas"]["Tipo"].ToString() == "0")
                                        {
                                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                     2); //Procesado
                                            //Recorre respuestas ok ----- 
                                            for (Res = 0; Res < (Int32)rss["SDTRespuestas"]["Datos"].Count(); Res++)
                                            {
                                                Respuesta = Respuesta.Trim() + " " + rss["SDTRespuestas"]["Datos"][Res]["NOMBRE"].ToString().Trim() + ": " +
                                                                                     rss["SDTRespuestas"]["Datos"][Res]["DATO"].ToString().Trim() + ".";
                                            }

                                            LogInfo("ConfirmacionRecepcionINET.", NombreProceso.Trim() + ". " + "Integracion OK. " + Respuesta.Trim());
                                        }

                                        //Si retorno Con errores
                                        if (rss["SDTRespuestas"]["Tipo"].ToString() == "1")
                                        {
                                            //Recorre respuestas Error ----- 
                                            for (Res = 0; Res < (Int32)rss["SDTRespuestas"]["Errores"].Count(); Res++)
                                            {
                                                Respuesta = Respuesta.Trim() + " " + rss["SDTRespuestas"]["Errores"][Res]["ErrorDescripcion"].ToString().Trim() + ".";
                                            }

                                            LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " +
                                                                                 "Error api Folio: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                                 ", Error: " + Respuesta.Trim() +
                                                                                 ". JSON: " + body.ToString(), true);

                                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                     3); //Procesado con error 
                                        }
                                    }
                                    else
                                    {
                                        //Si contiene mensaje de error lo rescata --- 
                                        if (rss.ToString().Contains("message") == true)
                                        {
                                            Respuesta = ". " + rss["error"]["code"].ToString() + " - " + rss["error"]["message"].ToString();
                                        }
                                        else
                                        {
                                            Respuesta = "";
                                        }

                                        LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " +
                                                                             "Error api Folio: " +
                                                                             myData.Tables[0].Rows[i]["Folio"].ToString().Trim() + Respuesta.Trim() +
                                                                             ". JSON: " + body.ToString(), true);

                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                 3); //Procesado con error
                                    }
                                } //FIN si cambia de Folio

                            } //FIN ciclo recorre Confirmaciones
                        }
                    }

                } //FIN lee ruta
            }
            catch (Exception ex)
            {
                LogInfo("ConfirmacionRecepcionINET", NombreProceso.Trim() + ". " + "Error: " + ex.Message, true);
            }
        }

        // Servicio WEB integracion Solicitud INET - SIWMS_WSSolicitud --> NombreProceso = GUIA_TRASLADO_INET
        private void SolicitudINET(string NombreProceso)
        {
            try
            {
                LogInfo("SolicitudINET", "Inicio ejecucion");

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpÌd, out EmpId);

                //Trae url de API para integrar Solicitudes INET  
                DataSet dsRuta = WS_Integrador.Classes.model.InfF_Generador.LeeRutaAPI(EmpId,
                                                                                       NombreProceso.Trim());
                if (dsRuta.Tables.Count > 0)
                {
                    //Extrae datos que debe integrar a INET ----------
                    DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId,
                                                                                                                   NombreProceso.Trim());
                    if (myData.Tables.Count > 0)
                    {
                        if (myData.Tables[0].Rows.Count > 0)
                        {
                            Cab_SolicitudINET CabJson = new Cab_SolicitudINET();
                            Cab2_SolicitudINET Cabecera = new Cab2_SolicitudINET();
                            Det_SolicitudINET Detalle = new Det_SolicitudINET();
                            Det_Lote_SolicitudINET Lote = new Det_Lote_SolicitudINET();
                            Det_Lote_Ubi_SolicitudINET Ubicacion = new Det_Lote_Ubi_SolicitudINET();

                            string varIntId = "";

                            //Recorre la confirmaciones de recepcion que retornó --------------
                            for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                            {
                                //Cuando cambie id interno de integracion debe cargar la estructura con la API -----
                                if (myData.Tables[0].Rows[i]["IntId"].ToString().Trim() != varIntId)
                                {
                                    //Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento --------------------
                                    #region Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento --------------------
                                    var client = new RestClient(dsRuta.Tables[0].Rows[0]["URL_EndPoint"].ToString().Trim());

                                    client.Timeout = -1;

                                    //Indica el metodo de llamado de la API ----
                                    var request = new RestRequest(Method.GET);
                                    switch (dsRuta.Tables[0].Rows[0]["Metodo"].ToString().Trim())
                                    {
                                        case "GET":
                                            request = new RestRequest(Method.GET); //consulta
                                            break;
                                        case "POST":
                                            request = new RestRequest(Method.POST); //crea
                                            break;
                                        case "PUT":
                                            request = new RestRequest(Method.PUT); //modifica
                                            break;
                                    }

                                    //Trae informacion para headers segun el nombre proceso -------
                                    DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId,
                                                                                                                                            NombreProceso.Trim(),
                                                                                                                                            2);

                                    //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
                                    if (myData2.Tables.Count > 0)
                                    {
                                        for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                                        {
                                            //agrega key y su valor -----------
                                            request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                        }
                                    }
                                    #endregion

                                    //Carga Variable para generar JSON ----------------------------------------------

                                    //Inicializa variable principal
                                    CabJson = new Cab_SolicitudINET();
                                    Cabecera = new Cab2_SolicitudINET();

                                    DateTime fecha;
                                    fecha = DateTime.Now;

                                    //Divide campo Texto1, trae TipoMovimiento|CodigoBodega|BodegaRecep|SOL_MovRefWMSTipDoc

                                    string[] Palabras = myData.Tables[0].Rows[i]["Texto1Cab"].ToString().Trim().Split('|');

                                    //Guarda el id interno que esta procesando ---------
                                    varIntId = myData.Tables[0].Rows[i]["IntId"].ToString().Trim();

                                    //myData.Tables[0].Rows[i]["Folio"].ToString().Trim();

                                    Cabecera.SOL_MovTpo = long.Parse(Palabras[0].Trim()); //Tipo movimiento
                                                                                          //Cabecera.SOL_MovIden = 0;

                                    //---------------------------------------------------------------------------------------------------------
                                    if (long.Parse(Palabras[0].Trim()) == 13) //Si Tipo movimiento = 13 --> recepcion traspaso
                                    {
                                        Cabecera.SOL_MovNumRef = myData.Tables[0].Rows[i]["Dato1"].ToString().Trim(); //envia tipoDoctorefINET;NumeroDoctoRefINET (tipo y numero de la guia separado por ; )
                                    }
                                    else
                                    {
                                        Cabecera.SOL_MovNumRef = myData.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim(); //numero referencia INET
                                    }
                                    //-------------------------------------------------------------------------------------------------------------------

                                    Cabecera.SOL_MovFecRef = DateTime.Parse(myData.Tables[0].Rows[i]["FechaProceso"].ToString().Trim());
                                    Cabecera.SOL_MovTipRef = 1;

                                    int LargoRut = myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Length;

                                    //Si el rut tiene mas de 2 caracteres y tiene guion
                                    if (LargoRut >= 3 && myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Contains("-") == true)
                                    {
                                        Cabecera.SOL_MovRutRef = long.Parse(myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Substring(0, LargoRut - 2));
                                        Cabecera.SOL_MovRutDig = myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().Substring(LargoRut - 1, 1);
                                    }
                                    else
                                    {
                                        Cabecera.SOL_MovRutRef = 0;
                                        Cabecera.SOL_MovRutDig = "";

                                        if (myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim().All(char.IsDigit) == true && LargoRut > 0)
                                        {
                                            Cabecera.SOL_MovRutRef = long.Parse(myData.Tables[0].Rows[i]["RutCliente"].ToString().Trim());
                                            Cabecera.SOL_MovRutDig = "";
                                        }
                                        else
                                        {
                                            Cabecera.SOL_MovRutRef = 0;
                                            Cabecera.SOL_MovRutDig = "";
                                        }
                                    }

                                    Cabecera.SOL_MovRutSec = 0;
                                    Cabecera.SOL_MovNomRef = myData.Tables[0].Rows[i]["RazonSocial"].ToString().Trim();
                                    Cabecera.SOL_MovDirRef = "";
                                    Cabecera.SOL_MovCiuRef = "";
                                    Cabecera.SOL_MovComRef = "";
                                    Cabecera.SOL_MovRegRef = "";
                                    Cabecera.SOL_MovTelRef = "";
                                    Cabecera.SOL_MovMaiRef = "";
                                    Cabecera.SOL_MovNomCon = "";
                                    Cabecera.SOL_MovTca = 1; //tipo cambio
                                    Cabecera.SOL_MovMonCod = 1; //moneda -> peso
                                    Cabecera.SOL_MovIdenWMS = long.Parse(myData.Tables[0].Rows[i]["Folio"].ToString().Trim()); //ODP - Cola picking
                                    Cabecera.SOL_MovRefWMSTipDoc = Palabras[3].Trim(); //Tipo documento interno que debe generar INET //myData.Tables[0].Rows[i]["TipoDocumento"].ToString().Trim(); 
                                    Cabecera.SOL_MovBodDes = Palabras[2].Trim(); //Bodega de destino en el ERP C(20)
                                    Cabecera.SOL_MovBodOri = Palabras[1].Trim(); //Bodega origen en el ERP C(20)

                                    //Busca detalles relacionados
                                    string CondicionBusqueda = "IntId = " + myData.Tables[0].Rows[i]["IntId"].ToString().Trim();
                                    string _ItemReferencia = "";
                                    string _NroSerieDesp = "";

                                    DataRow[] resultado = myData.Tables[0].Select(CondicionBusqueda);

                                    foreach (DataRow fila in resultado)
                                    {
                                        //Si cambia de Item Referencia -----
                                        if (fila["ItemReferencia"].ToString().Trim() != _ItemReferencia.Trim())
                                        {
                                            //si no era el primer ItemReferencia agrega el anterior al JSON -----
                                            if (_ItemReferencia.Trim() != "")
                                            {
                                                Cabecera.SolDetalle.Add(Detalle);
                                            }

                                            _ItemReferencia = fila["ItemReferencia"].ToString().Trim();
                                            _NroSerieDesp = "";

                                            Detalle = new Det_SolicitudINET();
                                            Detalle.SOL_MovLinId = int.Parse(fila["Linea"].ToString());
                                            Detalle.SOL_MovLin_ProdId = fila["CodigoArticulo"].ToString();
                                            Detalle.SOL_MovLin_ProdNam = fila["DescripArt"].ToString();
                                            Detalle.SOL_MovLin_UnMe = fila["UnidadMedida"].ToString();
                                            Detalle.SOL_MovLin_ReqAdi = "N"; //N=ninguno; L=lote; S=serie
                                            Detalle.SOL_MovLin_CantWMS = decimal.Parse(fila["Cantidad"].ToString());  //decimal.Parse(fila["CantidadProc"].ToString());

                                            Detalle.SOL_MovLin_PreWMS = 0;
                                            Detalle.SOL_MovLin_Centro = 0;

                                            //si el item referencia viene vacio o en cero asigna 1 por defecto --------------------
                                            if (fila["ItemReferencia"].ToString() == "" || fila["ItemReferencia"].ToString() == "0")
                                            {
                                                Detalle.SOL_MovLinId = 1;
                                            }
                                            else
                                            {
                                                Detalle.SOL_MovLinId = int.Parse(fila["ItemReferencia"].ToString());
                                            }
                                        }

                                        //Si cambia de Lote -----
                                        if (fila["NroSerieDesp"].ToString().Trim() != _NroSerieDesp.Trim())
                                        {
                                            //Carga campos Lote
                                            Lote = new Det_Lote_SolicitudINET();
                                            Lote.SOL_MovLinLSNum = fila["NroSerieDesp"].ToString(); //Lote
                                            Lote.SOL_MovLinLSDes = fila["NroSerieDesp"].ToString();
                                            Lote.SOL_MovLinLSFVig = DateTime.Parse(fila["Fecha1"].ToString()); //se agrega Fecha elaboracion 17/10/2022
                                            Lote.SOL_MovLinLSFVen = DateTime.Parse(fila["FechaVectoDesp"].ToString());
                                            Lote.SOL_MovLinLSCant = decimal.Parse(fila["CantidadProc"].ToString());
                                            Lote.SOL_MovLinLSIndi = (int.Parse(fila["UsaLote"].ToString()) == 1 ? "S" : "N");
                                            //Lote.SOL_MovLinLSIUbic = fila2["REC_MovLinLSIUbic"].ToString();

                                            //Carga campos ubicacion
                                            Ubicacion = new Det_Lote_Ubi_SolicitudINET();
                                            Ubicacion.SOL_MovLinLotCant = decimal.Parse(fila["CantidadProc"].ToString());
                                            Ubicacion.SOL_MovLinLotUbic = fila["CodigoUbicacion"].ToString();

                                            Lote.SOLLOTEUBI.Add(Ubicacion); //Agrega ubicacion al Lote
                                            Detalle.SOLLOTESERIE.Add(Lote); //Agrega lote al detalle

                                            _NroSerieDesp = fila["NroSerieDesp"].ToString().Trim();

                                        } //FIN Si cambia de Lote -----

                                    } //For each detalle 

                                    Cabecera.SolDetalle.Add(Detalle); //Agrega detalle al listado de la cabecera ----
                                    CabJson.SDTSolicitud = Cabecera;

                                    //-------------------------------------------------------------
                                    //Crea body para llamado con estructura de variable cargada ---
                                    var body = JsonConvert.SerializeObject(CabJson);

                                    request.AddParameter("application/json", body, ParameterType.RequestBody);

                                    //EJECUTA LLAMADO API ==========================
                                    IRestResponse response = client.Execute(request);

                                    LogInfo("SolicitudINET", "Ejecuta API Solicitud INET: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                             ", IntId: " + myData.Tables[0].Rows[i]["IntId"].ToString().Trim() +
                                                             ". JSON: " + body.ToString());

                                    HttpStatusCode CodigoRetorno = response.StatusCode;
                                    JObject rss = JObject.Parse(response.Content); //recupera json de retorno

                                    int Res;
                                    string Respuesta = "";

                                    //Si finalizó OK --------------------------
                                    if (CodigoRetorno.Equals(HttpStatusCode.OK))
                                    {
                                        //Si retorno sin errores
                                        if (rss["ProcesoRespuesta"]["Tipo"].ToString() == "0")
                                        {
                                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                     2); //Procesado
                                            //Recorre respuestas ok ----- 
                                            for (Res = 0; Res < (Int32)rss["ProcesoRespuesta"]["Datos"].Count(); Res++)
                                            {
                                                Respuesta = Respuesta.Trim() + " " + rss["ProcesoRespuesta"]["Datos"][Res]["NOMBRE"].ToString().Trim() + ": " +
                                                                                     rss["ProcesoRespuesta"]["Datos"][Res]["DATO"].ToString().Trim() + ".";
                                            }

                                            LogInfo("SolicitudINET", "Integracion OK. " + Respuesta.Trim(), true);
                                        }

                                        //Si retorno Con errores
                                        if (rss["ProcesoRespuesta"]["Tipo"].ToString() == "1")
                                        {
                                            //Recorre respuestas Error ----- 
                                            for (Res = 0; Res < (Int32)rss["ProcesoRespuesta"]["Errores"].Count(); Res++)
                                            {
                                                Respuesta = Respuesta.Trim() + " " + rss["ProcesoRespuesta"]["Errores"][Res]["ErrorDescripcion"].ToString().Trim() + ".";
                                            }

                                            LogInfo("SolicitudINET", "Error api ConfirmacionRecepcionINET para Folio: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                     "Error: " + Respuesta.Trim() + 
                                                                     ". JSON: " + body.ToString(), true);

                                            //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                            result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                     3); //Procesado con error 
                                        }
                                    }
                                    else
                                    {
                                        //Si contiene mensaje de error lo rescata --- 
                                        if (rss.ToString().Contains("message") == true)
                                        {
                                            Respuesta = ". " + rss["error"]["code"].ToString() + " - " + rss["error"]["message"].ToString();
                                        }
                                        else
                                        {
                                            Respuesta = "";
                                        }

                                        LogInfo("SolicitudINET", "Error api SolicitudDespachoINET para Folio: " +
                                                                 myData.Tables[0].Rows[i]["Folio"].ToString().Trim() + Respuesta.Trim() + 
                                                                 ". JSON: " + body.ToString(), true);

                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                 3); //Procesado con error
                                    }
                                } //FIN si cambia de Folio

                            } //FIN ciclo recorre Confirmaciones
                        }
                    }

                } //FIN lee ruta
            }
            catch (Exception ex)
            {
                LogInfo(ex.Message, "Error SolicitudDespachoINET", true);
            }
        }

        //=====================================
        //WEBHOOK CONFIRMACION SDR
        //=====================================
        private void ConfirmacionIngresoWebHook(string NombreProceso)
        {
            try
            {
                LogInfo("ConfirmacionIngresoWebHook", NombreProceso.Trim() + " - Inicio ejecucion", true);

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpÌd, out EmpId);

                //Extrae RDM (Recepciones de mercancia) ----------
                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId,
                                                                                                               NombreProceso);
                if (myData.Tables.Count > 0)
                {
                    if (myData.Tables[0].Rows.Count > 0)
                    {
                        Cab_Confirmacion_SDR CabJson = new Cab_Confirmacion_SDR();
                        Cab2_Confirmacion_SDR Cabecera = new Cab2_Confirmacion_SDR();
                        Det_Confirmacion_SDR Detalle = new Det_Confirmacion_SDR();

                        string var_IntId = "";

                        //Recorre la confirmaciones de recepcion que retornó --------------
                        for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                        {
                            //Cuando cambie de Folio RDM debe cargar la estructura con la API -----
                            if (myData.Tables[0].Rows[i]["IntId"].ToString().Trim() != var_IntId || var_IntId == "")
                            {
                                //Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento -----
                                #region Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento -----
                                var client = new RestClient(myData.Tables[0].Rows[0]["URL_EndPoint"].ToString().Trim());

                                client.Timeout = -1;

                                //Indica el metodo de llamado de la API ----
                                var request = new RestRequest(Method.GET);
                                switch (myData.Tables[0].Rows[0]["Metodo"].ToString().Trim())
                                {
                                    case "GET":
                                        request = new RestRequest(Method.GET); //consulta
                                        break;
                                    case "POST":
                                        request = new RestRequest(Method.POST); //crea
                                        break;
                                    case "PUT":
                                        request = new RestRequest(Method.PUT); //modifica
                                        break;
                                }

                                //Trae informacion para headers segun el nombre proceso -------
                                DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId,
                                                                                                                                        NombreProceso,
                                                                                                                                        2);

                                //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
                                if (myData2.Tables.Count > 0)
                                {
                                    for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                                    {
                                        //agrega key y su valor -----------
                                        request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                    }
                                }

                                #endregion

                                //Carga Variable para generar JSON ----------------------------------------------

                                //Inicializa variable principal
                                CabJson = new Cab_Confirmacion_SDR();
                                Cabecera = new Cab2_Confirmacion_SDR();

                                DateTime fecha;
                                fecha = DateTime.Now;

                                //Guarda IntId que esta procesando ---------
                                var_IntId = myData.Tables[0].Rows[i]["IntId"].ToString().Trim();

                                //--------------------------------------------
                                Cabecera.Id = int.Parse(myData.Tables[0].Rows[i]["Folio"].ToString().Trim());
                                Cabecera.RecepcionId = int.Parse(myData.Tables[0].Rows[i]["Folio"].ToString().Trim());
                                Cabecera.INT_NAME = "INT-CONFIRMA-INGRESOS";
                                Cabecera.FECHA_HORA = DateTime.Parse(myData.Tables[0].Rows[i]["FechaEstado"].ToString()).ToString("dd-MM-yyyy HH:mm"); // "30-05-2022 13:35";
                                Cabecera.SolRecepId = long.Parse(myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim());
                                Cabecera.FechaProceso = DateTime.Parse(myData.Tables[0].Rows[i]["FechaProceso"].ToString()).ToString("dd-MM-yyyy"); // "30-05-2022";
                                Cabecera.TipoDocumento = myData.Tables[0].Rows[i]["TipoDocumento"].ToString();
                                Cabecera.NumeroDocto = myData.Tables[0].Rows[i]["NumeroDocto"].ToString();
                                Cabecera.FechaDocto = DateTime.Parse(myData.Tables[0].Rows[i]["FechaDocto"].ToString()).ToString("dd-MM-yyyy"); // "30-05-2022";
                                Cabecera.TipoReferencia = myData.Tables[0].Rows[i]["TipoReferencia"].ToString();
                                Cabecera.NumeroReferencia = myData.Tables[0].Rows[i]["NumeroReferencia"].ToString();
                                Cabecera.FechaReferencia = DateTime.Parse(myData.Tables[0].Rows[i]["FechaReferencia"].ToString()).ToString("dd-MM-yyyy"); // "30-05-2022";
                                Cabecera.TipoSolicitud = int.Parse(myData.Tables[0].Rows[i]["TipoSolicitud"].ToString());
                                //--------------------------------------------

                                //Busca detalles relacionados
                                string CondicionBusqueda = "IntId = " + myData.Tables[0].Rows[i]["IntId"].ToString().Trim();

                                DataRow[] resultado = myData.Tables[0].Select(CondicionBusqueda);

                                foreach (DataRow fila in resultado)
                                {
                                    Detalle = new Det_Confirmacion_SDR();

                                    Detalle.Linea = int.Parse(fila["Linea"].ToString()); // 1;
                                    Detalle.CodigoArticulo = fila["CodigoArticulo"].ToString(); // "5";
                                    Detalle.CodigoOriginal = fila["CodigoArticulo"].ToString(); // "5";
                                    Detalle.UnidadCompra = fila["UnidadMedida"].ToString(); // "UN";
                                    Detalle.CantidadSolicitada = decimal.Parse(fila["Cantidad"].ToString()); // 150;
                                    Detalle.ItemReferencia = int.Parse(fila["ItemReferencia"].ToString()); // 0;
                                    Detalle.LoteSerie = fila["NroSerieDesp"].ToString(); // "132561";
                                    Detalle.FechaVencto = DateTime.Parse(fila["FechaVectoDesp"].ToString()).ToString("dd-MM-yyyy"); //fila["FechaVectoDesp"].ToString(); 

                                    Detalle.CantidadRecibida = decimal.Parse(fila["CantidadProc"].ToString()); // 100;
                                    Detalle.HuId = long.Parse(fila["Texto1"].ToString()); // 30025;
                                    Detalle.Estado = int.Parse(fila["Texto2"].ToString());

                                    Cabecera.items.Add(Detalle);
                                }

                                CabJson.cabeceras.Add(Cabecera);

                                //-------------------------------------------------------------
                                //Crea body para llamado con estructura de variable cargada ---
                                var body = JsonConvert.SerializeObject(CabJson);

                                request.AddParameter("application/json", body, ParameterType.RequestBody);

                                //EJECUTA LLAMADO API ---------------------------
                                IRestResponse response = client.Execute(request);

                                LogInfo("ConfirmacionIngresoWebHook", NombreProceso.Trim() + " - Ejecuta api NumeroReferencia " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim());

                                HttpStatusCode CodigoRetorno = response.StatusCode;

                                JObject rss = JObject.Parse(response.Content); //recupera json de retorno

                                string Respuesta = "";

                                //Si finalizó OK --------------------------
                                if (CodigoRetorno.Equals(HttpStatusCode.OK))
                                {
                                    //Si retorno sin errores
                                    if (rss["Message"].ToString().StartsWith("OK"))
                                    {
                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                 2); //Procesado
                                                                                                                                     //Recorre respuestas ok ----- 
                                        Respuesta = "Integracion OK. " + rss["Message"].ToString().Trim() + ". Folio: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim();

                                        LogInfo("ConfirmacionIngresoWebHook", NombreProceso.Trim() + " - " + Respuesta);
                                    }
                                    else //Si retorno Con errores
                                    {
                                        Respuesta = rss["Message"].ToString().Trim();

                                        LogInfo("ConfirmacionIngresoWebHook", NombreProceso.Trim() + 
                                                                              " - Error llamado api. " + response.StatusCode.ToString() +
                                                                              ", Folio: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                              "Error: " + Respuesta.Trim() +
                                                                              ". JSON: " + body.ToString());

                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                 3); //Procesado con error 
                                    }
                                }
                                else
                                {
                                    //Si contiene mensaje de error lo rescata --- 
                                    if (rss.ToString().Contains("message") == true)
                                    {
                                        Respuesta = ". " + rss["error"]["code"].ToString() + " - " + rss["error"]["message"].ToString();
                                    }
                                    else
                                    {
                                        Respuesta = "";
                                    }

                                    LogInfo("ConfirmacionIngresoWebHook", NombreProceso.Trim() + 
                                                                          " - Error llamado api. " + response.StatusCode.ToString() + 
                                                                          ", Folio: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() + 
                                                                          "Error: " + Respuesta.Trim() +
                                                                          ". JSON: " + body.ToString(), true);

                                    //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                             3); //Procesado con error
                                }
                            } //FIN si cambia de Folio

                        } //FIN ciclo recorre Confirmaciones
                    }
                }
            }
            catch (Exception ex)
            {
                LogInfo("ConfirmacionIngresoWebHook", NombreProceso.Trim() + 
                                                      " - Error: " + ex.Message, true);
            }
        }

        //=====================================
        //WEBHOOK CONFIRMACION SDD
        //=====================================
        private void ConfirmacionSalidaWebHook(string NombreProceso)
        {
            try
            {
                LogInfo("ConfirmacionSalidaWebHook", NombreProceso.Trim() + " - Inicio ejecucion", true);

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpId = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;

                Int32.TryParse(stEmpId, out EmpId);

                //Extrae RDM (Recepciones de mercancia) ----------
                DataSet myData = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId,
                                                                                                               NombreProceso);
                if (myData.Tables.Count > 0)
                {
                    if (myData.Tables[0].Rows.Count > 0)
                    {
                        Cab_Confirmacion_SDD CabJson = new Cab_Confirmacion_SDD();
                        Cab2_Confirmacion_SDD Cabecera = new Cab2_Confirmacion_SDD();
                        Det_Confirmacion_SDD Detalle = new Det_Confirmacion_SDD();

                        string var_IntId = "";

                        //Recorre la confirmaciones de salida --------------
                        for (int i = 0; i <= myData.Tables[0].Rows.Count - 1; i++)
                        {
                            //Cuando cambie de Folio RDM debe cargar la estructura con la API -----
                            if (myData.Tables[0].Rows[i]["IntId"].ToString().Trim() != var_IntId || var_IntId == "")
                            {
                                //Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento ----------
                                #region Carga ruta de la API para integrar a Woocommerce segun nombre proceso que genero documento ----------
                                var client = new RestClient(myData.Tables[0].Rows[0]["URL_EndPoint"].ToString().Trim());

                                client.Timeout = -1;

                                //Indica el metodo de llamado de la API ----
                                var request = new RestRequest(Method.GET);
                                switch (myData.Tables[0].Rows[0]["Metodo"].ToString().Trim())
                                {
                                    case "GET":
                                        request = new RestRequest(Method.GET); //consulta
                                        break;
                                    case "POST":
                                        request = new RestRequest(Method.POST); //crea
                                        break;
                                    case "PUT":
                                        request = new RestRequest(Method.PUT); //modifica
                                        break;
                                }

                                //Trae informacion para headers segun el nombre proceso -------
                                DataSet myData2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId,
                                                                                                                                        NombreProceso,
                                                                                                                                        2);

                                //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
                                if (myData2.Tables.Count > 0)
                                {
                                    for (int k = 0; k <= myData2.Tables[0].Rows.Count - 1; k++)
                                    {
                                        //agrega key y su valor -----------
                                        request.AddHeader(myData2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myData2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                    }
                                }
                                #endregion

                                //Carga Variable para generar JSON ----------------------------------------------

                                //Inicializa variable principal
                                CabJson = new Cab_Confirmacion_SDD();
                                Cabecera = new Cab2_Confirmacion_SDD();

                                DateTime fecha;
                                fecha = DateTime.Now;

                                //Guarda documento referencia que esta procesando ---------
                                var_IntId = myData.Tables[0].Rows[i]["IntId"].ToString().Trim();

                                //--------------------------------------------
                                Cabecera.Id = int.Parse(myData.Tables[0].Rows[i]["Folio"].ToString().Trim());
                                Cabecera.ColaPickId = int.Parse(myData.Tables[0].Rows[i]["Folio"].ToString().Trim());
                                Cabecera.INT_NAME = "INT-CONFIRMA-DESPACHOS";
                                Cabecera.FECHA_HORA = DateTime.Parse(myData.Tables[0].Rows[i]["FechaEstado"].ToString()).ToString("dd-MM-yyyy HH:mm"); // "30-05-2022 13:35";
                                Cabecera.SolDespId = long.Parse(myData.Tables[0].Rows[i]["FolioRel"].ToString().Trim());
                                Cabecera.FechaProceso = DateTime.Parse(myData.Tables[0].Rows[i]["FechaProceso"].ToString()).ToString("dd-MM-yyyy"); // "30-05-2022";
                                Cabecera.TipoDocumento = int.Parse(myData.Tables[0].Rows[i]["TipoDocumento"].ToString());
                                Cabecera.NumeroDocto = myData.Tables[0].Rows[i]["NumeroDocto"].ToString();
                                Cabecera.FechaDocto = DateTime.Parse(myData.Tables[0].Rows[i]["FechaDocto"].ToString()).ToString("dd-MM-yyyy"); // "30-05-2022";
                                Cabecera.TipoReferencia = myData.Tables[0].Rows[i]["TipoReferencia"].ToString();
                                Cabecera.NumeroReferencia = myData.Tables[0].Rows[i]["NumeroReferencia"].ToString();
                                Cabecera.FechaReferencia = DateTime.Parse(myData.Tables[0].Rows[i]["FechaReferencia"].ToString()).ToString("dd-MM-yyyy"); // "30-05-2022";
                                Cabecera.TipoSolicitud = int.Parse(myData.Tables[0].Rows[0]["TipoSolicitud"].ToString());

                                //Busca detalles relacionados
                                string CondicionBusqueda = "IntId = " + myData.Tables[0].Rows[i]["IntId"].ToString().Trim();

                                DataRow[] resultado = myData.Tables[0].Select(CondicionBusqueda);

                                foreach (DataRow fila in resultado)
                                {
                                    Detalle = new Det_Confirmacion_SDD();

                                    Detalle.Linea = int.Parse(fila["Linea"].ToString()); // 1;
                                    Detalle.CodigoArticulo = fila["CodigoArticulo"].ToString(); // "5";
                                    Detalle.CodigoOriginal = fila["CodigoArticulo"].ToString(); // "5";
                                    Detalle.UnidadVenta = fila["UnidadMedida"].ToString(); // "UN";
                                    Detalle.CantidadSolicitada = decimal.Parse(fila["Cantidad"].ToString()); // 150;
                                    Detalle.ItemReferencia = int.Parse(fila["ItemReferencia"].ToString()); // 0;
                                    Detalle.FecVenctoSol = DateTime.Parse(fila["FechaVectoDesp"].ToString()).ToString("dd-MM-yyyy"); //fila["FechaVectoDesp"].ToString(); 
                                    Detalle.CantidadDespachada = decimal.Parse(fila["CantidadProc"].ToString()); // 100;
                                    Detalle.LoteSerieDesp = fila["NroSerieDesp"].ToString(); // "132561";
                                    Detalle.FecVectoDesp = DateTime.Parse(fila["FechaVectoDesp"].ToString()).ToString("dd-MM-yyyy"); //fila["FechaVectoDesp"].ToString(); 

                                    Cabecera.Items.Add(Detalle);
                                }

                                CabJson.cabeceras.Add(Cabecera);

                                //-------------------------------------------------------------
                                //Crea body para llamado con estructura de variable cargada ---
                                var body = JsonConvert.SerializeObject(CabJson);

                                request.AddParameter("application/json", body, ParameterType.RequestBody);

                                //========== EJECUTA LLAMADO API ==========
                                IRestResponse response = client.Execute(request);

                                LogInfo("ConfirmacionSalidaWebHook", NombreProceso.Trim() + " - Ejecuta api NumeroReferencia " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim());

                                HttpStatusCode CodigoRetorno = response.StatusCode;
                                JObject rss = JObject.Parse(response.Content); //recupera json de retorno

                                string Respuesta = "";

                                //Si finalizó OK y el json no es erroneo ----------
                                if (CodigoRetorno.Equals(HttpStatusCode.OK))
                                {
                                    //Si retorno sin errores
                                    if (rss["Message"].ToString().StartsWith("OK"))
                                    {
                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                 2); //Procesado

                                        Respuesta = "Integracion OK. " + rss["Message"].ToString().Trim() + ". Folio: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim();
                                        LogInfo("ConfirmacionSalidaWebHook", NombreProceso.Trim() + " - " + Respuesta);
                                    }
                                    else //Si retorno Con errores
                                    {
                                        Respuesta = rss["Message"].ToString().Trim();

                                        LogInfo("ConfirmacionSalidaWebHook", NombreProceso.Trim() + 
                                                                             " - Error llamado api. " + response.StatusCode.ToString() +
                                                                             ", Folio: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                             "Error: " + Respuesta.Trim() +
                                                                             ". JSON: " + body.ToString());

                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                 3); //Procesado con error 
                                    }
                                }
                                else
                                {
                                    //Si contiene mensaje de error lo rescata --- 
                                    if (rss.ToString().Contains("message") == true)
                                    {
                                        Respuesta = ". " + rss["error"]["code"].ToString() + " - " + rss["error"]["message"].ToString();
                                    }
                                    else
                                    {
                                        Respuesta = "";
                                    }

                                    LogInfo("ConfirmacionSalidaWebHook", NombreProceso.Trim() + " - Error llamado api. " + response.StatusCode.ToString() +
                                                                         ", Folio: " + myData.Tables[0].Rows[i]["Folio"].ToString().Trim() +
                                                                         "Error: " + Respuesta.Trim() +
                                                                         ". JSON: " + body.ToString(), true);

                                    //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                             3); //Procesado con error
                                }

                            } //FIN si cambia de Folio

                        } //FIN ciclo recorre Confirmaciones
                    }
                }
            }
            catch (Exception ex)
            {
                LogInfo("ConfirmacionSalidaWebHook", NombreProceso.Trim() + " - Error: " + ex.Message, true);
            }
        }

        //Actualiza stocks en BigCommerce - actualizacion masiva por SKU
        private void ActualizaStockEComm_BigCommerce()
        {
            try
            {
                LogInfo("ActualizaStockEComm_BigCommerce", "Inicio ejecucion proceso", true);

                //agregar para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                string stEmpÌd = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;
                string Ruta = "";
                int Contador = 0;
                int CantidadProductosEnvio = 0;
                ActualizaStockBigCommerce Cabecera = new ActualizaStockBigCommerce();
                Detalle_ActualizaStockBigCommerce Detalle = new Detalle_ActualizaStockBigCommerce();

                Int32.TryParse(stEmpÌd, out EmpId);
                DataSet myDataSet = new DataSet();

                //Enviar a BigCommerce saldo de articulos en getpoint ----

                //Indica cada cuantos productos realizará el envio BigCommerce -----------
                CantidadProductosEnvio = int.Parse(ConfigurationManager.AppSettings["CantidadProductosEnvio_BigCommerce"].ToString());

                //------------------------------------------------------------------------------------------------------
                //Carga tabla de L_IntegraConfirmaciones y L_IntegraConfirmacionesDet con Articulos en bd getpoint -----
                //En el procedimiento tiene logica para sacar los datos cada cierta cantidad de minutos 

                result = WS_Integrador.Classes.model.InfF_Generador.IntegraStockWMSToEcomm("STOCK_To_BigComm");

                //Trae articulos para integracion con Item referencia ---------------
                DataSet myDataUpd = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId, "STOCK_To_BigComm"); //ValEjecutaWebHooks();
                if (myDataUpd.Tables.Count > 0)
                {
                    int i = 0;

                    for (i = 0; i <= myDataUpd.Tables[0].Rows.Count - 1; i++)
                    {
                        // Si tiene URL donde actualizar 
                        if (myDataUpd.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim() != "")
                        {
                            //LogInfo("ActualizaStockEComm_BigCommerce", "url endpoint: " + myDataUpd.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim());
                            //LogInfo("ActualizaStockEComm_BigCommerce", "ruta: " + Ruta.Trim());
                            //LogInfo("ActualizaStockEComm_BigCommerce", "Contador: " + Contador.ToString());
                            //LogInfo("ActualizaStockEComm_BigCommerce", "cantidadproductosenvio: " + CantidadProductosEnvio.ToString());

                            //Si cambia de Ruta o llego a la cantidad de productos por llamado ejecuta API Bigcommerce
                            if (myDataUpd.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim() != Ruta.Trim() || Contador >= CantidadProductosEnvio)
                            {                                
                                //Si no es la primera vez que entra al ciclo realiza llamado -----
                                if (Ruta.Trim() != "")
                                {
                                    var client = new RestClient(myDataUpd.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim());

                                    client.Timeout = -1;

                                    //Indica el metodo de llamado de la API ----
                                    var request = new RestRequest(Method.GET);
                                    switch (myDataUpd.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                                    {
                                        case "GET":
                                            request = new RestRequest(Method.GET); //consulta
                                            break;
                                        case "POST":
                                            request = new RestRequest(Method.POST); //crea
                                            break;
                                        case "PUT":
                                            request = new RestRequest(Method.PUT); //modifica
                                            break;
                                    }

                                    //Trae informacion para headers segun el nombre proceso -------
                                    DataSet myDataH2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myDataUpd.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(), 2);

                                    //Carga listado de headers (atributo y valor) necesarios para realizar el llamado a la api ----------------
                                    if (myDataH2.Tables.Count > 0)
                                    {
                                        for (int k = 0; k <= myDataH2.Tables[0].Rows.Count - 1; k++)
                                        {
                                            //agrega key y su valor -----------
                                            request.AddHeader(myDataH2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myDataH2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                        }
                                    }

                                    //carga parametro con el JSON de productos ---

                                    //Crea body para llamado con estructura de variable cargada ---
                                    var body2 = JsonConvert.SerializeObject(Cabecera);

                                    //LogInfo("ActualizaStockEComm_BigCommerce", "Llama API actualiza stock Articulo " + myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim());

                                    request.AddParameter("application/json", body2, ParameterType.RequestBody);

                                    //Ejecuta llamado de la API --------------
                                    IRestResponse responseStock = client.Execute(request);
                                    HttpStatusCode CodigoRetorno = responseStock.StatusCode;

                                    //Si finalizó OK --------------------------
                                    if (CodigoRetorno.Equals(HttpStatusCode.OK))
                                    {
                                        LogInfo("ActualizaStockEComm_BigCommerce", "Actualizacion Stock OK. Corte control fila: " + (i + 1).ToString());

                                        //Actualiza estado de L_IntegraConfirmaciones, deja en estado traspasado (Estado = 2) ------
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmaciones(int.Parse(myDataUpd.Tables[0].Rows[i]["IntId"].ToString()));

                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (Estado = 1)------
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                                                                                                              int.Parse(myDataUpd.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                              int.Parse(myDataUpd.Tables[0].Rows[i]["IdDet"].ToString()));
                                    }
                                    else
                                    {
                                        if (responseStock.Content != "")
                                        {
                                            JObject rss = JObject.Parse(responseStock.Content);
                                            LogInfo("ActualizaStockEComm_BigCommerce", "Error actualiza Stock: Status:" + rss["status"] + "," + rss["title"] +
                                                                           ". JSON: " + body2.ToString());
                                        }
                                        else
                                        {
                                            //JObject rss = JObject.Parse(responseStock.Content);
                                            LogInfo("ActualizaStockEComm_BigCommerce", "Error actualiza Stock: " + myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + " (json no retorna datos)," +
                                                                           ". JSON: " + body2.ToString());
                                        }

                                        //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado con Error (Estado = 2)------
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                              int.Parse(myDataUpd.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                              int.Parse(myDataUpd.Tables[0].Rows[i]["IdDet"].ToString()));

                                    }

                                } //FIN si no es primera vez que entra al ciclo

                                //Inicializa variables
                                Cabecera = new ActualizaStockBigCommerce();
                                Cabecera.reason = "Actualizacion Stock Ultimate Fitness";

                                Ruta = myDataUpd.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim();
                                Contador = 0;
                                
                            } //FIN si cambia de ruta o llega a la cantidad de productos por llamado

                            //Agrega producto al listado 
                            Detalle = new Detalle_ActualizaStockBigCommerce();
                            Detalle.location_id = 1;
                            Detalle.sku = myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim();
                            Detalle.quantity = int.Parse(myDataUpd.Tables[0].Rows[i]["CantidadEntera"].ToString());
                            Cabecera.items.Add(Detalle);

                            //LogInfo("ActualizaStockEComm_BigCommerce", "fila:" + i.ToString() + ". Agrega Articulo: " + myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim());

                            Contador = Contador + 1;

                        } //FIN si la ruta no esta en blanco

                    } //FIN ciclo for

                    //Si quedaron items por enviar a integracion
                    if (Contador > 0)
                    {
                        if (Ruta.Trim() != "")
                        {
                            i = myDataUpd.Tables[0].Rows.Count - 1; //ultima posicion
                            var client = new RestClient(Ruta);

                            client.Timeout = -1;

                            //Indica el metodo de llamado de la API ----
                            var request = new RestRequest(Method.GET);
                            switch (myDataUpd.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                            {
                                case "GET":
                                    request = new RestRequest(Method.GET); //consulta
                                    break;
                                case "POST":
                                    request = new RestRequest(Method.POST); //crea
                                    break;
                                case "PUT":
                                    request = new RestRequest(Method.PUT); //modifica
                                    break;
                            }

                            //Trae informacion para headers segun el nombre proceso -------
                            DataSet myDataH2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson_Headers(EmpId, myDataUpd.Tables[0].Rows[i]["NombreProceso"].ToString().Trim(), 2);

                            //Carga listado de headers (atributo y valor) necesarios para realizar el llamado a la api ----------------
                            if (myDataH2.Tables.Count > 0)
                            {
                                for (int k = 0; k <= myDataH2.Tables[0].Rows.Count - 1; k++)
                                {
                                    //agrega key y su valor -----------
                                    request.AddHeader(myDataH2.Tables[0].Rows[k]["myKey"].ToString().Trim(), myDataH2.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                }
                            }

                            //carga parametro con el JSON de productos ---

                            //Crea body para llamado con estructura de variable cargada ---
                            var body2 = JsonConvert.SerializeObject(Cabecera);

                            //LogInfo("ActualizaStockEComm_BigCommerce", "Llama API actualiza stock Articulo " + myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim());

                            request.AddParameter("application/json", body2, ParameterType.RequestBody);

                            //Ejecuta llamado de la API --------------
                            IRestResponse responseStock = client.Execute(request);
                            HttpStatusCode CodigoRetorno = responseStock.StatusCode;

                            //Si finalizó OK --------------------------
                            if (CodigoRetorno.Equals(HttpStatusCode.OK))
                            {
                                LogInfo("ActualizaStockEComm_BigCommerce", "Actualizacion Stock OK. Ultimo envio");

                                //Actualiza estado de L_IntegraConfirmaciones, deja en estado traspasado (Estado = 2) ------
                                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmaciones(int.Parse(myDataUpd.Tables[0].Rows[i]["IntId"].ToString()));

                                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado OK (Estado = 1)------
                                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(1,
                                                                                                                      int.Parse(myDataUpd.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                      int.Parse(myDataUpd.Tables[0].Rows[i]["IdDet"].ToString()));
                            }
                            else
                            {
                                if (responseStock.Content != "")
                                {
                                    JObject rss = JObject.Parse(responseStock.Content);
                                    LogInfo("ActualizaStockEComm_BigCommerce", "Error actualiza Stock: Status:" + rss["status"] + "," + rss["title"] +
                                                                   ". JSON: " + body2.ToString());
                                }
                                else
                                {
                                    //JObject rss = JObject.Parse(responseStock.Content);
                                    LogInfo("ActualizaStockEComm_BigCommerce", "Error actualiza Stock: " + myDataUpd.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + " (json no retorna datos)," +
                                                                   ". JSON: " + body2.ToString());
                                }

                                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado con Error (Estado = 2)------
                                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmacionesDet(2,
                                                                                                                      int.Parse(myDataUpd.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                      int.Parse(myDataUpd.Tables[0].Rows[i]["IdDet"].ToString()));

                            }

                        } //FIN si no es primera vez que entra al ciclo
                    }
                }

                LogInfo("ActualizaStockEComm_BigCommerce", "FIN ejecucion proceso");
            }
            catch (Exception ex)
            {
                LogInfo("ActualizaStockEComm_BigCommerce", "Error: " + ex.Message, true);
            }
        }

        private void LeeArchivo(int EmpId, string BD_GETPOINT)
        {
            // Introducir aquí el código de usuario para inicializar la página
            string usuario = System.Configuration.ConfigurationManager.AppSettings["usuario"].ToString(); //ConfigurationManager.AppSettings["usuario"].ToString();
            string filepath = ConfigurationManager.AppSettings["PathFilesINPUT"].ToString();
            string fileOK = ConfigurationManager.AppSettings["PathFilesINPUT_OK"].ToString();
            string fileERR = ConfigurationManager.AppSettings["PathFilesINPUT_ERR"].ToString();
            string CharEsp = ConfigurationManager.AppSettings["CharEsp"].ToString();
            char Sep = Char.Parse(ConfigurationManager.AppSettings["Separador"].ToString());
            string stValue = "";

            //27.03.2017: Obtiene datos desde tabla de configuracion
            DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_INPUT");
            filepath = myDataSet.Tables[0].Rows[0]["Valor"].ToString().Trim();


            myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_INPUT-OK");
            fileOK = myDataSet.Tables[0].Rows[0]["Valor"].ToString().Trim();

            myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_INPUT-ERR");
            fileERR = myDataSet.Tables[0].Rows[0]["Valor"].ToString().Trim();

            string[] files = Directory.GetFiles(filepath, "*.csv");
            string[] array = files;
            string file;

            string[] arrCharEsp = CharEsp.Split(Sep);


            string mensaje = "";
            string resultado = "";
            bool resultadobool;
            int x = 0;
            int INDICE = 0;
            //string[] ARREGLO;
            string SqlInsert = "";
            string SqlInsert2 = "";
            bool boLeeArchivos = false;

            mensaje = "########################## BD: " + BD_GETPOINT.Trim() + " #############################";
            this.EscribeLog(mensaje);


            for (int i = 0; i < array.Length; i++)
            {
                boLeeArchivos = true;

                if (i == 0)
                {
                    mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Inicio Lectura de Archivos  *.csv; Cantidad de Archivos: " + array.Length.ToString();
                    this.EscribeLog(mensaje);
                }

                file = array[i];
                mensaje = "";
                resultado = "";
                x = 0;
                INDICE = 0;
                SqlInsert = "";
                SqlInsert2 = "";

                string nombrearchivo = file.Substring(filepath.Length + 1, file.Length - filepath.Length - 1);
                string fecha = DateTime.Now.ToShortDateString();

                int correlativo = 1;
                StreamReader objReader = new StreamReader(file);

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Inicio Lectura de Archivo " + nombrearchivo.Trim() + ".csv";

                resultadobool = WS_Integrador.Classes.model.InfF_Generador.RenombraArchivoTablaLog(BD_GETPOINT, nombrearchivo);
                this.EscribeLog(mensaje);


                try
                {
                    string sLine = "";
                    ArrayList myArrayList = new ArrayList();
                    while (sLine != null)
                    {
                        sLine = objReader.ReadLine();
                        if (sLine != null)
                        {
                            //x = Cuenta(sLine, ";") - 1;
                            string[] Values = sLine.Split(';');
                            x = Values.Count();

                            SqlInsert = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea";

                            for (int j = 1; j < x + 1; j++)
                            {
                                SqlInsert = SqlInsert + " ,Texto" + j.ToString();
                                INDICE++;
                            }

                            SqlInsert = SqlInsert + ")";
                            //SqlInsert2 = "('" + nombrearchivo + "','" + fecha + "'," + correlativo + ",";
                            SqlInsert2 = "('" + nombrearchivo + "','" + usuario + "','" + fecha + "'," + correlativo + ",";


                            for (int j = 0; j < x; j++)
                            {
                                stValue = Values[j];
                                //28.03.2017: Elimina caracteres especiales
                                for (int i10 = 0; i10 < arrCharEsp.Length; i10++)
                                {
                                    stValue = stValue.Replace(arrCharEsp[i10], "");
                                }

                                SqlInsert2 = SqlInsert2 + "'" + stValue + "',";
                            }
                            SqlInsert2 = SqlInsert2.Substring(0, SqlInsert2.Length - 1) + ")";
                            resultado = WS_Integrador.Classes.model.InfF_Generador.InsertarRegistro_OleDb(BD_GETPOINT, SqlInsert, SqlInsert2);
                            if (resultado != "")
                            {
                                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " READ: ERROR: " + resultado;
                                this.EscribeLog(mensaje);
                            }

                            correlativo++;
                        }
                    }
                    objReader.Close();
                    objReader.Dispose();

                    objReader = null;
                    string fileOK_move;
                    resultado = WS_Integrador.Classes.model.InfF_Generador.ProcesaArchivo(BD_GETPOINT, nombrearchivo, usuario, fecha);

                    //0: Error; 1:OK
                    if (resultado == "0;OK")
                    {
                        fileOK_move = fileERR + "\\" + nombrearchivo + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".csv";
                    }
                    else
                    {
                        fileOK_move = fileOK + "\\" + nombrearchivo + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".csv";
                    }

                    mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Moviedo Archivo. Origen: " + file + " destino: OK: " + fileOK_move;
                    this.EscribeLog(mensaje);

                    //File Move se cae, se cambia por copy delete
                    File.Copy(file, fileOK_move);
                    File.Delete(file);

                }
                catch (Exception ex)
                {
                    string fileERR_move = fileERR + "\\" + nombrearchivo;
                    mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Integrador ERR: Ocurrio el siguiente error, " + ex.Message;
                    this.EscribeLog(mensaje);
                    mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Integrador ERR: Moviendo archivo a carpeta ERR";
                    this.EscribeLog(mensaje);
                    File.Move(file, fileERR_move);
                }

            }  //fin ciclo for x archivo

            if (boLeeArchivos)
            {
                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Fin Lectura de Archivos  *.csv";
                this.EscribeLog(mensaje);
            }

        }
        private void voGenArchivoART(int EmpId, string BD_GETPOINT)
        {
            string mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Inicio Proceso voGenArchivoART";
            //this.EscribeLog(mensaje);
            string cabecera = "";
            string detalle = "";
            string fincampo = ";";
            //string finlinea = ">";
            //string finsegmento = "~";
            string pie = "";
            //string stNumeroReferencia = "";
            string stIdDocto = "";
            StringBuilder myString = new StringBuilder();
            string Filename = "";
            string FilePath = "";
            StreamWriter strStreamWriter;
            string filetarget2 = "";
            //DateTime dtFechaHora;
            string result = "";
            //DataSet myDataSet2;

            try
            {
                DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_ART(BD_GETPOINT);

                if (myDataSet.Tables[0].Rows.Count <= 0)
                {
                    return;
                }

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Inicio Proceso voGenArchivoART. Lineas para generar " + myDataSet.Tables.Count.ToString();
                this.EscribeLog(mensaje);

                cabecera = "";
                detalle = "";

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    stIdDocto = myDataSet.Tables[0].Rows[i]["Id"].ToString().Trim();

                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto1"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto2"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto3"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto4"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto5"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto6"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto7"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto8"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto9"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto10"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto11"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto12"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto13"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto14"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto15"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto16"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto17"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto18"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto19"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto20"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto21"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto22"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto23"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto24"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto25"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto26"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto27"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto28"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto29"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto30"].ToString().Trim() + fincampo;

                    detalle = detalle + System.Environment.NewLine;
                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoARTERP(BD_GETPOINT, stIdDocto);
                }

                pie = "";

                Filename = "ART_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                myString.Clear();
                myString.Append(cabecera + detalle + pie);
                myString.Append(Environment.NewLine);
                strStreamWriter = File.AppendText(FilePath);
                strStreamWriter.Write(myString.ToString());
                strStreamWriter.Close();

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                this.EscribeLog(mensaje);

                //myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT");
                //filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                filetarget2 = ConfigurationManager.AppSettings["PathFilesINPUT"].ToString() + "\\" + Filename;
                File.Copy(FilePath, filetarget2);

                //myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT-BACKUP");
                //filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                //filetarget2 = ConfigurationManager.AppSettings["PathFilesOUTPUT_Backup"].ToString() + "\\" + Filename;
                //File.Copy(FilePath, filetarget2);

                File.Delete(FilePath);

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Fin Proceso voGenArchivoART";
                this.EscribeLog(mensaje);

                FTP_UploadFile(filetarget2, Filename);
            }
            catch (Exception ex2)
            {
                //05.06: Aqui mander correo
                string mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error " + ex2.Message;
                this.EscribeLog(mensaje1);

                //Para envio por correo electronico
                //mensaje = "Ocurrio el siguiente error <br>" + "- Ultimo registro de Log en archivo de texto : " + mensaje + "<br>";
                //mensaje = mensaje + "- Descripcion del Error Detectado : " + ex2.Message + "<br>";
                //WS_itec2.Classes.model.InfF_DMI_Archivo_852_Vw.in_AlertasSis(
                //"no-reply@grupoprecision.com",
                //ConfigurationManager.AppSettings["Correo"].ToString(),
                //ConfigurationManager.AppSettings["CorreoCC"].ToString(),
                //" ",
                //"[ALARMA] Notificacion Integracion DMI - Generacion de O/C",
                //mensaje,
                //" ", " ", " ");
            }

            mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Termino de la generacion archivos ART";
            this.EscribeLog(mensaje);
            //this.tmServicio1.Start();   
        }
        private void voGenArchivoSDR(int EmpId, string BD_GETPOINT)
        {
            string mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Inicio Proceso voGenArchivoSDR";
            //this.EscribeLog(mensaje);
            string cabecera = "";
            string detalle = "";
            string fincampo = ";";
            //string finlinea = ">";
            //string finsegmento = "~";
            string pie = "";
            string stNumeroReferencia = "", stIdDocto = "";
            StringBuilder myString = new StringBuilder();
            string Filename = "";
            string FilePath = "";
            StreamWriter strStreamWriter;
            string filetarget2 = "";
            //DateTime dtFechaHora;
            string result = "";
            //DataSet myDataSet2;

            try
            {
                DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_SRD();

                if (myDataSet.Tables[0].Rows.Count <= 0)
                {
                    return;
                }

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Inicio Proceso voGenArchivoSDR. Lineas para generar " + myDataSet.Tables.Count.ToString();
                this.EscribeLog(mensaje);

                cabecera = "";
                detalle = "";

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    //Si cambio de SDR genera nuevo archivo
                    if ((myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() != stNumeroReferencia) & (stNumeroReferencia != ""))
                    {
                        stIdDocto = myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();
                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP(BD_GETPOINT, stIdDocto, "", "");

                        //genera archivo y lo copia al FTP
                        pie = "";

                        //Filename = "ConfRecep_SRD_" + stSolRecepId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                        Filename = "OC_" + stNumeroReferencia + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                        FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                        myString.Clear();
                        myString.Append(cabecera + detalle + pie);
                        myString.Append(Environment.NewLine);
                        strStreamWriter = File.AppendText(FilePath);
                        strStreamWriter.Write(myString.ToString());
                        strStreamWriter.Close();

                        mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                        this.EscribeLog(mensaje);

                        filetarget2 = ConfigurationManager.AppSettings["PathFilesINPUT"].ToString() + "\\" + Filename;
                        File.Copy(FilePath, filetarget2);

                        File.Delete(FilePath);
                        FTP_UploadFile(filetarget2, Filename);

                        detalle = "";
                    }

                    stNumeroReferencia = myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();
                    stIdDocto = myDataSet.Tables[0].Rows[i]["Id"].ToString().Trim();

                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto1"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto2"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto3"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto4"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto5"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto6"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto7"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto8"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto9"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto10"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto11"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto12"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto13"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto14"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto15"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto16"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto17"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto18"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto19"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto20"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto21"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto22"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto23"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto24"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto25"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto26"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto27"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto28"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto29"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto30"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto31"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto32"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto33"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto34"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto35"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto36"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto37"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto38"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto39"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto40"].ToString().Trim() + fincampo;

                    detalle = detalle + System.Environment.NewLine;
                }

                pie = "";

                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP(BD_GETPOINT,
                                                                                       stIdDocto,
                                                                                       "",
                                                                                       "");

                Filename = "OC_" + stNumeroReferencia + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                myString.Clear();
                myString.Append(cabecera + detalle + pie);
                myString.Append(Environment.NewLine);
                strStreamWriter = File.AppendText(FilePath);
                strStreamWriter.Write(myString.ToString());
                strStreamWriter.Close();

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                this.EscribeLog(mensaje);

                filetarget2 = ConfigurationManager.AppSettings["PathFilesINPUT"].ToString() + "\\" + Filename;
                File.Copy(FilePath, filetarget2);


                File.Delete(FilePath);

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Fin Proceso voGenArchivoSDR";
                this.EscribeLog(mensaje);

                this.FTP_UploadFile(filetarget2, Filename);
            }
            catch (Exception ex2)
            {
                //05.06: Aqui mander correo
                string mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error " + ex2.Message;
                this.EscribeLog(mensaje1);


                //Para envio por correo electronico
                //mensaje = "Ocurrio el siguiente error <br>" + "- Ultimo registro de Log en archivo de texto : " + mensaje + "<br>";
                //mensaje = mensaje + "- Descripcion del Error Detectado : " + ex2.Message + "<br>";
                //WS_itec2.Classes.model.InfF_DMI_Archivo_852_Vw.in_AlertasSis(
                //"no-reply@grupoprecision.com",
                //ConfigurationManager.AppSettings["Correo"].ToString(),
                //ConfigurationManager.AppSettings["CorreoCC"].ToString(),
                //" ",
                //"[ALARMA] Notificacion Integracion DMI - Generacion de O/C",
                //mensaje,
                //" ", " ", " ");

            }
            mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Termino de la generacion archivos SDR";
            this.EscribeLog(mensaje);
            //this.tmServicio1.Start();   
        }
        private void voGenArchivoSALDO(int EmpId, string BD_GETPOINT)
        {
            string mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Inicio Proceso voGenArchivoSALDO";
            //this.EscribeLog(mensaje);
            string cabecera = "";
            string detalle = "";
            string fincampo = ";";
            //string finlinea = ">";
            //string finsegmento = "~";
            string pie = "";
            //string stNumeroReferencia = "";
            string stIdDocto = "";
            StringBuilder myString = new StringBuilder();
            string Filename = "";
            string FilePath = "";
            StreamWriter strStreamWriter;
            string filetarget2 = "";
            //DateTime dtFechaHora;
            //string result = "";
            //DataSet myDataSet2;

            try
            {
                DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_SALDO(BD_GETPOINT);

                if (myDataSet.Tables[0].Rows.Count <= 0)
                {
                    return;
                }

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Inicio Proceso voGenArchivoSALDO. Lineas para generar " + myDataSet.Tables.Count.ToString();
                this.EscribeLog(mensaje);

                cabecera = "";
                detalle = "";

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    stIdDocto = myDataSet.Tables[0].Rows[i]["Id"].ToString().Trim();

                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto1"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto2"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto3"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto4"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto5"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto6"].ToString().Trim() + fincampo;

                    detalle = detalle + System.Environment.NewLine;
                    //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoARTERP(BD_GETPOINT, stIdDocto);
                }
                pie = "";

                Filename = "SALDO_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                myString.Clear();
                myString.Append(cabecera + detalle + pie);
                myString.Append(Environment.NewLine);
                strStreamWriter = File.AppendText(FilePath);
                strStreamWriter.Write(myString.ToString());
                strStreamWriter.Close();

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                this.EscribeLog(mensaje);

                filetarget2 = ConfigurationManager.AppSettings["PathFilesINPUT"].ToString() + "\\" + Filename;
                File.Copy(FilePath, filetarget2);

                File.Delete(FilePath);

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Fin Proceso voGenArchivoSALDO";
                this.EscribeLog(mensaje);

                FTP_UploadFile(filetarget2, Filename);

            }
            catch (Exception ex2)
            {
                string mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error " + ex2.Message;
                this.EscribeLog(mensaje1);
            }
            mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Termino de la generacion archivos SALDO";
            this.EscribeLog(mensaje);
        }
        private void voGenArchivoSDD(int EmpId, string BD_GETPOINT)
        {
            string mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Inicio Proceso voGenArchivoSDD";
            //this.EscribeLog(mensaje);
            string cabecera = "";
            string detalle = "";
            string fincampo = ";";
            //string finlinea = ">";
            //string finsegmento = "~";
            string pie = "";
            string stNumeroReferencia = "0", stIdDocto = "";
            StringBuilder myString = new StringBuilder();
            string Filename = "";
            string FilePath = "";
            StreamWriter strStreamWriter;
            string filetarget2 = "";
            //DateTime dtFechaHora;
            string result = "";
            //DataSet myDataSet2;

            try
            {
                DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_SDD(BD_GETPOINT);

                if (myDataSet.Tables[0].Rows.Count <= 0)
                {
                    return;
                }

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Inicio Proceso voGenArchivoSDD. Lineas para generar " + myDataSet.Tables.Count.ToString();
                this.EscribeLog(mensaje);

                cabecera = "";
                detalle = "";

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    //Si cambio de SDR genera nuevo archivo
                    if ((myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() != stNumeroReferencia) & (stNumeroReferencia != ""))
                    {
                        stIdDocto = myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();
                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP(BD_GETPOINT, stIdDocto, "", "");

                        //genera archivo y lo copia al FTP
                        pie = "";


                        //Filename = "ConfRecep_SRD_" + stSolRecepId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                        Filename = "SDD_" + stNumeroReferencia + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                        FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                        myString.Clear();
                        myString.Append(cabecera + detalle + pie);
                        myString.Append(Environment.NewLine);
                        strStreamWriter = File.AppendText(FilePath);
                        strStreamWriter.Write(myString.ToString());
                        strStreamWriter.Close();

                        mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                        this.EscribeLog(mensaje);

                        //myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT");
                        //filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                        filetarget2 = ConfigurationManager.AppSettings["PathFilesINPUT"].ToString() + "\\" + Filename;
                        File.Copy(FilePath, filetarget2);


                        //myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT-BACKUP");
                        //filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                        //File.Copy(FilePath, filetarget2);


                        File.Delete(FilePath);
                        FTP_UploadFile(filetarget2, Filename);
                        //reinicia variables para un nuevo archivo
                        detalle = "";

                    }

                    stNumeroReferencia = myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim();
                    stIdDocto = myDataSet.Tables[0].Rows[i]["Id"].ToString().Trim();

                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto1"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto2"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto3"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto4"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto5"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto6"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto7"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto8"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto9"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto10"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto11"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto12"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto13"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto14"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto15"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto16"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto17"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto18"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto19"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto20"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto21"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto22"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto23"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto24"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto25"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto26"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto27"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto28"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto29"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto30"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto31"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto32"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto33"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto34"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto35"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto36"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto37"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto38"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto39"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto40"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto41"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Texto42"].ToString().Trim() + fincampo;

                    detalle = detalle + System.Environment.NewLine;
                }
                pie = "";

                result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoERP(BD_GETPOINT, stIdDocto, "", "");

                Filename = "SDD_" + stNumeroReferencia + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                myString.Clear();
                myString.Append(cabecera + detalle + pie);
                myString.Append(Environment.NewLine);
                strStreamWriter = File.AppendText(FilePath);
                strStreamWriter.Write(myString.ToString());
                strStreamWriter.Close();

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                this.EscribeLog(mensaje);

                //myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT");
                //filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                filetarget2 = ConfigurationManager.AppSettings["PathFilesINPUT"].ToString() + "\\" + Filename;
                File.Copy(FilePath, filetarget2);

                //myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT-BACKUP");
                //filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                //filetarget2 = ConfigurationManager.AppSettings["PathFilesOUTPUT_Backup"].ToString() + "\\" + Filename;
                //File.Copy(FilePath, filetarget2);

                File.Delete(FilePath);

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Fin Proceso voGenArchivoSDD";
                this.EscribeLog(mensaje);

                FTP_UploadFile(filetarget2, Filename);
            }
            catch (Exception ex2)
            {
                //05.06: Aqui mander correo
                string mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error" + ex2.Message;
                this.EscribeLog(mensaje1);

                //Para envio por correo electronico
                //mensaje = "Ocurrio el siguiente error <br>" + "- Ultimo registro de Log en archivo de texto : " + mensaje + "<br>";
                //mensaje = mensaje + "- Descripcion del Error Detectado : " + ex2.Message + "<br>";
                //WS_itec2.Classes.model.InfF_DMI_Archivo_852_Vw.in_AlertasSis(
                //"no-reply@grupoprecision.com",
                //ConfigurationManager.AppSettings["Correo"].ToString(),
                //ConfigurationManager.AppSettings["CorreoCC"].ToString(),
                //" ",
                //"[ALARMA] Notificacion Integracion DMI - Generacion de O/C",
                //mensaje,
                //" ", " ", " ");

            }
            mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Termino de la generacion archivos SDD";
            this.EscribeLog(mensaje);
            //this.tmServicio1.Start();   
        }
        private void voGenArchivoConfirmaSDR(int EmpId, string BD_GETPOINT)
        {
            string mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Inicio Proceso voGenArchivoConfirmaSDR";
            //this.EscribeLog(mensaje);
            string cabecera = "";
            string detalle = "";
            string fincampo = ";";
            //string finlinea = ">";
            //string finsegmento = "~";
            string pie = "";
            string stSolRecepId = "";
            StringBuilder myString = new StringBuilder();
            string Filename = "";
            string FilePath = "";
            StreamWriter strStreamWriter;
            string filetarget2 = "";
            DateTime dtFechaHora;
            string stArchivo = "";
            int inLenArchivo = 0;
            string result = "";
            DataSet myDataSet2;

            try
            {
                DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_SRDConfirmadas(BD_GETPOINT);

                if (myDataSet.Tables[0].Rows.Count <= 0)
                {
                    return;
                }

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Inicio Proceso voGenArchivoConfirmaSDR. Cantidad de Confirmaciones Pendientes " + myDataSet.Tables.Count.ToString();
                this.EscribeLog(mensaje);

                cabecera = "";
                detalle = "";

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoTarea(BD_GETPOINT, myDataSet.Tables[0].Rows[i]["RecepcionId"].ToString().Trim());
                    if ((myDataSet.Tables[0].Rows[i]["SolRecepId"].ToString().Trim() != stSolRecepId) & (stSolRecepId != ""))
                    {
                        //genera archivo y lo copia al FTP
                        pie = "";

                        //Filename = "ConfRecep_SRD_" + stSolRecepId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                        Filename = "CONF_OC_" + stArchivo + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                        FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                        myString.Clear();
                        myString.Append(cabecera + detalle + pie);
                        myString.Append(Environment.NewLine);
                        strStreamWriter = File.AppendText(FilePath);
                        strStreamWriter.Write(myString.ToString());
                        strStreamWriter.Close();

                        mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                        this.EscribeLog(mensaje);

                        myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT");
                        filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                        File.Copy(FilePath, filetarget2);


                        myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT-BACKUP");
                        filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                        File.Copy(FilePath, filetarget2);

                        File.Delete(FilePath);

                        //reinicia variables para un nuevo archivo
                        detalle = "";
                    }

                    stSolRecepId = myDataSet.Tables[0].Rows[i]["SolRecepId"].ToString().Trim();

                    //Solo archivo sin extension
                    stArchivo = "";
                    inLenArchivo = (myDataSet.Tables[0].Rows[i]["Archivo"].ToString().Trim()).Length;

                    if (inLenArchivo != 0)
                    {
                        stArchivo = (myDataSet.Tables[0].Rows[i]["Archivo"].ToString().Trim()).Substring(0, inLenArchivo - 4);
                    }

                    dtFechaHora = DateTime.Parse(myDataSet.Tables[0].Rows[i]["FECHAHORA"].ToString().Trim());

                    detalle = detalle + myDataSet.Tables[0].Rows[i]["INT-NAME"].ToString().Trim() + fincampo;
                    detalle = detalle + dtFechaHora.ToString("yyyyMMdd HHmmss") + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["TIPO_TRK"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["ID_WMS"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["ID_QAD"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["EmpId"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["SolRecepId"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["RecepcionId"].ToString().Trim() + fincampo;

                    //detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaDigitacion"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["UsuarioDig"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaProceso"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["TipoSolicitud"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Comprador"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["RutProveedor"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["RazonSocial"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Contacto"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Vendedor"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Region"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Ciudad"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Comuna"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Direccion"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Email"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["RutaDespId"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Simbolo"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["TipoDocumento"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["NumeroDocto"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaDocto"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["TipoReferencia"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaReferencia"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["PorcTolerancia"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Glosa"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Linea"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["CodigoOriginal"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["UnidadCompra"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Cantidad"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["ItemReferencia"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["UbicRecepWMS"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["UbicQAD"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["NroSerieRecep"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaVectoRecep"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;

                    //Atributos de la tarea
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["CantAlmacenWMS"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["NroSerieAlmacenWMS"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaVectoAlmacenWMS"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["PaletId"].ToString().Trim();

                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Referencia"].ToString().Trim() + fincampo;                        
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["PorcTolerancia"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["ControlCalidad"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["PorcQA"].ToString().Trim() + fincampo;
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["CantidadQA"].ToString().Trim() + fincampo;                            
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["UbicAlamacenWMS"].ToString().Trim() + fincampo;                            
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Referencia"].ToString().Trim() + fincampo;                            
                    //detalle = detalle + myDataSet.Tables[0].Rows[i]["Estado"].ToString().Trim() + fincampo;
                    detalle = detalle + System.Environment.NewLine;
                }
                pie = "";

                //Filename = "ConfRecep_SRD_" + stSolRecepId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                Filename = "CONF_OC_" + stArchivo + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                myString.Clear();
                myString.Append(cabecera + detalle + pie);
                myString.Append(Environment.NewLine);
                strStreamWriter = File.AppendText(FilePath);
                strStreamWriter.Write(myString.ToString());
                strStreamWriter.Close();

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                this.EscribeLog(mensaje);

                myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT");
                filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                //filetarget2 = ConfigurationManager.AppSettings["PathFilesOUTPUT"].ToString() + "\\" + Filename;
                File.Copy(FilePath, filetarget2);

                myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT-BACKUP");
                filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                //filetarget2 = ConfigurationManager.AppSettings["PathFilesOUTPUT_Backup"].ToString() + "\\" + Filename;
                File.Copy(FilePath, filetarget2);

                File.Delete(FilePath);

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Fin Proceso voGenArchivoConfirmaSDR";
                this.EscribeLog(mensaje);
            }
            catch (Exception ex2)
            {
                //05.06: Aqui mander correo
                string mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error" + ex2.Message;
                this.EscribeLog(mensaje1);
            }
            mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Termino de la generacion archivos confirmacion SDR";
            this.EscribeLog(mensaje);
            //this.tmServicio1.Start();   
        }
        private void voGenArchivoConfirmaSDD(int EmpId, string BD_GETPOINT)
        {
            //string mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Inicio Proceso voGenArchivoConfirmaSDD";
            //this.EscribeLog(mensaje);
            string mensaje = "";
            string cabecera = "";
            string detalle = "";
            string fincampo = ";";
            //string finlinea = ">";
            //string finsegmento = "~";
            string pie = "";
            string stSolDespId = "";
            StringBuilder myString = new StringBuilder();
            string Filename = "";
            string FilePath = "";
            StreamWriter strStreamWriter;
            string filetarget2 = "";
            DateTime dtFechaHora;
            string stArchivo = "";
            int inLenArchivo = 0;
            string result = "";
            DataSet myDataSet2;

            try
            {
                DataSet myDataSet = WS_Integrador.Classes.model.InfF_Generador.ShowList_SDDConfirmadas(BD_GETPOINT);
                if (myDataSet.Tables[0].Rows.Count <= 0)
                {
                    return;
                }

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Inicio Proceso voGenArchivoConfirmaSDD. Cantidad de Confirmaciones Pendientes " + myDataSet.Tables.Count.ToString();
                this.EscribeLog(mensaje);

                cabecera = "";
                detalle = "";

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoCola(BD_GETPOINT,
                                                                                            myDataSet.Tables[0].Rows[i]["ColaPickId"].ToString().Trim());
                    //Si cambio de SDR genera nuevo archivo
                    if ((myDataSet.Tables[0].Rows[i]["SolDespId"].ToString().Trim() != stSolDespId) & (stSolDespId != ""))
                    {
                        //genera archivo y lo copia al FTP
                        pie = "";

                        //Filename = "ConfRecep_SRD_" + stSolRecepId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                        Filename = "WMS_CONF" + stArchivo + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                        FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                        myString.Clear();
                        myString.Append(cabecera + detalle + pie);
                        myString.Append(Environment.NewLine);
                        strStreamWriter = File.AppendText(FilePath);
                        strStreamWriter.Write(myString.ToString());
                        strStreamWriter.Close();
                        mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Archivo Generado ";
                        this.EscribeLog(mensaje);

                        myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT");
                        filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                        File.Copy(FilePath, filetarget2);

                        myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT-BACKUP");
                        filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                        File.Copy(FilePath, filetarget2);

                        mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                        this.EscribeLog(mensaje);

                        //reinicia variables para un nuevo archivo
                        detalle = "";
                    }

                    //Solo archivo sin extension
                    inLenArchivo = (myDataSet.Tables[0].Rows[i]["Archivo"].ToString().Trim()).Length;
                    stArchivo = (myDataSet.Tables[0].Rows[i]["Archivo"].ToString().Trim()).Substring(0, inLenArchivo - 4);
                    stSolDespId = myDataSet.Tables[0].Rows[i]["SolDespId"].ToString().Trim();
                    dtFechaHora = DateTime.Parse(myDataSet.Tables[0].Rows[i]["FECHAHORA"].ToString().Trim());

                    detalle = detalle + myDataSet.Tables[0].Rows[i]["INT-NAME"].ToString().Trim() + fincampo;
                    detalle = detalle + dtFechaHora.ToString("yyyyMMdd HHmmss") + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["TIPO_TRK"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["ID_WMS"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["ID_QAD"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["EmpId"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["SolDespId"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["ColaPickId"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaProceso"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["TipoDocumento"].ToString().Trim() + fincampo;

                    detalle = detalle + myDataSet.Tables[0].Rows[i]["NumeroDocto"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaDocto"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["TipoReferencia"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["NumeroReferencia"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaReferencia"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["PorcTolerancia"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Linea"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["CodigoArticulo"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["UnidadVenta"].ToString().Trim() + fincampo;

                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Cantidad"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["ItemReferencia"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["NroSerieDesp"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["Referencia"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaVectoDesp"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["CantAlmacenWMS"].ToString().Trim() + fincampo;
                    detalle = detalle + myDataSet.Tables[0].Rows[i]["NroSerieAlmacenWMS"].ToString().Trim() + fincampo;
                    detalle = detalle + DateTime.Parse(myDataSet.Tables[0].Rows[i]["FechaVectoAlmacenWMS"].ToString().Trim()).ToString("yyyyMMdd") + fincampo;

                    detalle = detalle + System.Environment.NewLine;
                }
                pie = "";

                //Filename = "ConfRecep_SRD_" + stSolRecepId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                Filename = "WMS_CONF" + stArchivo + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
                FilePath = ConfigurationManager.AppSettings["PathLogITEC"].ToString() + "\\" + Filename;
                myString.Clear();
                myString.Append(cabecera + detalle + pie);
                myString.Append(Environment.NewLine);
                strStreamWriter = File.AppendText(FilePath);
                strStreamWriter.Write(myString.ToString());
                strStreamWriter.Close();

                myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT");
                filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                File.Copy(FilePath, filetarget2);

                myDataSet2 = WS_Integrador.Classes.model.InfF_Generador.ShowList_ConfigEsp(EmpId, "PATH_OUTPUT-BACKUP");
                filetarget2 = myDataSet2.Tables[0].Rows[0]["Valor"].ToString().Trim() + "\\" + Filename;
                File.Copy(FilePath, filetarget2);

                File.Delete(FilePath);

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "  - Archivo Generado :" + FilePath.Trim();
                this.EscribeLog(mensaje);

                mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + "+ Fin Proceso voGenArchivoConfirmaSDD";
                this.EscribeLog(mensaje);
            }
            catch (Exception ex2)
            {
                //05.06: Aqui mander correo
                string mensaje1 = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Ocurrio el siguiente error" + ex2.Message;
                this.EscribeLog(mensaje1);
            }
            mensaje = "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd HHmmss") + " Termino de la generacion archivos confirmacion SDD";
            this.EscribeLog(mensaje);
            this.tmServicio1.Start();
        }
    }
}

