using _420DA3_Demo_Intra_Live.Business;
using System.Data;

namespace _420DA3_Demo_Intra_Live.GUI;

public partial class FilmsManagementWindow : Form {
    private readonly FilmsApp application;

    public FilmsManagementWindow(FilmsApp application) {
        this.application = application;
        this.InitializeComponent();
    }

    public void BindDataTable(DataTable table) {
        this.filmsGrigView.DataSource = table;
        this.filmsGrigView.Refresh();
    }

    private void ButtonClose_Click(object sender, EventArgs e) {
        this.application.Stop();
    }

    private void ButtonSave_Click(object sender, EventArgs e) {
        this.application.SaveData();
    }

    private void ButtonLoad_Click(object sender, EventArgs e) {
        this.application.LoadData();
    }
}
