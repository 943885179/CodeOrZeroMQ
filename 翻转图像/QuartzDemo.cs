using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 翻转图像
{
   public class QuartzDemo
    {
        public void Execute(IJobExecutionContext context)
        {
            //向c:\Quartz.txt写入当前时间并换行
            System.IO.File.AppendAllText(@"g:\Quartz.txt", DateTime.Now + Environment.NewLine);
        }
    }
}
