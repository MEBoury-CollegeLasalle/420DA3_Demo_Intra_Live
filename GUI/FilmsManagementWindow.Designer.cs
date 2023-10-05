namespace _420DA3_Demo_Intra_Live.GUI;

partial class FilmsManagementWindow {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        filmsGrigView = new DataGridView();
        buttonClose = new Button();
        buttonSave = new Button();
        buttonLoad = new Button();
        ((System.ComponentModel.ISupportInitialize) filmsGrigView).BeginInit();
        this.SuspendLayout();
        // 
        // filmsGrigView
        // 
        filmsGrigView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        filmsGrigView.Location = new Point(12, 12);
        filmsGrigView.Name = "filmsGrigView";
        filmsGrigView.RowHeadersWidth = 51;
        filmsGrigView.RowTemplate.Height = 29;
        filmsGrigView.Size = new Size(776, 391);
        filmsGrigView.TabIndex = 0;
        // 
        // buttonClose
        // 
        buttonClose.Location = new Point(694, 409);
        buttonClose.Name = "buttonClose";
        buttonClose.Size = new Size(94, 29);
        buttonClose.TabIndex = 1;
        buttonClose.Text = "Fermer";
        buttonClose.UseVisualStyleBackColor = true;
        buttonClose.Click += this.ButtonClose_Click;
        // 
        // buttonSave
        // 
        buttonSave.Location = new Point(568, 409);
        buttonSave.Name = "buttonSave";
        buttonSave.Size = new Size(120, 29);
        buttonSave.TabIndex = 2;
        buttonSave.Text = "Sauvegarder";
        buttonSave.UseVisualStyleBackColor = true;
        buttonSave.Click += this.ButtonSave_Click;
        // 
        // buttonLoad
        // 
        buttonLoad.Location = new Point(382, 409);
        buttonLoad.Name = "buttonLoad";
        buttonLoad.Size = new Size(180, 29);
        buttonLoad.TabIndex = 3;
        buttonLoad.Text = "Recharger Données";
        buttonLoad.UseVisualStyleBackColor = true;
        buttonLoad.Click += this.ButtonLoad_Click;
        // 
        // FilmsManagementWindow
        // 
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(buttonLoad);
        this.Controls.Add(buttonSave);
        this.Controls.Add(buttonClose);
        this.Controls.Add(filmsGrigView);
        this.Name = "FilmsManagementWindow";
        this.Text = "Films Management Window";
        ((System.ComponentModel.ISupportInitialize) filmsGrigView).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private DataGridView filmsGrigView;
    private Button buttonClose;
    private Button buttonSave;
    private Button buttonLoad;
}
