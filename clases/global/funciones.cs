using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using WS_Integrador_MeLoLLevo.Classes.global;
using System.Configuration;
using System.Web;
using WS_Integrador_MeLoLLevo.Classes.model;


namespace WS_Integrador_MeLoLLevo.Classes.global
{

	public class Funciones
	{				
		public static string FechaServer(int numformatofecha)
		{
			OleDbDataReader myDataReader;
			string sql="";
			string result ="";
		
            //if(ConfigurationSettings.AppSettings["BaseDatos"].ToString()=="Oracle")
            //{
            //    sql ="select To_Char(sysdate,'dd/mm/yyyy')as FecSistema from dual";
            //}
            //else
            //{
				sql ="Select Convert(char,GetDate()," + numformatofecha.ToString()+ ")";		
            //}


			OleDbConnection myConnection = DB.getConnection();
			OleDbCommand myCommand = new OleDbCommand(sql,myConnection);
			myCommand.CommandType=CommandType.Text;
			try
			{								
				myConnection.Open();
				myDataReader = myCommand.ExecuteReader();

				if(myDataReader.Read()) 
				{
					result  = myDataReader.GetString(0).Trim();						
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

			//DateTime fechaserver = DateTime.Parse(result);

			return result;
		}


        public static bool ValidaRut(string rut)
        {
            throw new NotImplementedException();
        }
    }
}
