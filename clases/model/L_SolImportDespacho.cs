using System;
 using System.ComponentModel;
 using System.Collections;
 using System.Diagnostics;
 using System.Data;
 using System.Data.OleDb;
using WS_Integrador_MeLoLLevo.Classes.global;

namespace WS_Integrador_MeLoLLevo.Classes.model
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

		public L_SolImportDespacho(decimal soldespid)
		{
			try
			{
				this.ClsLoad(soldespid);
			}
			catch(Exception ex)
			{
			throw new Exception(ex.Message);
			}
		}

		public static L_SolImportDespacho Get(decimal soldespid)
		{
			L_SolImportDespacho myL_SolImportDespacho;
			try
			{
				myL_SolImportDespacho = new L_SolImportDespacho(soldespid);
				return myL_SolImportDespacho;
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

#region Código generado por el Diseñador de componentes
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}

#endregion

		public bool ClsLoad(decimal SolDespId)
		{
			OleDbDataReader myDataReader; 
			string sql="" ; 
			bool result;
            sql = "Select SolDespId, EmpId, FechaDigitacion, UsuarioDig, FechaProceso, TipoTransporte, TipoSolicitud, CodigoBodega, CodigoUbicacion, Comprador, RutCliente, RazonSocial, Contacto, Vendedor, Pais, Region, Ciudad, Comuna, Direccion, CodigoPostal, Email, RutaDespId, Moneda, TipoDocumento, NumeroDocto, FechaDocto, TipoReferencia, NumeroReferencia, FechaReferencia, CrossDock, IndCodN, PorcTolerancia, Glosa, FolioRel, FechaAct, UsuarioAct, FechaAprob, UsuarioAprob, FechaCierre, UsuarioCierre, Estado, FechaEstado, Archivo, Fecha1, Fecha2, Fecha3, Dato1, Dato2, Dato3, Valor1, Valor2, Valor3,BodegaRecep";
			sql += " From L_SolImportDespacho Where SolDespId = ?  ";
			OleDbConnection myConnection = DB.getConnection();
			OleDbCommand myCommand = new OleDbCommand(sql,myConnection);
			myCommand.CommandType=CommandType.Text;
			try
			{
				myCommand.Parameters.Add("SolDespId",OleDbType.Numeric).Value = SolDespId;
				myConnection.Open();
				myDataReader = myCommand.ExecuteReader();
				result=true;
				if (myDataReader.Read()) 
				{
					this.soldespid = decimal.Parse(myDataReader.GetDecimal(0).ToString());
					this.empid = long.Parse(myDataReader.GetInt32(1).ToString());
					this.fechadigitacion = DateTime.Parse(myDataReader.GetDateTime(2).ToString());
					this.usuariodig = myDataReader.GetString(3);
					this.fechaproceso = DateTime.Parse(myDataReader.GetDateTime(4).ToString());
					this.tipotransporte = int.Parse(myDataReader.GetInt16(5).ToString());
					this.tiposolicitud = int.Parse(myDataReader.GetInt16(6).ToString());
					this.codigobodega = long.Parse(myDataReader.GetInt32(7).ToString());
					this.codigoubicacion = myDataReader.GetString(8);
					this.comprador = myDataReader.GetString(9);
					this.rutcliente = myDataReader.GetString(10);
					this.razonsocial = myDataReader.GetString(11);
					this.contacto = myDataReader.GetString(12);
					this.vendedor = myDataReader.GetString(13);
					this.pais = myDataReader.GetString(14);
					this.region = int.Parse(myDataReader.GetInt16(15).ToString());
					this.ciudad = int.Parse(myDataReader.GetInt16(16).ToString());
					this.comuna = int.Parse(myDataReader.GetInt16(17).ToString());
					this.direccion = myDataReader.GetString(18);
					this.codigopostal = myDataReader.GetString(19);
					this.email = myDataReader.GetString(20);
					this.rutadespid = myDataReader.GetString(21);
					this.moneda = int.Parse(myDataReader.GetInt16(22).ToString());
					this.tipodocumento = long.Parse(myDataReader.GetInt32(23).ToString());
					this.numerodocto = myDataReader.GetString(24);
					this.fechadocto = DateTime.Parse(myDataReader.GetDateTime(25).ToString());
					this.tiporeferencia = myDataReader.GetString(26);
					this.numeroreferencia = myDataReader.GetString(27);
					this.fechareferencia = DateTime.Parse(myDataReader.GetDateTime(28).ToString());
					this.crossdock = int.Parse(myDataReader.GetByte(29).ToString());
					this.indcodn = int.Parse(myDataReader.GetByte(30).ToString());
					this.porctolerancia = decimal.Parse(myDataReader.GetDouble(31).ToString());
					this.glosa = myDataReader.GetString(32);
					this.foliorel = long.Parse(myDataReader.GetInt32(33).ToString());
					this.fechaact = DateTime.Parse(myDataReader.GetDateTime(34).ToString());
					this.usuarioact = myDataReader.GetString(35);
					this.fechaaprob = DateTime.Parse(myDataReader.GetDateTime(36).ToString());
					this.usuarioaprob = myDataReader.GetString(37);
					this.fechacierre = DateTime.Parse(myDataReader.GetDateTime(38).ToString());
					this.usuariocierre = myDataReader.GetString(39);
					this.estado = int.Parse(myDataReader.GetInt16(40).ToString());
					this.fechaestado = DateTime.Parse(myDataReader.GetDateTime(41).ToString());
					this.archivo = myDataReader.GetString(42);
					this.fecha1 = DateTime.Parse(myDataReader.GetDateTime(43).ToString());
					this.fecha2 = DateTime.Parse(myDataReader.GetDateTime(44).ToString());
					this.fecha3 = DateTime.Parse(myDataReader.GetDateTime(45).ToString());
					this.dato1 = myDataReader.GetString(46);
					this.dato2 = myDataReader.GetString(47);
					this.dato3 = myDataReader.GetString(48);
					this.valor1 = decimal.Parse(myDataReader.GetDecimal(49).ToString());
					this.valor2 = decimal.Parse(myDataReader.GetDecimal(50).ToString());
					this.valor3 = decimal.Parse(myDataReader.GetDecimal(51).ToString());
                    this.BodegaRecep = long.Parse(myDataReader.GetInt32(52).ToString());

                    
				}
				else
				{
				result=false;
				}
				}
				catch (Exception e)
				{
					throw new Exception(e.Message);
				}
				finally
				{
					myConnection.Close();
					myConnection.Dispose();
				}
			return result;
		}

		public static bool Exists(decimal soldespid)
		{
			try
			{
				return new L_SolImportDespacho().ClsLoad(soldespid);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
        public static DataSet ShowListSDRInforme(int sddid, int empid)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_SDDDetInforme", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@SolRecepId", OleDbType.Integer).Value = sddid;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empid;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_SDDDetInforme");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }
		public static DataSet ShowList(string sortField, string sortDirection, string filterField, string filterValue)
		{
			DataSet myDataSet = new DataSet();
			OleDbDataAdapter myAdapter = new OleDbDataAdapter();
			string sql="";

			sql = " Select"+ 
			 " SolDespId, " + 
			 " EmpId, " + 
			 " FechaDigitacion, " + 
			 " UsuarioDig, " + 
			 " FechaProceso, " + 
			 " TipoTransporte, " + 
			 " TipoSolicitud, " + 
			 " CodigoBodega, " + 
			 " CodigoUbicacion, " + 
			 " Comprador, " + 
			 " RutCliente, " + 
			 " RazonSocial, " + 
			 " Contacto, " + 
			 " Vendedor, " + 
			 " Pais, " + 
			 " Region, " + 
			 " Ciudad, " + 
			 " Comuna, " + 
			 " Direccion, " + 
			 " CodigoPostal, " + 
			 " Email, " + 
			 " RutaDespId, " + 
			 " Moneda, " + 
			 " TipoDocumento, " + 
			 " NumeroDocto, " + 
			 " FechaDocto, " + 
			 " TipoReferencia, " + 
			 " NumeroReferencia, " + 
			 " FechaReferencia, " + 
			 " CrossDock, " + 
			 " IndCodN, " + 
			 " PorcTolerancia, " + 
			 " Glosa, " + 
			 " FolioRel, " + 
			 " FechaAct, " + 
			 " UsuarioAct, " + 
			 " FechaAprob, " + 
			 " UsuarioAprob, " + 
			 " FechaCierre, " + 
			 " UsuarioCierre, " + 
			 " Estado, " + 
			 " FechaEstado, " + 
			 " Archivo, " + 
			 " Fecha1, " + 
			 " Fecha2, " + 
			 " Fecha3, " + 
			 " Dato1, " + 
			 " Dato2, " + 
			 " Dato3, " + 
			 " Valor1, " + 
			 " Valor2, " + 
			 " Valor3"+
			" From L_SolImportDespacho  "+
			" Where 1=1" ;

			if(filterField != "")
			{
				sql +=  " And Upper("+ filterField +") like '%"+ filterValue.ToUpper().Trim() + "%'";
			}
			//ORDENAMIENTO
			if(sortField != "")
			{
				sql+= "Order by "+ sortField +" " + sortDirection + " ";
			}
			OleDbConnection myConnection = DB.getConnection();
			OleDbCommand myCommand = new OleDbCommand(sql,myConnection);
			myCommand.CommandType=CommandType.Text;
			try
			{
				myAdapter.SelectCommand = myCommand;
				myAdapter.Fill(myDataSet, "L_SolImportDespacho");
			}
			catch (Exception e) 
			{
				throw new Exception(e.Message);
			}
			finally
			{
				myConnection.Close();
				myConnection.Dispose();
			}
			return myDataSet;
		}
        public static DataSet ResumenShowList(long sddid)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_SDD_Res", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = sddid;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_SDD_Res");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }

            return myDataSet;
        }
        public static DataSet generaAnulacion(decimal soldespid, int motivoanula, string glosaanula, string usuario)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_cmbEstadoAnula_SDD", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = soldespid;
            myCommand.Parameters.Add("@MotivoAnula", OleDbType.Integer).Value = motivoanula;
            myCommand.Parameters.Add("@GlosaAnula", OleDbType.VarChar, 8000).Value = glosaanula;
            myCommand.Parameters.Add("@Usuario", OleDbType.Char, 15).Value = usuario;
            //sp_gen_GestionadorCord


            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "L_SolImportDespaccho");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }
        public static DataSet GeneraCierre(decimal soldespid, int motivoanula, string glosaanula, string usuario)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_cmbEstadoCerrar_SDD", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = soldespid;
            myCommand.Parameters.Add("@MotivoAnula", OleDbType.Integer).Value = motivoanula;
            myCommand.Parameters.Add("@GlosaAnula", OleDbType.VarChar, 8000).Value = glosaanula;
            myCommand.Parameters.Add("@Usuario", OleDbType.Char, 15).Value = usuario;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "cmbEstadoCerrar_SDD");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }
        public static DataSet ProcesaRemplazoLotesSDD(decimal soldespid, string usuario)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_val_ReemplazaLotesSDD", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {

                myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = soldespid;
                myCommand.Parameters.Add("@Usuario", OleDbType.Char, 15).Value = usuario;

                OleDbParameter mensaje = new OleDbParameter("@Mensaje", OleDbType.VarChar, 1000);
                mensaje.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(mensaje);

                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_val_ReemplazaLotesSDD");

                if (!mensaje.Value.ToString().Trim().Equals(""))
                {
                    throw new Exception(mensaje.Value.ToString().Trim());
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }
        public static DataSet ShowListSeguimiento(int sddid, int tipo, string usuario)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_TrackingSDD", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@ProcesoId", OleDbType.Integer).Value = sddid;
            myCommand.Parameters.Add("@Tipo", OleDbType.Integer).Value = tipo;
            myCommand.Parameters.Add("@Usuario", OleDbType.Char, 15).Value = usuario;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_TrackingSDD");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }
        public static DataSet ShowList(int empId, string username, DateTime fechaini, DateTime fechafin, int estado, long soldespid, string codigoArticulo,int numeroRef, int numeroRelacion)
		{
			DataSet myDataSet = new DataSet();
			OleDbConnection myConnection = DB.getConnection();
			OleDbCommand myCommand = new OleDbCommand("sp_sel_SDD", myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            myCommand.Parameters.Add("@UserName", OleDbType.Char, 15).Value = username;
            myCommand.Parameters.Add("@FechaInicio", OleDbType.Date).Value = fechaini;
            myCommand.Parameters.Add("@FechaTermino", OleDbType.Date).Value = fechafin;
            myCommand.Parameters.Add("@Estado", OleDbType.Integer).Value = estado;
            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = soldespid;
			myCommand.Parameters.Add("@CodigoArticulo", OleDbType.Char,30).Value = codigoArticulo;
            myCommand.Parameters.Add("@NumeroRef", OleDbType.Integer).Value = numeroRef;
            myCommand.Parameters.Add("@NumeroRelacion", OleDbType.Integer).Value = numeroRelacion;
 


			try
			{
			myCommand.CommandTimeout = 9999;
			myConnection.Open();
            //myCommand.ExecuteNonQuery();
			OleDbDataAdapter myAdapter = new OleDbDataAdapter();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"L_SolImportDespacho");
			}
			catch (Exception e)
			{
			throw new Exception(e.Message);
			}
			finally
			{
			myConnection.Close();
			myConnection.Dispose();
			}
			return myDataSet;
		}
        public static DataSet ShowListStatus(int empId, long soldespid)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_SDDStatus", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = soldespid;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "StatusSDD");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }
        public static DataSet ShowListTD(int empId, string username, DateTime fechaini, DateTime fechafin, int estado, long soldespid, string codigoArticulo, int numeroRef, int numeroRelacion)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_SDT", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            myCommand.Parameters.Add("@UserName", OleDbType.Char, 15).Value = username;
            myCommand.Parameters.Add("@FechaInicio", OleDbType.Date).Value = fechaini;
            myCommand.Parameters.Add("@FechaTermino", OleDbType.Date).Value = fechafin;
            myCommand.Parameters.Add("@Estado", OleDbType.Integer).Value = estado;
            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = soldespid;
            myCommand.Parameters.Add("@CodigoArticulo", OleDbType.Char, 30).Value = codigoArticulo;
            myCommand.Parameters.Add("@NumeroRef", OleDbType.Integer).Value = numeroRef;
            myCommand.Parameters.Add("@NumeroRelacion", OleDbType.Integer).Value = numeroRelacion;



            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "L_SolImportDespacho");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }
        public static DataSet ShowListGestionador(int empId, string username, DateTime fechaini, DateTime fechafin, int estado, string cliente, string codigoArticulo, string ruta, string tipoCliente, int numeroRefini, int numeroReffin, int numeroDoctoini, int numeroDoctofin, long soldespid, string comunadespacho, int tiposolicitud, int lineaproducto, int tiposaldo)
		{
			DataSet myDataSet = new DataSet();
			OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_GestionadorV2", myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            myCommand.Parameters.Add("@UserName", OleDbType.Char, 15).Value = username;
            myCommand.Parameters.Add("@FechaInicio", OleDbType.Date).Value = fechaini;
            myCommand.Parameters.Add("@FechaTermino", OleDbType.Date).Value = fechafin;
            myCommand.Parameters.Add("@Estado", OleDbType.Integer).Value = estado;

            myCommand.Parameters.Add("@Cliente", OleDbType.Char,30).Value = cliente;
            myCommand.Parameters.Add("@CodigoArticulo", OleDbType.Char,50).Value = codigoArticulo;
            myCommand.Parameters.Add("@Ruta", OleDbType.Char,50).Value = ruta;
            myCommand.Parameters.Add("@tipocliente", OleDbType.Char,30).Value = tipoCliente;
            myCommand.Parameters.Add("@NumeroRefIni", OleDbType.Integer).Value = numeroRefini;
            myCommand.Parameters.Add("@NumeroRefFin", OleDbType.Integer).Value = numeroReffin;
            myCommand.Parameters.Add("@NumeroDoctoIni", OleDbType.Integer).Value = numeroDoctoini;
            myCommand.Parameters.Add("@NumeroDoctoFin", OleDbType.Integer).Value = numeroDoctofin;
            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = soldespid;
            myCommand.Parameters.Add("@ComunaDesp", OleDbType.Char, 30).Value = comunadespacho;
            myCommand.Parameters.Add("@TipoSolicitud", OleDbType.Integer).Value = tiposolicitud;
            myCommand.Parameters.Add("@LineaProducto", OleDbType.Integer).Value = lineaproducto;
            myCommand.Parameters.Add("@TipoSaldo", OleDbType.Integer).Value = tiposaldo;
		 
 
            try
			{
			myCommand.CommandTimeout = 9999;
			myConnection.Open();
            //myCommand.ExecuteNonQuery();
			OleDbDataAdapter myAdapter = new OleDbDataAdapter();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"L_SolImportDespacho");
			}
			catch (Exception e)
			{
			throw new Exception(e.Message);
			}
			finally
			{
			myConnection.Close();
			myConnection.Dispose();
			}
			return myDataSet;
		}


        public static DataSet ShowListLeeRevisionPed(int empId, string username, decimal numeropicking, decimal numerosolicituds)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_LeeRevisionPedidosUlt", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            myCommand.Parameters.Add("@UserName", OleDbType.Char, 15).Value = username;
            myCommand.Parameters.Add("@NumeroPicking", OleDbType.Numeric).Value = numeropicking;
            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = numerosolicituds;
   
            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "L_SolImportDespacho");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }



        public static DataSet ShowListLeeRevisionProx(int empId, string username, decimal revisionid, decimal numpaletactual)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_LeeRevisionPedidosProx", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            myCommand.Parameters.Add("@UserName", OleDbType.Char, 15).Value = username;
            myCommand.Parameters.Add("@RevisionId", OleDbType.Numeric).Value = revisionid;
            myCommand.Parameters.Add("@NumeroPaletAct", OleDbType.Numeric).Value = numpaletactual;


            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "L_SolImportDespacho");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }

        public static DataSet ShowListLeeRevisionAnt(int empId, string username, decimal revisionid, decimal numpaletactual)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_LeeRevisionPedidosAnt", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            myCommand.Parameters.Add("@UserName", OleDbType.Char, 15).Value = username;
            myCommand.Parameters.Add("@RevisionId", OleDbType.Numeric).Value = revisionid;
            myCommand.Parameters.Add("@NumeroPaletAct", OleDbType.Numeric).Value = numpaletactual;


            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "L_SolImportDespacho");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return myDataSet;
        }
        
		public bool Create()
		{
			bool result;
			OleDbConnection myConnection = DB.getOleDbConnection();
			OleDbCommand myCommand = new OleDbCommand("sp_in_SolImportDespacho", myConnection);
 			myCommand.CommandType = CommandType.StoredProcedure;

		//	myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = this.soldespid;
			myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = this.empid;
			myCommand.Parameters.Add("@FechaDigitacion", OleDbType.Date).Value = this.fechadigitacion;
			myCommand.Parameters.Add("@UsuarioDig", OleDbType.Char , 15).Value = this.usuariodig;
			myCommand.Parameters.Add("@FechaProceso", OleDbType.Date).Value = this.fechaproceso;
			myCommand.Parameters.Add("@TipoTransporte", OleDbType.SmallInt).Value = this.tipotransporte;
			myCommand.Parameters.Add("@TipoSolicitud", OleDbType.SmallInt).Value = this.tiposolicitud;
			myCommand.Parameters.Add("@CodigoBodega", OleDbType.Integer).Value = this.codigobodega;
			myCommand.Parameters.Add("@CodigoUbicacion", OleDbType.Char , 20).Value = this.codigoubicacion;
			myCommand.Parameters.Add("@Comprador", OleDbType.Char , 50).Value = this.comprador;
			myCommand.Parameters.Add("@RutCliente", OleDbType.Char , 12).Value = this.rutcliente;
			myCommand.Parameters.Add("@RazonSocial", OleDbType.Char , 50).Value = this.razonsocial;
			myCommand.Parameters.Add("@Contacto", OleDbType.Char , 50).Value = this.contacto;
			myCommand.Parameters.Add("@Vendedor", OleDbType.Char , 50).Value = this.vendedor;
			myCommand.Parameters.Add("@Pais", OleDbType.Char , 50).Value = this.pais;
			myCommand.Parameters.Add("@Region", OleDbType.SmallInt).Value = this.region;
			myCommand.Parameters.Add("@Ciudad", OleDbType.SmallInt).Value = this.ciudad;
			myCommand.Parameters.Add("@Comuna", OleDbType.SmallInt).Value = this.comuna;
			myCommand.Parameters.Add("@Direccion", OleDbType.Char , 100).Value = this.direccion;
			myCommand.Parameters.Add("@CodigoPostal", OleDbType.Char , 20).Value = this.codigopostal;
			myCommand.Parameters.Add("@Email", OleDbType.Char , 50).Value = this.email;
			myCommand.Parameters.Add("@RutaDespId", OleDbType.Char , 30).Value = this.rutadespid;
			myCommand.Parameters.Add("@Moneda", OleDbType.SmallInt).Value = this.moneda;
			myCommand.Parameters.Add("@TipoDocumento", OleDbType.Integer).Value = this.tipodocumento;
			myCommand.Parameters.Add("@NumeroDocto", OleDbType.Char , 20).Value = this.numerodocto;
			myCommand.Parameters.Add("@FechaDocto", OleDbType.Date).Value = this.fechadocto;
			myCommand.Parameters.Add("@TipoReferencia", OleDbType.Char , 20).Value = this.tiporeferencia;
			myCommand.Parameters.Add("@NumeroReferencia", OleDbType.Char , 20).Value = this.numeroreferencia;
			myCommand.Parameters.Add("@FechaReferencia", OleDbType.Date).Value = this.fechareferencia;
			myCommand.Parameters.Add("@CrossDock", OleDbType.TinyInt).Value = this.crossdock;
			myCommand.Parameters.Add("@IndCodN", OleDbType.TinyInt).Value = this.indcodn;
			myCommand.Parameters.Add("@PorcTolerancia", OleDbType.Decimal).Value = this.porctolerancia;
			myCommand.Parameters.Add("@Glosa", OleDbType.Char , -1).Value = this.glosa;
			myCommand.Parameters.Add("@FolioRel", OleDbType.Integer).Value = this.foliorel;
			myCommand.Parameters.Add("@FechaAct", OleDbType.Date).Value = this.fechaact;
			myCommand.Parameters.Add("@UsuarioAct", OleDbType.Char , 15).Value = this.usuarioact;
			myCommand.Parameters.Add("@FechaAprob", OleDbType.Date).Value = this.fechaaprob;
			myCommand.Parameters.Add("@UsuarioAprob", OleDbType.Char , 15).Value = this.usuarioaprob;
			myCommand.Parameters.Add("@FechaCierre", OleDbType.Date).Value = this.fechacierre;
			myCommand.Parameters.Add("@UsuarioCierre", OleDbType.Char , 15).Value = this.usuariocierre;
			myCommand.Parameters.Add("@Estado", OleDbType.SmallInt).Value = this.estado;
			myCommand.Parameters.Add("@FechaEstado", OleDbType.Date).Value = this.fechaestado;
			myCommand.Parameters.Add("@Archivo", OleDbType.Char , 100).Value = this.archivo;
			myCommand.Parameters.Add("@Fecha1", OleDbType.Date).Value = this.fecha1;
			myCommand.Parameters.Add("@Fecha2", OleDbType.Date).Value = this.fecha2;
			myCommand.Parameters.Add("@Fecha3", OleDbType.Date).Value = this.fecha3;
			myCommand.Parameters.Add("@Dato1", OleDbType.Char , 250).Value = this.dato1;
			myCommand.Parameters.Add("@Dato2", OleDbType.Char , 250).Value = this.dato2;
			myCommand.Parameters.Add("@Dato3", OleDbType.Char , 250).Value = this.dato3;
			myCommand.Parameters.Add("@Valor1", OleDbType.Decimal).Value = this.valor1;
			myCommand.Parameters.Add("@Valor2", OleDbType.Decimal).Value = this.valor2;
			myCommand.Parameters.Add("@Valor3", OleDbType.Decimal).Value = this.valor3;
            myCommand.Parameters.Add("@BodegaRecep", OleDbType.Integer).Value = this.BodegaRecep;
			try
			{
			//REVISAR
                OleDbParameter identity1 = new OleDbParameter("@SolDespId", OleDbType.Numeric);
			identity1.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(identity1);
				myConnection.Open();

				myCommand.ExecuteNonQuery();
				this.mySolDespId = int.Parse(identity1.Value.ToString());//REVISAR
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
				myConnection.Close();
				myConnection.Dispose();
			}
				return result;
	    }
		public bool Update()
		{
			bool result;
			OleDbConnection myConnection = DB.getOleDbConnection();
			OleDbCommand myCommand = new OleDbCommand("sp_upd_SolImportDespacho", myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = this.soldespid;
			myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = this.empid;
			myCommand.Parameters.Add("@FechaDigitacion", OleDbType.Date).Value = this.fechadigitacion;
			myCommand.Parameters.Add("@UsuarioDig", OleDbType.Char , 15).Value = this.usuariodig;
			myCommand.Parameters.Add("@FechaProceso", OleDbType.Date).Value = this.fechaproceso;
			myCommand.Parameters.Add("@TipoTransporte", OleDbType.SmallInt).Value = this.tipotransporte;
			myCommand.Parameters.Add("@TipoSolicitud", OleDbType.SmallInt).Value = this.tiposolicitud;
			myCommand.Parameters.Add("@CodigoBodega", OleDbType.Integer).Value = this.codigobodega;
			myCommand.Parameters.Add("@CodigoUbicacion", OleDbType.Char , 20).Value = this.codigoubicacion;
			myCommand.Parameters.Add("@Comprador", OleDbType.Char , 50).Value = this.comprador;
			myCommand.Parameters.Add("@RutCliente", OleDbType.Char , 12).Value = this.rutcliente;
			myCommand.Parameters.Add("@RazonSocial", OleDbType.Char , 50).Value = this.razonsocial;
			myCommand.Parameters.Add("@Contacto", OleDbType.Char , 50).Value = this.contacto;
			myCommand.Parameters.Add("@Vendedor", OleDbType.Char , 50).Value = this.vendedor;
			myCommand.Parameters.Add("@Pais", OleDbType.Char , 50).Value = this.pais;
			myCommand.Parameters.Add("@Region", OleDbType.SmallInt).Value = this.region;
			myCommand.Parameters.Add("@Ciudad", OleDbType.SmallInt).Value = this.ciudad;
			myCommand.Parameters.Add("@Comuna", OleDbType.SmallInt).Value = this.comuna;
			myCommand.Parameters.Add("@Direccion", OleDbType.Char , 100).Value = this.direccion;
			myCommand.Parameters.Add("@CodigoPostal", OleDbType.Char , 20).Value = this.codigopostal;
			myCommand.Parameters.Add("@Email", OleDbType.Char , 50).Value = this.email;
			myCommand.Parameters.Add("@RutaDespId", OleDbType.Char , 30).Value = this.rutadespid;
			myCommand.Parameters.Add("@Moneda", OleDbType.SmallInt).Value = this.moneda;
			myCommand.Parameters.Add("@TipoDocumento", OleDbType.Integer).Value = this.tipodocumento;
			myCommand.Parameters.Add("@NumeroDocto", OleDbType.Char , 20).Value = this.numerodocto;
			myCommand.Parameters.Add("@FechaDocto", OleDbType.Date).Value = this.fechadocto;
			myCommand.Parameters.Add("@TipoReferencia", OleDbType.Char , 20).Value = this.tiporeferencia;
			myCommand.Parameters.Add("@NumeroReferencia", OleDbType.Char , 20).Value = this.numeroreferencia;
			myCommand.Parameters.Add("@FechaReferencia", OleDbType.Date).Value = this.fechareferencia;
			myCommand.Parameters.Add("@CrossDock", OleDbType.TinyInt).Value = this.crossdock;
			myCommand.Parameters.Add("@IndCodN", OleDbType.TinyInt).Value = this.indcodn;
			myCommand.Parameters.Add("@PorcTolerancia", OleDbType.Decimal).Value = this.porctolerancia;
			myCommand.Parameters.Add("@Glosa", OleDbType.Char , -1).Value = this.glosa;
			myCommand.Parameters.Add("@FolioRel", OleDbType.Integer).Value = this.foliorel;
			myCommand.Parameters.Add("@FechaAct", OleDbType.Date).Value = this.fechaact;
			myCommand.Parameters.Add("@UsuarioAct", OleDbType.Char , 15).Value = this.usuarioact;
			myCommand.Parameters.Add("@FechaAprob", OleDbType.Date).Value = this.fechaaprob;
			myCommand.Parameters.Add("@UsuarioAprob", OleDbType.Char , 15).Value = this.usuarioaprob;
			myCommand.Parameters.Add("@FechaCierre", OleDbType.Date).Value = this.fechacierre;
			myCommand.Parameters.Add("@UsuarioCierre", OleDbType.Char , 15).Value = this.usuariocierre;
			myCommand.Parameters.Add("@Estado", OleDbType.SmallInt).Value = this.estado;
			myCommand.Parameters.Add("@FechaEstado", OleDbType.Date).Value = this.fechaestado;
			myCommand.Parameters.Add("@Archivo", OleDbType.Char , 100).Value = this.archivo;
			myCommand.Parameters.Add("@Fecha1", OleDbType.Date).Value = this.fecha1;
			myCommand.Parameters.Add("@Fecha2", OleDbType.Date).Value = this.fecha2;
			myCommand.Parameters.Add("@Fecha3", OleDbType.Date).Value = this.fecha3;
			myCommand.Parameters.Add("@Dato1", OleDbType.Char , 250).Value = this.dato1;
			myCommand.Parameters.Add("@Dato2", OleDbType.Char , 250).Value = this.dato2;
			myCommand.Parameters.Add("@Dato3", OleDbType.Char , 250).Value = this.dato3;
			myCommand.Parameters.Add("@Valor1", OleDbType.Decimal).Value = this.valor1;
			myCommand.Parameters.Add("@Valor2", OleDbType.Decimal).Value = this.valor2;
			myCommand.Parameters.Add("@Valor3", OleDbType.Decimal).Value = this.valor3;
            myCommand.Parameters.Add("@BodegaRecep", OleDbType.Integer).Value = this.BodegaRecep;
			try
			{
				myConnection.Open();
				myCommand.ExecuteNonQuery();
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
				myConnection.Close();
				myConnection.Dispose();
			}
				return result;
			}
        public static bool Delete(decimal SolDespId, string usuario)
		{
			bool result;
			OleDbConnection myConnection = DB.getOleDbConnection();
			OleDbCommand myCommand = new OleDbCommand("sp_del_SolImportDespacho", myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			try
			{
				myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = SolDespId;
                myCommand.Parameters.Add("@Usuario", OleDbType.Char, 15).Value = usuario;

                OleDbParameter mensaje = new OleDbParameter("@Mensaje", OleDbType.VarChar, 1000);
                mensaje.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(mensaje);

				myConnection.Open();
				myCommand.ExecuteNonQuery();

                if (!mensaje.Value.ToString().Trim().Equals(""))
                {
                    throw new Exception(mensaje.Value.ToString().Trim());
                }

				result = true;
			}
			catch (Exception ex) 
			{
				result = false;
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
				myConnection.Close();
			}
			return result;
		}
		public bool Save() 
		{
			try
			{
				if (L_SolImportDespacho.Exists(this.soldespid))
				{
					return this.Update();
				}
				else
				{
					return this.Create();
				}
			}
			catch (Exception e) 
			{
				throw new Exception(e.Message.ToString());
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