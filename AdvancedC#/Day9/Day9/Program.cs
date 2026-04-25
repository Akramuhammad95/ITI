using System;
using System.Windows.Forms;
//using Application;
using Application.interfaces;
using Application.Interfaces;
using Day9;
using Infrastructure.Repositories;

namespace Presentation
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string conn = "your_connection_string";

            IEmployeeRepository repo = new EmployeeRepository(conn);
            IEmployeeService service = new EmployeeService(repo);

            System.Windows.Forms.Application.Run(new Form1(service));
        }
    }
}