namespace XrmToolBoxTool_MoveAutomations.Forms
{
    partial class ErrorList
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
            this.lvErrors = new System.Windows.Forms.ListView();
            this.chWorkflow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvErrors
            // 
            this.lvErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chWorkflow,
            this.chError});
            this.lvErrors.HideSelection = false;
            this.lvErrors.Location = new System.Drawing.Point(12, 12);
            this.lvErrors.Name = "lvErrors";
            this.lvErrors.Size = new System.Drawing.Size(776, 426);
            this.lvErrors.TabIndex = 0;
            this.lvErrors.UseCompatibleStateImageBehavior = false;
            this.lvErrors.View = System.Windows.Forms.View.Details;
            // 
            // chWorkflow
            // 
            this.chWorkflow.Text = "Name";
            this.chWorkflow.Width = 250;
            // 
            // chError
            // 
            this.chError.Text = "Error";
            this.chError.Width = 550;
            // 
            // ErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvErrors);
            this.Name = "ErrorList";
            this.Text = "List of Errors";
            this.Load += new System.EventHandler(this.ErrorList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvErrors;
        private System.Windows.Forms.ColumnHeader chWorkflow;
        private System.Windows.Forms.ColumnHeader chError;
    }
}