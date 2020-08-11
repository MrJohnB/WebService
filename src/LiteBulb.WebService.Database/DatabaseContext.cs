using LiteBulb.SimpleDatabase;
using LiteBulb.WebService.Models;
using System.Collections.Generic;
using System.Data;

namespace LiteBulb.WebService.Database
{
	public class DatabaseContext : IDatabaseContext<Guitar>
	{
		private readonly SimpleTable _table;

		public DatabaseContext()
		{
			_table = new SimpleTable("GuitarDataSet", "GuitarTable");

			InitializeSchema();
			AddData();
		}

		public string DataSetName => _table.DataSetName;

		public string TableName => _table.TableName;

		private void InitializeSchema()
		{
			var columns = new List<DataColumn>();

			columns.Add(new DataColumn(nameof(Guitar.Id), typeof(int))
			{
				ReadOnly = true,
				Unique = true,
				AutoIncrement = true,
				AutoIncrementSeed = 1,
				AutoIncrementStep = 1
			});

			columns.Add(new DataColumn(nameof(Guitar.Brand), typeof(string)));
			columns.Add(new DataColumn(nameof(Guitar.Model), typeof(string)));
			columns.Add(new DataColumn(nameof(Guitar.StringCount), typeof(int)));
			columns.Add(new DataColumn(nameof(Guitar.Type), typeof(GuitarType)));

			_table.InitializeSchema(columns.ToArray());
		}

		private void AddData()
		{
			var guitars = new List<Guitar>()
			{
				new Guitar() { Brand = "Martin", Model = "D20", StringCount = 6, Type = GuitarType.Acoustic },
				new Guitar() { Brand = "Taylor", Model = "300", StringCount = 6, Type = GuitarType.Acoustic },
				new Guitar() { Brand = "Fender", Model = "Stratocaster", StringCount = 6, Type = GuitarType.Electric },
				new Guitar() { Brand = "Gibson", Model = "Les Paul", StringCount = 6, Type = GuitarType.Electric },
				new Guitar() { Brand = "PRS", Model = "Mira", StringCount = 6, Type = GuitarType.Electric },
				new Guitar() { Brand = "Fender", Model = "Precision", StringCount = 4, Type = GuitarType.Bass },
				new Guitar() { Brand = "Carvin", Model = "LB70", StringCount = 4, Type = GuitarType.Bass }
			};

			foreach (var guitar in guitars)
				Insert(guitar);
		}

		public Guitar Insert(Guitar model)
		{
			DataRow row = _table.NewRow();
			row[nameof(Guitar.Brand)] = model.Brand;
			row[nameof(Guitar.Model)] = model.Model;
			row[nameof(Guitar.StringCount)] = model.StringCount;
			row[nameof(Guitar.Type)] = model.Type;
			model.Id = _table.Insert(row);
			return model;
		}

		public Guitar Select(int id)
		{
			DataRow row = _table.Select(id);

			if (row == null)
				return null;
		
			return new Guitar()
			{
				Id = (int)row[nameof(Guitar.Id)],
				Brand = (string)row[nameof(Guitar.Brand)],
				Model = (string)row[nameof(Guitar.Model)],
				StringCount = (int)row[nameof(Guitar.StringCount)],
				Type = (GuitarType)row[nameof(Guitar.Type)]
			};
		}

		public bool Delete(int id)
		{
			return _table.Delete(id);
		}
	}
}
