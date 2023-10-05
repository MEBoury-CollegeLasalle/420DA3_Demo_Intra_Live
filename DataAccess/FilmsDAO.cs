using Microsoft.Data.SqlClient;
using System.Data;

namespace _420DA3_Demo_Intra_Live.DataAccess;
public class FilmsDAO {
    private readonly SqlDataAdapter adapter;
    private readonly SqlConnection connection;
    private readonly DataSet dataset;

    private static readonly string TABLE_NAME = "Films";
    private static readonly string SELECT_QUERY = $"SELECT * FROM {TABLE_NAME};";
    private static readonly string INSERT_QUERY = $"INSERT INTO {TABLE_NAME} (Titre, Description, Annee) " +
        $"VALUES (@titre, @desc, @annee); SELECT * FROM {TABLE_NAME} WHERE Id = SCOPE_IDENTITY();";
    private static readonly string UPDATE_QUERY = $"UPDATE {TABLE_NAME} " +
        $"SET Titre = @titre, " +
        $"Description = @desc, " +
        $"Annee = @annee, " +
        $"DateModification = @dateModif " +
        $"WHERE (Id = @id AND DateModification = @oldDateModif);";
    private static readonly string DELETE_QUERY = $"DELETE FROM {TABLE_NAME} WHERE Id = @id;";

    public FilmsDAO(SqlConnection connection, DataSet dataset) {
        this.connection = connection;
        this.dataset = dataset;
        this.adapter = this.CreateDataAdapter();
    }

    private SqlDataAdapter CreateDataAdapter() {
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        adapter.SelectCommand = new SqlCommand(SELECT_QUERY, this.connection);

        adapter.InsertCommand = new SqlCommand(INSERT_QUERY, this.connection);
        adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
        _ = adapter.InsertCommand.Parameters.Add("@titre", SqlDbType.NVarChar, 128, "Titre");
        _ = adapter.InsertCommand.Parameters.Add("@desc", SqlDbType.Text, -1, "Description");
        _ = adapter.InsertCommand.Parameters.Add("@annee", SqlDbType.Int, 4, "Annee");

        adapter.UpdateCommand = new SqlCommand(UPDATE_QUERY, this.connection);
        _ = adapter.UpdateCommand.Parameters.Add("@titre", SqlDbType.NVarChar, 128, "Titre");
        _ = adapter.UpdateCommand.Parameters.Add("@desc", SqlDbType.Text, -1, "Description");
        _ = adapter.UpdateCommand.Parameters.Add("@annee", SqlDbType.Int, 4, "Annee");
        _ = adapter.UpdateCommand.Parameters.Add("@dateModif", SqlDbType.DateTime, 6, "DateModification");
        _ = adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
        adapter.UpdateCommand.Parameters.Add("@oldDateModif", SqlDbType.DateTime, 6, "DateModification")
            .SourceVersion = DataRowVersion.Original;

        adapter.DeleteCommand = new SqlCommand(DELETE_QUERY, this.connection);
        _ = adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");

        adapter.RowUpdating += this.OnRowUpdating;

        return adapter;
    }

    private void OnRowUpdating(object sender, SqlRowUpdatingEventArgs args) {
        if (args.StatementType == StatementType.Update) {
            args.Command.Parameters[3].Value = DateTime.Now;
        }
    }

    public DataTable GetDataTable() {
        return this.LoadDataTable();
    }

    private DataTable LoadDataTable() {
        if (this.connection.State != ConnectionState.Open) {
            this.connection.Open();
        }

        this.dataset.Tables[TABLE_NAME]?.Clear();

        _ = this.adapter.Fill(this.dataset, TABLE_NAME);

        this.connection.Close();

        DataTable table = this.dataset.Tables[TABLE_NAME] ?? throw new Exception("table does not exist in dataset.");

        this.ConfigureDataTable(table);

        return table;
    }

    private void ConfigureDataTable(DataTable table) {

        DataColumn idColumn = table.Columns["Id"] ?? throw new Exception("column [Id] does not exist.");
        idColumn.ReadOnly = true;
        idColumn.AllowDBNull = true;

        DataColumn titleColumn = table.Columns["Titre"] ?? throw new Exception("column [Titre] does not exist.");
        titleColumn.MaxLength = 128;

        DataColumn descColumn = table.Columns["Description"] ?? throw new Exception("column [Description] does not exist.");
        descColumn.AllowDBNull = true;

        DataColumn dateCreatedColumn = table.Columns["DateCreation"] ?? throw new Exception("column [DateCreation] does not exist.");
        dateCreatedColumn.ReadOnly = true;
        dateCreatedColumn.AllowDBNull = true;

        DataColumn dateModifiedColumn = table.Columns["DateModification"] ?? throw new Exception("column [DateModification] does not exist.");
        dateModifiedColumn.AllowDBNull = true;
    }

    public void SaveChanges() {
        if (this.connection.State != ConnectionState.Open) {
            this.connection.Open();
        }

        _ = this.adapter.Update(this.dataset, TABLE_NAME);

        this.connection.Close();
    }

}
