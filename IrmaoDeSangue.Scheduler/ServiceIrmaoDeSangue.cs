using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Scheduler
{
    public partial class ServiceIrmaoDeSangue : ServiceBase
    {
        public ServiceIrmaoDeSangue()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {            
        }

        protected override void OnStop()
        {
           
        }

        public void Iniciar()
        {
            OnStart(new string[0]);
        }

        public void Parar()
        {
            OnStop();
        }
    }
}
