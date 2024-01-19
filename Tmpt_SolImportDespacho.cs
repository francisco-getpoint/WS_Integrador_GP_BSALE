using System;
 using System.ComponentModel;
 using System.Collections;
 using System.Diagnostics;
 using System.Data;
 using System.Data.OleDb;
 using WS_Integrador_MeLoLLevo.Classes.global;
 
namespace WS_Integrador_MeLoLLevo
{
	public class Tmpt_SolImportDespacho : System.ComponentModel.Component
	{
		private decimal correlativo;
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
		private long bodegarecep;
		private DateTime fecha1;
		private DateTime fecha2;
		private DateTime fecha3;
		private string dato1;
		private string dato2;
		private string dato3;
		private decimal valor1;
		private decimal valor2;
		private decimal valor3;
		private string codigoarticulo;
		private string unidadventa;
		private decimal cantidad;
		private decimal costounitario;
		private decimal kilostotales;
		private decimal porcqa;
		private int maquila;
		private string paletid;
        private DateTime FechaVectoRecep;
        private string NroSerieRecep;
        private int ItemReferencia;

		private System.ComponentModel.Container components = null;

		public Tmpt_SolImportDespacho(System.ComponentModel.IContainer container)
		{
			container.Add(this); 
			InitializeComponent(); 
		}

		public Tmpt_SolImportDespacho()
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

		public Tmpt_SolImportDespacho(decimal correlativo)
		{
			try
			{
				this.ClsLoad(correlativo);
			}
			catch(Exception ex)
			{
			throw new Exception(ex.Message);
			}
		}

		public static Tmpt_SolImportDespacho Get(decimal correlativo)
		{
			Tmpt_SolImportDespacho myTmpt_SolImportDespacho;
			try
			{
				myTmpt_SolImportDespacho = new Tmpt_SolImportDespacho(correlativo);
				return myTmpt_SolImportDespacho;
			}
			catch(Exception ex)
			{
			throw new Exception(ex.Message);
			}
		}

        public Tmpt_SolImportDespacho(decimal correlativo, long empid, DateTime fechadigitacion, string usuariodig, DateTime fechaproceso, int tipotransporte, int tiposolicitud, long codigobodega, string codigoubicacion, string comprador, string rutcliente, string razonsocial, string contacto, string vendedor, string pais, int region, int ciudad, int comuna, string direccion, string codigopostal, string email, string rutadespid, int moneda, long tipodocumento, string numerodocto, DateTime fechadocto, string tiporeferencia, string numeroreferencia, DateTime fechareferencia, int crossdock, int indcodn, decimal porctolerancia, string glosa, long foliorel, DateTime fechaact, string usuarioact, DateTime fechaaprob, string usuarioaprob, DateTime fechacierre, string usuariocierre, int estado, DateTime fechaestado, string archivo, long bodegarecep, DateTime fecha1, DateTime fecha2, DateTime fecha3, string dato1, string dato2, string dato3, decimal valor1, decimal valor2, decimal valor3, string codigoarticulo, string unidadventa, decimal cantidad, decimal costounitario, decimal kilostotales, decimal porcqa, int maquila, string paletid, DateTime FechaVectoRecep, string NroSerieRecep, int ItemReferencia)
		{
			this.correlativo = correlativo;
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
			this.bodegarecep = bodegarecep;
			this.fecha1 = fecha1;
			this.fecha2 = fecha2;
			this.fecha3 = fecha3;
			this.dato1 = dato1;
			this.dato2 = dato2;
			this.dato3 = dato3;
			this.valor1 = valor1;
			this.valor2 = valor2;
			this.valor3 = valor3;
			this.codigoarticulo = codigoarticulo;
			this.unidadventa = unidadventa;
			this.cantidad = cantidad;
			this.costounitario = costounitario;
			this.kilostotales = kilostotales;
			this.porcqa = porcqa;
			this.maquila = maquila;
			this.paletid = paletid;
            this.FechaVectoRecep = FechaVectoRecep;
            this.NroSerieRecep = NroSerieRecep;
            this.ItemReferencia = ItemReferencia;
		}

#region Código generado por el Diseñador de componentes
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}

#endregion

