using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //BOTÃO CADASTRAR
        private void button1_Click(object sender, EventArgs e)
        {
     
            OleDbConnection conn = new OleDbConnection();
            string connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jaqueline.opaula\Downloads\teste.accdb";
            conn.ConnectionString = connect;
            OleDbCommand cmd = new OleDbCommand("INSERT INTO tabela1(nome) VALUES ('"+textBox1.Text +"')");
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado Cadastrado");
            conn.Close();
        }

        //BOTÃO EXCLUIR
        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            string connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jaqueline.opaula\Downloads\teste.accdb";
            conn.ConnectionString = connect;
            OleDbCommand cmd = new OleDbCommand("DELETE FROM tabela1 WHERE nome = ('" + textBox1.Text + "')");
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado apagado");
            conn.Close();
        }

        //BOTÃO ALTERAR
        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            string connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jaqueline.opaula\Downloads\teste.accdb";
            conn.ConnectionString = connect;
            OleDbCommand cmd = new OleDbCommand("UPDATE tabela1 SET nome = ('" + textBox2.Text + "') WHERE nome = ('" + textBox1.Text + "')");
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado atualizado");
            conn.Close();

        }

        //BOTÃO CONSULTAR
        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            string connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jaqueline.opaula\Downloads\teste.accdb";
            conn.ConnectionString = connect;
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM tabela1 WHERE nome LIKE ('" + textBox1.Text + "%') ORDER BY nome ASC");
            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader aReader = cmd.ExecuteReader();
            textBox3.Text = "Os valores retornados da tabela são : ";
            while (aReader.Read())
            {
                textBox3.Text += Environment.NewLine + (aReader.GetString(0));
            }
            conn.Close();
        }
    }
}
