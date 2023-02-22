using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;

namespace SQL_app;

public partial class Page2 : ContentPage
{
    
    public Page2()
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

            command.CommandText = $"INSERT INTO playerInput (FIRST_NAME,LAST_NAME,PHONE_NUMBER,DISCORD_ID,PLAYER_ID,ESPORT_GAME) VALUES ('{first_nameText.Text}','{last_nameText.Text}','{phone_numText.Text}','{discord_idText.Text}','{player_idText.Text}','{esport_gameText.Text}');";

            first_nameText.Text = last_nameText.Text = phone_numText.Text = discord_idText.Text = player_idText.Text = esport_gameText.Text = "";


            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
        }
    }
    
    
}


