using System.Data;

namespace LiteBulb.SimpleDatabase
{
	public class SimpleTable
	{
		private readonly DataSet _dataSet;
		private readonly DataTable _dataTable;

		public SimpleTable(string dataSetName, string tableName)
		{
			_dataSet = new DataSet(dataSetName);
			_dataTable = new DataTable(tableName: tableName);
		}

		public string DataSetName => _dataSet.DataSetName;

		public string TableName => _dataTable.TableName;

		public DataRow NewRow() => _dataTable.NewRow();

		public void InitializeSchema(DataColumn[] columns)
		{
			foreach (DataColumn column in columns)
				_dataTable.Columns.Add(column);
		}

		public int Insert(DataRow row)
		{
			_dataTable.Rows.Add(row);
			DataRow addedRow = _dataTable.Rows[_dataTable.Rows.Count - 1];
			int idColumn = (int)addedRow.ItemArray[0];
			return idColumn;
		}

		public DataRow Select(int id)
		{
			foreach (DataRow row in _dataTable.Rows)
			{
				int idColumn = (int)row.ItemArray[0];

				if (id == idColumn)
					return row;
			}

			return null;
		}

		public bool Delete(int id)
		{
			foreach (DataRow row in _dataTable.Rows)
			{
				int idColumn = (int)row.ItemArray[0];

				if (id == idColumn)
				{
					_dataTable.Rows.Remove(row);
					return true;
				}
			}

			return false;
		}
	}
}
