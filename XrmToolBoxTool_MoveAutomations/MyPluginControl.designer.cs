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
            this.btn = new System.Windows.Forms.Button();
            this.gbSourceProcesses = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.gbTargetProcesses = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.gbSourceProcesses.SuspendLayout();
            this.gbTargetProcesses.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectTarget
            // 
            this.btnSelectTarget.Location = new System.Drawing.Point(6, 39);
            this.btnSelectTarget.Name = "btnSelectTarget";
            this.btnSelectTarget.Size = new System.Drawing.Size(94, 23);
            this.btnSelectTarget.TabIndex = 5;
            this.btnSelectTarget.Text = "Select Target";
            this.btnSelectTarget.UseVisualStyleBackColor = true;
            this.btnSelectTarget.Click += new System.EventHandler(this.btnSelectTarget_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lbTargetEnvValue);
            this.groupBox1.Controls.Add(this.lbSourceEnvValue);
            this.groupBox1.Controls.Add(this.cbTargetSolution);
            this.groupBox1.Controls.Add(this.lbTargetSolution);
            this.groupBox1.Controls.Add(this.lbSourceEnvironment);
            this.groupBox1.Controls.Add(this.btnSelectTarget);
            this.groupBox1.Controls.Add(this.lbSourceSolution);
            this.groupBox1.Controls.Add(this.cbSourceSolution);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 68);
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
            this.cbSourceSolution.Location = new System.Drawing.Point(263, 15);
            this.cbSourceSolution.Name = "cbSourceSolution";
            this.cbSourceSolution.Size = new System.Drawing.Size(131, 21);
            this.cbSourceSolution.TabIndex = 10;
            this.cbSourceSolution.SelectedIndexChanged += new System.EventHandler(this.cbSourceSolution_SelectedIndexChanged);
            // 
            // lvSourceProcesses
            // 
            this.lvSourceProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSourceProcesses.CheckBoxes = true;
            this.lvSourceProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chEntity,
            this.chEnvironmentState});
            this.lvSourceProcesses.FullRowSelect = true;
            this.lvSourceProcesses.HideSelection = false;
            this.lvSourceProcesses.Location = new System.Drawing.Point(6, 36);
            this.lvSourceProcesses.Name = "lvSourceProcesses";
            this.lvSourceProcesses.Size = new System.Drawing.Size(496, 441);
            this.lvSourceProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSourceProcesses.TabIndex = 9;
            this.lvSourceProcesses.UseCompatibleStateImageBehavior = false;
            this.lvSourceProcesses.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 289;
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
            this.lvTargetProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTargetProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvTargetProcesses.HideSelection = false;
            this.lvTargetProcesses.Location = new System.Drawing.Point(3, 36);
            this.lvTargetProcesses.Name = "lvTargetProcesses";
            this.lvTargetProcesses.Size = new System.Drawing.Size(495, 441);
            this.lvTargetProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTargetProcesses.TabIndex = 10;
            this.lvTargetProcesses.UseCompatibleStateImageBehavior = false;
            this.lvTargetProcesses.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 288;
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
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.ForeColor = System.Drawing.Color.Blue;
            this.btn.Location = new System.Drawing.Point(855, 40);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(162, 31);
            this.btn.TabIndex = 13;
            this.btn.Text = "Transfer Automations";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // gbSourceProcesses
            // 
            this.gbSourceProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSourceProcesses.Controls.Add(this.chkSelectAll);
            this.gbSourceProcesses.Controls.Add(this.lvSourceProcesses);
            this.gbSourceProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSourceProcesses.Location = new System.Drawing.Point(3, 77);
            this.gbSourceProcesses.Name = "gbSourceProcesses";
            this.gbSourceProcesses.Size = new System.Drawing.Size(504, 483);
            this.gbSourceProcesses.TabIndex = 14;
            this.gbSourceProcesses.TabStop = false;
            this.gbSourceProcesses.Text = "Source Processes";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.Location = new System.Drawing.Point(9, 19);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(117, 17);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Text = "Select/Unselect All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // gbTargetProcesses
            // 
            this.gbTargetProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTargetProcesses.Controls.Add(this.lvTargetProcesses);
            this.gbTargetProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTargetProcesses.Location = new System.Drawing.Point(513, 77);
            this.gbTargetProcesses.Name = "gbTargetProcesses";
            this.gbTargetProcesses.Size = new System.Drawing.Size(504, 483);
            this.gbTargetProcesses.TabIndex = 15;
            this.gbTargetProcesses.TabStop = false;
            this.gbTargetProcesses.Text = "Target Processes";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbTargetProcesses, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.gbSourceProcesses, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.27586F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.72414F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 563);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1026, 571);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSourceProcesses.ResumeLayout(false);
            this.gbSourceProcesses.PerformLayout();
            this.gbTargetProcesses.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.GroupBox gbSourceProcesses;
        private System.Windows.Forms.GroupBox gbTargetProcesses;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
