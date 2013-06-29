using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Nodule_wCI.Worker.Host
{
    partial class NoduleProcessorHost : ServiceBase
    {
        ServiceHost host;

        public NoduleProcessorHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Type serviceType = typeof(Processor);
            host = new ServiceHost(serviceType);
            host.Open();
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            if (host != null)
            {
                host.Close();
                host = null;
            }
        }
    }
}
