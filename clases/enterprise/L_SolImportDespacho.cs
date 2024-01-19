using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using WS_Integrador_MeLoLLevo.Classes.model;

namespace WS_Integrador_MeLoLLevo.Classes.enterprise
{
	public class L_SolImportDespacho : System.ComponentModel.Component
	{
        private decimal soldespid;
		private long empid;
		private DateTime fechadigitacion;
		private string usuariodig;
		private DateTime fechaproceso;
		private int tipotransporte;
		private int tiposolicitud;
		private long codigobodega;
		private string codigoubicacion;
		private string comprador;
		private string rutcliente;
		private string razonsocial;
		private string contacto;
		private string vendedor;
		private string pais;
		private int region;
		private int ciudad;
		private int comuna;
		private string direccion;
		private string codigopostal;
		private string email;
		private string rutadespid;
		private int moneda;
		private long tipodocumento;
		private string numerodocto;
		private DateTime fechadocto;
		private string tiporeferencia;
		private string numeroreferencia;
		private DateTime fechareferencia;
		private int crossdock;
		private int indcodn;
		private decimal porctolerancia;
		private string glosa;
		private long foliorel;
		private DateTime fechaact;
		private string usuarioact;
		private DateTime fechaaprob;
		private string usuarioaprob;
		private DateTime fechacierre;
		private string usuariocierre;
		private int estado;
		private DateTime fechaestado;
		private string archivo;
		private DateTime fecha1;
		private DateTime fecha2;
		private DateTime fecha3;
		private string dato1;
		private string dato2;
		private string dato3;
		private decimal valor1;
		private decimal valor2;
		private decimal valor3;
        private long BodegaRecep;

		private System.ComponentModel.Container components = null;

		public L_SolImportDespacho(System.ComponentModel.IContainer container)
		{
			container.Add(this); 
			InitializeComponent(); 
		}

		public L_SolImportDespacho()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
				base.Dispose( disposing );
		}

#region Código generado por el Diseñador de componentes
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}

