namespace FlowerShopView
{
    partial class FormReportOrdersAllDates
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonFormToPDF = new System.Windows.Forms.Button();
            this.buttonForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "FlowerShopView.ReportOrdersAllDates.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(7, 48);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(920, 455);
            this.reportViewer.TabIndex = 13;
            // 
            // buttonFormToPDF
            // 
            this.buttonFormToPDF.Location = new System.Drawing.Point(851, 14);
            this.buttonFormToPDF.Name = "buttonFormToPDF";
            this.buttonFormToPDF.Size = new System.Drawing.Size(75, 23);
            this.buttonFormToPDF.TabIndex = 12;
            this.buttonFormToPDF.Text = "В PDF";
            this.buttonFormToPDF.UseVisualStyleBackColor = true;
            this.buttonFormToPDF.Click += new System.EventHandler(this.buttonFormToPDF_Click);
            // 
            // buttonForm
            // 
            this.buttonForm.Location = new System.Drawing.Point(695, 14);
            this.buttonForm.Name = "buttonForm";
            this.buttonForm.Size = new System.Drawing.Size(100, 23);
            this.buttonForm.TabIndex = 11;
            this.buttonForm.Text = "Сформировать";
            this.buttonForm.UseVisualStyleBackColor = true;
            this.buttonForm.Click += new System.EventHandler(this.buttonForm_Click);
            // 
            // FormReportOrdersAllDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonFormToPDF);
            this.Controls.Add(this.buttonForm);
            this.Name = "FormReportOrdersAllDates";
            this.Text = "Заказы клиентов за все время";
            this.Load += new System.EventHandler(this.FormReportOrdersAllDates_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button buttonFormToPDF;
        private System.Windows.Forms.Button buttonForm;
    }
}