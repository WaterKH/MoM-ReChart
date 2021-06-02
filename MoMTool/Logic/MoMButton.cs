using MoMMusicAnalysis;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public class MoMButton<T>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Button Button { get; set; }

        public T Note { get; set; }
        //public FieldAsset Asset { get; set; }
        //public PerformerNote Performer { get; set; }
        //public TimeShift Time { get; set; }
    }
}