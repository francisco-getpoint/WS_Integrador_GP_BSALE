using Administracion.Classes.global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;



namespace WS_Integrador.Classes.model
{
    public partial class InfF_Generador : Component
    {
        public InfF_Generador()
        {
            InitializeComponent();
        }

        public InfF_Generador(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public static string InsertarRegistro_ado(string sql1, string sql2)
        {
            //insertas los registros en base local
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string result;
            try
            {
                cn.ConnectionString = "workstation id=DESARROL-73AD64;packet size=4096;user id=sa;password=@Windows2008;data source=192.168.100.113;persist security info=False;initial catalog=Getpoint_2014";
                //cn.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
                cn.Open();

                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql1 + " values " + sql2;
                    cmd.ExecuteNonQuery();
                }
                result = "";

            }
            catch (Exception ex)
            {
                result = "0;Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return result;
        }
        public static string InsertarRegistro_OleDb(string BD_GETPOINT, string sql1, string sql2)
        {
            string consulta = sql1 + " values " + sql2;

            OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);

            OleDbCommand myCommand = new OleDbCommand(consulta,myConnection);
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
        public static string ValDoctoIntegrado(string texto1, string texto2, string texto3, string texto4)
        {
            //OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_GP_INT_ValDoctoIntegrado", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@Texto1", OleDbType.VarChar, 100).Value = texto1;
            myCommand.Parameters.Add("@Texto2", OleDbType.VarChar, 100).Value = texto2;
            myCommand.Parameters.Add("@Texto3", OleDbType.VarChar, 100).Value = texto3;
            myCommand.Parameters.Add("@Texto4", OleDbType.VarChar, 100).Value = texto4;

            string result;
            try
            {
                OleDbParameter pGeneracion = new OleDbParameter("@Existe", OleDbType.Numeric);
                pGeneracion.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(pGeneracion);

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = pGeneracion.Value.ToString();
            }
            catch (Exception ex)
            {
                result = "0";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static string ValEjecutaProceso(string texto1)
        {
            //OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_GP_INT_ValEjecutaProceso", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@Texto1", OleDbType.VarChar, 100).Value = texto1;


            string result;
            try
            {
                OleDbParameter pGeneracion = new OleDbParameter("@Resultado", OleDbType.Numeric);
                pGeneracion.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(pGeneracion);

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = pGeneracion.Value.ToString();
            }
            catch (Exception ex)
            {
                result = "0";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static string ValEjecutaProcesoOffSet()
        {
            //OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_GP_INT_BsalePedidosOffSet", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            //myCommand.Parameters.Add("@Texto1", OleDbType.VarChar, 100).Value = texto1;


            string result;
            try
            {
                OleDbParameter pGeneracion = new OleDbParameter("@Resultado", OleDbType.Numeric);
                pGeneracion.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(pGeneracion);

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = pGeneracion.Value.ToString();
            }
            catch (Exception ex)
            {
                result = "0";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static DataSet ValEjecutaWebHooks()
        {

            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_WebHook_Nuevos_DocumentBSale", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            //myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empid;
            //myCommand.Parameters.Add("@UserName", OleDbType.Char, 15).Value = username;
            //myCommand.Parameters.Add("@Periodo", OleDbType.Integer).Value = periodo;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_WebHook_Nuevos_DocumentBSale");
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
        public static string ActualizaOffSet(int empid ,string  username, string contador)
        {

            OleDbConnection myConnection = DB.getConnection();

            OleDbCommand myCommand = new OleDbCommand("Sp_in_LogProcesos", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@Empid", OleDbType.Integer).Value = empid;
            myCommand.Parameters.Add("@UserName", OleDbType.VarChar, 15).Value = username;
            myCommand.Parameters.Add("@Contador", OleDbType.Integer).Value = contador;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "0;Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static string ProcesaArchivo(string BD_GETPOINT, string Archivo, string Usuario, string Fecha)
        {
            DateTime dtFechaEnvio = Convert.ToDateTime(Fecha);

            OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            
            OleDbCommand myCommand = new OleDbCommand("Sp_Proc_Integracion", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@Archivo", OleDbType.VarChar,100).Value = Archivo;
            myCommand.Parameters.Add("@UserName", OleDbType.VarChar,50).Value = Usuario;
            myCommand.Parameters.Add("@Fecha", OleDbType.Date).Value = dtFechaEnvio;
            
            
            string result;
            try
            {
                OleDbParameter pGeneracion = new OleDbParameter("@Generacion", OleDbType.Numeric);
                pGeneracion.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(pGeneracion);

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = pGeneracion.Value.ToString() + ";OK";
            }
            catch (Exception ex)
            {
                result = "0;Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static string ActualizaEstadoARTERP(string BD_GETPOINT, string TareaId)
        {

            OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            OleDbCommand myCommand = new OleDbCommand("sp_upd_CambEstado_ART_ERP", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@NumeroReferencia", OleDbType.VarChar, 100).Value = TareaId.Trim();


            string result;
            try
            {

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static string ActualizaEstadoERP(string BD_GETPOINT, string recepcion, string colapickid , string guideRef)
        {

            //OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_CambEstado_INT", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@RecepcionId", OleDbType.Numeric).Value = recepcion;
            myCommand.Parameters.Add("@ColaPickId", OleDbType.Numeric).Value = colapickid;
            myCommand.Parameters.Add("@URLRef", OleDbType.VarChar,250).Value = guideRef;

            string result;
            try
            {

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static string ActualizaEstadoWebhook(string id, string estado, decimal document)
        {

            //OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_WebHook", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@Id", OleDbType.Numeric).Value = id;
            myCommand.Parameters.Add("@Estado", OleDbType.Numeric).Value = estado;
            myCommand.Parameters.Add("@Document", OleDbType.Numeric).Value = document;

            string result;
            try
            {

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static string ActualizaPickingRechazado(string BD_GETPOINT, string colapickid)
        {

            //OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_CambEstadoPicking_INT", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@ColaPickId	", OleDbType.Numeric).Value = colapickid;

            string result;
            try
            {

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        //*** pendiente de ver algun campo o crear***
        public static string GuardaPickingErrorBSALE(string colapickid, string MensajeError)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_INT_GuardaPickingErrorBSALE", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@ColaPickId", OleDbType.Numeric).Value = colapickid;
            myCommand.Parameters.Add("@MensajeError", OleDbType.VarChar).Value = MensajeError;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static string ActualizaEstadoTarea(string BD_GETPOINT, string TareaId)
        {

            OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            OleDbCommand myCommand = new OleDbCommand("Sp_Upd_Tarea_Estado", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@TareaId", OleDbType.VarChar, 100).Value = int.Parse(TareaId.Trim());


            string result;
            try
            {

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static string ActualizaEstadoCola(string BD_GETPOINT, string ColaPickId)
        {

            OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            OleDbCommand myCommand = new OleDbCommand("sp_upd_ColaPicking_Estado", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@ColaPickId", OleDbType.VarChar, 100).Value = int.Parse(ColaPickId.Trim());


            string result;
            try
            {

                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static DataSet ShowList_SDD(string BD_GETPOINT)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            //OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);

            OleDbCommand myCommand = new OleDbCommand("sp_sel_SDD_Generadas", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            //myCommand.Parameters.Add("@SortField", OleDbType.Char, 50).Value = sortField;
            //myCommand.Parameters.Add("@sortDirection", OleDbType.Char, 50).Value = sortDirection;
            //myCommand.Parameters.Add("@FilterField", OleDbType.Char, 50).Value = filterField;
            //myCommand.Parameters.Add("@FilterValue", OleDbType.Char, 50).Value = filterValue;
            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_SDR_Confirmadas");
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
        public static DataSet ShowList_ART(string BD_GETPOINT)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            //OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);

            OleDbCommand myCommand = new OleDbCommand("sp_sel_ART_Generados", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            //myCommand.Parameters.Add("@SortField", OleDbType.Char, 50).Value = sortField;
            //myCommand.Parameters.Add("@sortDirection", OleDbType.Char, 50).Value = sortDirection;
            //myCommand.Parameters.Add("@FilterField", OleDbType.Char, 50).Value = filterField;
            //myCommand.Parameters.Add("@FilterValue", OleDbType.Char, 50).Value = filterValue;
            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_ART_Confirmados");
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
        public static DataSet ShowList_SALDO(string BD_GETPOINT)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            //OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);

            OleDbCommand myCommand = new OleDbCommand("sp_sel_SALDO", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_SALDO");
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
        public static DataSet ShowList_SRD()
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getOleDbConnection();

            OleDbCommand myCommand = new OleDbCommand("sp_sel_SDR_Confirmadas", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_SDR_Confirmadas");
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
        public static DataSet ShowList_SDD()
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getOleDbConnection();

            OleDbCommand myCommand = new OleDbCommand("sp_sel_SDD_Confirmadas", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_SDD_Confirmadas");
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
        public static DataSet ShowList_SRDConfirmadas(string BD_GETPOINT)
        {
            DataSet myDataSet = new DataSet();
            //OleDbConnection myConnection = DB.getConnection();
            OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);

            OleDbCommand myCommand = new OleDbCommand("sp_sel_SDR_Confirmadas", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            //myCommand.Parameters.Add("@SortField", OleDbType.Char, 50).Value = sortField;
            //myCommand.Parameters.Add("@sortDirection", OleDbType.Char, 50).Value = sortDirection;
            //myCommand.Parameters.Add("@FilterField", OleDbType.Char, 50).Value = filterField;
            //myCommand.Parameters.Add("@FilterValue", OleDbType.Char, 50).Value = filterValue;
            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_SDR_Confirmadas");
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
        public static DataSet ShowList_SDDConfirmadas(string BD_GETPOINT)
        {
            DataSet myDataSet = new DataSet();
            //OleDbConnection myConnection = DB.getConnection();
            OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);

            OleDbCommand myCommand = new OleDbCommand("sp_sel_SDD_Confirmadas", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = empId;
            //myCommand.Parameters.Add("@SortField", OleDbType.Char, 50).Value = sortField;
            //myCommand.Parameters.Add("@sortDirection", OleDbType.Char, 50).Value = sortDirection;
            //myCommand.Parameters.Add("@FilterField", OleDbType.Char, 50).Value = filterField;
            //myCommand.Parameters.Add("@FilterValue", OleDbType.Char, 50).Value = filterValue;
            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_SDD_Confirmadas");
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

        public static DataSet ShowList_IntegraConfirmacionesJson(int EmpId,string NombreProceso)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getOleDbConnection();

            OleDbCommand myCommand = new OleDbCommand("sp_sel_API_IntegraConfirmacionesJson", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = EmpId;
            myCommand.Parameters.Add("@NombreProceso", OleDbType.VarChar).Value = NombreProceso;
            myCommand.Parameters.Add("@Limit", OleDbType.Integer).Value = 100;
            myCommand.Parameters.Add("@Rowset", OleDbType.Integer).Value = 0;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_API_IntegraConfirmacionesJson");
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

        public static DataSet ShowList_IntegraConfirmacionesJson_Headers(int EmpId, string NombreProceso,int TipoParam)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getOleDbConnection();

            OleDbCommand myCommand = new OleDbCommand("sp_sel_INT_EndPointHeaders", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = EmpId;
            myCommand.Parameters.Add("@NombreProceso", OleDbType.VarChar).Value = NombreProceso;
            myCommand.Parameters.Add("@TipoParam", OleDbType.VarChar).Value = TipoParam;
            myCommand.Parameters.Add("@Limit", OleDbType.Integer).Value = 100;
            myCommand.Parameters.Add("@Rowset", OleDbType.Integer).Value = 0;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_API_IntegraConfirmacionesJson_Headers");
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

        //Carga tabla de integraciones con Articulos sin Id de Woocommerce ----------------
        public static string ShowList_IntegraConfirmacionesJson_SinReferencia()
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getOleDbConnection();

            OleDbCommand myCommand = new OleDbCommand("sp_proc_INT_ArticulosSinRefEcomm", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        public static string ActualizaItemReferenciaEcommerce(int Empid,string CodigoArticulo,int CodigoDetCategoria,int Id_Producto_Ecomm, int Id_Producto_Ecomm2)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_INT_ArticulosCategoriasRefEComm", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@Empid", OleDbType.Numeric).Value = Empid;
            myCommand.Parameters.Add("@CodigoArticulo", OleDbType.VarChar,20).Value = CodigoArticulo;
            myCommand.Parameters.Add("@CodigoDetCat", OleDbType.Numeric).Value = CodigoDetCategoria;
            myCommand.Parameters.Add("@IdEcomm", OleDbType.Numeric).Value = Id_Producto_Ecomm;
            myCommand.Parameters.Add("@IdEcomm2", OleDbType.Numeric).Value = Id_Producto_Ecomm2;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        public static string IntegraStockWMSToEcomm(string NombreProceso)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_proc_INT_IntegraStockWMSToEcomm", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@NombreProceso", OleDbType.VarChar, 20).Value = NombreProceso;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        //Marca estado de cabecera de integracion es estado procesado
        public static string ActualizaIntegraConfirmaciones(int Intid)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_API_IntegraConfirmaciones", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@IntId", OleDbType.Numeric).Value = Intid;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        //Marca estado de los detalles de la integracion, si todos los id detalle asociados a un id cabecera estan marcados, marca la cabecera como procesada
        public static string ActualizaIntegraConfirmacionesDet(int Estado,int Intid,int IdDet)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_API_IntegraConfirmacionesDet", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@Estado", OleDbType.Numeric).Value = Estado;
            myCommand.Parameters.Add("@IntId", OleDbType.Numeric).Value = Intid;
            myCommand.Parameters.Add("@IdDet", OleDbType.Numeric).Value = IdDet;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        //Cambia estado de cabecera de integracion 
        public static string ActualizaEstadoIntegraConfirmaciones(int Id, int Estado)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_API_EstadoIntegraConfirmaciones", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@Id", OleDbType.Numeric).Value = Id;
            myCommand.Parameters.Add("@Estado", OleDbType.Numeric).Value = Estado;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        //Guarda Referencia al Envio generado en el Ecommerce en la Solicitud de Despacho
        public static string ActualizaSolDespachoReferenciaEnvioEcommerce(int SolDespId, string Dato4, string ZPL, string RutaPDF)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_INT_SolDespachoRefEnvioToEcomm", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@SolDespId", OleDbType.Numeric).Value = SolDespId;
            myCommand.Parameters.Add("@Dato4", OleDbType.VarChar,250).Value = Dato4;
            myCommand.Parameters.Add("@ZPL", OleDbType.VarChar).Value = ZPL;
            myCommand.Parameters.Add("@RutaPDF", OleDbType.VarChar,250).Value = RutaPDF;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
        public static DataSet ShowList_ConfigEsp(int inEmpId, string stConfig)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_sel_ConfigEsp", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = inEmpId;
            myCommand.Parameters.Add("@Config", OleDbType.Char, 50).Value = stConfig;
            //myCommand.Parameters.Add("@sortDirection", OleDbType.Char, 50).Value = sortDirection;
            //myCommand.Parameters.Add("@FilterField", OleDbType.Char, 50).Value = filterField;
            //myCommand.Parameters.Add("@FilterValue", OleDbType.Char, 50).Value = filterValue;
            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_ConfigEsp");
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
        public static bool RenombraArchivoTablaLog(string BD_GETPOINT, string Archivo)
        {


            OleDbConnection myConnection = DB.getOleDbConnection2(BD_GETPOINT);
            
            
            OleDbCommand myCommand = new OleDbCommand("sp_upd_NomArchivo_Integracion", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@Archivo", OleDbType.VarChar, 100).Value = Archivo;


            bool result;
            try
            {
                myCommand.CommandTimeout = 99999;
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

        //Guarda registro en tabla L_Integraciones
        public static string Inserta_API_Integracion(string Key, int EmpId, string NombreArchivo, string TXT)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_in_API_Integracion", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@Key", OleDbType.VarChar).Value = Key;
            myCommand.Parameters.Add("@Empid", OleDbType.Integer).Value = EmpId;
            myCommand.Parameters.Add("@NombreArchivo", OleDbType.VarChar).Value = NombreArchivo;
            myCommand.Parameters.Add("@TXT", OleDbType.VarChar).Value = TXT;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        //Guarda registro en tabla L_Integraciones campo a campo
        public static string Inserta_Integraciones(string Archivo, string UserName,DateTime FechaProceso,int Linea, string Texto1 = "", string Texto2 = "", string Texto3 = "", string Texto4 = "", string Texto5 = "", string Texto6 = "", string Texto7 = "", string Texto8 = "", string Texto9 = "", string Texto10 = "", string Texto11 = "", string Texto12 = "", string Texto13 = "", string Texto14 = "", string Texto15 = "", string Texto16 = "", string Texto17 = "", string Texto18 = "", string Texto19 = "", string Texto20 = "", string Texto21 = "", string Texto22 = "", string Texto23 = "", string Texto24 = "", string Texto25 = "", string Texto26 = "", string Texto27 = "", string Texto28 = "", string Texto29 = "", string Texto30 = "", string Texto31 = "", string Texto32 = "", string Texto33 = "", string Texto34 = "", string Texto35 = "", string Texto36 = "", string Texto37 = "", string Texto38 = "", string Texto39 = "", string Texto40 = "", string Texto41 = "", string Texto42 = "", string Texto43 = "", string Texto44 = "", string Texto45 = "", string Texto46 = "", string Texto47 = "", string Texto48 = "", string Texto49 = "", string Texto50 = "", string Texto51 = "", string Texto52 = "", string Texto53 = "", string Texto54 = "", string Texto55 = "", string Texto56 = "", string Texto57 = "", string Texto58 = "", string Texto59 = "", string Texto60 = "", string Texto61 = "", string Texto62 = "", string Texto63 = "", string Texto64 = "", string Texto65 = "", string Texto66 = "", string Texto67 = "", string Texto68 = "", string Texto69 = "", string Texto70 = "", string Texto71 = "", string Texto72 = "", string Texto73 = "", string Texto74 = "", string Texto75 = "", string Texto76 = "", string Texto77 = "", string Texto78 = "", string Texto79 = "", string Texto80 = "", string Texto81 = "", string Texto82 = "", string Texto83 = "",string Texto84 = "", string Texto85 = "", string Texto86 = "", string Texto87 = "", string Texto88 = "", string Texto89 = "", string Texto90 = "", string Texto91 = "", string Texto92 = "",string Texto93 = "", string Texto94 = "", string Texto95 = "", string Texto96 = "", string Texto97 = "", string Texto98 = "", string Texto99 = "", string Texto100 = "")
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_in_INT_Integraciones", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@Archivo", OleDbType.VarChar).Value = Archivo;
            myCommand.Parameters.Add("@UserName", OleDbType.VarChar).Value = UserName;
            myCommand.Parameters.Add("@FechaProceso", OleDbType.Date).Value = FechaProceso;
            myCommand.Parameters.Add("@Linea", OleDbType.Integer).Value = Linea;
            myCommand.Parameters.Add("@Texto1", OleDbType.VarChar).Value = Texto1;
            myCommand.Parameters.Add("@Texto2", OleDbType.VarChar).Value = Texto2;
            myCommand.Parameters.Add("@Texto3", OleDbType.VarChar).Value = Texto3;
            myCommand.Parameters.Add("@Texto4", OleDbType.VarChar).Value = Texto4;
            myCommand.Parameters.Add("@Texto5", OleDbType.VarChar).Value = Texto5;
            myCommand.Parameters.Add("@Texto6", OleDbType.VarChar).Value = Texto6;
            myCommand.Parameters.Add("@Texto7", OleDbType.VarChar).Value = Texto7;
            myCommand.Parameters.Add("@Texto8", OleDbType.VarChar).Value = Texto8;
            myCommand.Parameters.Add("@Texto9", OleDbType.VarChar).Value = Texto9;
            myCommand.Parameters.Add("@Texto10", OleDbType.VarChar).Value = Texto10;
            myCommand.Parameters.Add("@Texto11", OleDbType.VarChar).Value = Texto11;
            myCommand.Parameters.Add("@Texto12", OleDbType.VarChar).Value = Texto12;
            myCommand.Parameters.Add("@Texto13", OleDbType.VarChar).Value = Texto13;
            myCommand.Parameters.Add("@Texto14", OleDbType.VarChar).Value = Texto14;
            myCommand.Parameters.Add("@Texto15", OleDbType.VarChar).Value = Texto15;
            myCommand.Parameters.Add("@Texto16", OleDbType.VarChar).Value = Texto16;
            myCommand.Parameters.Add("@Texto17", OleDbType.VarChar).Value = Texto17;
            myCommand.Parameters.Add("@Texto18", OleDbType.VarChar).Value = Texto18;
            myCommand.Parameters.Add("@Texto19", OleDbType.VarChar).Value = Texto19;
            myCommand.Parameters.Add("@Texto20", OleDbType.VarChar).Value = Texto20;
            myCommand.Parameters.Add("@Texto21", OleDbType.VarChar).Value = Texto21;
            myCommand.Parameters.Add("@Texto22", OleDbType.VarChar).Value = Texto22;
            myCommand.Parameters.Add("@Texto23", OleDbType.VarChar).Value = Texto23;
            myCommand.Parameters.Add("@Texto24", OleDbType.VarChar).Value = Texto24;
            myCommand.Parameters.Add("@Texto25", OleDbType.VarChar).Value = Texto25;
            myCommand.Parameters.Add("@Texto26", OleDbType.VarChar).Value = Texto26;
            myCommand.Parameters.Add("@Texto27", OleDbType.VarChar).Value = Texto27;
            myCommand.Parameters.Add("@Texto28", OleDbType.VarChar).Value = Texto28;
            myCommand.Parameters.Add("@Texto29", OleDbType.VarChar).Value = Texto29;
            myCommand.Parameters.Add("@Texto30", OleDbType.VarChar).Value = Texto30;
            myCommand.Parameters.Add("@Texto31", OleDbType.VarChar).Value = Texto31;
            myCommand.Parameters.Add("@Texto32", OleDbType.VarChar).Value = Texto32;
            myCommand.Parameters.Add("@Texto33", OleDbType.VarChar).Value = Texto33;
            myCommand.Parameters.Add("@Texto34", OleDbType.VarChar).Value = Texto34;
            myCommand.Parameters.Add("@Texto35", OleDbType.VarChar).Value = Texto35;
            myCommand.Parameters.Add("@Texto36", OleDbType.VarChar).Value = Texto36;
            myCommand.Parameters.Add("@Texto37", OleDbType.VarChar).Value = Texto37;
            myCommand.Parameters.Add("@Texto38", OleDbType.VarChar).Value = Texto38;
            myCommand.Parameters.Add("@Texto39", OleDbType.VarChar).Value = Texto39;
            myCommand.Parameters.Add("@Texto40", OleDbType.VarChar).Value = Texto40;
            myCommand.Parameters.Add("@Texto41", OleDbType.VarChar).Value = Texto41;
            myCommand.Parameters.Add("@Texto42", OleDbType.VarChar).Value = Texto42;
            myCommand.Parameters.Add("@Texto43", OleDbType.VarChar).Value = Texto43;
            myCommand.Parameters.Add("@Texto44", OleDbType.VarChar).Value = Texto44;
            myCommand.Parameters.Add("@Texto45", OleDbType.VarChar).Value = Texto45;
            myCommand.Parameters.Add("@Texto46", OleDbType.VarChar).Value = Texto46;
            myCommand.Parameters.Add("@Texto47", OleDbType.VarChar).Value = Texto47;
            myCommand.Parameters.Add("@Texto48", OleDbType.VarChar).Value = Texto48;
            myCommand.Parameters.Add("@Texto49", OleDbType.VarChar).Value = Texto49;
            myCommand.Parameters.Add("@Texto50", OleDbType.VarChar).Value = Texto50;
            myCommand.Parameters.Add("@Texto51", OleDbType.VarChar).Value = Texto51;
            myCommand.Parameters.Add("@Texto52", OleDbType.VarChar).Value = Texto52;
            myCommand.Parameters.Add("@Texto53", OleDbType.VarChar).Value = Texto53;
            myCommand.Parameters.Add("@Texto54", OleDbType.VarChar).Value = Texto54;
            myCommand.Parameters.Add("@Texto55", OleDbType.VarChar).Value = Texto55;
            myCommand.Parameters.Add("@Texto56", OleDbType.VarChar).Value = Texto56;
            myCommand.Parameters.Add("@Texto57", OleDbType.VarChar).Value = Texto57;
            myCommand.Parameters.Add("@Texto58", OleDbType.VarChar).Value = Texto58;
            myCommand.Parameters.Add("@Texto59", OleDbType.VarChar).Value = Texto59;
            myCommand.Parameters.Add("@Texto60", OleDbType.VarChar).Value = Texto60;
            myCommand.Parameters.Add("@Texto61", OleDbType.VarChar).Value = Texto61;
            myCommand.Parameters.Add("@Texto62", OleDbType.VarChar).Value = Texto62;
            myCommand.Parameters.Add("@Texto63", OleDbType.VarChar).Value = Texto63;
            myCommand.Parameters.Add("@Texto64", OleDbType.VarChar).Value = Texto64;
            myCommand.Parameters.Add("@Texto65", OleDbType.VarChar).Value = Texto65;
            myCommand.Parameters.Add("@Texto66", OleDbType.VarChar).Value = Texto66;
            myCommand.Parameters.Add("@Texto67", OleDbType.VarChar).Value = Texto67;
            myCommand.Parameters.Add("@Texto68", OleDbType.VarChar).Value = Texto68;
            myCommand.Parameters.Add("@Texto69", OleDbType.VarChar).Value = Texto69;
            myCommand.Parameters.Add("@Texto70", OleDbType.VarChar).Value = Texto70;
            myCommand.Parameters.Add("@Texto71", OleDbType.VarChar).Value = Texto71;
            myCommand.Parameters.Add("@Texto72", OleDbType.VarChar).Value = Texto72;
            myCommand.Parameters.Add("@Texto73", OleDbType.VarChar).Value = Texto73;
            myCommand.Parameters.Add("@Texto74", OleDbType.VarChar).Value = Texto74;
            myCommand.Parameters.Add("@Texto75", OleDbType.VarChar).Value = Texto75;
            myCommand.Parameters.Add("@Texto76", OleDbType.VarChar).Value = Texto76;
            myCommand.Parameters.Add("@Texto77", OleDbType.VarChar).Value = Texto77;
            myCommand.Parameters.Add("@Texto78", OleDbType.VarChar).Value = Texto78;
            myCommand.Parameters.Add("@Texto79", OleDbType.VarChar).Value = Texto79;
            myCommand.Parameters.Add("@Texto80", OleDbType.VarChar).Value = Texto80;
            myCommand.Parameters.Add("@Texto81", OleDbType.VarChar).Value = Texto81;
            myCommand.Parameters.Add("@Texto82", OleDbType.VarChar).Value = Texto82;
            myCommand.Parameters.Add("@Texto83", OleDbType.VarChar).Value = Texto83;
            myCommand.Parameters.Add("@Texto84", OleDbType.VarChar).Value = Texto84;
            myCommand.Parameters.Add("@Texto85", OleDbType.VarChar).Value = Texto85;
            myCommand.Parameters.Add("@Texto86", OleDbType.VarChar).Value = Texto86;
            myCommand.Parameters.Add("@Texto87", OleDbType.VarChar).Value = Texto87;
            myCommand.Parameters.Add("@Texto88", OleDbType.VarChar).Value = Texto88;
            myCommand.Parameters.Add("@Texto89", OleDbType.VarChar).Value = Texto89;
            myCommand.Parameters.Add("@Texto90", OleDbType.VarChar).Value = Texto90;
            myCommand.Parameters.Add("@Texto91", OleDbType.VarChar).Value = Texto91;
            myCommand.Parameters.Add("@Texto92", OleDbType.VarChar).Value = Texto92;
            myCommand.Parameters.Add("@Texto93", OleDbType.VarChar).Value = Texto93;
            myCommand.Parameters.Add("@Texto94", OleDbType.VarChar).Value = Texto94;
            myCommand.Parameters.Add("@Texto95", OleDbType.VarChar).Value = Texto95;
            myCommand.Parameters.Add("@Texto96", OleDbType.VarChar).Value = Texto96;
            myCommand.Parameters.Add("@Texto97", OleDbType.VarChar).Value = Texto97;
            myCommand.Parameters.Add("@Texto98", OleDbType.VarChar).Value = Texto98;
            myCommand.Parameters.Add("@Texto99", OleDbType.VarChar).Value = Texto99;
            myCommand.Parameters.Add("@Texto100", OleDbType.VarChar).Value = Texto100;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        //Lee tabla de parametros de EndPoint y rescata token del dia para Ripley
        public static DataSet LeeTokenRipley(int EmpId)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getOleDbConnection();

            OleDbCommand myCommand = new OleDbCommand("sp_sel_API_TokenRipley", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = EmpId;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_API_TokenRipley");
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

        //Actualiza token obtenido desde la API de Ripley en tabla EmpresaDatos para el ecommerce correspondiente 
        public static string ActualizaTokenRipleyEndPoint(int EmpId, string NombreProceso, string TOKEN_EndPoint)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_upd_API_TokenRipleyEndPoint", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = EmpId;
            myCommand.Parameters.Add("@NombreProceso", OleDbType.VarChar).Value = NombreProceso;
            myCommand.Parameters.Add("@TOKEN_EndPoint", OleDbType.VarChar).Value = TOKEN_EndPoint;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        //Inserta una Orden de Ripley con etiqueta generada en la tabla de integracion para que la tome el proceso de descarga de etiqueta
        public static string IntegraDescargaEtiquetaRipley(int RevisionId)
        {
            OleDbConnection myConnection = DB.getConnection();
            OleDbCommand myCommand = new OleDbCommand("sp_proc_INT_Descarga_Etiqueta_Ripley", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@RevisionId", OleDbType.Integer).Value = RevisionId;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        //Trae url de conexion a una API 
        public static DataSet LeeRutaAPI(int EmpId,string NombreProceso)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getOleDbConnection();

            OleDbCommand myCommand = new OleDbCommand("sp_sel_API_RutaAPI", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = EmpId;
            myCommand.Parameters.Add("@NombreProceso", OleDbType.VarChar).Value = NombreProceso;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_API_RutaAPI");
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

        //Valida si una OT ya se integro al sistema --------------------
        public static DataSet Busca_Integracion_Existente(string Username, string Texto1, string TipoReferencia, string NumeroReferencia)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = DB.getOleDbConnection();

            OleDbCommand myCommand = new OleDbCommand("sp_sel_API_IntegracionExistente", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;                
            myCommand.Parameters.Add("@Username", OleDbType.VarChar).Value = Username;
            myCommand.Parameters.Add("@Texto1", OleDbType.VarChar).Value = Texto1;
            myCommand.Parameters.Add("@TipoReferencia", OleDbType.VarChar).Value = TipoReferencia;
            myCommand.Parameters.Add("@NumeroReferencia", OleDbType.VarChar).Value = NumeroReferencia;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                //myCommand.ExecuteNonQuery();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "sp_sel_API_IntegracionExistente");
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
    }
}
