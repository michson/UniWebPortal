namespace TestingCenter
{
    partial class Form1
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
            this.ctrlGrid = new System.Windows.Forms.DataGridView();
            this.ctrlRetrieve = new System.Windows.Forms.Button();
            this.ctrlDelete = new System.Windows.Forms.Button();
            this.ctrlSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlGrid
            // 
            this.ctrlGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlGrid.Location = new System.Drawing.Point(0, 0);
            this.ctrlGrid.Name = "ctrlGrid";
            this.ctrlGrid.Size = new System.Drawing.Size(477, 150);
            this.ctrlGrid.TabIndex = 0;
            // 
            // ctrlRetrieve
            // 
            this.ctrlRetrieve.Location = new System.Drawing.Point(13, 177);
            this.ctrlRetrieve.Name = "ctrlRetrieve";
            this.ctrlRetrieve.Size = new System.Drawing.Size(75, 23);
            this.ctrlRetrieve.TabIndex = 1;
            this.ctrlRetrieve.Text = "Retrieve";
            this.ctrlRetrieve.UseVisualStyleBackColor = true;
            this.ctrlRetrieve.Click += new System.EventHandler(this.ctrlRetrieve_Click);
            // 
            // ctrlDelete
            // 
            this.ctrlDelete.Location = new System.Drawing.Point(95, 176);
            this.ctrlDelete.Name = "ctrlDelete";
            this.ctrlDelete.Size = new System.Drawing.Size(75, 23);
            this.ctrlDelete.TabIndex = 2;
            this.ctrlDelete.Text = "Delete";
            this.ctrlDelete.UseVisualStyleBackColor = true;
            this.ctrlDelete.Click += new System.EventHandler(this.ctrlDelete_Click);
            // 
            // ctrlSave
            // 
            this.ctrlSave.Location = new System.Drawing.Point(177, 176);
            this.ctrlSave.Name = "ctrlSave";
            this.ctrlSave.Size = new System.Drawing.Size(75, 23);
            this.ctrlSave.TabIndex = 3;
            this.ctrlSave.Text = "Save";
            this.ctrlSave.UseVisualStyleBackColor = true;
            this.ctrlSave.Click += new System.EventHandler(this.ctrlSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 262);
            this.Controls.Add(this.ctrlSave);
            this.Controls.Add(this.ctrlDelete);
            this.Controls.Add(this.ctrlRetrieve);
            this.Controls.Add(this.ctrlGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ctrlGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ctrlGrid;
        private System.Windows.Forms.Button ctrlRetrieve;
        private System.Windows.Forms.Button ctrlDelete;
        private System.Windows.Forms.Button ctrlSave;
    }
}

