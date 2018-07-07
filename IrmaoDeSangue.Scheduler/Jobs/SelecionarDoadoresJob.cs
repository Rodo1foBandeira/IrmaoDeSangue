using IrmaoDeSangue.Business;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Scheduler.Jobs
{
    public class SelecionarDoadoresJob : IJob
    {
        public SelecionarDoadoresJob()
        { 

        }

        public void Execute(IJobExecutionContext context)
        {         
            try
            {
                var _processarAgendamento = new ProcessarAgendamentoBusiness();
                
                _processarAgendamento.Processar();
            }
            catch (Exception ex)
            {
            }            
        }
    }
}
