using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using WS_Integrador_MeLoLLevo.Classes.global;
using WS_Integrador_MeLoLLevo.Classes.enterprise;

namespace WS_Integrador_MeLoLLevo.Classes.global
{
	/// <summary>
	/// Descripción breve de Menu.
	/// </summary>
	public class Menu1 : System.ComponentModel.Component
	{
		/// <summary>
		private int id;
		private string code;
		private ArrayList items = new ArrayList();
		private string text;
		private string desc;
		private string link;
		private string icon;
		private string tipo;
		private bool isRead;
		private bool isWrite;
		private bool isDelete;
		private Hashtable permisos  = new Hashtable();
	
		public Menu1(int id, String code) 
		{	
			this.id = id;	
			this.code = code;
		}
	
		public bool HasChilds() 
		{
			if(this.items.Count==0) 
			{
				return false;
			} 
			else 
			{
				return true;
			}
		}

		public int CountChilds() 
		{
			return this.items.Count;
		}
	
		public void AddSubMenu(Menu1 menu) 
		{
			this.items.Add(menu);
		}
	
		public ArrayList GetItems() 
		{
			return this.items;
		}

		public String GetIcon() 
		{
			return "images/blank.png";
		}
	
		public String GetLink() 
		{
			return this.myLink + "?Section=" + this.code.ToLower();
		}
	
		public void setPermisos(bool[] arg) 
		{
			this.isRead = arg[0];
			this.isWrite = arg[1];
			this.isDelete = arg[2];
		}
	
		public void setPermisos(int Id, Permission permission) 
		{
			this.permisos.Add(Id, permission);
		}
		public void setPermisos() 
		{
			this.isRead = true;
			this.isWrite = true;
			this.isDelete = true;
		}
		public void setIsRead(bool isRead) 
		{
			this.isRead = isRead;
		}
		public bool getIsRead() 
		{
			return this.isRead;
		}
		public void setIsWrite(bool isWrite) 
		{
			this.isWrite = isWrite;
		}
		public bool getIsWrite() 
		{
			return this.isWrite;
		}
		public void setIsDelete(bool isDelete) 
		{
			this.isDelete = isDelete;
		}
		public bool getIsDelete() 
		{
			return this.isDelete;
		}
		public void setTipo(String tipo) 
		{
			this.tipo = tipo;
		}
		public string GetTipo() 
		{
			return this.tipo;
		}
	
