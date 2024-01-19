using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace GP_LogDll.Classes.global.util
{
	/// <summary>
	/// Descripción breve de IMString.
	/// </summary>
	public class IMString : System.ComponentModel.Component
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IMString(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
			/// </summary>
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			//
		}

		public IMString()
		{
			/// <summary>
			/// Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
			/// </summary>
			InitializeComponent();

			//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			//
		}
		
		public static string GetLastRightOf(string LookFor, string myString)
		{
			int pos;
			pos = myString.LastIndexOf(LookFor);
			return myString.Substring(pos + 1);
		}

		public static string GetIndexOf(string LookFor, string myString)
		{
			int pos;
			pos = myString.IndexOf(LookFor);
			if(pos==0) pos=1;
			return myString.Substring(0, pos);
		}

		#region Component Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
