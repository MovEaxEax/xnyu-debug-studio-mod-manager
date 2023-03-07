namespace xnyu_debug_studio_mod_manager
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_online_install = new System.Windows.Forms.Button();
            this.combobox_online_install = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_online_uninstall = new System.Windows.Forms.Button();
            this.combobox_online_uninstall = new System.Windows.Forms.ComboBox();
            this.combobox_local_uninstall = new System.Windows.Forms.ComboBox();
            this.button_local_uninstall = new System.Windows.Forms.Button();
            this.button_local_install = new System.Windows.Forms.Button();
            this.button_online_updates = new System.Windows.Forms.Button();
            this.textbox_local_install = new System.Windows.Forms.TextBox();
            this.button_offline_select = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_online_install
            // 
            this.button_online_install.Location = new System.Drawing.Point(12, 34);
            this.button_online_install.Name = "button_online_install";
            this.button_online_install.Size = new System.Drawing.Size(75, 23);
            this.button_online_install.TabIndex = 0;
            this.button_online_install.Text = "Install";
            this.button_online_install.UseVisualStyleBackColor = true;
            this.button_online_install.Click += new System.EventHandler(this.button_online_install_Click);
            // 
            // combobox_online_install
            // 
            this.combobox_online_install.FormattingEnabled = true;
            this.combobox_online_install.Location = new System.Drawing.Point(93, 36);
            this.combobox_online_install.Name = "combobox_online_install";
            this.combobox_online_install.Size = new System.Drawing.Size(186, 21);
            this.combobox_online_install.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Available online mods";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Local mods";
            // 
            // button_online_uninstall
            // 
            this.button_online_uninstall.Location = new System.Drawing.Point(12, 63);
            this.button_online_uninstall.Name = "button_online_uninstall";
            this.button_online_uninstall.Size = new System.Drawing.Size(75, 23);
            this.button_online_uninstall.TabIndex = 5;
            this.button_online_uninstall.Text = "Uninstall";
            this.button_online_uninstall.UseVisualStyleBackColor = true;
            this.button_online_uninstall.Click += new System.EventHandler(this.button_online_uninstall_Click);
            // 
            // combobox_online_uninstall
            // 
            this.combobox_online_uninstall.FormattingEnabled = true;
            this.combobox_online_uninstall.Location = new System.Drawing.Point(93, 65);
            this.combobox_online_uninstall.Name = "combobox_online_uninstall";
            this.combobox_online_uninstall.Size = new System.Drawing.Size(186, 21);
            this.combobox_online_uninstall.TabIndex = 6;
            // 
            // combobox_local_uninstall
            // 
            this.combobox_local_uninstall.FormattingEnabled = true;
            this.combobox_local_uninstall.Location = new System.Drawing.Point(93, 228);
            this.combobox_local_uninstall.Name = "combobox_local_uninstall";
            this.combobox_local_uninstall.Size = new System.Drawing.Size(186, 21);
            this.combobox_local_uninstall.TabIndex = 10;
            // 
            // button_local_uninstall
            // 
            this.button_local_uninstall.Location = new System.Drawing.Point(12, 226);
            this.button_local_uninstall.Name = "button_local_uninstall";
            this.button_local_uninstall.Size = new System.Drawing.Size(75, 23);
            this.button_local_uninstall.TabIndex = 9;
            this.button_local_uninstall.Text = "Uninstall";
            this.button_local_uninstall.UseVisualStyleBackColor = true;
            this.button_local_uninstall.Click += new System.EventHandler(this.button_local_uninstall_Click);
            // 
            // button_local_install
            // 
            this.button_local_install.Location = new System.Drawing.Point(12, 197);
            this.button_local_install.Name = "button_local_install";
            this.button_local_install.Size = new System.Drawing.Size(75, 23);
            this.button_local_install.TabIndex = 7;
            this.button_local_install.Text = "Install";
            this.button_local_install.UseVisualStyleBackColor = true;
            this.button_local_install.Click += new System.EventHandler(this.button_local_install_Click);
            // 
            // button_online_updates
            // 
            this.button_online_updates.Location = new System.Drawing.Point(12, 92);
            this.button_online_updates.Name = "button_online_updates";
            this.button_online_updates.Size = new System.Drawing.Size(75, 23);
            this.button_online_updates.TabIndex = 11;
            this.button_online_updates.Text = "Updates";
            this.button_online_updates.UseVisualStyleBackColor = true;
            // 
            // textbox_local_install
            // 
            this.textbox_local_install.Location = new System.Drawing.Point(93, 172);
            this.textbox_local_install.Name = "textbox_local_install";
            this.textbox_local_install.Size = new System.Drawing.Size(186, 20);
            this.textbox_local_install.TabIndex = 12;
            // 
            // button_offline_select
            // 
            this.button_offline_select.Location = new System.Drawing.Point(12, 169);
            this.button_offline_select.Name = "button_offline_select";
            this.button_offline_select.Size = new System.Drawing.Size(75, 23);
            this.button_offline_select.TabIndex = 13;
            this.button_offline_select.Text = "Select";
            this.button_offline_select.UseVisualStyleBackColor = true;
            this.button_offline_select.Click += new System.EventHandler(this.button_offline_select_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::xnyu_debug_studio_mod_manager.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(297, 268);
            this.Controls.Add(this.button_offline_select);
            this.Controls.Add(this.textbox_local_install);
            this.Controls.Add(this.button_online_updates);
            this.Controls.Add(this.combobox_local_uninstall);
            this.Controls.Add(this.button_local_uninstall);
            this.Controls.Add(this.button_local_install);
            this.Controls.Add(this.combobox_online_uninstall);
            this.Controls.Add(this.button_online_uninstall);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combobox_online_install);
            this.Controls.Add(this.button_online_install);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xNyu Mod Manager v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_online_install;
        private System.Windows.Forms.ComboBox combobox_online_install;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_online_uninstall;
        private System.Windows.Forms.ComboBox combobox_online_uninstall;
        private System.Windows.Forms.ComboBox combobox_local_uninstall;
        private System.Windows.Forms.Button button_local_uninstall;
        private System.Windows.Forms.Button button_local_install;
        private System.Windows.Forms.Button button_online_updates;
        private System.Windows.Forms.TextBox textbox_local_install;
        private System.Windows.Forms.Button button_offline_select;
    }
}