		public void GetMenuSQL(int contexto,string Username) 
		{
			string Componente;
			bool isRead, isWrite, isDelete;
			string id;
			object controlData;
			Permission permiso;
			string sSQL;
			OleDbDataReader myDataReader;
			OleDbConnection myConnection = DB.getConnection();
			sSQL = "SELECT C.AccesoId AS componente_id, " +
				"C.AccesoId, " +
				"C.AccesoNombre, " +
				"S.RolId, " +
				"S.Leer, " +
				"S.Escribir, " +
				"S.Eliminar, " +
				"C.PadreId " +
				"FROM  Acceso C, " +
				"      Seguridad S  " +
				"WHERE C.AccesoId = S.AccesoId " +
				"And   C.Codigo = " + contexto + " " +
				"And   S.RolId IN (SELECT RolId FROM RolUsuario "+
				"                  WHERE Username=?)";
			OleDbCommand myCommand = new OleDbCommand(sSQL, myConnection);
			myCommand.CommandType = CommandType.Text;
			myCommand.Parameters.Add("Username",  OleDbType.Char, 15).Value = Username;
				
			try	
			{
				myConnection.Open();
				myDataReader = myCommand.ExecuteReader();
				while (myDataReader.Read()) 
				{
					string str = myDataReader.GetFieldType(4).ToString();
                    //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                    //{
                    //    Componente = (string) myDataReader.GetDecimal(1).ToString(); 
                    //    isDelete = bool.Parse(myDataReader.GetDecimal(6).Equals(1)?"true":"false");
                    //}
                    //else
                    //{
						Componente = (string) myDataReader.GetInt32(1).ToString(); 
						isDelete = bool.Parse(myDataReader.GetInt32(6).Equals(1)?"true":"false");
                    //}

					isRead = true; //bool.Parse(myDataReader.GetInt32(4).Equals(1)?"true":"false");
					isWrite = true; //bool.Parse(myDataReader.GetInt32(5).Equals(1)?"true":"false");
					permiso = new Permission(Componente, isRead, isWrite, isDelete);
					permisos.Add (Componente.ToString(), permiso);
				}
				sSQL = "SELECT CP.AccesoId, "+
					"CP.AccesoId id1, "+
					"CP.AccesoId codigo_nivel1, " +
					"CP.AccesoNombre nombre_nivel1, ";
                //if (ConfigurationSettings.AppSettings["BaseDatos"].ToString()=="Oracle")
                //{
                //    sSQL+= "Nvl(CP.AccesoPagina, '') link_nivel1, ";
                //}
                //else
                //{
					sSQL+= "Isnull(CP.AccesoPagina, '') link_nivel1, ";
                //}
				sSQL+="CP.AccesoIcono comp_imagen1," +
					"CH.AccesoId id2, "+
					"CH.AccesoId codigo_nivel2, " +
					"CH.AccesoNombre nombre_nivel2, ";
                //if (ConfigurationSettings.AppSettings["BaseDatos"].ToString()=="Oracle")
                //{
                //    sSQL+= "Nvl(CH.AccesoPagina, '') link_nivel2, ";
                //}
                //else
                //{
					sSQL+= "Isnull(CH.AccesoPagina, '') link_nivel2, ";
                //}
				sSQL+= "CH.AccesoIcono AS comp_imagen2, " +
					"CN.AccesoId id3, "+
					"CN.AccesoId codigo_nivel3, " +
					"CN.AccesoNombre nombre_nivel3, ";
                //if (ConfigurationSettings.AppSettings["BaseDatos"].ToString()=="Oracle")
                //{
                //    sSQL+= "Nvl(CN.AccesoPagina, '') link_nivel3, ";
                //}
                //else
                //{
					sSQL+= "Isnull(CN.AccesoPagina, '') link_nivel3, ";
                //}
				sSQL+= "CN.AccesoIcono comp_imagen3 ";
//                if (ConfigurationSettings.AppSettings["BaseDatos"].ToString()=="Oracle")
//                {
//                    sSQL+="FROM Acceso CP, Acceso CH, Acceso CN  " +
//                        "Where CP.AccesoId = CH.PadreId (+) And CH.AccesoId = CN.PadreId (+) " +
//                        "And  (CP.PadreId IS NULL OR CP.PadreId = 0) " +
//                        "And  CP.Codigo = " + contexto + " " +
////						"And  CH.Codigo = " + contexto + " " +
////						"And  CN.Codigo = " + contexto + " " +
//                        "And  CP.Codigo = CH.Codigo (+) And CH.Codigo = CN.Codigo (+) ";
//                }
//                else
//                {
					sSQL+="FROM   Acceso CP Left Join Acceso CH "+
						"On (CP.AccesoId = CH.PadreId And CH.Codigo = " + contexto +") "+
						"Left Join Acceso CN "+
						"On (CH.AccesoId = CN.PadreId And CN.Codigo = " + contexto +") " +
						"Where (CP.PadreId IS NULL OR CP.PadreId = 0) " +
						"And    CP.Codigo = " + contexto + " ";
                //}

				sSQL+="ORDER BY CP.AccesoOrden, CH.AccesoOrden, CN.AccesoOrden";
				myDataReader.Close();
				myCommand = new OleDbCommand(sSQL, myConnection);
				myCommand.CommandType = CommandType.Text;
				myDataReader = myCommand.ExecuteReader();
				bool exist = myDataReader.Read();
				while (exist) 
				{
                    //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                    //{
                    //    id = myDataReader.GetDecimal(2).ToString();
                    //}
                    //else
                    //{
						id = myDataReader.GetInt32(2).ToString();
                    //}


					if (permisos.ContainsKey(id)) 
					{
						permiso = (Permission) permisos[id];
					} 
					else 
					{
						permiso = new Permission();					
					}
					if(permiso.MyRead)
					{
						string codigo_nivel1 = "";
                        //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                        //{
                        //    codigo_nivel1 = (string) myDataReader.GetDecimal(2).ToString();//codigo_nivel1
                        //}
                        //else
                        //{
							codigo_nivel1 = (string) myDataReader.GetInt32(2).ToString();//codigo_nivel1
                        //}


						Menu1 menu1 = new Menu1();//codigo_nivel1		
                        //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                        //{
                        //    menu1.myId = int.Parse(myDataReader.GetDecimal(1).ToString());
                        //    menu1.myCode = (string) myDataReader.GetDecimal(2).ToString();//codigo_nivel1
                        //}
                        //else
                        //{
							menu1.myId = int.Parse(myDataReader.GetInt32(1).ToString());
							menu1.myCode = (string) myDataReader.GetInt32(2).ToString();//codigo_nivel1
                        //}


						string tipo = myDataReader.GetFieldType(3).ToString();
						menu1.text = myDataReader.GetString(3).Trim();
						menu1.link = myDataReader.GetString(4).ToString().Trim();//link_nivel1
						menu1.icon = myDataReader.GetString(5).ToString().Trim();//comp_imagen1
						while (exist && codigo_nivel1.Equals(myDataReader.GetInt32(2).ToString())) //codigo_nivel1
						{
							controlData = myDataReader.GetValue(7);
							if (!(controlData is DBNull))// && permiso.MyRead)//codigo_nivel2 
							{
								object myText = myDataReader[7];//nombre_nivel1
                                //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                //{
                                //    id = myDataReader.GetDecimal(7).ToString();
                                //}
                                //else
                                //{
									id = myDataReader.GetInt32(7).ToString();
                                //}

								if (permisos.ContainsKey(id)) 
								{
									permiso = (Permission) permisos[id];
								} 
								else 
								{
									permiso = new Permission();			
								}
								if(permiso.MyRead)
								{
									string codigo_nivel2 = "";
                                    //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                    //{
                                    //    codigo_nivel2 = (myDataReader.GetDecimal(7).ToString()==null?"":myDataReader.GetDecimal(7).ToString());
                                    //}
                                    //else
                                    //{
										codigo_nivel2 = (myDataReader.GetInt32(7).ToString()==null?"":myDataReader.GetInt32(7).ToString());
                                    //}


									
									Menu1 menu2 = new Menu1();//codigo_nivel2
                                    //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                    //{
                                    //    menu2.myId = int.Parse(myDataReader.GetDecimal(6).ToString());
                                    //    menu2.myCode = (string) myDataReader.GetDecimal(7).ToString();//codigo_nivel1
                                    //}
                                    //else
                                    //{
										menu2.myId = int.Parse(myDataReader.GetInt32(6).ToString());
										menu2.myCode = (string) myDataReader.GetInt32(7).ToString();//codigo_nivel1
                                    //}

									
									menu2.text = myDataReader.GetString(8).Trim();
									menu2.link = myDataReader.GetString(9).ToString().Trim();
									menu2.icon = myDataReader.GetString(10).ToString().Trim();
									//menu2.icon = (String) SQLUtil.getObjectValue(res, "comp_imagen2", "String");
								
									while (exist && codigo_nivel1.Equals( myDataReader.GetInt32(2).ToString()) && codigo_nivel2.Equals(myDataReader.GetInt32(7).ToString()))
									{
										controlData = myDataReader.GetValue(12);
										if (!(controlData is DBNull))// && permiso.MyRead) 
										{
                                            //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                            //{
                                            //    id = myDataReader.GetDecimal(12).ToString();
                                            //}
                                            //else
                                            //{
												id = myDataReader.GetInt32(12).ToString();
                                            //}


											if (permisos.ContainsKey(id)) 
											{
												permiso = (Permission) permisos[id];
											} 
											else 
											{
												permiso = new Permission();					
											}
											if(permiso.MyRead)
											{
												//											string codigo_nivel3 = (myDataReader.GetInt32(12).ToString()==null?"":myDataReader.GetInt32(12).ToString());
												//											Menu menu3 = new Menu(int.Parse(myDataReader.GetInt32(11).ToString()), myDataReader.GetInt32(12).ToString());
												string codigo_nivel3 = "";
                                                //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                                //{
                                                //    codigo_nivel3 = (myDataReader.GetDecimal(12).ToString()==null?"":myDataReader.GetDecimal(12).ToString());
                                                //}
                                                //else
                                                //{
													codigo_nivel3 = (myDataReader.GetInt32(12).ToString()==null?"":myDataReader.GetInt32(12).ToString());
                                                //}


												Menu1 menu3 = new Menu1();//codigo_nivel3
                                                //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                                //{
                                                //    menu3.myId = int.Parse(myDataReader.GetDecimal(11).ToString());
                                                //    menu3.myCode = (string) myDataReader.GetDecimal(12).ToString();//codigo_nivel1
                                                //}
                                                //else
                                                //{
													menu3.myId = int.Parse(myDataReader.GetInt32(11).ToString());
													menu3.myCode = (string) myDataReader.GetInt32(12).ToString();//codigo_nivel1
                                                //}

                                                
                                                //Encrypt myEncr = new Encrypt();
                                                //string linkEncr = myEncr.EncriptaValor(myDataReader.GetString(14).ToString().Trim());
												
												menu3.text = myDataReader.GetString(13).Trim();
                                                menu3.link = myDataReader.GetString(14).ToString().Trim(); // linkEncr; //
												menu3.icon = myDataReader.GetString(15).ToString().Trim();
												menu2.AddSubMenu(menu3);
											}
										}
										exist = myDataReader.Read();
									}
									menu1.AddSubMenu(menu2);
								}
								else
								{
									exist = myDataReader.Read();
								}
							} 
							else 
							{
								exist = myDataReader.Read();
							}
						}
						this.AddSubMenu(menu1);
					} 
					else 
					{
						exist = myDataReader.Read();
					}
				}
			} 
			catch (Exception e) 
			{
				throw new Exception(e.Message.ToString() + " " + e.StackTrace);
			} 
			finally 
			{
				try 
				{
					myConnection.Close();
				} 
				catch (Exception e) 
				{
					throw new Exception(e.Message.ToString());
				}
			}
		}
		
