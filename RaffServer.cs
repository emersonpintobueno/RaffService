using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Raffinato
{
    public partial class RaffServer : ServiceBase
    {
        public RaffServer()
        {
            InitializeComponent();
            Inicializa();
        }

        protected override void OnStart(string[] args)
        {
            
        }

        protected override void OnStop()
        {
        }

        public void Inicializa()
        {
            string curDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());

            if (!LocalizaServicos("Servidor.exe"))
            {
                //System.Diagnostics.Process.Start(@"net stop mssql$sqlexpress");
                System.Diagnostics.Process.Start(curDir + @"\Servidor.exe");
            }
        }

        public Boolean LocalizaServicos(String v)
        {
            bool s = false;
            List<String> l = ListaServicos();

            string r = l.Find(x => x.Contains(v));
            if(r!=null)
            {
                Console.WriteLine("encontrado" + r);
            }

            return s;
        }
        
        public List<String> ListaServicos()
        {
            List<String> p = new List<string>();
            //Process[] processos = Process.GetProcessesByName("notepad");
            Process[] processos = Process.GetProcesses();
            foreach (Process processo in processos)
            {
                p.Add(processo.ProcessName);
                
                //foreach (Process processo in processos)
                //{
                //    processo.Kill();
                //}
            }
            return p;
        }
    }
}
