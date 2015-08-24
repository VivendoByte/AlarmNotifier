using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VivendoByte.AlarmNotifier.Messages
{
    public class AlarmMessage
    {
        static Random random = new Random((int)DateTime.Now.Ticks);
        public Guid Identifier { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Title { get; set; }
        public int Severity { get; set; }
        public string Description { get; set; }
        public AlarmMessage()
        {
            this.Identifier = Guid.NewGuid();
            this.TimeStamp = DateTime.Now;
            this.Title = "Title " + random.Next(1000, 100000).ToString();
            this.Severity = random.Next(0, 10);
        }

        public override string ToString()
        {
            string output = string.Format("{0}\t{1}\t{2}", this.TimeStamp.ToString(), this.Title, this.Severity);

            return output;
        }
    }
}