		public void GetMenuOracle(int contexto,string Username) 
		{
			string Componente;
			bool isRead, isWrite, isDelete;
			string id;
			object controlData;
			Permission permiso;
			string sSQL;
			OleDbDataReader myDataReader;
			OleDbConnection myConnection = DB.getConnection();
			sSQL = "SELECT C.AccesoId AS componente_id, " +
				"C.AccesoId, " +
				"C.AccesoNombre, " +
				"S.RolId, " +
				"S.Leer, " +
				"S.Escribir, " +
				"S.Eliminar, " +
				"C.PadreId " +
				"FROM  Acceso C, " +
				"      Seguridad S  " +
				"WHERE C.AccesoId = S.AccesoId " +
				"And   C.Codigo = " + contexto + " " +
				"And   S.RolId IN (SELECT RolId FROM RolUsuario "+
				"                  WHERE Username=?)";
			OleDbCommand myCommand = new OleDbCommand(sSQL, myConnection);
			myCommand.CommandType = CommandType.Text;
			myCommand.Parameters.Add("Username",  OleDbType.Char, 15).Value = Username;
				
			try	
			{
				myConnection.Open();
				myDataReader = myCommand.ExecuteReader();
				while (myDataReader.Read()) 
				{
					string str = myDataReader.GetFieldType(4).ToString();
                    //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                    //{
                    //    Componente = (string) myDataReader.GetDecimal(1).ToString(); 
                    //    isDelete = bool.Parse(myDataReader.GetDecimal(6).Equals(1)?"true":"false");
                    //}
                    //else
                    //{
						Componente = (string) myDataReader.GetInt32(1).ToString(); 
						isDelete = bool.Parse(myDataReader.GetInt32(6).Equals(1)?"true":"false");
                    //}

					isRead = true; //bool.Parse(myDataReader.GetInt32(4).Equals(1)?"true":"false");
					isWrite = true; //bool.Parse(myDataReader.GetInt32(5).Equals(1)?"true":"false");
					permiso = new Permission(Componente, isRead, isWrite, isDelete);
					permisos.Add (Componente.ToString(), permiso);
				}
				sSQL = "SELECT CP.AccesoId, "+
					"CP.AccesoId id1, "+
					"CP.AccesoId codigo_nivel1, " +
					"CP.AccesoNombre nombre_nivel1, ";
                //if (ConfigurationSettings.AppSettings["BaseDatos"].ToString()=="Oracle")
                //{
                //    sSQL+= "Nvl(CP.AccesoPagina, '') link_nivel1, ";
                //}
                //else
                //{
					sSQL+= "Isnull(CP.AccesoPagina, '') link_nivel1, ";
                //}
				sSQL+="CP.AccesoIcono comp_imagen1," +
					"CH.AccesoId id2, "+
					"CH.AccesoId codigo_nivel2, " +
					"CH.AccesoNombre nombre_nivel2, ";
                //if (ConfigurationSettings.AppSettings["BaseDatos"].ToString()=="Oracle")
                //{
                //    sSQL+= "Nvl(CH.AccesoPagina, '') link_nivel2, ";
                //}
                //else
                //{
					sSQL+= "Isnull(CH.AccesoPagina, '') link_nivel2, ";
                //}
				sSQL+= "CH.AccesoIcono AS comp_imagen2, " +
					"CN.AccesoId id3, "+
					"CN.AccesoId codigo_nivel3, " +
					"CN.AccesoNombre nombre_nivel3, ";
                //if (ConfigurationSettings.AppSettings["BaseDatos"].ToString()=="Oracle")
                //{
                //    sSQL+= "Nvl(CN.AccesoPagina, '') link_nivel3, ";
                //}
                //else
                //{
					sSQL+= "Isnull(CN.AccesoPagina, '') link_nivel3, ";
                //}
				sSQL+= "CN.AccesoIcono comp_imagen3 ";
                //if (ConfigurationSettings.AppSettings["BaseDatos"].ToString()=="Oracle")
                //{
                //    sSQL+="FROM Acceso CP, Acceso CH, Acceso CN  " +
                //        "Where CP.AccesoId = CH.PadreId (+) And CH.AccesoId = CN.PadreId (+) " +
                //        "And  (CP.PadreId IS NULL OR CP.PadreId = 0) " +
                //        "And  CP.Codigo = " + contexto + " " +
                //        //						"And  CH.Codigo = " + contexto + " " +
                //        //						"And  CN.Codigo = " + contexto + " " +
                //        "And  CP.Codigo = CH.Codigo (+) And CH.Codigo = CN.Codigo (+) ";
                //}
                //else
                //{
					sSQL+="FROM   Acceso CP Left Join Acceso CH "+
						"On (CP.AccesoId = CH.PadreId And CH.Codigo = " + contexto +") "+
						"Left Join Acceso CN "+
						"On (CH.AccesoId = CN.PadreId And CN.Codigo = " + contexto +") " +
						"Where (CP.PadreId IS NULL OR CP.PadreId = 0) " +
						"And    CP.Codigo = " + contexto + " ";
                //}

				sSQL+="ORDER BY CP.AccesoOrden, CH.AccesoOrden, CN.AccesoOrden";
				myDataReader.Close();
				myCommand = new OleDbCommand(sSQL, myConnection);
				myCommand.CommandType = CommandType.Text;
				myDataReader = myCommand.ExecuteReader();
				bool exist = myDataReader.Read();
				while (exist) 
				{
                    //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                    //{
                    //    id = myDataReader.GetDecimal(2).ToString();
                    //}
                    //else
                    //{
						id = myDataReader.GetInt32(2).ToString();
                    //}


					if (permisos.ContainsKey(id)) 
					{
						permiso = (Permission) permisos[id];
					} 
					else 
					{
						permiso = new Permission();					
					}
					if(permiso.MyRead)
					{
						string codigo_nivel1 = "";
                        //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                        //{
                        //    codigo_nivel1 = (string) myDataReader.GetDecimal(2).ToString();//codigo_nivel1
                        //}
                        //else
                        //{
							codigo_nivel1 = (string) myDataReader.GetInt32(2).ToString();//codigo_nivel1
                        //}


						Menu1 menu1 = new Menu1();//codigo_nivel1		
                        //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                        //{
                        //    menu1.myId = int.Parse(myDataReader.GetDecimal(1).ToString());
                        //    menu1.myCode = (string) myDataReader.GetDecimal(2).ToString();//codigo_nivel1
                        //}
                        //else
                        //{
							menu1.myId = int.Parse(myDataReader.GetInt32(1).ToString());
							menu1.myCode = (string) myDataReader.GetInt32(2).ToString();//codigo_nivel1
                        //}


						string tipo = myDataReader.GetFieldType(3).ToString();
						menu1.text = myDataReader.GetString(3).Trim();
						menu1.link = myDataReader.GetString(4).ToString().Trim();//link_nivel1
						menu1.icon = myDataReader.GetString(5).ToString().Trim();//comp_imagen1
						while (exist && codigo_nivel1.Equals(myDataReader.GetDecimal(2).ToString())) //codigo_nivel1
						{
							controlData = myDataReader.GetValue(7);
							if (!(controlData is DBNull))// && permiso.MyRead)//codigo_nivel2 
							{
								object myText = myDataReader[7];//nombre_nivel1
                                //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                //{
                                //    id = myDataReader.GetDecimal(7).ToString();
                                //}
                                //else
                                //{
									id = myDataReader.GetInt32(7).ToString();
                                //}

								if (permisos.ContainsKey(id)) 
								{
									permiso = (Permission) permisos[id];
								} 
								else 
								{
									permiso = new Permission();			
								}
								if(permiso.MyRead)
								{
									string codigo_nivel2 = "";
                                    //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                    //{
                                    //    codigo_nivel2 = (myDataReader.GetDecimal(7).ToString()==null?"":myDataReader.GetDecimal(7).ToString());
                                    //}
                                    //else
                                    //{
										codigo_nivel2 = (myDataReader.GetInt32(7).ToString()==null?"":myDataReader.GetInt32(7).ToString());
                                    //}


									
									Menu1 menu2 = new Menu1();//codigo_nivel2
                                    //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                    //{
                                    //    menu2.myId = int.Parse(myDataReader.GetDecimal(6).ToString());
                                    //    menu2.myCode = (string) myDataReader.GetDecimal(7).ToString();//codigo_nivel1
                                    //}
                                    //else
                                    //{
										menu2.myId = int.Parse(myDataReader.GetInt32(6).ToString());
										menu2.myCode = (string) myDataReader.GetInt32(7).ToString();//codigo_nivel1
                                    //}

									
									menu2.text = myDataReader.GetString(8).Trim();
									menu2.link = myDataReader.GetString(9).ToString().Trim();
									menu2.icon = myDataReader.GetString(10).ToString().Trim();
									//menu2.icon = (String) SQLUtil.getObjectValue(res, "comp_imagen2", "String");
								
									while (exist && codigo_nivel1.Equals( myDataReader.GetDecimal(2).ToString()) && codigo_nivel2.Equals(myDataReader.GetDecimal(7).ToString()))
									{
										controlData = myDataReader.GetValue(12);
										if (!(controlData is DBNull))// && permiso.MyRead) 
										{
                                            //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                            //{
                                            //    id = myDataReader.GetDecimal(12).ToString();
                                            //}
                                            //else
                                            //{
												id = myDataReader.GetInt32(12).ToString();
                                            //}


											if (permisos.ContainsKey(id)) 
											{
												permiso = (Permission) permisos[id];
											} 
											else 
											{
												permiso = new Permission();					
											}
											if(permiso.MyRead)
											{
												//											string codigo_nivel3 = (myDataReader.GetInt32(12).ToString()==null?"":myDataReader.GetInt32(12).ToString());
												//											Menu menu3 = new Menu(int.Parse(myDataReader.GetInt32(11).ToString()), myDataReader.GetInt32(12).ToString());
												string codigo_nivel3 = "";
                                                //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                                //{
                                                //    codigo_nivel3 = (myDataReader.GetDecimal(12).ToString()==null?"":myDataReader.GetDecimal(12).ToString());
                                                //}
                                                //else
                                                //{
													codigo_nivel3 = (myDataReader.GetInt32(12).ToString()==null?"":myDataReader.GetInt32(12).ToString());
                                                //}


												Menu1 menu3 = new Menu1();//codigo_nivel3
                                                //if (ConfigurationSettings.AppSettings["BaseDatos"] =="Oracle")
                                                //{
                                                //    menu3.myId = int.Parse(myDataReader.GetDecimal(11).ToString());
                                                //    menu3.myCode = (string) myDataReader.GetDecimal(12).ToString();//codigo_nivel1
                                                //}
                                                //else
                                                //{
													menu3.myId = int.Parse(myDataReader.GetInt32(11).ToString());
													menu3.myCode = (string) myDataReader.GetInt32(12).ToString();//codigo_nivel1
                                                //}

												
												menu3.text = myDataReader.GetString(13).Trim();
												menu3.link = myDataReader.GetString(14).ToString().Trim();
												menu3.icon = myDataReader.GetString(15).ToString().Trim();
												menu2.AddSubMenu(menu3);
											}
										}
										exist = myDataReader.Read();
									}
									menu1.AddSubMenu(menu2);
								}
								else
								{
									exist = myDataReader.Read();
								}
							} 
							else 
							{
								exist = myDataReader.Read();
							}
						}
						this.AddSubMenu(menu1);
					} 
					else 
					{
						exist = myDataReader.Read();
					}
				}
			} 
			catch (Exception e) 
			{
				throw new Exception(e.Message.ToString() + " " + e.StackTrace);
			} 
			finally 
			{
				try 
				{
					myConnection.Close();
				} 
				catch (Exception e) 
				{
					throw new Exception(e.Message.ToString());
				}
			}
		}
		
