using _420DA3_Demo_Intra_Live.DataAccess;
using _420DA3_Demo_Intra_Live.GUI;
using System.Data;

namespace _420DA3_Demo_Intra_Live.Business;
public class FilmsApp {
    private readonly FilmsDAO dao;
    private readonly FilmsManagementWindow window;
    private readonly DataSet dataset;

    public FilmsApp() {
        ApplicationConfiguration.Initialize();
        this.dataset = new DataSet();
        this.dao = new FilmsDAO(ConnectionFactory.GetConnection(), this.dataset);
        this.window = new FilmsManagementWindow(this);
    }

    public void Start() {
        this.LoadData();
        Application.Run(this.window);
    }

    public void Stop() {
        ConnectionFactory.CloseConnection();
        Application.Exit();
    }

    public void LoadData() {
        this.window.BindDataTable(this.dao.GetDataTable());
    }

    public void SaveData() {
        this.dao.SaveChanges();
    }

}
