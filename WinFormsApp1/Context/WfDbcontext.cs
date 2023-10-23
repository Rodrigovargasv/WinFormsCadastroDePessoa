
namespace WinFormsApp1.Context
{
    public class WfDbcontext
    {
        public string ConnectString { get; }
            = "Server=localhost;Port=5433;Database=postgres;User Id=postgres;Password=12345";

        //"Server=localhost;Port=5433;Database=wf_database;User Id=postgres;Password=12345";
    }
}
