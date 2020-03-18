using System.Collections.Generic;

namespace Olbrasoft.Data.Paging.DataTables
{
    /// <summary>
    /// An order, as sent by jQuery DataTables when doing AJAX queries.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Column to which ordering should be applied.
        /// This is an index reference to the columns array of information that is also submitted to the server.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Ordering direction for this column.
        /// It will be dt-string asc or dt-string desc to indicate ascending ordering or descending ordering, respectively.
        /// </summary>
        public string Dir { get; set; }
    }


    public class Column
    {
        /// <summary>
        /// Column's data source, as defined by columns.data.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Column's name, as defined by columns.name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Flag to indicate if this column is searchable (true) or not (false). This is controlled by columns.searchable.
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// Flag to indicate if this column is orderable (true) or not (false). This is controlled by columns.orderable.
        /// </summary>
        public bool Orderable { get; set; }

    }

    public class Search
    {
        public string Value { get; set; }
        public bool RegEx { get; set; }
    }

    /// <summary>
    /// Model binder for datatables.js parameters a la http://geeksprogramando.blogspot.com/2011/02/jquery-datatables-plug-in-with-asp-mvc.html
    /// </summary>

    public class DataTableModel
    {
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public int iColumns { get; set; }
        //public Search search { get; set; }
        public bool bEscapeRegex { get; set; }
        public int iSortingCols { get; set; }
        public int sEcho { get; set; }
        public List<string> sColumnNames { get; set; }
        public List<bool> bSortable { get; set; }
        public List<bool> bSearchable { get; set; }
        public List<string> sSearchValues { get; set; }
        public List<int> iSortCol { get; set; }
        public List<string> sSortDir { get; set; }
        public List<bool> bEscapeRegexColumns { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public Order[] Order { get; set; }
        public Column[] Columns { get; set; }
        public Search Search { get; set; }




        public DataTableModel()
        {
            sColumnNames = new List<string>();
            bSortable = new List<bool>();
            bSearchable = new List<bool>();
            sSearchValues = new List<string>();
            iSortCol = new List<int>();
            sSortDir = new List<string>();
            bEscapeRegexColumns = new List<bool>();
        }

        public DataTableModel(int iColumns)
        {
            this.iColumns = iColumns;
            sColumnNames = new List<string>(iColumns);
            bSortable = new List<bool>(iColumns);
            bSearchable = new List<bool>(iColumns);
            sSearchValues = new List<string>(iColumns);
            iSortCol = new List<int>(iColumns);
            sSortDir = new List<string>(iColumns);
            bEscapeRegexColumns = new List<bool>(iColumns);
        }




        //public DataTablesResponseData GetDataTablesResponse<TSource>(IQueryable<TSource> data)
        //{
        //    var totalRecords = data.Count(); // annoying this, as it causes an extra evaluation..

        //    var filters = new DataTablesFiltering();

        //    var outputProperties = DataTablesTypeInfo<TSource>.Properties;

        //    var filteredData = filters.ApplyFiltersAndSort(this, data, outputProperties);
        //    var totalDisplayRecords = filteredData.Count();

        //    var skipped = filteredData.Skip(iDisplayStart);
        //    var page = (iDisplayLength <= 0 ? skipped : skipped.Take(iDisplayLength)).ToArray();

        //    var result = new DataTablesResponseData()
        //    {
        //        iTotalRecords = totalRecords,
        //        iTotalDisplayRecords = totalDisplayRecords,
        //        sEcho = sEcho,
        //        aaData = page.Cast<object>().ToArray(),
        //    };

        //    return result;
        //}
    }



    //public enum DataType
    //{
    //    tInt,
    //    tString,
    //    tnone
    //}
}