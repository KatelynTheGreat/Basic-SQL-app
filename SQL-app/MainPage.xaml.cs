using MySql.Data.MySqlClient;
using System.Data;

namespace SQL_app;

public partial class MainPage : ContentPage
{


    public MainPage()
	{
		InitializeComponent();
       
    }
    private void button1_Clicked(object sender, EventArgs e)
    {
        string connectionString = "Server=192.169.144.133;Database=sr_team_3;Uid=mcctc3;Pwd=mcctcrocks;";
        string query = "SELECT * FROM playerInput";





        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            
            command.CommandText = $"SELECT * FROM playerInput WHERE FIRST_NAME = '{infoText.Text}';";



            

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    infoGiven.Text = $"First Name: {reader.GetString(0)} |Last Name: {reader.GetString(1)} |Phone:  {reader.GetString(2)} |Discord: {reader.GetString(3)} |Game: {reader.GetString(4)} |ID: {reader.GetString(5)}"; 
                    reader.NextResult();
                }
            }
        }
    }
}