#endregion

		public static DataSet ShowList(string sortField, string sortDirection, string filterField, string filterValue)
		{
			try
			{
				return model.L_SolImportDespacho.ShowList(sortField, sortDirection, filterField, filterValue);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
			}
		}
        public static DataSet ShowListSeguimiento(int sddid, int tipo, string usuario)
        {
            try
            {
                return model.L_SolImportDespacho.ShowListSeguimiento(sddid, tipo, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }
        public static DataSet generaAnulacion(decimal soldespid, int motivoanula, string glosaanula, string usuario)
        {
            try
            {
                return model.L_SolImportDespacho.generaAnulacion(soldespid, motivoanula, glosaanula, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }
        public static DataSet GeneraCierre(decimal soldespid, int motivoanula, string glosaanula, string usuario)
        {
            try
            {
                return model.L_SolImportDespacho.GeneraCierre(soldespid, motivoanula, glosaanula, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }
        public static DataSet ProcesaRemplazoLotesSDD(decimal soldespid, string usuario)
        {
            try
            {
                return model.L_SolImportDespacho.ProcesaRemplazoLotesSDD(soldespid,  usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }

        public static DataSet ShowList(int empId, string username, DateTime fechaini, DateTime fechafin, int estado, long soldespid, string codigoArticulo, int numeroRef, int numeroRelacion)
		{
			try
			{
				return model.L_SolImportDespacho.ShowList( empId,  username,  fechaini,  fechafin, estado, soldespid, codigoArticulo, numeroRef, numeroRelacion);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
			}
		}
        public static DataSet ShowListStatus(int empId, long soldespid)
        {
            try
            {
                return model.L_SolImportDespacho.ShowListStatus(empId,soldespid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }


        public static DataSet ResumenShowList(long sddid)
        {
            try
            {
                return model.L_SolImportDespacho.ResumenShowList(sddid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }
        public static DataSet ShowListTD(int empId, string username, DateTime fechaini, DateTime fechafin, int estado, long soldespid, string codigoArticulo, int numeroRef, int numeroRelacion)
        {
            try
            {
                return model.L_SolImportDespacho.ShowListTD(empId, username, fechaini, fechafin, estado, soldespid, codigoArticulo, numeroRef, numeroRelacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }

        }
        public static DataSet ShowListSDRInforme(int sddrd, int empid)
        {
            try
            {
                return model.L_SolImportDespacho.ShowListSDRInforme(sddrd, empid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }
        public static DataSet ShowListGestionador(int empId, string username, DateTime fechaini, DateTime fechafin, int estado, string cliente, string codigoArticulo, string ruta, string tipoCliente, int numeroRefini, int numeroReffin, int numeroDoctoini, int numeroDoctofin, long soldespid, string comunadespacho, int tiposolicitud, int lineaproducto, int tiposaldo)
		{
			try
			{
                return model.L_SolImportDespacho.ShowListGestionador(empId, username, fechaini, fechafin, estado, cliente, codigoArticulo, ruta, tipoCliente, numeroRefini, numeroReffin, numeroDoctoini, numeroDoctofin, soldespid, comunadespacho, tiposolicitud, lineaproducto, tiposaldo);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
			}
		}

        public static DataSet ShowListLeeRevisionPed(int empId, string username, decimal numeropicking, decimal soldespid)
        {
            try
            {
                return model.L_SolImportDespacho.ShowListLeeRevisionPed(empId, username, numeropicking, soldespid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }
        public static DataSet ShowListLeeRevisionProx(int empId, string username, decimal revisionid, decimal numpaletactual)
        {
            try
            {
                return model.L_SolImportDespacho.ShowListLeeRevisionProx(empId, username, revisionid, numpaletactual);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }
        public static DataSet ShowListLeeRevisionAnt(int empId, string username, decimal revisionid, decimal numpaletactual)
        {
            try
            {
                return model.L_SolImportDespacho.ShowListLeeRevisionAnt(empId, username, revisionid, numpaletactual);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
            }
        }

        public L_SolImportDespacho(decimal soldespid)
		{
			model.L_SolImportDespacho myL_SolImportDespacho;
			try
			{
				myL_SolImportDespacho = model.L_SolImportDespacho.Get(soldespid);
				this.soldespid = myL_SolImportDespacho.mySolDespId;
				this.empid = myL_SolImportDespacho.myEmpId;
				this.fechadigitacion = myL_SolImportDespacho.myFechaDigitacion;
				this.usuariodig = myL_SolImportDespacho.myUsuarioDig;
				this.fechaproceso = myL_SolImportDespacho.myFechaProceso;
				this.tipotransporte = myL_SolImportDespacho.myTipoTransporte;
				this.tiposolicitud = myL_SolImportDespacho.myTipoSolicitud;
				this.codigobodega = myL_SolImportDespacho.myCodigoBodega;
				this.codigoubicacion = myL_SolImportDespacho.myCodigoUbicacion;
				this.comprador = myL_SolImportDespacho.myComprador;
				this.rutcliente = myL_SolImportDespacho.myRutCliente;
				this.razonsocial = myL_SolImportDespacho.myRazonSocial;
				this.contacto = myL_SolImportDespacho.myContacto;
				this.vendedor = myL_SolImportDespacho.myVendedor;
				this.pais = myL_SolImportDespacho.myPais;
				this.region = myL_SolImportDespacho.myRegion;
				this.ciudad = myL_SolImportDespacho.myCiudad;
				this.comuna = myL_SolImportDespacho.myComuna;
				this.direccion = myL_SolImportDespacho.myDireccion;
				this.codigopostal = myL_SolImportDespacho.myCodigoPostal;
				this.email = myL_SolImportDespacho.myEmail;
				this.rutadespid = myL_SolImportDespacho.myRutaDespId;
				this.moneda = myL_SolImportDespacho.myMoneda;
				this.tipodocumento = myL_SolImportDespacho.myTipoDocumento;
				this.numerodocto = myL_SolImportDespacho.myNumeroDocto;
				this.fechadocto = myL_SolImportDespacho.myFechaDocto;
				this.tiporeferencia = myL_SolImportDespacho.myTipoReferencia;
				this.numeroreferencia = myL_SolImportDespacho.myNumeroReferencia;
				this.fechareferencia = myL_SolImportDespacho.myFechaReferencia;
				this.crossdock = myL_SolImportDespacho.myCrossDock;
				this.indcodn = myL_SolImportDespacho.myIndCodN;
				this.porctolerancia = myL_SolImportDespacho.myPorcTolerancia;
				this.glosa = myL_SolImportDespacho.myGlosa;
				this.foliorel = myL_SolImportDespacho.myFolioRel;
				this.fechaact = myL_SolImportDespacho.myFechaAct;
				this.usuarioact = myL_SolImportDespacho.myUsuarioAct;
				this.fechaaprob = myL_SolImportDespacho.myFechaAprob;
				this.usuarioaprob = myL_SolImportDespacho.myUsuarioAprob;
				this.fechacierre = myL_SolImportDespacho.myFechaCierre;
				this.usuariocierre = myL_SolImportDespacho.myUsuarioCierre;
				this.estado = myL_SolImportDespacho.myEstado;
				this.fechaestado = myL_SolImportDespacho.myFechaEstado;
				this.archivo = myL_SolImportDespacho.myArchivo;
				this.fecha1 = myL_SolImportDespacho.myFecha1;
				this.fecha2 = myL_SolImportDespacho.myFecha2;
				this.fecha3 = myL_SolImportDespacho.myFecha3;
				this.dato1 = myL_SolImportDespacho.myDato1;
				this.dato2 = myL_SolImportDespacho.myDato2;
				this.dato3 = myL_SolImportDespacho.myDato3;
				this.valor1 = myL_SolImportDespacho.myValor1;
				this.valor2 = myL_SolImportDespacho.myValor2;
				this.valor3 = myL_SolImportDespacho.myValor3;
                this.BodegaRecep = myL_SolImportDespacho.myBodegaRecep;
			}
			catch(Exception ex)
			{
			throw new Exception(ex.Message);
			}
		}

        public L_SolImportDespacho(decimal soldespid, long empid, DateTime fechadigitacion, string usuariodig, DateTime fechaproceso, int tipotransporte, int tiposolicitud, long codigobodega, string codigoubicacion, string comprador, string rutcliente, string razonsocial, string contacto, string vendedor, string pais, int region, int ciudad, int comuna, string direccion, string codigopostal, string email, string rutadespid, int moneda, long tipodocumento, string numerodocto, DateTime fechadocto, string tiporeferencia, string numeroreferencia, DateTime fechareferencia, int crossdock, int indcodn, decimal porctolerancia, string glosa, long foliorel, DateTime fechaact, string usuarioact, DateTime fechaaprob, string usuarioaprob, DateTime fechacierre, string usuariocierre, int estado, DateTime fechaestado, string archivo, DateTime fecha1, DateTime fecha2, DateTime fecha3, string dato1, string dato2, string dato3, decimal valor1, decimal valor2, decimal valor3, long BodegaRecep)
		{
			this.soldespid = soldespid;
			this.empid = empid;
			this.fechadigitacion = fechadigitacion;
			this.usuariodig = usuariodig;
			this.fechaproceso = fechaproceso;
			this.tipotransporte = tipotransporte;
			this.tiposolicitud = tiposolicitud;
			this.codigobodega = codigobodega;
			this.codigoubicacion = codigoubicacion;
			this.comprador = comprador;
			this.rutcliente = rutcliente;
			this.razonsocial = razonsocial;
			this.contacto = contacto;
			this.vendedor = vendedor;
			this.pais = pais;
			this.region = region;
			this.ciudad = ciudad;
			this.comuna = comuna;
			this.direccion = direccion;
			this.codigopostal = codigopostal;
			this.email = email;
			this.rutadespid = rutadespid;
			this.moneda = moneda;
			this.tipodocumento = tipodocumento;
			this.numerodocto = numerodocto;
			this.fechadocto = fechadocto;
			this.tiporeferencia = tiporeferencia;
			this.numeroreferencia = numeroreferencia;
			this.fechareferencia = fechareferencia;
			this.crossdock = crossdock;
			this.indcodn = indcodn;
			this.porctolerancia = porctolerancia;
			this.glosa = glosa;
			this.foliorel = foliorel;
			this.fechaact = fechaact;
			this.usuarioact = usuarioact;
			this.fechaaprob = fechaaprob;
			this.usuarioaprob = usuarioaprob;
			this.fechacierre = fechacierre;
			this.usuariocierre = usuariocierre;
			this.estado = estado;
			this.fechaestado = fechaestado;
			this.archivo = archivo;
			this.fecha1 = fecha1;
			this.fecha2 = fecha2;
			this.fecha3 = fecha3;
			this.dato1 = dato1;
			this.dato2 = dato2;
			this.dato3 = dato3;
			this.valor1 = valor1;
			this.valor2 = valor2;
			this.valor3 = valor3;
            this.BodegaRecep = BodegaRecep;
		}

        public bool Save()
		{
			bool results;
			model.L_SolImportDespacho myL_SolImportDespacho;
			try
			{
                myL_SolImportDespacho = new model.L_SolImportDespacho(this.soldespid, this.empid, this.fechadigitacion, this.usuariodig, this.fechaproceso, this.tipotransporte, this.tiposolicitud, this.codigobodega, this.codigoubicacion, this.comprador, this.rutcliente, this.razonsocial, this.contacto, this.vendedor, this.pais, this.region, this.ciudad, this.comuna, this.direccion, this.codigopostal, this.email, this.rutadespid, this.moneda, this.tipodocumento, this.numerodocto, this.fechadocto, this.tiporeferencia, this.numeroreferencia, this.fechareferencia, this.crossdock, this.indcodn, this.porctolerancia, this.glosa, this.foliorel, this.fechaact, this.usuarioact, this.fechaaprob, this.usuarioaprob, this.fechacierre, this.usuariocierre, this.estado, this.fechaestado, this.archivo, this.fecha1, this.fecha2, this.fecha3, this.dato1, this.dato2, this.dato3, this.valor1, this.valor2, this.valor3, this.BodegaRecep);
                if (myL_SolImportDespacho.Save())
			{
                this.mySolDespId = myL_SolImportDespacho.mySolDespId;//REVISAR
			results = true;
			}
			else
			{
				results = false;
			}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message.ToString());
			}
			finally
			{
			}
			return results;
		}

        public static bool Delete(decimal soldespid,string usuario)
		{
			try
			{
                return model.L_SolImportDespacho.Delete(soldespid, usuario);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
			}
		}

        public decimal mySolDespId
		{
			get{return soldespid;}
			set{soldespid = value;}
		}
		public long myEmpId
		{
			get{return empid;}
			set{empid = value;}
		}
		public DateTime myFechaDigitacion
		{
			get{return fechadigitacion;}
			set{fechadigitacion = value;}
		}
		public string myUsuarioDig
		{
			get{return usuariodig;}
			set{usuariodig = value;}
		}
		public DateTime myFechaProceso
		{
			get{return fechaproceso;}
			set{fechaproceso = value;}
		}
		public int myTipoTransporte
		{
			get{return tipotransporte;}
			set{tipotransporte = value;}
		}
		public int myTipoSolicitud
		{
			get{return tiposolicitud;}
			set{tiposolicitud = value;}
		}
		public long myCodigoBodega
		{
			get{return codigobodega;}
			set{codigobodega = value;}
		}
		public string myCodigoUbicacion
		{
			get{return codigoubicacion;}
			set{codigoubicacion = value;}
		}
		public string myComprador
		{
			get{return comprador;}
			set{comprador = value;}
		}
		public string myRutCliente
		{
			get{return rutcliente;}
			set{rutcliente = value;}
		}
		public string myRazonSocial
		{
			get{return razonsocial;}
			set{razonsocial = value;}
		}
		public string myContacto
		{
			get{return contacto;}
			set{contacto = value;}
		}
		public string myVendedor
		{
			get{return vendedor;}
			set{vendedor = value;}
		}
		public string myPais
		{
			get{return pais;}
			set{pais = value;}
		}
		public int myRegion
		{
			get{return region;}
			set{region = value;}
		}
		public int myCiudad
		{
			get{return ciudad;}
			set{ciudad = value;}
		}
		public int myComuna
		{
			get{return comuna;}
			set{comuna = value;}
		}
		public string myDireccion
		{
			get{return direccion;}
			set{direccion = value;}
		}
		public string myCodigoPostal
		{
			get{return codigopostal;}
			set{codigopostal = value;}
		}
		public string myEmail
		{
			get{return email;}
			set{email = value;}
		}
		public string myRutaDespId
		{
			get{return rutadespid;}
			set{rutadespid = value;}
		}
		public int myMoneda
		{
			get{return moneda;}
			set{moneda = value;}
		}
		public long myTipoDocumento
		{
			get{return tipodocumento;}
			set{tipodocumento = value;}
		}
		public string myNumeroDocto
		{
			get{return numerodocto;}
			set{numerodocto = value;}
		}
		public DateTime myFechaDocto
		{
			get{return fechadocto;}
			set{fechadocto = value;}
		}
		public string myTipoReferencia
		{
			get{return tiporeferencia;}
			set{tiporeferencia = value;}
		}
		public string myNumeroReferencia
		{
			get{return numeroreferencia;}
			set{numeroreferencia = value;}
		}
		public DateTime myFechaReferencia
		{
			get{return fechareferencia;}
			set{fechareferencia = value;}
		}
		public int myCrossDock
		{
			get{return crossdock;}
			set{crossdock = value;}
		}
		public int myIndCodN
		{
			get{return indcodn;}
			set{indcodn = value;}
		}
		public decimal myPorcTolerancia
		{
			get{return porctolerancia;}
			set{porctolerancia = value;}
		}
		public string myGlosa
		{
			get{return glosa;}
			set{glosa = value;}
		}
		public long myFolioRel
		{
			get{return foliorel;}
			set{foliorel = value;}
		}
		public DateTime myFechaAct
		{
			get{return fechaact;}
			set{fechaact = value;}
		}
		public string myUsuarioAct
		{
			get{return usuarioact;}
			set{usuarioact = value;}
		}
		public DateTime myFechaAprob
		{
			get{return fechaaprob;}
			set{fechaaprob = value;}
		}
		public string myUsuarioAprob
		{
			get{return usuarioaprob;}
			set{usuarioaprob = value;}
		}
		public DateTime myFechaCierre
		{
			get{return fechacierre;}
			set{fechacierre = value;}
		}
		public string myUsuarioCierre
		{
			get{return usuariocierre;}
			set{usuariocierre = value;}
		}
		public int myEstado
		{
			get{return estado;}
			set{estado = value;}
		}
		public DateTime myFechaEstado
		{
			get{return fechaestado;}
			set{fechaestado = value;}
		}
		public string myArchivo
		{
			get{return archivo;}
			set{archivo = value;}
		}
		public DateTime myFecha1
		{
			get{return fecha1;}
			set{fecha1 = value;}
		}
		public DateTime myFecha2
		{
			get{return fecha2;}
			set{fecha2 = value;}
		}
		public DateTime myFecha3
		{
			get{return fecha3;}
			set{fecha3 = value;}
		}
		public string myDato1
		{
			get{return dato1;}
			set{dato1 = value;}
		}
		public string myDato2
		{
			get{return dato2;}
			set{dato2 = value;}
		}
		public string myDato3
		{
			get{return dato3;}
			set{dato3 = value;}
		}
		public decimal myValor1
		{
			get{return valor1;}
			set{valor1 = value;}
		}
		public decimal myValor2
		{
			get{return valor2;}
			set{valor2 = value;}
		}
		public decimal myValor3
		{
			get{return valor3;}
			set{valor3 = value;}
		}
        public long myBodegaRecep
        {
            get { return BodegaRecep; }
            set { BodegaRecep = value; }
        }
	}
}