using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionPivotTable2ImageIssue
{
    public class DataSourceModel
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Value { get; set; }
    }

    public class DataSource
    {
        public List<DataSourceModel> Items = new List<DataSourceModel>();

        public DataSource()
        {
            Items.Add(new DataSourceModel { Group = "BCC", Name = "5F", Count = 1, Value = 0 });
            Items.Add(new DataSourceModel { Group = "ACC", Name = "5F", Count = 2, Value = 0 });
            Items.Add(new DataSourceModel { Group = "BCC", Name = "5F", Count = 3, Value = 0 });
            Items.Add(new DataSourceModel { Group = "BCC", Name = "4F", Count = 1, Value = 0 });
            Items.Add(new DataSourceModel { Group = "BCC", Name = "4F", Count = 2, Value = 0 });
        }
    }
}
