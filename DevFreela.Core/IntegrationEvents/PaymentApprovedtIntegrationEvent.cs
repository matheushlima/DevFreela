using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.IntegrationEvents
{
    public class PaymentApprovedtIntegrationEvent
    {
        public int IdProject { get; set; }

        public PaymentApprovedtIntegrationEvent(int idProject)
        {
            IdProject = idProject;
        }
    }
}
