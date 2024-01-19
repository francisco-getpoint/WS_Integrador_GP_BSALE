using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace GP_LogDll.Classes.global.util
{
	/// <summary>
	/// Descripción breve de IMFile.
	/// </summary>
	public class IMFile : System.ComponentModel.Component
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IMFile(System.ComponentModel.IContainer container)
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

		public IMFile()
		{
			/// <summary>
			/// Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
			/// </summary>
			InitializeComponent();

			//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			//
		}
		
		public static string Upload(string nameFile )
		{
			string imgUploadedName = nameFile;
			string imgNameValue;
			try
			{
				System.Random boolName = new System.Random();
				string strNewName = boolName.Next(1, 1000000).ToString();
				imgNameValue = IMString.GetLastRightOf("\"", imgUploadedName);
				imgNameValue = IMString.GetLastRightOf(".", imgNameValue);
				imgNameValue = "file_" + strNewName + "." + imgNameValue;
			}
			catch (Exception ex) 
			{
				throw new Exception(ex.Message.ToString());
			}
			return imgNameValue;
		}
		public static void Rename(string lastName, string newName)
		{
			File.Move(lastName, newName);
		}

		public static void Delete(string fileName)
		{
			File.Delete(fileName);
		}

		public static string[] GetFiles(string directory) 
		{
			//Obtiene la lista de archivos del directorio segun Path.
			string[] files= Directory.GetFiles(directory);
			//foreach (string i in files) 
			//{
			//	leerArchivo(i);
			//}
			return files;
		}

		public static string[] GetFolders(string directory)
		{
			string[] directorys = Directory.GetDirectories(directory);
			return directorys;
		}

		public static bool ExistDirectory(string folderName)
		{
			return Directory.Exists(folderName);
		}
		public static bool ExistFile(string fileName)
		{
			return File.Exists(fileName);
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