		public int myId
		{
			get 
			{ 
				return this.id; 
			}
			set 
			{ 
				this.id = value;
			}
		}

		public string myCode
		{
			get 
			{ 
				return this.code; 
			}
			set 
			{ 
				this.code = value;
			}
		}
		public string myText
		{
			get 
			{ 
				return this.text; 
			}
			set 
			{ 
				this.text = value;
			}
		}

		public string myLink
		{
			get 
			{ 
				return this.link; 
			}
			set 
			{ 
				this.link = value;
			}
		}
		public string myIcon
		{
			get 
			{ 
				return this.icon; 
			}
			set 
			{ 
				this.icon = value;
			}
		}
		public string myDesc
		{
			get 
			{ 
				return this.desc; 
			}
			set 
			{ 
				this.desc = value;
			}
		}
		
		/**
		 * Retorna el valor de isRead
		 */
		public bool myIsRead() 
		{
			return this.isRead;
		}
	
		/**
		 * Retorna el valor de isWrite
		 */
		public bool myIsWrite() 
		{
			return this.isWrite;
		}
	
		/**
		 * Retorna el valor de isDelete
		 */
		public bool myIsDelete() 
		{
			return this.isDelete;
		}

		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Menu1(System.ComponentModel.IContainer container)
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

		public Menu1()
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
	}
}
