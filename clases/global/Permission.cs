using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace WS_Integrador_MeLoLLevo.Classes.global
{
	/// <summary>
	/// Descripci�n breve de Permission.
	/// </summary>
	public class Permission : System.ComponentModel.Component
	{
		/// <summary>
		/// Variable del dise�ador requerida.
		/// 
		private int Id;
		private string Code;
		private bool Read;
		private bool Write;
		private bool Delete;
		
		public Permission(int id, bool read, bool write, bool delete) 
		{
			try 
			{
				this.Id = id;
				this.Read = read;
				this.Write = write;
				this.Delete = delete;
			}
			catch (Exception e) 
			{
				throw new Exception(e.Message.ToString());
			}
		}
	
		public Permission(string code, bool read, bool write, bool delete) 
		{
			try 
			{
				this.Code = code;
				this.Read = read;
				this.Write = write;
				this.Delete = delete;
			}
			catch (Exception e) 
			{
				throw new Exception(e.Message.ToString());
			}
		}
	
		
		public int MyId 
		{
			get 
			{ 
				return this.Id; 
			}
			set 
			{ 
				this.Id = value;
			}
		}
		public string MyCode 
		{
			get 
			{ 
				return this.Code; 
			}
			set 
			{ 
				this.Code = value;
			}
		}
		
		public bool MyRead
		{
			get 
			{ 
				return this.Read; 
			}
			set 
			{ 
				this.Read = value;
			}
		}

		public bool MyWrite
		{
			get 
			{ 
				return this.Write; 
			}
			set 
			{ 
				this.Write = value;
			}
		}
		public bool MyDelete
		{
			get 
			{ 
				return this.Delete; 
			}
			set 
			{ 
				this.Delete = value;
			}
		}
		
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Permission(System.ComponentModel.IContainer container)
		{
			///
			/// Requerido para la compatibilidad con el Dise�ador de composiciones de clases Windows.Forms
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: agregar c�digo de constructor despu�s de llamar a InitializeComponent
			//
		}

		public Permission()
		{
			///
			/// Requerido para la compatibilidad con el Dise�ador de composiciones de clases Windows.Forms
			///
			InitializeComponent();

			//
			// TODO: agregar c�digo de constructor despu�s de llamar a InitializeComponent
			//
		}

		/// <summary> 
		/// Limpiar los recursos que se est�n utilizando.
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


		#region C�digo generado por el Dise�ador de componentes
		/// <summary>
		/// M�todo necesario para admitir el Dise�ador. No se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
