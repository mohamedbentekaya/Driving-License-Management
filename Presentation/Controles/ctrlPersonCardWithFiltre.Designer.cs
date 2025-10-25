namespace Presentation.Controles
{
    partial class ctrlPersonCardWithFiltre
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
            this.txtbFilterPeople = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new Presentation.Controles.ctrlPersonCard();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnSearchPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbFilterPeople
            // 
            this.txtbFilterPeople.Location = new System.Drawing.Point(307, 28);
            this.txtbFilterPeople.Multiline = true;
            this.txtbFilterPeople.Name = "txtbFilterPeople";
            this.txtbFilterPeople.Size = new System.Drawing.Size(187, 23);
            this.txtbFilterPeople.TabIndex = 8;
            this.txtbFilterPeople.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFilterPeople_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(113, 27);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(188, 24);
            this.cbFilter.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filter By:";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.Linen;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 63);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(847, 261);
            this.ctrlPersonCard1.TabIndex = 11;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackgroundImage = global::Presentation.Properties.Resources.Add_person_;
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddPerson.Location = new System.Drawing.Point(555, 19);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(49, 38);
            this.btnAddPerson.TabIndex = 10;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnSearchPerson
            // 
            this.btnSearchPerson.BackgroundImage = global::Presentation.Properties.Resources.search_person_;
            this.btnSearchPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchPerson.Location = new System.Drawing.Point(500, 19);
            this.btnSearchPerson.Name = "btnSearchPerson";
            this.btnSearchPerson.Size = new System.Drawing.Size(49, 38);
            this.btnSearchPerson.TabIndex = 9;
            this.btnSearchPerson.UseVisualStyleBackColor = true;
            this.btnSearchPerson.Click += new System.EventHandler(this.btnSearchPerson_Click);
            // 
            // ctrlPersonCardWithFiltre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.btnSearchPerson);
            this.Controls.Add(this.txtbFilterPeople);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label1);
            this.Name = "ctrlPersonCardWithFiltre";
            this.Size = new System.Drawing.Size(853, 325);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFiltre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnSearchPerson;
        private System.Windows.Forms.TextBox txtbFilterPeople;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label1;
        private ctrlPersonCard ctrlPersonCard1;
    }
}
