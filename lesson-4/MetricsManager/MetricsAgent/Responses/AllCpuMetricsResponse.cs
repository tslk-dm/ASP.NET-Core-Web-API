using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Responses
{
    public class AllCpuMetricsResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }

   public class CpuMetricDto
   {
       public int Value { get; set; }
       public int Id { get; set; }
       public int Time { get; set; }
   }
}