		public bool ClsLoad(decimal Correlativo)
		{
			OleDbDataReader myDataReader; 
			string sql="" ; 
			bool result;
            sql = "Select Correlativo, EmpId, FechaDigitacion, UsuarioDig, FechaProceso, TipoTransporte, TipoSolicitud, CodigoBodega, CodigoUbicacion, Comprador, RutCliente, RazonSocial, Contacto, Vendedor, Pais, Region, Ciudad, Comuna, Direccion, CodigoPostal, Email, RutaDespId, Moneda, TipoDocumento, NumeroDocto, FechaDocto, TipoReferencia, NumeroReferencia, FechaReferencia, CrossDock, IndCodN, PorcTolerancia, Glosa, FolioRel, FechaAct, UsuarioAct, FechaAprob, UsuarioAprob, FechaCierre, UsuarioCierre, Estado, FechaEstado, Archivo, BodegaRecep, Fecha1, Fecha2, Fecha3, Dato1, Dato2, Dato3, Valor1, Valor2, Valor3, CodigoArticulo, UnidadVenta, Cantidad, CostoUnitario, KilosTotales, PorcQA, Maquila, PaletId ,FechaVectoDesp, NroSerieDesp , ItemReferencia";
			sql += " From Tmpt_SolImportDespacho Where Correlativo = ?  ";
			OleDbConnection myConnection = DB.getConnection();
			OleDbCommand myCommand = new OleDbCommand(sql,myConnection);
			myCommand.CommandType=CommandType.Text;
			try
			{
				myCommand.Parameters.Add("Correlativo",OleDbType.Numeric).Value = Correlativo;
				myConnection.Open();
				myDataReader = myCommand.ExecuteReader();
				result=true;
				if (myDataReader.Read()) 
				{
					this.correlativo = decimal.Parse(myDataReader.GetDecimal(0).ToString());
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
					this.bodegarecep = long.Parse(myDataReader.GetInt32(43).ToString());
					this.fecha1 = DateTime.Parse(myDataReader.GetDateTime(44).ToString());
					this.fecha2 = DateTime.Parse(myDataReader.GetDateTime(45).ToString());
					this.fecha3 = DateTime.Parse(myDataReader.GetDateTime(46).ToString());
					this.dato1 = myDataReader.GetString(47);
					this.dato2 = myDataReader.GetString(48);
					this.dato3 = myDataReader.GetString(49);
					this.valor1 = decimal.Parse(myDataReader.GetDecimal(50).ToString());
					this.valor2 = decimal.Parse(myDataReader.GetDecimal(51).ToString());
					this.valor3 = decimal.Parse(myDataReader.GetDecimal(52).ToString());
					this.codigoarticulo = myDataReader.GetString(53);
					this.unidadventa = myDataReader.GetString(54);
					this.cantidad = decimal.Parse(myDataReader.GetDecimal(55).ToString());
					this.costounitario = decimal.Parse(myDataReader.GetDecimal(56).ToString());
					this.kilostotales = decimal.Parse(myDataReader.GetDecimal(57).ToString());
					this.porcqa = decimal.Parse(myDataReader.GetDecimal(58).ToString());
					this.maquila = int.Parse(myDataReader.GetByte(59).ToString());
					this.paletid = myDataReader.GetString(60);
                    this.FechaVectoRecep = DateTime.Parse(myDataReader.GetDateTime(61).ToString());
                    this.NroSerieRecep = myDataReader.GetString(62);
                    this.ItemReferencia = int.Parse(myDataReader.GetString(63).ToString());
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

		public static bool Exists(decimal correlativo)
		{
			try
			{
				return new Tmpt_SolImportDespacho().ClsLoad(correlativo);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public static DataSet ShowList(string sortField, string sortDirection, string filterField, string filterValue)
		{
			DataSet myDataSet = new DataSet();
			OleDbDataAdapter myAdapter = new OleDbDataAdapter();
			string sql="";

			sql = " Select"+ 
			 " Correlativo, " + 
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
			 " BodegaRecep, " + 
			 " Fecha1, " + 
			 " Fecha2, " + 
			 " Fecha3, " + 
			 " Dato1, " + 
			 " Dato2, " + 
			 " Dato3, " + 
			 " Valor1, " + 
			 " Valor2, " + 
			 " Valor3, " + 
			 " CodigoArticulo, " + 
			 " UnidadVenta, " + 
			 " Cantidad, " + 
			 " CostoUnitario, " + 
			 " KilosTotales, " + 
			 " PorcQA, " + 
			 " Maquila, " + 
			 " PaletId, "+
             " FechaVectoRecep, " +
             " NroSerieRecep, " +
             " itemReferencia" +
			" From Tmpt_SolImportDespacho  "+
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
				myAdapter.Fill(myDataSet, "Tmpt_SolImportDespacho");
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


        public static DataSet GeneraProceso(string username)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_proc_ImpSolImportDesp", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@Usuario", OleDbType.Char, 15).Value = username;
            try
            {
                OleDbParameter Generacion = new OleDbParameter("@Generacion", OleDbType.TinyInt);
                Generacion.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(Generacion);
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //ExecuteNonQuery se usa para traer un valor desde la BD
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "Tmpt_SolImportDespacho");
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

        public static DataSet ShowListDocument(int empId, string username)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_OtrosPedidos_SimpliRoute", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            myCommand.Parameters.Add("@Usuario", OleDbType.Char, 15).Value = username;
            //myCommand.Parameters.Add("@SolDespId", OleDbType.Integer).Value = soldespid;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_OtrosPedidos_SimpliRoute");
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

        public static DataSet ShowListDocument(int empId, string usernam, int soldespid)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_SUP_EmisionBoletaPorSDD2", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            myCommand.Parameters.Add("@Usuario", OleDbType.Char, 15).Value = usernam;
            myCommand.Parameters.Add("@SolDespId", OleDbType.Integer).Value = soldespid;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "Tmpt_SolImportDespacho");
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

        public static DataSet ShowList(int empId,string sortField, string sortDirection, string filterField, string filterValue)
		{
			DataSet myDataSet = new DataSet();
			OleDbConnection myConnection = DB.getConnection();
			OleDbCommand myCommand = new OleDbCommand("sp_sel_Tmpt_SolImportDespacho", myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
			myCommand.Parameters.Add("@SortField", OleDbType.Char,50).Value = sortField;
			myCommand.Parameters.Add("@sortDirection", OleDbType.Char,50).Value = sortDirection;
			myCommand.Parameters.Add("@FilterField", OleDbType.Char,50).Value = filterField;
			myCommand.Parameters.Add("@FilterValue", OleDbType.Char,50).Value = filterValue;
			try
			{
			myCommand.CommandTimeout = 9999;
			myConnection.Open();
			//myCommand.ExecuteNonQuery();
			OleDbDataAdapter myAdapter = new OleDbDataAdapter();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"Tmpt_SolImportDespacho");
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

        public static DataSet ShowList_PedidosDoctoLegal(int gEmpId)
        {
            DataSet myDataSet = new DataSet();
            OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            string sql = "";

            sql = "sp_GP_INT_ConfODPDoctoLegal";

            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnection);

            myConnection.Open();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 0;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = gEmpId;


            try
            {
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "ShowList_PedidosDoctoLegal");
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
            public static DataSet ShowList_Conf_Despachos(int gEmpId, string sortField, string sortDirection, string filterField, string filterValue)
        {
            DataSet myDataSet = new DataSet();
            OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            string sql = "";

            sql = "sp_GP_INT_ConfSDD";

            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnection);

            myConnection.Open();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 0;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = gEmpId;


            try
            {
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "ShowList_Conf_Despachos");
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

        public static DataSet ShowList_Conf_Recepciones(int gEmpId, string sortField, string sortDirection, string filterField, string filterValue)
        {
            DataSet myDataSet = new DataSet();
            OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            string sql = "";

            sql = "sp_GP_INT_ConfRDM";

            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnection);

            myConnection.Open();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 0;
            //myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = gEmpId;


            try
            {
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "ShowList_Conf_Despachos");
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
        public static DataSet ShowList_SaldoConsolidado(int gEmpId, string sortField, string sortDirection, string filterField, string filterValue)
        {
            DataSet myDataSet = new DataSet();
            OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            string sql = "";

            sql = "sp_GP_INT_SaldoConsolidado";

            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnection);

            myConnection.Open();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 0;
            //myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = gEmpId;


            try
            {
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "ShowList_Conf_Despachos");
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

        public static string InsertarRegistro_LogIntegraciones(object checkin_time, object checkout_time, string reference, string estado)
        {

            OleDbConnection myConnection = DB.getOleDbConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_in_LogIntegraciones", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = "1";// empid;
            myCommand.Parameters.Add("@UsrCodigo", OleDbType.Char, 50).Value = "";// usuariodig;
            myCommand.Parameters.Add("@FileName", OleDbType.Char, 100).Value = ""; // usuariodig;
            myCommand.Parameters.Add("@NomTransaccion", OleDbType.Char, 100).Value = ""; // usuariodig;
            myCommand.Parameters.Add("@Estado", OleDbType.Char, 50).Value = estado;
            myCommand.Parameters.Add("@DescripLarga", OleDbType.Char, 500).Value = "";
            myCommand.Parameters.Add("@DescripError", OleDbType.Char, 100).Value = "";
            myCommand.Parameters.Add("@NumeroReferencia1", OleDbType.Integer).Value = "0";
            myCommand.Parameters.Add("@NumeroReferencia2", OleDbType.Integer).Value = "0";
            myCommand.Parameters.Add("@Referencia1", OleDbType.Char, 50).Value = "NUMEROREFERENCIA";
            myCommand.Parameters.Add("@Referencia2", OleDbType.Char, 50).Value = reference;
            if (checkin_time != null)
            {
                myCommand.Parameters.Add("@FechaReferencia1", OleDbType.Date).Value = checkin_time;
            }
            else
            {
                myCommand.Parameters.Add("@FechaReferencia1", OleDbType.Date).Value = "01-01-1900";
            }
            if (checkout_time != null)
            {
                myCommand.Parameters.Add("@FechaReferencia2", OleDbType.Date).Value = checkout_time;
            }
            else
            {
                myCommand.Parameters.Add("@FechaReferencia2", OleDbType.Date).Value = "01-01-1900";
            }


            myCommand.Parameters.Add("@TipoTransaccion", OleDbType.Char, 100).Value = "RETORNO_SIPLIROUTE";

            string result;
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "";
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        public static DataSet ShowListRetornoSimpliRoute()
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_ProcesosRetornoSimpliRoute", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            //myCommand.Parameters.Add("@Usuario", OleDbType.Char, 15).Value = username;
            //myCommand.Parameters.Add("@SolDespId", OleDbType.Integer).Value = soldespid;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_ProcesosRetornoSimpliRoute");
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
        public static DataSet ShowList_SaldoMovimimientos(int gEmpId, string sortField, string sortDirection, string filterField, string filterValue)
        {
            DataSet myDataSet = new DataSet();
            OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            string sql = "";

            sql = "sp_GP_INT_SaldosWMS";

            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnection);

            myConnection.Open();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 0;
            //myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = gEmpId;


            try
            {
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "ShowList_Conf_Despachos");
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
            OleDbCommand myCommand = new OleDbCommand("sp_in_Tmpt_SolImportDespacho", myConnection);
 			myCommand.CommandType = CommandType.StoredProcedure;

			//myCommand.Parameters.Add("@Correlativo", OleDbType.Numeric).Value = this.correlativo;
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
			myCommand.Parameters.Add("@Glosa", OleDbType.Char , 8000).Value = this.glosa;
			myCommand.Parameters.Add("@FolioRel", OleDbType.Integer).Value = this.foliorel;
			myCommand.Parameters.Add("@FechaAct", OleDbType.Date).Value = this.fechaact;
			myCommand.Parameters.Add("@UsuarioAct", OleDbType.Char , 15).Value = this.usuarioact;
			myCommand.Parameters.Add("@FechaAprob", OleDbType.Date).Value = this.fechaaprob;
			myCommand.Parameters.Add("@UsuarioAprob", OleDbType.Char , 15).Value = this.usuarioaprob;
			myCommand.Parameters.Add("@FechaCierre", OleDbType.Date).Value = this.fechacierre;
			myCommand.Parameters.Add("@UsuarioCierre", OleDbType.Char , 15).Value = this.usuariocierre;
			myCommand.Parameters.Add("@Estado", OleDbType.SmallInt).Value = this.estado;
			myCommand.Parameters.Add("@FechaEstado", OleDbType.Date).Value = this.fechaestado;
			myCommand.Parameters.Add("@Archivo", OleDbType.Char , 200).Value = this.archivo;
			myCommand.Parameters.Add("@BodegaRecep", OleDbType.Integer).Value = this.bodegarecep;
			myCommand.Parameters.Add("@Fecha1", OleDbType.Date).Value = this.fecha1;
			myCommand.Parameters.Add("@Fecha2", OleDbType.Date).Value = this.fecha2;
			myCommand.Parameters.Add("@Fecha3", OleDbType.Date).Value = this.fecha3;
			myCommand.Parameters.Add("@Dato1", OleDbType.Char , 250).Value = this.dato1;
			myCommand.Parameters.Add("@Dato2", OleDbType.Char , 250).Value = this.dato2;
			myCommand.Parameters.Add("@Dato3", OleDbType.Char , 250).Value = this.dato3;
			myCommand.Parameters.Add("@Valor1", OleDbType.Decimal).Value = this.valor1;
			myCommand.Parameters.Add("@Valor2", OleDbType.Decimal).Value = this.valor2;
			myCommand.Parameters.Add("@Valor3", OleDbType.Decimal).Value = this.valor3;
			myCommand.Parameters.Add("@CodigoArticulo", OleDbType.Char , 20).Value = this.codigoarticulo;
			myCommand.Parameters.Add("@UnidadVenta", OleDbType.Char , 10).Value = this.unidadventa;
			myCommand.Parameters.Add("@Cantidad", OleDbType.Decimal).Value = this.cantidad;
			myCommand.Parameters.Add("@CostoUnitario", OleDbType.Decimal).Value = this.costounitario;
			myCommand.Parameters.Add("@KilosTotales", OleDbType.Numeric).Value = this.kilostotales;
            myCommand.Parameters.Add("@PorcQA", OleDbType.Numeric).Value = this.porcqa;
			myCommand.Parameters.Add("@Maquila", OleDbType.TinyInt).Value = this.maquila;
			myCommand.Parameters.Add("@PaletId", OleDbType.Char , 35).Value = this.paletid;
            myCommand.Parameters.Add("@FechaVectoRecep", OleDbType.Date).Value = this.FechaVectoRecep;
            myCommand.Parameters.Add("@NroSerieRecep", OleDbType.Char, 25).Value = this.NroSerieRecep;
            myCommand.Parameters.Add("@ItemReferencia", OleDbType.Integer).Value = this.ItemReferencia;
            
			try
			{
			//REVISAR
			OleDbParameter identity1 = new OleDbParameter("@Correlativo", OleDbType.Numeric);
			identity1.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(identity1);
				myConnection.Open();

				myCommand.ExecuteNonQuery();
				this.myCorrelativo = int.Parse(identity1.Value.ToString());//REVISAR
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

        public static string InsertarRegistro_OleDb(string BD_GETPOINT, string sql)
        {

            OleDbConnection myConnection = DB.getOleDbConnection();

            OleDbCommand myCommand = new OleDbCommand(sql, myConnection);
            myCommand.CommandType = CommandType.Text;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "";
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

		public static string Inserta_Integraciones_Masivo(string Archivo, string UserName, DateTime FechaProceso, string Datos = "")
		{
			OleDbConnection myConnection = DB.getConnection();
			OleDbCommand myCommand = new OleDbCommand("sp_in_INT_Integraciones_Masivo", myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add("@Archivo", OleDbType.VarChar).Value = Archivo;
			myCommand.Parameters.Add("@UserName", OleDbType.VarChar).Value = UserName;
			myCommand.Parameters.Add("@FechaProceso", OleDbType.Date).Value = FechaProceso;
			myCommand.Parameters.Add("@Datos", OleDbType.VarChar).Value = Datos;

			string resultado;
			try
			{
				myCommand.CommandTimeout = 99999;
				myConnection.Open();
				myCommand.ExecuteNonQuery();
				resultado = "OK";
			}
			catch (Exception ex)
			{
				resultado = "Error";
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
				myConnection.Close();
				myConnection.Dispose();
			}
			return resultado;
		}

		public static DataSet GeneraProceso(string archivo, string username, DateTime fechaproceso)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_proc_Integracion", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                myCommand.Parameters.Add("@Archivo", OleDbType.VarChar).Value = archivo;
                myCommand.Parameters.Add("@UserName", OleDbType.VarChar).Value = username;
                myCommand.Parameters.Add("@FechaProceso", OleDbType.Date).Value = fechaproceso;

                OleDbParameter Generacion = new OleDbParameter("@Generacion", OleDbType.TinyInt);
                Generacion.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(Generacion);

                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_proc_ImpUsuarios");
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
        public bool Update()
		{
			bool result;
			OleDbConnection myConnection = DB.getOleDbConnection();
			OleDbCommand myCommand = new OleDbCommand("sp_upd_Tmpt_SolImportDespacho", myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@Correlativo", OleDbType.Numeric).Value = this.correlativo;
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
			myCommand.Parameters.Add("@Glosa", OleDbType.Char , 8000).Value = this.glosa;
			myCommand.Parameters.Add("@FolioRel", OleDbType.Integer).Value = this.foliorel;
			myCommand.Parameters.Add("@FechaAct", OleDbType.Date).Value = this.fechaact;
			myCommand.Parameters.Add("@UsuarioAct", OleDbType.Char , 15).Value = this.usuarioact;
			myCommand.Parameters.Add("@FechaAprob", OleDbType.Date).Value = this.fechaaprob;
			myCommand.Parameters.Add("@UsuarioAprob", OleDbType.Char , 15).Value = this.usuarioaprob;
			myCommand.Parameters.Add("@FechaCierre", OleDbType.Date).Value = this.fechacierre;
			myCommand.Parameters.Add("@UsuarioCierre", OleDbType.Char , 15).Value = this.usuariocierre;
			myCommand.Parameters.Add("@Estado", OleDbType.SmallInt).Value = this.estado;
			myCommand.Parameters.Add("@FechaEstado", OleDbType.Date).Value = this.fechaestado;
			myCommand.Parameters.Add("@Archivo", OleDbType.Char , 200).Value = this.archivo;
			myCommand.Parameters.Add("@BodegaRecep", OleDbType.Integer).Value = this.bodegarecep;
			myCommand.Parameters.Add("@Fecha1", OleDbType.Date).Value = this.fecha1;
			myCommand.Parameters.Add("@Fecha2", OleDbType.Date).Value = this.fecha2;
			myCommand.Parameters.Add("@Fecha3", OleDbType.Date).Value = this.fecha3;
			myCommand.Parameters.Add("@Dato1", OleDbType.Char , 250).Value = this.dato1;
			myCommand.Parameters.Add("@Dato2", OleDbType.Char , 250).Value = this.dato2;
			myCommand.Parameters.Add("@Dato3", OleDbType.Char , 250).Value = this.dato3;
			myCommand.Parameters.Add("@Valor1", OleDbType.Decimal).Value = this.valor1;
			myCommand.Parameters.Add("@Valor2", OleDbType.Decimal).Value = this.valor2;
			myCommand.Parameters.Add("@Valor3", OleDbType.Decimal).Value = this.valor3;
			myCommand.Parameters.Add("@CodigoArticulo", OleDbType.Char , 20).Value = this.codigoarticulo;
			myCommand.Parameters.Add("@UnidadVenta", OleDbType.Char , 10).Value = this.unidadventa;
			myCommand.Parameters.Add("@Cantidad", OleDbType.Decimal).Value = this.cantidad;
			myCommand.Parameters.Add("@CostoUnitario", OleDbType.Decimal).Value = this.costounitario;
			myCommand.Parameters.Add("@KilosTotales", OleDbType.Numeric).Value = this.kilostotales;
			myCommand.Parameters.Add("@PorcQA", OleDbType.Numeric).Value = this.porcqa;
			myCommand.Parameters.Add("@Maquila", OleDbType.TinyInt).Value = this.maquila;
			myCommand.Parameters.Add("@PaletId", OleDbType.Char , 35).Value = this.paletid;
            myCommand.Parameters.Add("@FechaVectoRecep", OleDbType.Date).Value = this.FechaVectoRecep;
            myCommand.Parameters.Add("@NroSerieRecep", OleDbType.Char, 25).Value = this.NroSerieRecep;
            myCommand.Parameters.Add("@ItemReferencia", OleDbType.Integer).Value = this.ItemReferencia;
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
		public static bool Delete(int empid, string usuario)
		{
			bool result;
			OleDbConnection myConnection = DB.getOleDbConnection();
			OleDbCommand myCommand = new OleDbCommand("sp_del_Tmpt_SolImportDespacho", myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			try
			{
                myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empid;
                myCommand.Parameters.Add("@usuario", OleDbType.Char,15).Value = usuario;
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
			}
			return result;
		}
		public bool Save() 
		{
			try
			{
				if (Tmpt_SolImportDespacho.Exists(this.correlativo))
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
		public decimal myCorrelativo
		{
			get{return correlativo;}
			set{correlativo = value;}
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
		public long myBodegaRecep
		{
			get{return bodegarecep;}
			set{bodegarecep = value;}
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
		public string myCodigoArticulo
		{
			get{return codigoarticulo;}
			set{codigoarticulo = value;}
		}
		public string myUnidadVenta
		{
			get{return unidadventa;}
			set{unidadventa = value;}
		}
		public decimal myCantidad
		{
			get{return cantidad;}
			set{cantidad = value;}
		}
		public decimal myCostoUnitario
		{
			get{return costounitario;}
			set{costounitario = value;}
		}
		public decimal myKilosTotales
		{
			get{return kilostotales;}
			set{kilostotales = value;}
		}
		public decimal myPorcQA
		{
			get{return porcqa;}
			set{porcqa = value;}
		}
		public int myMaquila
		{
			get{return maquila;}
			set{maquila = value;}
		}
		public string myPaletId
		{
			get{return paletid;}
			set{paletid = value;}
		}
        public DateTime myFechaVectoRecep
        {
            get { return FechaVectoRecep; }
            set { FechaVectoRecep = value; }
        }
        public string myNroSerieRecep
        {
            get { return NroSerieRecep; }
            set { NroSerieRecep = value; }
        }
        public int myItemReferencia
        {
            get { return ItemReferencia; }
            set { ItemReferencia = value; }
        }
	}
}