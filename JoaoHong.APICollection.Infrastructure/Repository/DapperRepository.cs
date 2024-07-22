using Dapper;
using JoaoHong.APICollection.Domain.Port.InfraStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Infrastructure.Repository
{
    public abstract class DapperRepository<T> : IDapperRepository<T>
    {
        private readonly IMySQLContextDB _mySqlContext;
        private readonly string _connectionString;

        public DapperRepository(IMySQLContextDB mySQLContext, string connectionString = null)
        {
            _mySqlContext = mySQLContext;
            _connectionString = connectionString;
        }

		public async Task<bool> DeleteAsync(T entity)
        {
			int rowsEffected = 0;
			try
			{
				string tableName = GetTableName();
				string keyColumn = GetKeyColumnName();
				string keyProperty = GetKeyPropertyName();
				string query = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyProperty}";

				using (var con = await _mySqlContext.Connection(_connectionString))
				{
					rowsEffected = await con.ExecuteAsync(query, entity);
				}
			}
			catch (Exception ex) 
			{

			}

			return rowsEffected > 0 ? true : false;
		}

		public async Task<T> GetById(int id)
        {
			IEnumerable<T> result = null;
			try
			{
				var tableName = GetTableName();
				var keyColumn = GetKeyColumnName();
				var query = "";

				query = $"SELECT * FROM {tableName} WHERE {keyColumn} = '{id}'";

				using (var con = await _mySqlContext.Connection(_connectionString	))
				{
					result = await con.QueryAsync<T>(query);
				}
			}
			catch (Exception ex) 
			{ 
			}

			return result.FirstOrDefault();
		}

        public async Task<IEnumerable<T>> GetByParam(params (string column, object value)[] filters)
        {
            IEnumerable<T> result = null;
            try
            {
                var tableName = GetTableName();

                var query = new StringBuilder($"SELECT * FROM {tableName}");

                if (filters != null && filters.Length > 0)
                {
                    query.Append(" WHERE ");

                    for (int i = 0; i < filters.Length; i++)
                    {
                        var (column, value) = filters[i];

                        query.Append($"{column} = @param{i}");

                        if (i < filters.Length - 1)
                        {
                            query.Append(" AND ");
                        }
                    }
                }

                using (var con = await _mySqlContext.Connection(_connectionString))

                {
                    result = await con.QueryAsync<T>(query.ToString(), filters.Select((f, index) => new KeyValuePair<string, object>($"param{index}", f.value)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
                }

            }

            catch (Exception ex)

            {
            }

			return result;

		}
        public async Task<long> InsertAsync(T entity)
        {
			long id = 0;

			try
			{
				string tableName = GetTableName();
				string columns = GetColumns(excludeKey: true);
				string properties = GetPropertyNames(excludeKey: true);
				string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties}); SELECT SCOPE_IDENTITY();";

				using (var con = await _mySqlContext.Connection(_connectionString))
				{
					id = await con.ExecuteScalarAsync<long>(query, entity);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return id;
		}

		public async Task<bool> UpdateAsync(T entity)
        {
			int rowsEffected = 0;
			try
			{
				string tableName = GetTableName();
				string keyColumn = GetKeyColumnName();
				string keyProperty = GetKeyPropertyName();

				StringBuilder query = new StringBuilder();

				query.Append($"UPDATE {tableName} SET ");

				foreach (var property in GetProperties(true))
				{
					var columnAttr = property.GetCustomAttribute<ColumnAttribute>();
					string propertyName = property.Name;
					string columnName = columnAttr.Name;

					query.Append($"{columnName} = @{propertyName},");
				}

				query.Remove(query.Length - 1, 1);

				query.Append($" WHERE {keyColumn} = @{keyProperty}");

				using (var con = await _mySqlContext.Connection(_connectionString))
				{
					rowsEffected = await con.ExecuteAsync(query.ToString(), entity);
				}
			}
			catch (Exception ex) 
			{
			}

			return rowsEffected > 0 ? true : false;
		}

		public static string GetKeyColumnNameAll()
		{
			PropertyInfo[] properties = typeof(T).GetProperties();

			List<string> columnNames = new List<string>();

			foreach (PropertyInfo property in properties)
			{
				object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

				if (columnAttributes.Length > 0)
				{
					ColumnAttribute columnAttribute = (ColumnAttribute)columnAttributes[0];

					columnNames.Add($"{columnAttribute.Name} as {property.Name}");
				}
			}

			return string.Join(", ", columnNames);
		}

		private string GetTableName()
		{
			string tableName = "";

			var type = typeof(T);

			var tableAttr = type.GetCustomAttribute<TableAttribute>();

			if (tableAttr != null)
			{
				tableName = tableAttr.Name;

				return tableName;
			}

			return type.Name + "s";
		}

		public static string GetKeyColumnName()
		{
			PropertyInfo[] properties = typeof(T).GetProperties();

			foreach (PropertyInfo property in properties)
			{
				object[] keyAttributes = property.GetCustomAttributes(typeof(KeyAttribute), true);

				if (keyAttributes != null && keyAttributes.Length > 0)
				{
					object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

					if (columnAttributes != null && columnAttributes.Length > 0)
					{
						ColumnAttribute columnAttribute = (ColumnAttribute)columnAttributes[0];

						return columnAttribute.Name;
					}
					else
					{
						return property.Name;
					}
				}
			}

			return null;
		}

		private string GetColumns(bool excludeKey = false)
		{
			var type = typeof(T);

			var columns = string.Join(", ", type.GetProperties()
				.Where(p => (!excludeKey || !p.IsDefined(typeof(KeyAttribute))) &&
							!p.IsDefined(typeof(NotMappedAttribute)))
				.Select(p =>
				{
					var columnAttr = p.GetCustomAttribute<ColumnAttribute>();
					return columnAttr != null ? columnAttr.Name : p.Name;
				})
			);

			return columns;
		}

		protected string GetPropertyNames(bool excludeKey = false)
		{
			var properties = typeof(T).GetProperties()
				.Where(p => (!excludeKey || p.GetCustomAttribute<KeyAttribute>() == null) &&
					!Attribute.IsDefined(p, typeof(NotMappedAttribute)));

			var values = string.Join(", ", properties.Select(p =>
			{
				return $"@{p.Name}";
			}));

			return values;
		}

		protected IEnumerable<PropertyInfo> GetProperties(bool excludeKey = false)
		{
			var properties = typeof(T).GetProperties()
				.Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

			return properties;
		}

		protected string GetKeyPropertyName()
		{
			var properties = typeof(T).GetProperties()
				.Where(p => p.GetCustomAttribute<KeyAttribute>() != null);

			if (properties.Any())
			{
				return properties.FirstOrDefault().Name;
			}

			return null;
		}
	}
}
