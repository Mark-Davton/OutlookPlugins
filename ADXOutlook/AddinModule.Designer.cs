namespace ADXOutlook
{
    partial class AddinModule
    {
        /// <summary>
        /// Required by designer
        /// </summary>
        private System.ComponentModel.IContainer components;
 
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required by designer support - do not modify
        /// the following method
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.adxOlExplorerMainMenu1 = new AddinExpress.MSO.ADXOlExplorerMainMenu(this.components);
            this.adxCommandBarButton1 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            // 
            // adxOlExplorerMainMenu1
            // 
            this.adxOlExplorerMainMenu1.CommandBarName = "Menu Bar";
            this.adxOlExplorerMainMenu1.CommandBarTag = "7ffdaf80-918a-4975-ae80-6243a1e9e5a2";
            this.adxOlExplorerMainMenu1.Controls.Add(this.adxCommandBarButton1);
            this.adxOlExplorerMainMenu1.Temporary = true;
            this.adxOlExplorerMainMenu1.UpdateCounter = 2;
            this.adxOlExplorerMainMenu1.UseForRibbon = true;
            // 
            // adxCommandBarButton1
            // 
            this.adxCommandBarButton1.Caption = "hello ";
            this.adxCommandBarButton1.ControlTag = "35c83c36-5a44-44ed-b11f-0cf62102c7c9";
            this.adxCommandBarButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton1.Temporary = true;
            this.adxCommandBarButton1.UpdateCounter = 3;
            this.adxCommandBarButton1.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxCommandBarButton1_Click);
            // 
            // AddinModule
            // 
            this.AddinName = "ADXOutlook";
            this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;

        }
        #endregion
        private AddinExpress.MSO.ADXOlExplorerMainMenu adxOlExplorerMainMenu1;
        private AddinExpress.MSO.ADXCommandBarButton adxCommandBarButton1;
    }
}

