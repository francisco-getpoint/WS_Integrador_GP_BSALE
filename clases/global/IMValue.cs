using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;

namespace WS_Integrador_MeLoLLevo.Classes.global
{
	/// <summary>
	/// Descripción breve de IMValue.
	/// </summary>
	public class IMValue : System.ComponentModel.Component
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IMValue(System.ComponentModel.IContainer container)
		{
			///
			/// Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
		}

		public IMValue()
		{
			///
			/// Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
			///
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
		}

		/// <summary> 
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Código generado por el Diseñador de componentes
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		public static DataSet showList(string sSQL) 
		{
			DataSet myDataSet = new DataSet();
			OleDbDataAdapter myAdapter = new OleDbDataAdapter();
			OleDbConnection myConnection = DB.getConnection();
			OleDbCommand myCommand = new OleDbCommand(sSQL, myConnection);
			myCommand.CommandType = CommandType.Text;
			try 
			{
				myAdapter.SelectCommand = myCommand;
				myAdapter.Fill(myDataSet);
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
