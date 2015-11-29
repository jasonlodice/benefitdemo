using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lopay.Benefits.Server.Domain.Entities;
using Newtonsoft.Json;

namespace Lopay.Benefits.Server.Domain.Services
{
	/// <summary>
	/// Service for interacting with Employee Entities
	/// </summary>
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly List<Employee> _employees = new List<Employee>();
		private readonly JsonSerializer _serializer;
		private const string DbFilePath = @"./db/employees.json";

		public EmployeeRepository()
		{
			//	db operations in this class are simulated 
			//	by saving data to a file

			_serializer = JsonSerializer.Create();

			EnsureDbDirExists();
			LoadFromFile();
		}

		#region File Operations

		private void EnsureDbDirExists()
		{
			var directory = Path.GetDirectoryName(DbFilePath);
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
		}

		/// <summary>
		/// Load employee entities from json file at <see cref="DbFilePath"/>
		/// </summary>
		private void LoadFromFile()
		{
			using (var sr = File.OpenText(DbFilePath))
			using (var jr = new JsonTextReader(sr))
			{
				var employees = _serializer.Deserialize<Employee[]>(jr);
				_employees.Clear();
				_employees.AddRange(employees);
			}
		}

		/// <summary>
		/// Save employee entities to json file at <see cref="DbFilePath"/>
		/// </summary>
		private void SaveToFile()
		{
			using (var fs = File.Open(DbFilePath, FileMode.OpenOrCreate))
			using (var sw = new StreamWriter(fs))
			using (var jw = new JsonTextWriter(sw))
			{
				jw.Formatting = Formatting.Indented;
				var serializer = new JsonSerializer();
				serializer.Serialize(jw, _employees);
			}
		}

		#endregion

		/// <summary>
		/// Get Employee entity by Id
		/// </summary>
		/// <param name="id">Employee entity id</param>
		/// <returns></returns>
		public Employee Get(int id)
		{
			return _employees.FirstOrDefault(x => x.Id == id);
		}

		/// <summary>
		/// Get all Employee entities
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Employee> GetAll()
		{
			return _employees;
		}

		/// <summary>
		/// Add a new employee entity
		/// </summary>
		/// <param name="employee"></param>
		public void Create(Employee employee)
		{
			employee.Id = _employees.Max(x => x.Id) + 1;
			_employees.Add(employee);
		}

		/// <summary>
		/// Persist changes in the repository
		/// </summary>
		public void Save()
		{
			SaveToFile();
		}
	}
}