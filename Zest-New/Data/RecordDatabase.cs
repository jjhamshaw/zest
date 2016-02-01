using System;
using SQLite;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZestNew
{
	public class RecordDatabase : SQLiteConnection
	{
		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "ZestAppDB.db3";

				#if NETFX_CORE
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
				#else

				#if SILVERLIGHT
                // Windows Phone expects a local path, not absolute
                var path = sqliteFilename;
				#else

				#if __ANDROID__
                // Just use whatever directory SpecialFolder.Personal returns
                string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
				#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine(documentsPath, "../Library/"); // Library folder
				#endif
				var path = Path.Combine(libraryPath, sqliteFilename);
				#endif      

				#endif
				return path;    
			}
		}

		public RecordDatabase(string path)
			: base(path)
		{
			CreateTable<RecordDao>();
		}

		static object locker = new object();

		public IEnumerable<Record> GetAll()
		{
            
			lock (locker) {
				var data = (from i in Table<RecordDao>()
				            select i);
                
				return data.Select(i => new Record() {
					Id = i.Id,
					CreatedDate = i.CreatedDate
				});
			}
		}

		public Record Get(int id)
		{
			lock (locker) {
				var data = Table<RecordDao>().FirstOrDefault(x => x.Id == id);
				return new Record() {
					Id = data.Id,
					CreatedDate = data.CreatedDate
				}; 
			}
		}

		public int Save(Record item)
		{
			var data = new RecordDao {
				Id = item.Id,
				CreatedDate = item.CreatedDate
			};
			lock (locker) {
				if (data.Id != 0) {
					Update(data);
					return data.Id;
				} else {
					return Insert(data);
				}
			}
		}

		public int Delete(Record item)
		{
			lock (locker) {
				return Delete<RecordDao>(item.Id);            
			}   
		}
	}
}

