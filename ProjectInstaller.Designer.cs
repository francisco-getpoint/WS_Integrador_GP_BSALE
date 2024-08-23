namespace WS_itec2
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            this.serviceProcessInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller1_AfterInstall);
            // 
            // serviceInstaller1
            // 
            /*SERVICIO SOLO DE BOLETAS*/

            string Empresa;

            Empresa = "MUNDOSALUD";

            this.serviceInstaller1.DisplayName = "GP Integrador_GP_BSALE " + Empresa.Trim();
            this.serviceInstaller1.ServiceName = "WS_Integrador_GP_BSALE_" + Empresa.Trim();

            //this.serviceInstaller1.DisplayName = "GP Integrador_GP_BSALE NOVAPET BOL";
            //this.serviceInstaller1.ServiceName = "WS_Integrador_GP_BSALE_NOVAPET_BOL";

            //this.serviceInstaller1.DisplayName = "GP Integrador_GP_BSALE NOVAPET";
            //this.serviceInstaller1.ServiceName = "WS_Integrador_GP_BSALE_NOVAPET";

            //this.serviceInstaller1.DisplayName = "GP Integrador_GP_BSALE MUNDOSALUD";
            //this.serviceInstaller1.ServiceName = "WS_Integrador_GP_BSALE_MUNDOSALUD";

            //this.serviceInstaller1.DisplayName = "GP Integrador_GP_BSALE FASTPACK";
            //this.serviceInstaller1.ServiceName = "WS_Integrador_GP_BSALE_FASTPACK";

            //this.serviceInstaller1.DisplayName = "GP Integrador_GP_BSALE PORTLAND";
            //this.serviceInstaller1.ServiceName = "WS_Integrador_GP_BSALE_PORTLAND";

            //this.serviceInstaller1.DisplayName = "GP Integrador_GP_BSALE SIKSA";
            //this.serviceInstaller1.ServiceName = "WS_Integrador_GP_BSALE_SIKSA";

            //this.serviceInstaller1.DisplayName = "GP Integrador_GP_BSALE REUSE";
            //this.serviceInstaller1.ServiceName = "WS_Integrador_GP_BSALE_REUSE";


            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.serviceInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
    }
}