namespace XrmToolBoxTool_MoveAutomations
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSample = new System.Windows.Forms.ToolStripButton();
            this.btnSelectTarget = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTargetEnvValue = new System.Windows.Forms.Label();
            this.lbSourceEnvValue = new System.Windows.Forms.Label();
            this.cbTargetSolution = new System.Windows.Forms.ComboBox();
            this.lbTargetSolution = new System.Windows.Forms.Label();
            this.lbSourceEnvironment = new System.Windows.Forms.Label();
            this.lbSourceSolution = new System.Windows.Forms.Label();
            this.cbSourceSolution = new System.Windows.Forms.ComboBox();
            this.lvSourceProcesses = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnvironmentState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTargetProcesses = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbSourceProcesses = new System.Windows.Forms.Label();
            this.lbTargetProcesses = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.toolStripMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSample});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1025, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(46, 22);
            this.tsbSample.Text = "Try me";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // btnSelectTarget
            // 
            this.btnSelectTarget.Location = new System.Drawing.Point(9, 39);
            this.btnSelectTarget.Name = "btnSelectTarget";
            this.btnSelectTarget.Size = new System.Drawing.Size(94, 23);
            this.btnSelectTarget.TabIndex = 5;
            this.btnSelectTarget.Text = "Select Target";
            this.btnSelectTarget.UseVisualStyleBackColor = true;
            this.btnSelectTarget.Click += new System.EventHandler(this.btnSelectTarget_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTargetEnvValue);
            this.groupBox1.Controls.Add(this.lbSourceEnvValue);
            this.groupBox1.Controls.Add(this.cbTargetSolution);
            this.groupBox1.Controls.Add(this.lbTargetSolution);
            this.groupBox1.Controls.Add(this.lbSourceEnvironment);
            this.groupBox1.Controls.Add(this.btnSelectTarget);
            this.groupBox1.Controls.Add(this.lbSourceSolution);
            this.groupBox1.Controls.Add(this.cbSourceSolution);
            this.groupBox1.Location = new System.Drawing.Point(3, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 70);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Details";
            // 
            // lbTargetEnvValue
            // 
            this.lbTargetEnvValue.AutoSize = true;
            this.lbTargetEnvValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTargetEnvValue.Location = new System.Drawing.Point(109, 45);
            this.lbTargetEnvValue.Name = "lbTargetEnvValue";
            this.lbTargetEnvValue.Size = new System.Drawing.Size(61, 13);
            this.lbTargetEnvValue.TabIndex = 15;
            this.lbTargetEnvValue.Text = "Unselected";
            // 
            // lbSourceEnvValue
            // 
            this.lbSourceEnvValue.AutoSize = true;
            this.lbSourceEnvValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbSourceEnvValue.Location = new System.Drawing.Point(109, 19);
            this.lbSourceEnvValue.Name = "lbSourceEnvValue";
            this.lbSourceEnvValue.Size = new System.Drawing.Size(61, 13);
            this.lbSourceEnvValue.TabIndex = 14;
            this.lbSourceEnvValue.Text = "Unselected";
            // 
            // cbTargetSolution
            // 
            this.cbTargetSolution.FormattingEnabled = true;
            this.cbTargetSolution.Location = new System.Drawing.Point(263, 42);
            this.cbTargetSolution.Name = "cbTargetSolution";
            this.cbTargetSolution.Size = new System.Drawing.Size(131, 21);
            this.cbTargetSolution.TabIndex = 13;
            this.cbTargetSolution.SelectedIndexChanged += new System.EventHandler(this.cbTargetSolution_SelectedIndexChanged);
            // 
            // lbTargetSolution
            // 
            this.lbTargetSolution.AutoSize = true;
            this.lbTargetSolution.Location = new System.Drawing.Point(178, 45);
            this.lbTargetSolution.Name = "lbTargetSolution";
            this.lbTargetSolution.Size = new System.Drawing.Size(79, 13);
            this.lbTargetSolution.TabIndex = 12;
            this.lbTargetSolution.Text = "Target Solution";
            // 
            // lbSourceEnvironment
            // 
            this.lbSourceEnvironment.AutoSize = true;
            this.lbSourceEnvironment.Location = new System.Drawing.Point(4, 19);
            this.lbSourceEnvironment.Name = "lbSourceEnvironment";
            this.lbSourceEnvironment.Size = new System.Drawing.Size(103, 13);
            this.lbSourceEnvironment.TabIndex = 6;
            this.lbSourceEnvironment.Text = "Source Environment";
            // 
            // lbSourceSolution
            // 
            this.lbSourceSolution.AutoSize = true;
            this.lbSourceSolution.Location = new System.Drawing.Point(178, 19);
            this.lbSourceSolution.Name = "lbSourceSolution";
            this.lbSourceSolution.Size = new System.Drawing.Size(82, 13);
            this.lbSourceSolution.TabIndex = 11;
            this.lbSourceSolution.Text = "Source Solution";
            // 
            // cbSourceSolution
            // 
            this.cbSourceSolution.FormattingEnabled = true;
            this.cbSourceSolution.Location = new System.Drawing.Point(263, 16);
            this.cbSourceSolution.Name = "cbSourceSolution";
            this.cbSourceSolution.Size = new System.Drawing.Size(131, 21);
            this.cbSourceSolution.TabIndex = 10;
            this.cbSourceSolution.SelectedIndexChanged += new System.EventHandler(this.cbSourceSolution_SelectedIndexChanged);
            // 
            // lvSourceProcesses
            // 
            this.lvSourceProcesses.CheckBoxes = true;
            this.lvSourceProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chEntity,
            this.chEnvironmentState});
            this.lvSourceProcesses.FullRowSelect = true;
            this.lvSourceProcesses.HideSelection = false;
            this.lvSourceProcesses.Location = new System.Drawing.Point(3, 133);
            this.lvSourceProcesses.Name = "lvSourceProcesses";
            this.lvSourceProcesses.Size = new System.Drawing.Size(505, 420);
            this.lvSourceProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSourceProcesses.TabIndex = 9;
            this.lvSourceProcesses.UseCompatibleStateImageBehavior = false;
            this.lvSourceProcesses.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 300;
            // 
            // chEntity
            // 
            this.chEntity.Text = "Entity";
            this.chEntity.Width = 100;
            // 
            // chEnvironmentState
            // 
            this.chEnvironmentState.Text = "State";
            this.chEnvironmentState.Width = 100;
            // 
            // lvTargetProcesses
            // 
            this.lvTargetProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvTargetProcesses.HideSelection = false;
            this.lvTargetProcesses.Location = new System.Drawing.Point(514, 133);
            this.lvTargetProcesses.Name = "lvTargetProcesses";
            this.lvTargetProcesses.Size = new System.Drawing.Size(508, 420);
            this.lvTargetProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTargetProcesses.TabIndex = 10;
            this.lvTargetProcesses.UseCompatibleStateImageBehavior = false;
            this.lvTargetProcesses.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Entity";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "State";
            this.columnHeader3.Width = 100;
            // 
            // lbSourceProcesses
            // 
            this.lbSourceProcesses.AutoSize = true;
            this.lbSourceProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSourceProcesses.Location = new System.Drawing.Point(4, 108);
            this.lbSourceProcesses.Name = "lbSourceProcesses";
            this.lbSourceProcesses.Size = new System.Drawing.Size(118, 16);
            this.lbSourceProcesses.TabIndex = 11;
            this.lbSourceProcesses.Text = "Source Processes";
            // 
            // lbTargetProcesses
            // 
            this.lbTargetProcesses.AutoSize = true;
            this.lbTargetProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTargetProcesses.Location = new System.Drawing.Point(511, 107);
            this.lbTargetProcesses.Name = "lbTargetProcesses";
            this.lbTargetProcesses.Size = new System.Drawing.Size(115, 16);
            this.lbTargetProcesses.TabIndex = 12;
            this.lbTargetProcesses.Text = "Target Processes";
            // 
            // btn
            // 
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.ForeColor = System.Drawing.Color.Blue;
            this.btn.Location = new System.Drawing.Point(419, 41);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(134, 23);
            this.btn.TabIndex = 13;
            this.btn.Text = "Transfer Automations";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn);
            this.Controls.Add(this.lbTargetProcesses);
            this.Controls.Add(this.lbSourceProcesses);
            this.Controls.Add(this.lvTargetProcesses);
            this.Controls.Add(this.lvSourceProcesses);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1025, 556);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbSample;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Button btnSelectTarget;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvSourceProcesses;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chEntity;
        private System.Windows.Forms.ColumnHeader chEnvironmentState;
        private System.Windows.Forms.ComboBox cbSourceSolution;
        private System.Windows.Forms.Label lbSourceSolution;
        private System.Windows.Forms.Label lbTargetSolution;
        private System.Windows.Forms.ComboBox cbTargetSolution;
        private System.Windows.Forms.Label lbSourceEnvironment;
        private System.Windows.Forms.Label lbSourceEnvValue;
        private System.Windows.Forms.Label lbTargetEnvValue;
        private System.Windows.Forms.ListView lvTargetProcesses;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lbSourceProcesses;
        private System.Windows.Forms.Label lbTargetProcesses;
        private System.Windows.Forms.Button btn;
    }
}
