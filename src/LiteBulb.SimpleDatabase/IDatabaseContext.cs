
namespace LiteBulb.SimpleDatabase
{
	public interface IDatabaseContext<TModel>
	{
		string DataSetName { get; }
		string TableName { get; }
		TModel Insert(TModel row);
		TModel Select(int id);
		bool Delete(int id);
	}
}
